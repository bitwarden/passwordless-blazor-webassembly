
using System.ComponentModel.DataAnnotations;

namespace Passwordless.BlazorWebAssembly.Example.ViewModels;

public class RegisterViewModel
{
    [Required(AllowEmptyStrings = false), RegularExpression("^[a-zA-Z0-9]*$"), StringLength(20)]
    public string Username { get; set; }

    [RegularExpression("^[a-zA-Z0-9]*$"), StringLength(20)]
    public string? Alias { get; set; }
}
