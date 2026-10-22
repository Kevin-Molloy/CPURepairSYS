using CPURepairSYS.Web.Components;
using CPURepairSYS.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var oracleConnectionString = builder.Configuration.GetConnectionString("Oracle");
if (!string.IsNullOrWhiteSpace(oracleConnectionString))
{
    builder.Services.AddOracleRepairPersistence(builder.Configuration);
}
else
{
    builder.Logging.AddFilter("CPURepairSYS.Infrastructure", LogLevel.Warning);
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
