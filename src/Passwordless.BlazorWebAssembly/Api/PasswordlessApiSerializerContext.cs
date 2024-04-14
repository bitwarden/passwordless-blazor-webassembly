
using System.Text.Json.Serialization;
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly.Api;

[JsonSerializable(typeof(RegisterBeginRequest))]
[JsonSerializable(typeof(RegisterBeginResponse))]
[JsonSerializable(typeof(RegisterCompleteRequest))]
[JsonSerializable(typeof(RegisterCompleteResponse))]
[JsonSerializable(typeof(LoginBeginRequest))]
[JsonSerializable(typeof(LoginBeginResponse))]
[JsonSerializable(typeof(LoginCompleteRequest))]
[JsonSerializable(typeof(LoginCompleteResponse))]
[JsonSerializable(typeof(ProblemDetails))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
public partial class PasswordlessApiSerializerContext : JsonSerializerContext;
