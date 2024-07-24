namespace Passwordless.BlazorWebAssembly.Contracts;

public class BaseErrorResponse
{
    public ProblemDetails? Error { get; set; }
}