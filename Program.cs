using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Speccon.Learnership.FrontEnd;
using Speccon.Learnership.FrontEnd.Models.Qualification;
using Speccon.Learnership.FrontEnd.Services;
using Speccon.Learnership.FrontEnd.Services.Authorization;
using Speccon.Learnership.FrontEnd.Services.Configurations;
using Speccon.Learnership.FrontEnd.Services.Disabilities;
using Speccon.Learnership.FrontEnd.Services.Identity;
using Speccon.Learnership.FrontEnd.Services.PracticalService;
using Speccon.Learnership.FrontEnd.Services.Qualifications;
using Speccon.Learnership.FrontEnd.Services.System;
using Speccon.Learnership.FrontEnd.Services.TestClients;
using Speccon.Learnership.FrontEnd.Services.TestQualifications;
using Speccon.Learnership.FrontEnd.Services.TestQualificationTypes;
using Speccon.Learnership.FrontEnd.Services.Users;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    var site = string.Empty;
    if (builder.HostEnvironment.IsDevelopment())
    {
        site = AppConfig.DevBaseUri;
    }
    else
    {
        site = AppConfig.ProdBaseUri;
    }

    builder.Services.AddHttpClient("API", client =>
    {
        client.BaseAddress = new Uri(site);
    }).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

    builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
    builder.Services.AddScoped<RouteGuardService>();
    builder.Services.AddScoped(sp =>
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(site)
        };
        return client;
    });

    builder.Services.AddScoped<AuthService>();
    builder.Services.AddScoped<UsersService>();
    builder.Services.AddScoped<DisabilityService>();
    builder.Services.AddScoped<TestQualificationService>();
    builder.Services.AddScoped<TestQualificationTypeService>();
    builder.Services.AddScoped<TestClientService>();
    builder.Services.AddScoped<EncryptionHelper>();
    builder.Services.AddScoped<ApiEndpointCall>();
    //builder.Services.AddScoped<QualificationService>();
    builder.Services.AddScoped<IPracticalAssignmentService, PracticalAssignmentService>();
    builder.Services.AddScoped<IQCTOQualificationService>(sp =>
    {
        var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
        var logger = sp.GetRequiredService<ILogger<QCTOQualificationService>>();
        return new QCTOQualificationService(httpClientFactory, logger);
    });

    builder.Services.AddScoped<ISetaQualificationService, SetaQualificationService>();

    builder.Services.AddSingleton<DrawerService>();

    builder.Services.AddHttpClient();
    builder.Services.AddBlazoredLocalStorage();

    // Perform the authentication check
    builder.Services.AddScoped<CustomAuthenticationStateProvider>();
    builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    builder.Services.AddAuthorizationCore();

    builder.Services.AddMudServices();
    await builder.Build().RunAsync();
}
//catch
//{
//    throw new Exception();
//}
catch (Exception ex)
{
    Console.WriteLine("Unhandled exception: " + ex);
}
