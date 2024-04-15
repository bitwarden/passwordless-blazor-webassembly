
namespace Passwordless.BlazorWebAssembly.Contracts;

public sealed class RegisterBeginRequest : BaseApiRequest
{
    /// <summary>
    /// The `register_` token returned by your backend.
    /// </summary>
    public string Token { get; set; }
}
