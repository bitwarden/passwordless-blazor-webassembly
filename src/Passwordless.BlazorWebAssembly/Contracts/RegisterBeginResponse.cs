
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Contracts;

public sealed class RegisterBeginResponse
{
    public CredentialCreateOptions Data { get; set; }

    public string Session { get; set; }
}
