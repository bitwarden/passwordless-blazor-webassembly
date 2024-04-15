
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Abstractions;

public interface IPasswordlessClient : IDisposable
{
    /// <summary>
    /// Registers a credential for a new user.
    /// </summary>
    /// <param name="token">The `register_` token returned by your backend.</param>
    /// <param name="nickname">The credential's nickname.</param>
    /// <returns></returns>
    Task<RegisterCompleteResponse> RegisterAsync(string token, string nickname);
    
    /// <summary>
    /// Signs in a user.
    /// </summary>
    /// <param name="alias">When using non-discoverable credentials, this is the user's alias.</param>
    /// <returns>Returns the `verify_` token.</returns>
    Task<LoginCompleteResponse> LoginAsync(string? alias);
}
