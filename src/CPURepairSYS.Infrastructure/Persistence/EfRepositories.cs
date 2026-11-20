using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CPURepairSYS.Infrastructure.Persistence;

internal sealed class EfCustomerRepository(RepairDbContext db) : ICustomerRepository
{
    public async Task<CustomerId> GetNextIdAsync(CancellationToken cancellationToken = default)
    {
        var maxId = await db.Database
            .SqlQueryRaw<int>("SELECT NVL(MAX(CustId), 0) AS \"Value\" FROM Customers")
            .SingleAsync(cancellationToken);
        return new CustomerId(maxId + 1);
    }

    public Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default) =>
        db.Customers.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
        db.Customers.AnyAsync(x => x.Email == email.Trim() && (!excludingId.HasValue || x.Id != excludingId.Value), cancellationToken);

    public Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
        db.Customers.AnyAsync(x => x.Phone == phone && (!excludingId.HasValue || x.Id != excludingId.Value), cancellationToken);

    public async Task<IReadOnlyList<Customer>> SearchAsync(string? phone, string? firstName, CancellationToken cancellationToken = default)
    {
        var query = db.Customers.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(phone))
        {
            query = query.Where(x => x.Phone == new PhoneNumber(phone));
        }

        if (!string.IsNullOrWhiteSpace(firstName))
        {
            var normalisedName = firstName.Trim().ToUpperInvariant();
            query = query.Where(x => x.FirstName.ToUpper().Contains(normalisedName));
        }

        return await query.OrderBy(x => x.Surname).ThenBy(x => x.FirstName).ToListAsync(cancellationToken);
    }

    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        db.Customers.Add(customer);
        return Task.CompletedTask;
    }

    public void Update(Customer customer) => db.Customers.Update(customer);
}

internal sealed class EfPartRepository(RepairDbContext db) : IPartRepository
{
    public async Task<PartId> GetNextIdAsync(CancellationToken cancellationToken = default)
    {
        var maxId = await db.Database
            .SqlQueryRaw<int>("SELECT NVL(MAX(PartId), 0) AS \"Value\" FROM Parts")
            .SingleAsync(cancellationToken);
        return new PartId(maxId + 1);
    }

    public Task<Part?> GetByIdAsync(PartId id, CancellationToken cancellationToken = default) =>
        db.Parts.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Part>> SearchAsync(string? description, CancellationToken cancellationToken = default) =>
        await SearchQuery(description).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Part>> SearchForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default)
    {
        var query = db.Parts.AsNoTracking().Where(x => x.Status == PartStatus.Available);
        if (!string.IsNullOrWhiteSpace(description))
        {
            query = query.Where(x => x.Description.Contains(description.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(partTypeCode))
        {
            query = query.Where(x => x.PartTypeCode == partTypeCode.Trim());
        }

        return await query.OrderBy(x => x.Description).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Part>> SearchAvailableAsync(string? description, CancellationToken cancellationToken = default) =>
        await SearchQuery(description).Where(x => x.Status == PartStatus.Available).ToListAsync(cancellationToken);

    public Task AddAsync(Part part, CancellationToken cancellationToken = default)
    {
        db.Parts.Add(part);
        return Task.CompletedTask;
    }

    public void Update(Part part) => db.Parts.Update(part);

    private IQueryable<Part> SearchQuery(string? description)
    {
        var query = db.Parts.AsNoTracking();
        return string.IsNullOrWhiteSpace(description)
            ? query.OrderBy(x => x.Description)
            : query.Where(x => x.Description.Contains(description.Trim())).OrderBy(x => x.Description);
    }
}

internal sealed class EfRepairRepository(RepairDbContext db) : IRepairRepository
{
    public async Task<RepairId> GetNextIdAsync(CancellationToken cancellationToken = default)
    {
        var maxId = await db.Database
            .SqlQueryRaw<int>("SELECT NVL(MAX(RepairId), 0) AS \"Value\" FROM Repairs")
            .SingleAsync(cancellationToken);
        return new RepairId(maxId + 1);
    }

    public Task<Repair?> GetByIdAsync(RepairId id, CancellationToken cancellationToken = default) =>
        db.Repairs.Include(x => x.Items).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Repair>> SearchAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default)
    {
        var query = db.Repairs.Include(x => x.Items).AsNoTracking();
        if (!string.IsNullOrWhiteSpace(repairTypeCode))
        {
            query = query.Where(x => x.RepairTypeCode == repairTypeCode.Trim());
        }

        var repairs = await query
            .OrderByDescending(x => x.StartDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync(cancellationToken);

        return await query
            .OrderByDescending(x => x.StartDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public Task AddAsync(Repair repair, CancellationToken cancellationToken = default)
    {
        db.Repairs.Add(repair);
        return Task.CompletedTask;
    }

    public void Update(Repair repair) => db.Repairs.Update(repair);
}

internal sealed class EfUnitOfWork(RepairDbContext db) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        db.SaveChangesAsync(cancellationToken);

    public async Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
        await db.Database.BeginTransactionAsync(cancellationToken);
}
