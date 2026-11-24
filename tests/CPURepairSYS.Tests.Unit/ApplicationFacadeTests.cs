using CPURepairSYS.Application;
using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Application.Facades;
using CPURepairSYS.Application.Strategies;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Tests.Unit;

public sealed class ApplicationFacadeTests
{
    [Fact]
    public async Task LogRepairPersistsThroughTheFacade()
    {
        var customers = new FakeCustomerRepository();
        var repairs = new FakeRepairRepository();
        var unitOfWork = new FakeUnitOfWork();
        var facade = CreateRepairFacade(customers, repairs, new FakePartRepository(), unitOfWork);

        customers.Items.Add(Customer.Create(new CustomerId(1), "Alex", "Smith", new PhoneNumber("087123"), "alex@example.com"));

        var result = await facade.LogRepairAsync(new LogRepairRequest(
            new RepairId(1), "Replace screen", "SCRN", new CustomerId(1), new DateOnly(2026, 11, 24)));

        Assert.True(result.Succeeded);
        Assert.Single(repairs.Items);
        Assert.Equal(1, unitOfWork.SaveCount);
    }

    [Fact]
    public async Task CreateEstimateRejectsInsufficientStockWithoutMutation()
    {
        var repair = Repair.CreateLogged(new RepairId(1), "Repair", "PROC", new CustomerId(1), new DateOnly(2026, 11, 24));
        var part = Part.Create(new PartId(7), "CPU", new Money(100), 1, "PROC");
        var repairs = new FakeRepairRepository { Items = [repair] };
        var parts = new FakePartRepository { Items = [part] };
        var facade = CreateRepairFacade(new FakeCustomerRepository(), repairs, parts, new FakeUnitOfWork());

        var result = await facade.CreateEstimateAsync(repair.Id, new[] { new EstimateLineRequest(part.Id, 2) });

        Assert.False(result.Succeeded);
        Assert.Equal(1, part.Quantity);
        Assert.Equal(RepairStatus.Logged, repair.Status);
    }

    [Fact]
    public async Task RepairLifecycleApprovalAndCompletionUseApplicationOperations()
    {
        var repair = Repair.CreateLogged(new RepairId(1), "Repair", "PROC", new CustomerId(1), new DateOnly(2026, 11, 24));
        repair.CreateEstimate(new[] { RepairItem.Create(new PartId(7), new Money(50), 1) });
        var repairs = new FakeRepairRepository { Items = [repair] };
        var facade = CreateRepairFacade(new FakeCustomerRepository(), repairs, new FakePartRepository(), new FakeUnitOfWork());

        var approved = await facade.ApproveRepairAsync(repair.Id, new DateOnly(2026, 11, 25));
        var completed = await facade.CompleteRepairAsync(repair.Id, new DateOnly(2026, 11, 26));

        Assert.True(approved.Succeeded);
        Assert.True(completed.Succeeded);
        Assert.Equal(RepairStatus.Completed, repair.Status);
    }

    [Fact]
    public async Task InventoryDiscontinuationAndReportQueriesUseFacades()
    {
        var part = Part.Create(new PartId(7), "CPU", new Money(100), 2, "PROC");
        var parts = new FakePartRepository { Items = [part] };
        var inventory = new InventoryFacade(parts, new FakeUnitOfWork(), new AllowAuthorizer());

        var discontinued = await inventory.DiscontinuePartAsync(part.Id);

        Assert.True(discontinued.Succeeded);
        Assert.Equal(PartStatus.Discontinued, part.Status);

        var repair = Repair.CreateLogged(new RepairId(1), "Repair", "PROC", new CustomerId(1), new DateOnly(2026, 11, 24));
        var source = new FakeReportSource([repair], [part]);
        var reporting = new ReportingFacade(source, new AllowAuthorizer(), new RepairsByYearStrategy(), new AvailablePartsStrategy());
        var report = await reporting.GetRepairHistoryAsync(2026, RepairStatus.Logged);

        Assert.True(report.Succeeded);
        Assert.Single(report.Value!);
    }

    [Fact]
    public async Task TransactionAdapterRollsBackAfterFailure()
    {
        var unitOfWork = new FakeUnitOfWork();
        var adapter = new RecordingRepairDataAdapter();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            adapter.ExecuteInTransactionAsync<int>(_ =>
                throw new InvalidOperationException("save failed")));

        Assert.Equal(1, adapter.RollbackCount);
        Assert.Equal(0, unitOfWork.SaveCount);
    }

    private static RepairFacade CreateRepairFacade(
        ICustomerRepository customers,
        IRepairRepository repairs,
        IPartRepository parts,
        IUnitOfWork unitOfWork) =>
        new(
            customers,
            repairs,
            parts,
            new FakeRepairDataAdapter(unitOfWork),
            unitOfWork,
            new RepairFactory(),
            new AllowAuthorizer());

    private sealed class AllowAuthorizer : IApplicationAuthorizer
    {
        public Task AuthorizeAsync(ApplicationOperation operation, CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
    }

    private sealed class FakeUnitOfWork : IUnitOfWork
    {
        public int SaveCount { get; private set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SaveCount++;
            return Task.FromResult(1);
        }
        public Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult<IAsyncDisposable>(new FakeAsyncDisposable());
    }

    private sealed class FakeAsyncDisposable : IAsyncDisposable
    {
        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
    }

    private sealed class FakeRepairDataAdapter(IUnitOfWork unitOfWork) : IRepairDataAdapter
    {
        public async Task<T> ExecuteInTransactionAsync<T>(
            Func<CancellationToken, Task<T>> operation,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await operation(cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }

    private sealed class RecordingRepairDataAdapter : IRepairDataAdapter
    {
        public int RollbackCount { get; private set; }

        public async Task<T> ExecuteInTransactionAsync<T>(
            Func<CancellationToken, Task<T>> operation,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await operation(cancellationToken);
            }
            catch
            {
                RollbackCount++;
                throw;
            }
        }
    }

    private sealed class FakeCustomerRepository : ICustomerRepository
    {
        public List<Customer> Items { get; } = new();
        public Task<CustomerId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(new CustomerId(Items.Count + 1));
        public Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default) =>
            Task.FromResult(Items.SingleOrDefault(customer => customer.Id == id));
        public Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
            Task.FromResult(Items.Any(customer => customer.Email == email && (!excludingId.HasValue || customer.Id != excludingId.Value)));
        public Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
            Task.FromResult(Items.Any(customer => customer.Phone == phone && (!excludingId.HasValue || customer.Id != excludingId.Value)));
        public Task<IReadOnlyList<Customer>> SearchAsync(string? phone, string? firstName, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Customer>>(Items);
        public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            Items.Add(customer);
            return Task.CompletedTask;
        }
        public void Update(Customer customer) { }
    }

    private sealed class FakeRepairRepository : IRepairRepository
    {
        public List<Repair> Items { get; set; } = new();
        public Task<RepairId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(new RepairId(Items.Count + 1));
        public Task<Repair?> GetByIdAsync(RepairId id, CancellationToken cancellationToken = default) =>
            Task.FromResult(Items.SingleOrDefault(repair => repair.Id == id));
        public Task<IReadOnlyList<Repair>> SearchAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Repair>>(Items);
        public Task AddAsync(Repair repair, CancellationToken cancellationToken = default)
        {
            Items.Add(repair);
            return Task.CompletedTask;
        }
        public void Update(Repair repair) { }
    }

    private sealed class FakePartRepository : IPartRepository
    {
        public List<Part> Items { get; set; } = new();
        public Task<PartId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(new PartId(Items.Count + 1));
        public Task<Part?> GetByIdAsync(PartId id, CancellationToken cancellationToken = default) =>
            Task.FromResult(Items.SingleOrDefault(part => part.Id == id));
        public Task<IReadOnlyList<Part>> SearchAsync(string? description, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Part>>(Items);
        public Task<IReadOnlyList<Part>> SearchForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Part>>(Items.Where(part => part.Status == PartStatus.Available).ToList());
        public Task<IReadOnlyList<Part>> SearchAvailableAsync(string? description, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Part>>(Items.Where(part => part.Status == PartStatus.Available).ToList());
        public Task AddAsync(Part part, CancellationToken cancellationToken = default)
        {
            Items.Add(part);
            return Task.CompletedTask;
        }
        public void Update(Part part) { }
    }

    private sealed class FakeReportSource(IReadOnlyList<Repair> repairs, IReadOnlyList<Part> parts) : IRepairReportSource
    {
        public Task<IReadOnlyList<Repair>> GetRepairsAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(repairs);
        public Task<IReadOnlyList<Part>> GetPartsAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(parts);
    }
}
