
using Microsoft.Extensions.Options;
using Passwordless.BlazorWebAssembly.Configuration;

namespace Passwordless.BlazorWebAssembly.Api;

public sealed class ApiKeyDelegatingHandler : DelegatingHandler
{
    private const string ApiKeyHeader = "ApiKey";

    private readonly IOptions<PasswordlessOptions> _options;

    public ApiKeyDelegatingHandler(IOptions<PasswordlessOptions> options)
    {
        _options = options;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add(ApiKeyHeader, _options.Value.ApiKey);
        return base.SendAsync(request, cancellationToken);
    }
}
