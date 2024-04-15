![Build](https://github.com/bitwarden/passwordless-android/actions/workflows/android.yml/badge.svg)
[![Maven Central](https://img.shields.io/maven-central/v/com.bitwarden/passwordless-android.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22com.bitwarden%22%20AND%20a:%22passwordless-android%22)

# Passwordless.dev Blazor WebAssembly Client SDK

## Requirements

- A Blazor WebAssembly application using .NET 8 or higher.

## Installation

TODO

## Configuration


## Using

### Dependency Injection

You can use the following extension methods on `WebApplicationBuilder` to add configure the Passwordless client to your Blazor WebAssembly application:

```csharp
public static void AddPasswordlessClient(this IServiceCollection services, Action<PasswordlessOptions> configureOptions);

public static void AddPasswordlessClient(this IServiceCollection services, IConfiguration configuration);

public static void AddPasswordlessClient(this IServiceCollection services, string section);
```

### Registration

### Logging in

## References

- [Get Started - Passwordless.dev](https://docs.passwordless.dev/guide/get-started.html)
- [Integration with your backend - Passwordless.dev](https://docs.passwordless.dev/guide/backend)
