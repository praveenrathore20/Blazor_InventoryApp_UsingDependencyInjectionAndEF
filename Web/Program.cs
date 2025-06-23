//using Infrastructure.Persistence.Mappings;
//using Infrastructure.Persistence.Extensions;
//using Infrastructure.API.Extensions;
using MudBlazor.Services;
using Web.Components;
//using Application.Extensions;
//using Application.Interfaces.Services.Common;
//using Web.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;
using Web;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Domain.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Custom service configurations (assumed extension method)
builder.Services.ConfigureServices();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInventoryService, InventoryService>(); // Your concrete implementation here

// Add Razor Components and interactive server components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Blazor Server services and authorization core
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorizationCore();

// Get API base URL from configuration or use default
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

#region DB context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("ConnectionString non configurato!");
builder.Services.AddDbContext<dbcontext>(options =>
{
    options.UseSqlServer(connectionString)
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
#endregion

// Additional services
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();


// Build the app
var app = builder.Build();

// Configure middleware and pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
