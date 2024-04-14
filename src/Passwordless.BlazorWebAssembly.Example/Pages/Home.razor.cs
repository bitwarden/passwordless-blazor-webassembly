
using Microsoft.AspNetCore.Components;
using Passwordless.BlazorWebAssembly.Example.Services.DemoBackend.Contracts;
using Passwordless.BlazorWebAssembly.Example.ViewModels;

namespace Passwordless.BlazorWebAssembly.Example.Pages;

public partial class Home : ComponentBase
{
    private const string RegisterFormName = "RegisterForm";
    private const string LoginFormName = "LoginForm";

    [SupplyParameterFromForm(FormName = LoginFormName)]
    public LoginViewModel LoginViewModel { get; set; } = new();

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; } = new();

    [SupplyParameterFromForm(FormName = RegisterFormName)]
    public RegisterViewModel RegisterViewModel { get; set; } = new();

    private async Task OnSignInAsync()
    {
        var token = await WebAuthnClient.LoginAsync(LoginViewModel.Alias!);

        var backendRequest = new SignInRequest(token.Token);
        var backendResponse = await BackendClient.SignInAsync(backendRequest);
    }

    private async Task OnRegistrationAsync()
    {
        Console.WriteLine("Registration");
        if (RegisterViewModel?.Username == null)
        {
            return;
        }
        var registrationToken = await BackendClient.RegisterAsync(new RegisterRequest(RegisterViewModel.Username, RegisterViewModel.Alias));
        var token = await WebAuthnClient.RegisterAsync(registrationToken.Token, RegisterViewModel.Alias!);
    }
}
