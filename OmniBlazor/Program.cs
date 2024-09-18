using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OmniBlazor;
using OmniBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

var loginApi = builder.Configuration.GetValue<string>("ApiEndpoint:LoginApi");

builder.Services.AddHttpClient("LoginApi", client => {
    client.BaseAddress = new Uri(loginApi!);
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddCascadingAuthenticationState(); 

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthSateProvider>();
builder.Services.AddAuthorizationCore(options=> {
    options.AddPolicy("Omni", policy => policy.RequireClaim("role", "Omni"));
});

builder.Services.AddScoped<IAccountService, AccountService>();

builder
    .Services.AddBlazorise(options =>
    {
        options.Immediate = false;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
