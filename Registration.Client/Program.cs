using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using Registration.Client;
using Registration.Client.AuthServices;
using Registration.Client.Schedule;
using Registration.Client.Services.Implemintations;
using Registration.Client.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IRegistrationBlazorService, RegistrationBlazorService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<IAdminPermissionBlazorService, AdminPermissionBlazorService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<IStudentBlazorService, StudentBlazorService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<IStudentschedBlazorService, StudentschedBlazorService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});




builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7174/")
    });
builder.Services.AddScoped<SchduleDto>();



builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
