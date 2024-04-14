
namespace Passwordless.BlazorWebAssembly.Contracts;

public abstract class BaseApiRequest
{
    public string Origin { get; set; }

    public string RPID { get; set; }
}
