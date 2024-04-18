
using Microsoft.Extensions.Options;
using Passwordless.BlazorWebAssembly.Abstractions;
using Passwordless.BlazorWebAssembly.Api;
using Passwordless.BlazorWebAssembly.Configuration;
using Passwordless.BlazorWebAssembly.Contracts;

namespace Passwordless.BlazorWebAssembly;

public sealed class PasswordlessClient : IPasswordlessClient
{
    private readonly IWebAuthn _webAuthn;
    private readonly IPasswordlessApiClient _api;
    private readonly IOptionsSnapshot<PasswordlessOptions> _options;

    public PasswordlessClient(
        IWebAuthn webAuthn,
        IPasswordlessApiClient api,
        IOptionsSnapshot<PasswordlessOptions> options)
    {
        _webAuthn = webAuthn;
        _api = api;
        _options = options;
    }

    public async Task<bool> IsSupportedAsync()
    {
        return await _webAuthn.IsSupportedAsync();
    }

    public async Task<RegisterCompleteResponse> RegisterAsync(string token, string nickname)
    {
        var beginRequest = new RegisterBeginRequest
        {
            Token = token,
            Origin = _options.Value.Origin,
            RPID = _options.Value.Rpid
        };
        var beginResponse = await _api.RegisterBeginAsync(beginRequest);
        var authenticatorResponse = await _webAuthn.CreateCredentialAsync(beginResponse.Data);
        var completeRequest = new RegisterCompleteRequest
        {
            Session = beginResponse.Session,
            Response = authenticatorResponse,
            Nickname = nickname,
            Origin = _options.Value.Origin,
            RPID = _options.Value.Rpid
        };
        var completeResponse = await _api.RegisterCompleteAsync(completeRequest);
        return completeResponse;
    }

    public async Task<LoginCompleteResponse> LoginAsync(string? alias)
    {
        var beginRequest = new LoginBeginRequest
        {
            Alias = alias,
            Origin = _options.Value.Origin,
            RPID = _options.Value.Rpid
        };
        var beginResponse = await _api.SignInBeginAsync(beginRequest);
        var authenticatorResponse = await _webAuthn.VerifyAsync(beginResponse.Data);
        var completeRequest = new LoginCompleteRequest
        {
            Session = beginResponse.Session,
            Response = authenticatorResponse,
            Origin = _options.Value.Origin,
            RPID = _options.Value.Rpid
        };
        var completeResponse = await _api.SignInCompleteAsync(completeRequest);
        return completeResponse;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
