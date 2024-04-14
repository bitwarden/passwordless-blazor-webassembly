
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Api;

/// <summary>
/// Exception thrown when the API returns a non-successful response.
/// </summary>
public sealed class PasswordlessApiException : Exception
{
    public PasswordlessApiException(ProblemDetails? problemDetails) : this(problemDetails?.Title)
    {
        Details = problemDetails;
    }

    public PasswordlessApiException(string? message) : base(message)
    {

    }

    /// <summary>
    /// Details associated with the problem, returned by the API.
    /// </summary>
    public ProblemDetails? Details { get; }
}
