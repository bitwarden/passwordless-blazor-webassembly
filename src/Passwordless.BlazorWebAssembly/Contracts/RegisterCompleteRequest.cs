
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Contracts;

public sealed class RegisterCompleteRequest : BaseApiRequest
{
    public string Session { get; set; }

    public AuthenticatorAttestationRawResponse Response { get; set; }

    public string Nickname { get; set; }
}
