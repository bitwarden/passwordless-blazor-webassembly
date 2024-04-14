
namespace Passwordless.BlazorWebAssembly.Utils;

public class AssemblyVersionProvider : IAssemblyVersionProvider
{
    public string Version
    {
        get
        {
            var assembly = typeof(AssemblyVersionProvider).Assembly;
            return $"blazorwasm-{assembly.GetName().Version!.ToString(3)}";
        }
    }
}
