
using Passwordless.BlazorWebAssembly.Utils;

namespace Passwordless.BlazorWebAssembly.Api;

/// <summary>
/// Adds the 'Client-Version' header to all outgoing requests.
/// </summary>
public sealed class ClientVersionDelegatingHandler : DelegatingHandler
{
    private const string HeaderName = "Client-Version";

    private readonly IAssemblyVersionProvider _assemblyVersionProvider;

    public ClientVersionDelegatingHandler(IAssemblyVersionProvider assemblyVersionProvider)
    {
        _assemblyVersionProvider = assemblyVersionProvider;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add(HeaderName, _assemblyVersionProvider.Version);
        return base.SendAsync(request, cancellationToken);
    }
}
