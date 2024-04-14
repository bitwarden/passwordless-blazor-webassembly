
namespace Passwordless.BlazorWebAssembly.Contracts;

public sealed class RegisterBeginRequest : BaseApiRequest
{
    public string Token { get; set; }
}
