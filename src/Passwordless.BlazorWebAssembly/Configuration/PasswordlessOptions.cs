
namespace Passwordless.BlazorWebAssembly.Configuration;

public class PasswordlessOptions
{
    public string ApiUrl { get; set; } = "https://v4.passwordless.dev";

    public string ApiKey { get; set; }
}
