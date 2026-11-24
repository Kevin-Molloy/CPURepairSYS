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

    public Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default)
    {
        var normalisedEmail = email.Trim();
        return excludingId.HasValue
            ? EmailExistsExceptAsync(normalisedEmail, excludingId.Value, cancellationToken)
            : EmailExistsAsync(normalisedEmail, cancellationToken);
    }

    public Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default)
    {
        return excludingId.HasValue
            ? PhoneExistsExceptAsync(phone.Value, excludingId.Value, cancellationToken)
            : PhoneExistsAsync(phone.Value, cancellationToken);
    }

    private async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken) =>
        await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM Customers WHERE Email = {0}",
                email)
            .SingleAsync(cancellationToken) > 0;

    private async Task<bool> EmailExistsExceptAsync(string email, CustomerId excludingId, CancellationToken cancellationToken) =>
        await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM Customers WHERE Email = {0} AND CustId <> {1}",
                email,
                excludingId.Value)
            .SingleAsync(cancellationToken) > 0;

    private async Task<bool> PhoneExistsAsync(string phone, CancellationToken cancellationToken) =>
        await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM Customers WHERE Phone = {0}",
                phone)
            .SingleAsync(cancellationToken) > 0;

    private async Task<bool> PhoneExistsExceptAsync(string phone, CustomerId excludingId, CancellationToken cancellationToken) =>
        await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM Customers WHERE Phone = {0} AND CustId <> {1}",
                phone,
                excludingId.Value)
            .SingleAsync(cancellationToken) > 0;

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

    public async Task AddAsync(Part part, CancellationToken cancellationToken = default)
    {
        await EnsurePartTypeCodeAsync(part.PartTypeCode, cancellationToken);
        db.Parts.Add(part);
    }

    private async Task EnsurePartTypeCodeAsync(string code, CancellationToken cancellationToken)
    {
        var count = await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM PartTypeCodes WHERE PartTypeCode = {0}",
                code)
            .SingleAsync(cancellationToken);
        if (count > 0) return;

        var descriptions = new Dictionary<string, string>
        {
            ["PROC"] = "Processor",
            ["GCARD"] = "Graphics card",
            ["FAN"] = "Fan",
            ["CASE"] = "Case",
            ["BATT"] = "Battery",
            ["POWSUP"] = "Power supply",
            ["MTHBRD"] = "Motherboard",
            ["COOL"] = "Cooling",
            ["RAM"] = "Memory",
            ["STOR"] = "Storage",
            ["WIFIADAP"] = "Wireless adapter",
            ["SCRN"] = "Screen",
            ["MULT"] = "Multimedia",
            ["OTH"] = "Other"
        };

        if (!descriptions.TryGetValue(code, out var description))
        {
            throw new InvalidOperationException($"Unknown part type code '{code}'.");
        }

        await db.Database.ExecuteSqlRawAsync(
            "INSERT INTO PartTypeCodes (PartTypeCode, Description) VALUES ({0}, {1})",
            new object[] { code, description },
            cancellationToken);
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
        IQueryable<Repair> query = db.Repairs.Include(x => x.Items);
        if (!string.IsNullOrWhiteSpace(repairTypeCode))
        {
            query = query.Where(x => x.RepairTypeCode == repairTypeCode.Trim());
        }
        if (status.HasValue)
        {
            query = query.Where(x => x.PersistedStatus == status.Value);
        }

        return await query
            .OrderByDescending(x => x.StartDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Repair repair, CancellationToken cancellationToken = default)
    {
        await EnsureRepairTypeCodeAsync(repair.RepairTypeCode, cancellationToken);
        db.Repairs.Add(repair);
    }

    private async Task EnsureRepairTypeCodeAsync(string code, CancellationToken cancellationToken)
    {
        var count = await db.Database
            .SqlQueryRaw<int>(
                "SELECT COUNT(*) AS \"Value\" FROM RepairTypeCodes WHERE RepairTypeCode = {0}",
                code)
            .SingleAsync(cancellationToken);
        if (count > 0) return;

        var descriptions = new Dictionary<string, string>
        {
            ["PROC"] = "Processor repair",
            ["GCARD"] = "Graphics repair",
            ["FAN"] = "Fan repair",
            ["CASE"] = "Case repair",
            ["BATT"] = "Battery repair",
            ["POWSUP"] = "Power supply repair",
            ["MTHBRD"] = "Motherboard repair",
            ["COOL"] = "Cooling repair",
            ["RAM"] = "Memory repair",
            ["STOR"] = "Storage repair",
            ["WIFIADAP"] = "Wireless repair",
            ["SCRN"] = "Screen repair",
            ["MULT"] = "Multimedia repair",
            ["OTH"] = "Other repair"
        };

        if (!descriptions.TryGetValue(code, out var description))
        {
            throw new InvalidOperationException($"Unknown repair type code '{code}'.");
        }

        await db.Database.ExecuteSqlRawAsync(
            "INSERT INTO RepairTypeCodes (RepairTypeCode, Description) VALUES ({0}, {1})",
            new object[] { code, description },
            cancellationToken);
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
