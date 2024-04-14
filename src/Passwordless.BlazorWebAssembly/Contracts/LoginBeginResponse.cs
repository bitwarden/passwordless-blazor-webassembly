
using Fido2NetLib;

namespace Passwordless.BlazorWebAssembly.Contracts;

public class LoginBeginResponse
{
    public AssertionOptions Data { get; set; }

    public string Session { get; set; }
}
