using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application;
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
}
