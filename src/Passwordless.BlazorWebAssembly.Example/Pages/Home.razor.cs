
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

    public bool? IsBrowserSupported { get; private set; }

    public bool? IsPlatformSupported { get; private set; }

    public bool? IsAutofillSupported { get; private set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!IsBrowserSupported.HasValue)
        {
            IsBrowserSupported = await WebAuthnClient.IsBrowserSupportedAsync();
            StateHasChanged();
        }
        if (!IsPlatformSupported.HasValue)
        {
            IsPlatformSupported = await WebAuthnClient.IsPlatformSupportedAsync();
            StateHasChanged();
        }
        if (!IsAutofillSupported.HasValue)
        {
            IsAutofillSupported = await WebAuthnClient.IsAutofillSupportedAsync();
            StateHasChanged();
        }
    }

    private async Task OnSignInAsync()
    {
        var token = await WebAuthnClient.SigninWithAliasAsync(LoginViewModel.Alias!);

        var backendRequest = new SignInRequest(token);
        var backendResponse = await BackendClient.SignInAsync(backendRequest);
    }

    private async Task OnRegistrationAsync()
    {
        Console.WriteLine("Registration");
        if (RegisterViewModel?.Username == null)
        {
            return;
        }
        var request = new RegisterRequest(RegisterViewModel.Username, RegisterViewModel.Alias, RegisterViewModel.FirstName, RegisterViewModel.LastName);
        var registrationToken = await BackendClient.RegisterAsync(request);
        var token = await WebAuthnClient.RegisterAsync(registrationToken.Token);
    }
}
