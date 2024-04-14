
using System.ComponentModel.DataAnnotations;

namespace Passwordless.BlazorWebAssembly.Example.ViewModels;

public class LoginViewModel
{
    [RegularExpression("^[a-zA-Z0-9]*$"), StringLength(20)]
    public string? Alias { get; set; }
}
