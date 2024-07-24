
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passwordless.BlazorWebAssembly.Abstractions;
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
        services.AddScoped<IPasswordlessClient, PasswordlessClient>();
        services.AddScoped<IAssemblyVersionProvider, AssemblyVersionProvider>();
    }
}
