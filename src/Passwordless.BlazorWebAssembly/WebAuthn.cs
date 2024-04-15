
using Fido2NetLib;
using Microsoft.JSInterop;
using Passwordless.BlazorWebAssembly.Abstractions;

namespace Passwordless.BlazorWebAssembly;

/// <summary>
/// Module for accessing the browser's WebAuthn API.
/// </summary>
public class WebAuthn : IWebAuthn
{
    private readonly Lazy<ValueTask<IJSObjectReference>> _jsModule;
    
    public WebAuthn(IJSRuntime jsRuntime)
    {
        _jsModule = new (() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Passwordless.BlazorWebAssembly/js/WebAuthn.js"));
    }

    private async Task<IJSObjectReference> GetJsModuleAsync() => await _jsModule.Value.ConfigureAwait(false);

    public async Task<bool> IsSupportedAsync()
    {
        var jsModule = await GetJsModuleAsync().ConfigureAwait(false);
        return await jsModule.InvokeAsync<bool>("isSupported");
    }
    

    public async Task<AuthenticatorAttestationRawResponse> CreateCredentialAsync(CredentialCreateOptions options)
    {
        var jsModule = await GetJsModuleAsync().ConfigureAwait(false);
        return await jsModule.InvokeAsync<AuthenticatorAttestationRawResponse>("createCredential", options);
    }

    public async Task<AuthenticatorAssertionRawResponse> VerifyAsync(AssertionOptions options)
    {
        var jsModule = await GetJsModuleAsync().ConfigureAwait(false);
        return await jsModule.InvokeAsync<AuthenticatorAssertionRawResponse>("verify", options);
    }
}
