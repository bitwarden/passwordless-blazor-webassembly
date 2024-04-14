
using System.Net;
using System.Text;

namespace Passwordless.BlazorWebAssembly.Tests.DataFactory;

public sealed class ProblemDetailsHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var stringContent = new StringContent(Data.ProblemDetailsResponse, Encoding.UTF8, "application/problem+json");
        var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            RequestMessage = request,
            Content = stringContent
        };
        return Task.FromResult(response);
    }
}
