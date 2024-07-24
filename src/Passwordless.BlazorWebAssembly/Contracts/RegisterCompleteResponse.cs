
namespace Passwordless.BlazorWebAssembly.Contracts;

public class RegisterCompleteResponse : BaseErrorResponse
{
    public string? Token { get; set; }
}
