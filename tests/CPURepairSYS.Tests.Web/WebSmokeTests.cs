using CPURepairSYS.Application;
using CPURepairSYS.Application.Facades;
using CPURepairSYS.Infrastructure.Persistence;
using CPURepairSYS.Web.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CPURepairSYS.Tests.Web;

public sealed class WebSmokeTests
{
    [Fact]
    public void Application_services_resolve_without_oracle_configuration()
    {
        var services = new ServiceCollection();
        services.AddScoped<CPURepairSYS.Application.Abstractions.IApplicationAuthorizer, DevelopmentAuthorizer>();
        services.AddRepairApplication();
        services.AddUnavailableRepairPersistence();

        using var provider = services.BuildServiceProvider();
        Assert.NotNull(provider.GetRequiredService<RepairFacade>());
        Assert.NotNull(provider.GetRequiredService<InventoryFacade>());
        Assert.NotNull(provider.GetRequiredService<ReportingFacade>());
    }
}