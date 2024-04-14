
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Abstractions;

public interface IWebAuthn
{
    /// <summary>
    /// Wait for this to make sure this module is initialized.
    /// </summary>
    /// <returns></returns>
    Task InitializeAsync();

    /// <summary>
    /// Whether or not this browser supports WebAuthn.
    /// </summary>
    /// <returns></returns>
    Task<bool> IsSupportedAsync();

    /// <summary>
    /// Creates a new credential.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<AuthenticatorAttestationRawResponse> CreateCredentialAsync(CredentialCreateOptions options);

    /// <summary>
    /// Verifies a credential for login.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<AuthenticatorAssertionRawResponse> VerifyAsync(AssertionOptions options);
}
