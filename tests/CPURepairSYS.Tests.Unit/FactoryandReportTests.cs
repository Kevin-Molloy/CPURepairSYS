using System.Diagnostics;
using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Application.Strategies;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Tests.Unit;

public sealed class FactoryAndReportTests
{
    [Fact]
    public void RepairFactoryCreatesLoggedRepairWithTypedDefaults()
    {
        var repair = new CPURepairSYS.Application.RepairFactory().Create(
            new RepairId(9),
            " Replace CPU ",
            "PROC",
            new CustomerId(3),
            new DateOnly(2026, 11, 24));

        Assert.Equal(new RepairId(9), repair.Id);
        Assert.Equal("Replace CPU", repair.Description);
        Assert.Equal(RepairStatus.Logged, repair.Status);
        Assert.Equal(Money.Zero, repair.Price);
    }

    [Fact]
    public void RepairsAndAvailablePartsReportStrategiesFilterAndSort()
    {
        var repair2026 = Repair.CreateLogged(new RepairId(1), "A Repair", "PROC", new CustomerId(1), new DateOnly(2026, 1, 1));
        var repair2025 = Repair.CreateLogged(new RepairId(2), "B Repair", "PROC", new CustomerId(1), new DateOnly(2025, 1, 1));
        var strategy = new RepairsByYearStrategy();

        var result = strategy.Apply(new[] { repair2025, repair2026 }, 2026, RepairStatus.Logged).ToList();

        Assert.Single(result);
        Assert.Equal(2026, result[0].Year);
        Assert.Equal(new RepairId(1), result[0].Repair.Id);

        var part = Part.Create(new PartId(7), "CPU", new Money(100), 2, "PROC");
        var partRows = new AvailablePartsStrategy().Apply(new[] { part }, Array.Empty<Repair>(), 2026).ToList();
        Assert.Empty(partRows);
    }

    [Fact]
    public void ReportStrategyRemainsResponsiveForLargeInMemoryInput()
    {
        var repairs = Enumerable.Range(1, 10_000)
            .Select(index => Repair.CreateLogged(
                new RepairId(index),
                $"Repair {index}",
                "PROC",
                new CustomerId(index),
                new DateOnly(2026, 1, 1)))
            .ToList();

        var stopwatch = Stopwatch.StartNew();
        var result = new RepairsByYearStrategy().Apply(repairs, 2026, null).ToList();
        stopwatch.Stop();

        Assert.Equal(10_000, result.Count);
        Assert.True(stopwatch.ElapsedMilliseconds < 1000,
            $"Report generation took {stopwatch.ElapsedMilliseconds} ms.");
    }
}

public sealed class ApplicationSecurityTests
{
    [Fact]
    public async Task RejectingAuthorizerPreventsFacadeOperation()
    {
        var authorizer = new RejectingAuthorizer();
        var repairRepository = new EmptyRepairRepository();
        var facade = new CPURepairSYS.Application.Facades.RepairFacade(
            new EmptyCustomerRepository(),
            repairRepository,
            new EmptyPartRepository(),
            new ImmediateTransaction(),
            new EmptyUnitOfWork(),
            new CPURepairSYS.Application.RepairFactory(),
            authorizer);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            facade.GetRepairAsync(new RepairId(1)));
        Assert.Equal(0, repairRepository.ReadCount);
    }

    private sealed class RejectingAuthorizer : IApplicationAuthorizer
    {
        public Task AuthorizeAsync(ApplicationOperation operation, CancellationToken cancellationToken = default) =>
            throw new UnauthorizedAccessException($"Operation {operation} is not authorized.");
    }

    private sealed class EmptyRepairRepository : IRepairRepository
    {
        public int ReadCount { get; private set; }
        public Task<RepairId> GetNextIdAsync(CancellationToken cancellationToken = default) => Task.FromResult(new RepairId(1));
        public Task<Repair?> GetByIdAsync(RepairId id, CancellationToken cancellationToken = default)
        {
            ReadCount++;
            return Task.FromResult<Repair?>(null);
        }
        public Task<IReadOnlyList<Repair>> SearchAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Repair>>(Array.Empty<Repair>());
        public Task AddAsync(Repair repair, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public void Update(Repair repair) { }
    }

    private sealed class EmptyCustomerRepository : ICustomerRepository
    {
        public Task<CustomerId> GetNextIdAsync(CancellationToken cancellationToken = default) => Task.FromResult(new CustomerId(1));
        public Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default) => Task.FromResult<Customer?>(null);
        public Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default) => Task.FromResult(false);
        public Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default) => Task.FromResult(false);
        public Task<IReadOnlyList<Customer>> SearchAsync(string? phone, string? firstName, CancellationToken cancellationToken = default) => Task.FromResult<IReadOnlyList<Customer>>(Array.Empty<Customer>());
        public Task AddAsync(Customer customer, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public void Update(Customer customer) { }
    }

    private sealed class EmptyPartRepository : IPartRepository
    {
        public Task<PartId> GetNextIdAsync(CancellationToken cancellationToken = default) => Task.FromResult(new PartId(1));
        public Task<Part?> GetByIdAsync(PartId id, CancellationToken cancellationToken = default) => Task.FromResult<Part?>(null);
        public Task<IReadOnlyList<Part>> SearchAsync(string? description, CancellationToken cancellationToken = default) => Task.FromResult<IReadOnlyList<Part>>(Array.Empty<Part>());
        public Task<IReadOnlyList<Part>> SearchForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default) => Task.FromResult<IReadOnlyList<Part>>(Array.Empty<Part>());
        public Task<IReadOnlyList<Part>> SearchAvailableAsync(string? description, CancellationToken cancellationToken = default) => Task.FromResult<IReadOnlyList<Part>>(Array.Empty<Part>());
        public Task AddAsync(Part part, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public void Update(Part part) { }
    }

    private sealed class EmptyUnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => Task.FromResult(1);
        public Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult<IAsyncDisposable>(new EmptyAsyncDisposable());
    }

    private sealed class EmptyAsyncDisposable : IAsyncDisposable
    {
        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
    }

    private sealed class ImmediateTransaction : IRepairDataAdapter
    {
        public Task<T> ExecuteInTransactionAsync<T>(Func<CancellationToken, Task<T>> operation, CancellationToken cancellationToken = default) =>
            operation(cancellationToken);
    }
}
