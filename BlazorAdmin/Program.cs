using BlazorAdmin;
using BlazorAdmin.Services;
using Blazored.LocalStorage;
using BlazorShared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#admin");
builder.RootComponents.Add<HeadOutlet>("head::after");

var configSection = builder.Configuration.GetRequiredSection(BaseUrlConfiguration.CONFIG_NAME);
builder.Services.Configure<BaseUrlConfiguration>(configSection);

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<HttpService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorServices();

builder.Logging.AddConfiguration(builder.Configuration.GetRequiredSection("logging"));

await ClearLocalStorageCache(builder.Services);

await builder.Build().RunAsync();

static async Task ClearLocalStorageCache(IServiceCollection services)
{
    var sp = services.BuildServiceProvider();
    var localStorageService = sp.GetRequiredService<ILocalStorageService>();

    await localStorageService.ClearAsync();
}
