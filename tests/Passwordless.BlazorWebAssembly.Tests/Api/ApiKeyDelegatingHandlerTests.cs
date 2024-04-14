
using System.Net;
using Microsoft.Extensions.Options;
using Moq;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Configuration;
using Passwordless.BlazorWebAssembly.Tests.DataFactory;

namespace Passwordless.BlazorWebAssembly.Tests.Api;

public class ApiKeyDelegatingHandlerTests
{
    private readonly Mock<IOptions<PasswordlessOptions>> _optionsMock = new();

    [Fact]
    public async Task SendAsync_Adds_ExpectedApiKeyHeader()
    {
        // Arrange
        var expectedOptions = new PasswordlessOptions { ApiKey = $"yourapp:public:{Guid.NewGuid():N}" };
        _optionsMock.SetupGet(x => x.Value).Returns(expectedOptions);
        var sut = new ApiKeyDelegatingHandler(_optionsMock.Object);
        sut.InnerHandler = new OkHttpMessageHandler();
        using var httpClient = new HttpClient(sut);

        // Act
        var actual = await httpClient.GetAsync("http://hello-world");

        // Assert
        Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        Assert.True(actual.RequestMessage!.Headers.Contains("ApiKey"));
        Assert.Equal(expectedOptions.ApiKey, actual.RequestMessage.Headers.GetValues("ApiKey").Single());
    }
}
