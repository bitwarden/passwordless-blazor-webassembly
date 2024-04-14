
using Fido2NetLib;
using Microsoft.JSInterop;
using Passwordless.BlazorWebAssembly.Abstractions;

namespace Passwordless.BlazorWebAssembly;

/// <summary>
/// Module for accessing the browser's WebAuthn API.
/// </summary>
public class WebAuthn : IWebAuthn
{
    private IJSObjectReference _jsModule = null!;
    private readonly Task _initializer;

    public WebAuthn(IJSRuntime js)
    {
        _initializer = Task.Run(async () =>
            _jsModule = await js.InvokeAsync<IJSObjectReference>("import", "./_content/Passwordless.BlazorWebAssembly/js/WebAuthn.js"));
    }

    public Task InitializeAsync() => _initializer;

    public async Task<bool> IsSupportedAsync() => await _jsModule.InvokeAsync<bool>("isSupported");

    public async Task<AuthenticatorAttestationRawResponse> CreateCredentialAsync(CredentialCreateOptions options)
    {
        return await _jsModule.InvokeAsync<AuthenticatorAttestationRawResponse>("createCredential", options);
    }

    public async Task<AuthenticatorAssertionRawResponse> VerifyAsync(AssertionOptions options)
    {
        return await _jsModule.InvokeAsync<AuthenticatorAssertionRawResponse>("verify", options);
    }
}
