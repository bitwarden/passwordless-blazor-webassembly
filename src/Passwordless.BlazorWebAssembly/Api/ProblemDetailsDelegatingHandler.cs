
using System.Net.Http.Json;

namespace Passwordless.BlazorWebAssembly.Api;

public sealed class ProblemDetailsDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var httpResponseMessage = await base.SendAsync(request, cancellationToken);
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            return httpResponseMessage;
        }

        if (httpResponseMessage.Content.Headers.ContentType?.MediaType != "application/problem+json")
        {
            throw new PasswordlessApiException(await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
        }

        var problemDetails = await httpResponseMessage.Content.ReadFromJsonAsync(
            PasswordlessApiSerializerContext.Default.ProblemDetails,
            cancellationToken);

        if (problemDetails is not null)
        {
            throw new PasswordlessApiException(problemDetails);
        }

        throw new PasswordlessApiException(await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
    }
}
