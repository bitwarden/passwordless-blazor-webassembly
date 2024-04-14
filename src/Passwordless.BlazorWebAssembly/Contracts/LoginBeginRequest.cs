
using System.ComponentModel.DataAnnotations;

namespace Passwordless.BlazorWebAssembly.Contracts;

public class LoginBeginRequest : BaseApiRequest
{
    public string? Alias { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string UserId { get; set; }

    public string? UserVerification { get; set; }
}
