using Microsoft.AspNetCore.Localization;
using Playground.FrontEnd;
using Playground.FrontEnd.Components.Dialog;
using Playground.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register localization services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddAuthorizationCore();

//ToastService
builder.Services.AddSingleton<ToastService>();

//DialogService
builder.Services.AddScoped<IDialogService, DialogService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Define supported languages
var supportedCultures = new[]
{
    new CultureInfo("nl"),
    new CultureInfo("en"),
};

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

app.UseRequestLocalization(localizationOptions);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");

app.Run();
