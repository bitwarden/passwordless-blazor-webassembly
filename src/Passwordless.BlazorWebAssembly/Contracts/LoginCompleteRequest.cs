
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Contracts;

public class LoginCompleteRequest : BaseApiRequest
{
    public AuthenticatorAssertionRawResponse Response { get; set; }

    public string Session { get; set; }
}
