using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging; // Tilføj dette
using JagtApp.Client.Pages;
using JagtApp.Components;
using JagtApp.Components.Account;
using JagtApp.Data;
using JagtApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<GameAnimalService>();
builder.Services.AddScoped<UserAmmunitionService>();
builder.Services.AddScoped<FirearmService>();
builder.Services.AddScoped<BulletService>();
builder.Services.AddScoped<CartridgeService>();
builder.Services.AddScoped<CaliberService>();



// Add HttpClient with hardcoded BaseAddress
builder.Services.AddHttpClient<GameAnimalService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});
builder.Services.AddHttpClient<UserAmmunitionService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});
builder.Services.AddHttpClient<FirearmService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});
builder.Services.AddHttpClient<BulletService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});
builder.Services.AddHttpClient<CaliberService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});
builder.Services.AddHttpClient<CartridgeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7208");
});

// Add the following lines to register the controllers
builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// Tilføj logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery(); // Ensure this is placed correctly

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Ensure controllers are included
    endpoints.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(JagtApp.Client._Imports).Assembly);
    endpoints.MapAdditionalIdentityEndpoints();
});

app.Run();
