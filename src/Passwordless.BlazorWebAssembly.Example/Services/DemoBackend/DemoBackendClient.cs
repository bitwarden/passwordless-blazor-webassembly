
using System.Net.Http.Json;
using Passwordless.BlazorWebAssembly.Example.Services.DemoBackend.Contracts;

namespace Passwordless.BlazorWebAssembly.Example.Services.DemoBackend;

public class DemoBackendClient : IDemoBackendClient
{
    private readonly HttpClient _httpClient;
    public DemoBackendClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        var content = JsonContent.Create(request);
        var response = await _httpClient.PostAsync("auth/register", content);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<RegisterResponse>();
        return result!;
    }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        var content = JsonContent.Create(request);
        var response = await _httpClient.PostAsync("auth/login", content);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<SignInResponse>();
        return result!;
    }
}
