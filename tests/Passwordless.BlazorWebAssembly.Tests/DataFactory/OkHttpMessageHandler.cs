
using System.Net;
using System.Text;

namespace Passwordless.BlazorWebAssembly.Tests.DataFactory;

public sealed class OkHttpMessageHandler : HttpMessageHandler
{
    public readonly Guid ExpectedResult = Guid.NewGuid();

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var stringContent = new StringContent(ExpectedResult.ToString(), Encoding.UTF8);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            RequestMessage = request,
            Content = stringContent
        };
        return Task.FromResult(response);
    }
}
