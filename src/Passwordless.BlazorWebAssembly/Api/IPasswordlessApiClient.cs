
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Api;

public interface IPasswordlessApiClient
{
    Task<RegisterBeginResponse?> RegisterBeginAsync(RegisterBeginRequest request);
    Task<RegisterCompleteResponse?> RegisterCompleteAsync(RegisterCompleteRequest request);

    Task<LoginBeginResponse?> SignInBeginAsync(LoginBeginRequest request);
    Task<LoginCompleteResponse?> SignInCompleteAsync(LoginCompleteRequest request);
}
