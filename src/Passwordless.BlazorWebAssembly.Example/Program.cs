
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using Passwordless.BlazorWebAssembly;
using Passwordless.BlazorWebAssembly.Example;
using Passwordless.BlazorWebAssembly.Example.Services.DemoBackend;
using Passwordless.BlazorWebAssembly.Example.Services.DemoBackend.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOptions<DemoBackendOptions>().Bind(builder.Configuration.GetSection("DemoBackend"));
builder.Services.AddScoped<IDemoBackendClient, DemoBackendClient>();
builder.Services.AddHttpClient<IDemoBackendClient, DemoBackendClient>((sp, httpClient) =>
{
    var options = sp.GetRequiredService<IOptions<DemoBackendOptions>>().Value;
    httpClient.BaseAddress = new Uri(options.BaseUrl);
});

builder.Services.AddPasswordlessClient("PasswordlessJs");

await builder.Build().RunAsync();
