
using Passwordless.BlazorWebAssembly.Example.Services.DemoBackend.Contracts;

namespace Passwordless.BlazorWebAssembly.Example.Services.DemoBackend;

public interface IDemoBackendClient
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<SignInResponse> SignInAsync(SignInRequest request);
}
