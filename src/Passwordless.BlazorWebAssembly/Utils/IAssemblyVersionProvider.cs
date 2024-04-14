
namespace Passwordless.BlazorWebAssembly.Utils;

public interface IAssemblyVersionProvider
{
    /// <summary>
    /// Returns the version of the Passwordless.dev Blazor WebAssembly SDK.
    /// </summary>
    string Version { get; }
}
