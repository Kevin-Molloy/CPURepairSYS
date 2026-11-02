using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Facades;
using CPURepairSYS.Application.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace CPURepairSYS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddRepairApplication(this IServiceCollection services)
    {
        services.AddScoped<IRepairFactory, RepairFactory>();
        services.AddScoped<RepairFacade>();
        services.AddScoped<InventoryFacade>();
        services.AddScoped<ReportingFacade>();
        services.AddScoped<IRepairReportStrategy, RepairsByYearStrategy>();
        services.AddScoped<IPartReportStrategy, AvailablePartsStrategy>();
        return services;
    }
}
