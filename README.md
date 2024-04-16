![Build](https://github.com/bitwarden/passwordless-blazor-webassembly/actions/workflows/ci.yml/badge.svg)

# Passwordless.dev Blazor WebAssembly Client SDK

## Requirements

- A Blazor WebAssembly application using .NET 8 or higher.

## Installation

TODO

## Configuration

## Using

Be mindful that the code below are simple representations of how to use the SDK. To properly secure your Blazor WebAssembly application, check the [Secure ASP.NET Core Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/) guide.

### Dependency Injection

You can use the following extension methods on `WebApplicationBuilder` to add configure the Passwordless client to your
Blazor WebAssembly application:

```csharp
public static void AddPasswordlessClient(this IServiceCollection services, Action<PasswordlessOptions> configureOptions);

public static void AddPasswordlessClient(this IServiceCollection services, IConfiguration configuration);

public static void AddPasswordlessClient(this IServiceCollection services, string section);
```

### Registration

Inject the `IPasswordlessClient` into your component and call the `RegisterAsync` method to register a new user.

```
@inject IPasswordlessClient PasswordlessClient
```

Your form could look like the one below.

```html
<div class="card h-100">
    <div class="card-body">
        <h5 class="card-title mb-2">Register</h5>
        <EditForm FormName="@RegisterFormName" Model="@RegisterViewModel" OnValidSubmit="OnRegistrationAsync">
            <DataAnnotationsValidator/>
            <InputText class="form-control mb-2" DisplayName="Username" @bind-Value="RegisterViewModel.Username"
                       placeholder="Username"/>
            <ValidationMessage class="mb-2 validation-message" For="@(() => RegisterViewModel.Username)"/>
            <InputText class="form-control mb-2" DisplayName="Alias" @bind-Value="RegisterViewModel.Alias"
                       placeholder="Alias (optional)"/>
            <ValidationMessage class="mb-2 validation-message" For="@(() => RegisterViewModel.Alias)"/>
            <button class="btn btn-primary" type="submit">Register</button>
        </EditForm>
    </div>
</div>
```

In the form submission event handlers, handle the registration.

```csharp
private const string RegisterFormName = "RegisterForm";

[SupplyParameterFromForm(FormName = RegisterFormName)]
public RegisterViewModel RegisterViewModel { get; set; } = new();


private async Task OnRegistrationAsync()
{
    if (RegisterViewModel?.Username == null) return;
    
    // 1. Call your backend to obtain the `register_` token.
    var registrationToken = await PasswordlessClient.RegisterAsync(new RegisterRequest(RegisterViewModel.Username, RegisterViewModel.Alias));
    
    // 2. Call the Passwordless client to create and store the credentials.
    var token = await WebAuthnClient.RegisterAsync(registrationToken.Token, RegisterViewModel.Alias!);
}
```

### Logging in

Inject the `IPasswordlessClient` into your component and call the `RegisterAsync` method to register a new user.

```
@inject IPasswordlessClient PasswordlessClient
```

Your form could look like the one below.

```html
<div class="card h-100">
    <div class="card-body">
        <h5 class="card-title mb-2">Login</h5>
        <EditForm FormName="@LoginFormName" Model="@LoginViewModel" OnValidSubmit="OnSignInAsync">
            <DataAnnotationsValidator />
            <InputText class="form-control mb-2" DisplayName="Alias" @bind-Value="LoginViewModel.Alias" placeholder="Alias (optional)"/>
            <ValidationMessage class="mb-2 validation-message" For="@(() => LoginViewModel.Alias)"/>
            <button class="btn btn-primary" type="submit">Sign In</button>
        </EditForm>
    </div>
</div>
```

In the form submission event handlers, handle the login.

```csharp
private const string LoginFormName = "LoginForm";

[SupplyParameterFromForm(FormName = LoginFormName)]
public LoginViewModel LoginViewModel { get; set; } = new();

private async Task OnSignInAsync()
{
    // 1. Call Passwordless.dev to initiate the login process.
    var token = await PasswordlessClient.LoginAsync(LoginViewModel.Alias!);

    // 2. Once a valid credential is selected, call your backend to authenticate the user.
    // `backendResponse` can contain a JWT token or any other authentication information.
    var backendRequest = new SignInRequest(token.Token);
    var backendResponse = await BackendClient.SignInAsync(backendRequest);
}
```

## References

- [Get Started - Passwordless.dev](https://docs.passwordless.dev/guide/get-started.html)
- [Integration with your backend - Passwordless.dev](https://docs.passwordless.dev/guide/backend)
- [Secure ASP.NET Core Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/)
