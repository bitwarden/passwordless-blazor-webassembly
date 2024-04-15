
using System.ComponentModel.DataAnnotations;

namespace Passwordless.BlazorWebAssembly.Contracts;

public class LoginBeginRequest : BaseApiRequest
{
    /// <summary>
    /// When using non-discoverable credentials, this is the user's alias.
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// The `UserId` is used to link credentials of a user in Passwordless.dev to a user in your backend.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string UserId { get; set; }
}
