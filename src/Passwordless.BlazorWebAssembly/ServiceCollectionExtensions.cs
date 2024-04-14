
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passwordless.BlazorWebAssembly.Abstractions;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Configuration;
using Passwordless.BlazorWebAssembly.Utils;

namespace Passwordless.BlazorWebAssembly;

/// <summary>
/// Service registration extensions for Passwordless.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddPasswordlessClient(this IServiceCollection services, Action<PasswordlessOptions> configureOptions)
    {
        services.AddOptions<PasswordlessOptions>().Configure(configureOptions);
        services.AddShared();
    }

    public static void AddPasswordlessClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<PasswordlessOptions>().Configure(configuration.Bind);
        services.AddShared();
    }

    public static void AddPasswordlessClient(this IServiceCollection services, string section)
    {
        services.AddOptions<PasswordlessOptions>().BindConfiguration(section);
        services.AddShared();
    }

    private static void AddShared(this IServiceCollection services)
    {
        services.AddScoped<ApiKeyDelegatingHandler>();
        services.AddScoped<IAssemblyVersionProvider, AssemblyVersionProvider>();
        services.AddScoped<ClientVersionDelegatingHandler>();
        services.AddScoped<ProblemDetailsDelegatingHandler>();
        services.AddScoped<IPasswordlessApiClient, PasswordlessApiClient>();
        services.AddHttpClient(PasswordlessApiClient.Name, c =>
        {
            c.BaseAddress = new Uri("https://v4.passwordless.dev");
        }).AddHttpMessageHandler<ApiKeyDelegatingHandler>()
        .AddHttpMessageHandler<ClientVersionDelegatingHandler>()
        .AddHttpMessageHandler<ProblemDetailsDelegatingHandler>();
        services.AddScoped<IWebAuthn, WebAuthn>();
        services.AddScoped<IPasswordlessClient, PasswordlessClient>();
    }
}
