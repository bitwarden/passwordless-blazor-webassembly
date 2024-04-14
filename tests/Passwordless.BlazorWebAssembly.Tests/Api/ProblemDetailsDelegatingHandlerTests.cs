
using System.Net;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Tests.DataFactory;

namespace Passwordless.BlazorWebAssembly.Tests.Api;

public class ProblemDetailsDelegatingHandlerTests
{
    [Fact]
    public async Task SendAsync_Throws_PasswordlessApiException_WhenResponseContainsProblemDetailsHeader()
    {
        // Arrange
        var sut = new ProblemDetailsDelegatingHandler();
        sut.InnerHandler = new ProblemDetailsHttpMessageHandler();
        using var httpClient = new HttpClient(sut);

        // Act
        var actual = await Assert.ThrowsAsync<PasswordlessApiException>(async () =>
            await httpClient.GetAsync("http://hello-world"));

        // Assert
        Assert.Equal("You do not have enough credit.", actual.Message);
        Assert.Equal("You do not have enough credit.", actual.Details.Title);
        Assert.Equal("Your current balance is 30, but that costs 50.", actual.Details.Detail);
        Assert.Equal("/account/12345/msgs/abc", actual.Details.Instance);
        Assert.Equal("https://example.com/probs/out-of-credit", actual.Details.Type);
    }

    [Fact]
    public async Task SendAsync_Throws_PasswordlessApiException_WhenResponseContainsApplicationJsonHeader()
    {
        // Arrange
        var sut = new ProblemDetailsDelegatingHandler();
        sut.InnerHandler = new BadRequestHttpMessageHandler();
        using var httpClient = new HttpClient(sut);

        // Act
        var actual = await Assert.ThrowsAsync<PasswordlessApiException>(async () =>
            await httpClient.GetAsync("http://hello-world"));

        // Assert
        Assert.Equal(Data.BadRequestResponse, actual.Message);
        Assert.Null(actual.Details);
    }

    [Fact]
    public async Task SendAsync_Returns_ExpectedResult_WhenResponseDoesNotContainProblemDetailsHeader()
    {
        // Arrange
        var sut = new ProblemDetailsDelegatingHandler();
        var innerHandler = new OkHttpMessageHandler();
        sut.InnerHandler = innerHandler;
        using var httpClient = new HttpClient(sut);

        // Act
        var actual = await httpClient.GetAsync("http://hello-world");

        // Assert
        Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        Assert.Equal(innerHandler.ExpectedResult, Guid.Parse(await actual.Content.ReadAsStringAsync()));
    }
}
