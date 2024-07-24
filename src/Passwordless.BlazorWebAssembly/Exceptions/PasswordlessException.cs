using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Exceptions;

public class PasswordlessException : Exception
{
    public ProblemDetails Details { get; }

    public PasswordlessException(ProblemDetails details)
        : base(details.Title)
    {
        Details = details;
    }
}