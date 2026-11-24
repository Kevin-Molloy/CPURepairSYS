using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CPURepairSYS.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOracleRepairPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Oracle");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "ConnectionStrings:Oracle must be configured before Oracle persistence is registered.");
        }

        services.AddDbContext<RepairDbContext>(options => options.UseOracle(connectionString));
        services.AddScoped<ICustomerRepository, EfCustomerRepository>();
        services.AddScoped<IPartRepository, EfPartRepository>();
        services.AddScoped<IRepairRepository, EfRepairRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IRepairDataAdapter, RepairDataAdapter>();
        services.AddScoped<IRepairReportSource, EfRepairReportSource>();
        return services;
    }

    public static IServiceCollection AddUnavailableRepairPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, UnavailableCustomerRepository>();
        services.AddScoped<IPartRepository, UnavailablePartRepository>();
        services.AddScoped<IRepairRepository, UnavailableRepairRepository>();
        services.AddScoped<IUnitOfWork, UnavailableUnitOfWork>();
        services.AddScoped<IRepairDataAdapter, UnavailableRepairDataAdapter>();
        services.AddScoped<IRepairReportSource, UnavailableRepairReportSource>();
        return services;
    }
}

public static class UnavailablePersistence
{
    public static readonly InvalidOperationException ConfigurationError =
        new("ConnectionStrings:Oracle must be configured before repair persistence can be used.");

    public static Task<T> Unavailable<T>() => throw ConfigurationError;
    public static Task ThrowAsync() => Task.FromException(ConfigurationError);
}

public sealed class UnavailableCustomerRepository : ICustomerRepository
{
    public Task<CustomerId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<CustomerId>();
    public Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<Customer?>();
    public Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<bool>();
    public Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<bool>();
    public Task<IReadOnlyList<Customer>> SearchAsync(string? phone, string? firstName, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Customer>>();
    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.ThrowAsync();
    public void Update(Customer customer) => throw UnavailablePersistence.ConfigurationError;
}

public sealed class UnavailablePartRepository : IPartRepository
{
    public Task<PartId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<PartId>();
    public Task<Part?> GetByIdAsync(PartId id, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<Part?>();
    public Task<IReadOnlyList<Part>> SearchAsync(string? description, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Part>>();
    public Task<IReadOnlyList<Part>> SearchForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Part>>();
    public Task<IReadOnlyList<Part>> SearchAvailableAsync(string? description, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Part>>();
    public Task AddAsync(Part part, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.ThrowAsync();
    public void Update(Part part) => throw UnavailablePersistence.ConfigurationError;
}

public sealed class UnavailableRepairRepository : IRepairRepository
{
    public Task<RepairId> GetNextIdAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<RepairId>();
    public Task<Repair?> GetByIdAsync(RepairId id, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<Repair?>();
    public Task<IReadOnlyList<Repair>> SearchAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Repair>>();
    public Task AddAsync(Repair repair, CancellationToken cancellationToken = default) =>
        UnavailablePersistence.ThrowAsync();
    public void Update(Repair repair) => throw UnavailablePersistence.ConfigurationError;
}

public sealed class UnavailableUnitOfWork : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<int>();
    public Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IAsyncDisposable>();
}

public sealed class UnavailableRepairDataAdapter : IRepairDataAdapter
{
    public Task<T> ExecuteInTransactionAsync<T>(
        Func<CancellationToken, Task<T>> operation,
        CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<T>();
}

public sealed class UnavailableRepairReportSource : IRepairReportSource
{
    public Task<IReadOnlyList<Repair>> GetRepairsAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Repair>>();
    public Task<IReadOnlyList<Part>> GetPartsAsync(CancellationToken cancellationToken = default) =>
        UnavailablePersistence.Unavailable<IReadOnlyList<Part>>();
}
