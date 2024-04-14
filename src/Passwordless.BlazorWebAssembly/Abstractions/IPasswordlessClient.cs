
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Abstractions;

public interface IPasswordlessClient : IDisposable
{
    Task<RegisterCompleteResponse> RegisterAsync(string token, string credentialNickname);
    Task<LoginCompleteResponse> LoginAsync(string? alias);
}
