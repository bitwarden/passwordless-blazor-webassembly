
namespace Passwordless.BlazorWebAssembly.Contracts;

public class LoginCompleteResponse : BaseErrorResponse
{
    public string? Token { get; set; }
}
