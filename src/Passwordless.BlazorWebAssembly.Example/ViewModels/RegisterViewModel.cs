
using System.ComponentModel.DataAnnotations;

namespace Passwordless.BlazorWebAssembly.Example.ViewModels;

public class RegisterViewModel
{
    [StringLength(20)]
    public string Username { get; set; }

    [RegularExpression("^[a-zA-Z0-9]*$"), StringLength(20)]
    public string? Alias { get; set; }
    
    [RegularExpression("^[a-zA-Z0-9]*$"), StringLength(30)]
    public string FirstName { get; set; } = string.Empty;
    
    [RegularExpression("^[a-zA-Z0-9]*$"), StringLength(30)]
    public string LastName { get; set; } = string.Empty;
}
