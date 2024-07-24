
namespace Passwordless.BlazorWebAssembly.Example.Services.DemoBackend.Contracts;

public sealed record RegisterRequest(string Username, string? Alias, string FirstName, string LastName);
