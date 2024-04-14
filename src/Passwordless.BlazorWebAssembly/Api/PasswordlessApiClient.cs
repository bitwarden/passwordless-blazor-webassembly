
using System.Net.Http.Json;
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Api;

public sealed class PasswordlessApiClient : IPasswordlessApiClient
{
    public const string Name = "passwordless-blazor";

    private readonly PasswordlessApiSerializerContext _serializerContext = new();
    private readonly IHttpClientFactory _httpClientFactory;

    public PasswordlessApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<RegisterBeginResponse?> RegisterBeginAsync(RegisterBeginRequest request)
    {
        using var client = _httpClientFactory.CreateClient(Name);
        var httpResponseMessage = await client.PostAsJsonAsync("register/begin", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<RegisterBeginResponse>();
    }

    public async Task<RegisterCompleteResponse?> RegisterCompleteAsync(RegisterCompleteRequest request)
    {
        using var client = _httpClientFactory.CreateClient(Name);
        var httpResponseMessage = await client.PostAsJsonAsync("register/complete", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<RegisterCompleteResponse>();
    }

    public async Task<LoginBeginResponse?> SignInBeginAsync(LoginBeginRequest request)
    {
        using var client = _httpClientFactory.CreateClient(Name);
        var httpResponseMessage = await client.PostAsJsonAsync("signin/begin", request, _serializerContext.Options);
        return await httpResponseMessage.Content.ReadFromJsonAsync<LoginBeginResponse>();
    }

    public async Task<LoginCompleteResponse?> SignInCompleteAsync(LoginCompleteRequest request)
    {
        using var client = _httpClientFactory.CreateClient(Name);
        var httpResponseMessage = await client.PostAsJsonAsync("signin/complete", request, _serializerContext.Options);
        return await httpResponseMessage.Content.ReadFromJsonAsync<LoginCompleteResponse>();
    }
}
