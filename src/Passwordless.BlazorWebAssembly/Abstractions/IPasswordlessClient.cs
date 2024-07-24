namespace Passwordless.BlazorWebAssembly.Abstractions;

public interface IPasswordlessClient
{
    /// <summary>
    /// To build an efficient user experience for both passkey and password users, you can include passkeys in autofill
    /// suggestions. Returns <c href="true"/> if the browser supports autofill.
    /// </summary>
    Task<bool> IsAutofillSupportedAsync();

    /// <summary>
    /// Returns <c href="true"/> if the browser supports WebAuthn.
    /// </summary>
    /// <returns></returns>
    Task<bool> IsBrowserSupportedAsync();
    
    /// <summary>
    /// Platform authenticators, also known as internal authenticators, such as a fingerprint scanner built into a
    /// smartphone. Platform authenticators are limited to authenticating a user via a specific device (in the case of
    /// Windows Hello, the laptop running it). Returns <c href="true"/> if the browser supports platform authenticators.
    /// </summary>
    /// <returns></returns>
    Task<bool> IsPlatformSupportedAsync();
    
    /// <summary>
    /// Registers a user with the `register_` token returned by your backend.
    /// </summary>
    /// <param name="token">The `register_` token returned by your backend.</param>
    ValueTask<string> RegisterAsync(string token);
    
    /// <summary>
    /// Sign in a user using the userid
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithIdAsync(string userId);
    
    /// <summary>
    /// Sign in a user using an alias
    /// </summary>
    /// <param name="alias">e.g. email,username to specify the user.	</param>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithAliasAsync(string alias);
    
    /// <summary>
    /// Sign in a user using autofill UI (a.k.a conditional) sign in
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithAutofillAsync();
    
    /// <summary>
    /// Sign in a user using discoverable credentials
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithDiscoverableAsync();
}