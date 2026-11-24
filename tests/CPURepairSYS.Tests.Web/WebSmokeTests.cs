using CPURepairSYS.Application;
using CPURepairSYS.Application.Facades;
using CPURepairSYS.Infrastructure.Persistence;
using CPURepairSYS.Web.Components.Pages;
using CPURepairSYS.Web.Authorization;
using Bunit;
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

    [Fact]
    public void Inventory_component_renders_without_oracle_configuration()
    {
        using var context = new Bunit.TestContext();
        context.Services.AddScoped<CPURepairSYS.Application.Abstractions.IApplicationAuthorizer, DevelopmentAuthorizer>();
        context.Services.AddRepairApplication();
        context.Services.AddUnavailableRepairPersistence();

        var cut = context.RenderComponent<Inventory>();

        Assert.Contains("Inventory", cut.Markup);
        Assert.Contains("Find parts", cut.Markup);
        Assert.Contains("Add part", cut.Markup);
    }
}