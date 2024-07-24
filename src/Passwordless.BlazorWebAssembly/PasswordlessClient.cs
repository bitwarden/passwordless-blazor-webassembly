using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Passwordless.BlazorWebAssembly.Abstractions;
using Passwordless.BlazorWebAssembly.Configuration;
using Passwordless.BlazorWebAssembly.Contracts;
using Passwordless.BlazorWebAssembly.Exceptions;

namespace Passwordless.BlazorWebAssembly;

public class PasswordlessClient : IAsyncDisposable, IPasswordlessClient
{
    private readonly Lazy<Task<IJSObjectReference>> _passwordlessClientReferenceTask;
    private readonly ILogger<PasswordlessClient> _logger;

    public PasswordlessClient(IJSRuntime jsRuntime, IOptions<PasswordlessOptions> passwordlessOptions, ILogger<PasswordlessClient> logger)
    {
        _logger = logger;
        var options = passwordlessOptions.Value;
        _passwordlessClientReferenceTask = new Lazy<Task<IJSObjectReference>>(() => Initialize(jsRuntime, options.ApiKey, options.ApiUrl));
    }

    private static async Task<IJSObjectReference> Initialize(IJSRuntime jsRuntime, string apiKey, string apiUrl)
    {
        var module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Passwordless.BlazorWebAssembly/lib/passwordless/passwordless-blazor.js");
        var passwordlessClient = await module.InvokeAsync<IJSObjectReference>("init", apiKey, apiUrl);
        return passwordlessClient;
    }

    public async ValueTask<string> SigninWithIdAsync(string userId)
    {
        return await InvokeCoreAsync<LoginCompleteResponse, string>("signinWithId", r => r.Token!, userId);
    }

    public async ValueTask<string> SigninWithAliasAsync(string alias)
    {
        return await InvokeCoreAsync<LoginCompleteResponse, string>("signinWithAlias", r => r.Token!, alias);
    }

    public async ValueTask<string> SigninWithAutofillAsync()
    {
        return await InvokeCoreAsync<LoginCompleteResponse, string>("signinWithAutofill", r => r.Token!);
    }

    public async ValueTask<string> SigninWithDiscoverableAsync()
    {
        return await InvokeCoreAsync<LoginCompleteResponse, string>("signinWithDiscoverable", r => r.Token!);
    }

    public async Task<bool> IsPlatformSupportedAsync()
    {
        var passwordlessClient = await _passwordlessClientReferenceTask.Value;
        return await passwordlessClient.InvokeAsync<bool>("isPlatformSupported");
    }
    
    public async Task<bool> IsBrowserSupportedAsync()
    {
        var passwordlessClient = await _passwordlessClientReferenceTask.Value;
        return await passwordlessClient.InvokeAsync<bool>("isBrowserSupported");
    }
    
    public async Task<bool> IsAutofillSupportedAsync()
    {
        var passwordlessClient = await _passwordlessClientReferenceTask.Value;
        return await passwordlessClient.InvokeAsync<bool>("isAutofillSupported");
    }

    public async ValueTask<string> RegisterAsync(string token)
    {
        return await InvokeCoreAsync<RegisterCompleteResponse, string>("register", r => r.Token!, token);
    }

    private async ValueTask<TFinalReturn> InvokeCoreAsync<TReturn, TFinalReturn>(string identifier, Func<TReturn, TFinalReturn> returnCreator, params object?[]? args)
        where TReturn : BaseErrorResponse
    {
        var passwordlessClient = await _passwordlessClientReferenceTask.Value;
        try
        {
            var response = await passwordlessClient.InvokeAsync<TReturn>(identifier, args);
            if (response.Error is not null)
            {
                throw new PasswordlessException(response.Error);
            }

            return returnCreator(response);
        }
        catch (JSException ex)
        {
            _logger.LogError(ex, "An error occured during {Identifier}, please report this error so we can make a better product.", identifier);
            throw;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_passwordlessClientReferenceTask.IsValueCreated)
        {
            var module = await _passwordlessClientReferenceTask.Value;
            await module.DisposeAsync();
        }
    }
}