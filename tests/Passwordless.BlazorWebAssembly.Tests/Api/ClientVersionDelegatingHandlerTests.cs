
using System.Net;
using Moq;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Tests.DataFactory;
using Passwordless.BlazorWebAssembly.Utils;

namespace Passwordless.BlazorWebAssembly.Tests.Api;

public class ClientVersionDelegatingHandlerTests
{
    private readonly Mock<IAssemblyVersionProvider> _assemblyVersionProviderMock = new();

    [Fact]
    public async Task SendAsync_Adds_ExpectedClientVersionHeader()
    {
        // Arrange
        _assemblyVersionProviderMock.SetupGet(x => x.Version).Returns("blazorwasm-1.0.0");
        var sut = new ClientVersionDelegatingHandler(_assemblyVersionProviderMock.Object);
        sut.InnerHandler = new OkHttpMessageHandler();
        using var httpClient = new HttpClient(sut);

        // Act
        var actual = await httpClient.GetAsync("http://hello-world");

        // Assert
        Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        Assert.True(actual.RequestMessage!.Headers.Contains("Client-Version"));
        Assert.Equal("blazorwasm-1.0.0", actual.RequestMessage.Headers.GetValues("Client-Version").Single());
    }
}
