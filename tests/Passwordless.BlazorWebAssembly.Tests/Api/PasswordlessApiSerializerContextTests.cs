using System.Text.Json;
using Fido2NetLib;
using Fido2NetLib.Objects;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Tests.DataFactory;

namespace Passwordless.BlazorWebAssembly.Tests.Api;

public sealed class PasswordlessApiSerializerContextTests
{
    [Fact]
    public void Deserialize_RegisterBeginRequest_Returns_ExpectedResult()
    {
        // Arrange

        // Act
        var actual = JsonSerializer.Deserialize(Data.ValidRegisterBeginRequest, PasswordlessApiSerializerContext.Default.RegisterBeginRequest);

        // Assert
        Assert.Equal("https://admin.passwordless.dev", actual.Origin);
        Assert.Equal("admin.passwordless.dev", actual.RPID);
        Assert.Equal("register_k8Qgxpd7MmnIZU1snSEiM923jwthaQuldE44VRtPVTprJ3bEotwAE9f_u_5-0GYbhTbZJDAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMMDAwMDAwMDA2SQ5MjI0YzJhMS1kMzc0LTQ1ZDEtYjQ0Yi0yZDYzM2FhZjFiOGOvQWVnb24gVGFyZ2FyeWVutFBsYXlncm91bmQ6IGpvaG5zbm93pG5vbmXAw6lQcmVmZXJyZWSRqGpvaG5zbm93ws4PKdKS", actual.Token);
    }

    [Fact]
    public void Deserialize_RegisterBeginResponse_Returns_ExpectedResult()
    {
        // Arrange

        // Act
        var actual = JsonSerializer.Deserialize(Data.ValidRegisterBeginResponse, PasswordlessApiSerializerContext.Default.RegisterBeginResponse);

        // Assert
        Assert.NotNull(actual.Data);
        Assert.Equal("session_k8Qgyw8V1j25eqjAu-2zgdJUl5kFgnsOc4fcHni-7g1VfnvFAsaDp09wdGlvbnOLplN0YXR1c6Jva6xFcnJvck1lc3NhZ2WgolJwg6JJZLZhZG1pbi5wYXNzd29yZGxlc3MuZGV2pE5hbWW2YWRtaW4ucGFzc3dvcmRsZXNzLmRldqRJY29uwKRVc2Vyg6ROYW1ltFBsYXlncm91bmQ6IGpvaG5zbm93oklkxCQ5MjI0YzJhMS1kMzc0LTQ1ZDEtYjQ0Yi0yZDYzM2FhZjFiOGOrRGlzcGxheU5hbWWvQWVnb24gVGFyZ2FyeWVuqUNoYWxsZW5nZcQQjKQa7jMCiSis397AesiWe7BQdWJLZXlDcmVkUGFyYW1zmoKkVHlwZQCjQWxn-IKkVHlwZQCjQWxn-YKkVHlwZQCjQWxn0f7_gqRUeXBlAKNBbGfQ24KkVHlwZQCjQWxn0N2CpFR5cGUAo0FsZ9H-_oKkVHlwZQCjQWxn0NqCpFR5cGUAo0FsZ9DcgqRUeXBlAKNBbGfR_v2CpFR5cGUAo0FsZ9DZp1RpbWVvdXTN6mCrQXR0ZXN0YXRpb24AtkF1dGhlbnRpY2F0b3JTZWxlY3Rpb26Et0F1dGhlbnRpY2F0b3JBdHRhY2htZW50wKtSZXNpZGVudEtleQCyUmVxdWlyZVJlc2lkZW50S2V5w7BVc2VyVmVyaWZpY2F0aW9uAbJFeGNsdWRlQ3JlZGVudGlhbHOQqkV4dGVuc2lvbnOJp0V4YW1wbGXApUFwcElEwKpFeHRlbnNpb25zwLZVc2VyVmVyaWZpY2F0aW9uTWV0aG9kwKxEZXZpY2VQdWJLZXnAqUNyZWRQcm9wc8OjUFJGwLpDcmVkZW50aWFsUHJvdGVjdGlvblBvbGljecDZIUVuZm9yY2VDcmVkZW50aWFsUHJvdGVjdGlvblBvbGljecCnQWxpYXNlc5Goam9obnNub3esQWxpYXNIYXNoaW5nws4PKdKS", actual.Session);
    }

    [Fact]
    public void Deserialize_RegisterCompleteRequest_Returns_ExpectedResult()
    {
        // Arrange

        // Act
        var actual = JsonSerializer.Deserialize(Data.ValidRegisterCompleteRequest, PasswordlessApiSerializerContext.Default.RegisterCompleteRequest);

        // Assert
        Assert.Equal("https://admin.passwordless.dev", actual.Origin);
        Assert.Equal("admin.passwordless.dev", actual.RPID);
        Assert.Equal("Winterfell", actual.Nickname);
        Assert.Equal("session_k8Qgyw8V1j25eqjAu-2zgdJUl5kFgnsOc4fcHni-7g1VfnvFAsaDp09wdGlvbnOLplN0YXR1c6Jva6xFcnJvck1lc3NhZ2WgolJwg6JJZLZhZG1pbi5wYXNzd29yZGxlc3MuZGV2pE5hbWW2YWRtaW4ucGFzc3dvcmRsZXNzLmRldqRJY29uwKRVc2Vyg6ROYW1ltFBsYXlncm91bmQ6IGpvaG5zbm93oklkxCQ5MjI0YzJhMS1kMzc0LTQ1ZDEtYjQ0Yi0yZDYzM2FhZjFiOGOrRGlzcGxheU5hbWWvQWVnb24gVGFyZ2FyeWVuqUNoYWxsZW5nZcQQjKQa7jMCiSis397AesiWe7BQdWJLZXlDcmVkUGFyYW1zmoKkVHlwZQCjQWxn-IKkVHlwZQCjQWxn-YKkVHlwZQCjQWxn0f7_gqRUeXBlAKNBbGfQ24KkVHlwZQCjQWxn0N2CpFR5cGUAo0FsZ9H-_oKkVHlwZQCjQWxn0NqCpFR5cGUAo0FsZ9DcgqRUeXBlAKNBbGfR_v2CpFR5cGUAo0FsZ9DZp1RpbWVvdXTN6mCrQXR0ZXN0YXRpb24AtkF1dGhlbnRpY2F0b3JTZWxlY3Rpb26Et0F1dGhlbnRpY2F0b3JBdHRhY2htZW50wKtSZXNpZGVudEtleQCyUmVxdWlyZVJlc2lkZW50S2V5w7BVc2VyVmVyaWZpY2F0aW9uAbJFeGNsdWRlQ3JlZGVudGlhbHOQqkV4dGVuc2lvbnOJp0V4YW1wbGXApUFwcElEwKpFeHRlbnNpb25zwLZVc2VyVmVyaWZpY2F0aW9uTWV0aG9kwKxEZXZpY2VQdWJLZXnAqUNyZWRQcm9wc8OjUFJGwLpDcmVkZW50aWFsUHJvdGVjdGlvblBvbGljecDZIUVuZm9yY2VDcmVkZW50aWFsUHJvdGVjdGlvblBvbGljecCnQWxpYXNlc5Goam9obnNub3esQWxpYXNIYXNoaW5nws4PKdKS", actual.Session);

        Assert.Equal(Base64Url.Decode("AltqnKLVfJmwvisFNfDMyah4Af5AsI99kRFbYaTPQVc"), actual.Response.Id);
        Assert.Equal(Base64Url.Decode("AltqnKLVfJmwvisFNfDMyah4Af5AsI99kRFbYaTPQVc"), actual.Response.RawId);
        Assert.Equal(PublicKeyCredentialType.PublicKey, actual.Response.Type);

        Assert.True(actual.Response.Extensions.CredProps.Rk);

        Assert.Equal(Base64Url.Decode("o2NmbXRkbm9uZWdhdHRTdG10oGhhdXRoRGF0YVik8egiesVpgMwlnLcY0N3ldtvrzKGUPb763GkSYC4CzTlFAAAAAHcbSP3T1E90kjL8FXqwUHoAIAJbapyi1XyZsL4rBTXwzMmoeAH-QLCPfZERW2Gkz0FXpQECAyYgASFYIK1vYF4G076YgpwpV0-uxM34PQWN9P40i7Dh0-lxtc85IlggeReXcNqqZPBvBvmSxGjXBIbjvQwQGbIatx34XLfQAdM"), actual.Response.Response.AttestationObject);
        Assert.Equal(Base64Url.Decode("eyJ0eXBlIjoid2ViYXV0aG4uY3JlYXRlIiwiY2hhbGxlbmdlIjoiaktRYTdqTUNpU2lzMzk3QWVzaVdldyIsIm9yaWdpbiI6Imh0dHBzOi8vYWRtaW4ucGFzc3dvcmRsZXNzLmRldiIsImNyb3NzT3JpZ2luIjpmYWxzZX0"), actual.Response.Response.ClientDataJson);
    }

    [Fact]
    public void Deserialize_RegisterCompleteResponse_Returns_ExpectedResult()
    {
        // Arrange

        // Act
        var actual = JsonSerializer.Deserialize(Data.ValidRegisterCompleteResponse, PasswordlessApiSerializerContext.Default.RegisterCompleteResponse);

        // Assert
        Assert.Equal("verify_123", actual.Token);
    }
}
