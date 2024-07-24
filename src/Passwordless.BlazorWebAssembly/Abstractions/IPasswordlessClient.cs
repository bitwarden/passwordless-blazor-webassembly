namespace Passwordless.BlazorWebAssembly.Abstractions;

public interface IPasswordlessClient
{
    Task<bool> IsAutofillSupportedAsync();

    Task<bool> IsBrowserSupportedAsync();
    
    Task<bool> IsPlatformSupportedAsync();
    
    /// <summary>
    /// Registers a user with the `register_` token returned by your backend.
    /// </summary>
    /// <param name="token">The `register_` token returned by your backend.</param>
    ValueTask<string> RegisterAsync(string token);
    
    /// <summary>
    /// Sign in a user using the userid
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithIdAsync(string userId);
    
    /// <summary>
    /// Sign in a user using an alias
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithAliasAsync(string alias);
    
    /// <summary>
    /// Sign in a user using autofill UI (a.k.a conditional) sign in
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithAutofillAsync();
    
    /// <summary>
    /// ign in a user using discoverable credentials
    /// </summary>
    /// <returns>a verify_token</returns>
    ValueTask<string> SigninWithDiscoverableAsync();
}