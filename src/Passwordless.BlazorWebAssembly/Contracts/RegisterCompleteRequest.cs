
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Contracts;

public sealed class RegisterCompleteRequest : BaseApiRequest
{
    public string Session { get; set; }

    public AuthenticatorAttestationRawResponse Response { get; set; }

    /// <summary>
    /// The credential's nickname.
    /// </summary>
    public string Nickname { get; set; }
}
