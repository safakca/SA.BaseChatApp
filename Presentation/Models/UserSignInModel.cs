using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class UserSignInModel
{
    [Required(ErrorMessage ="Enter Username!")]
    public string UserName { get; set; }

    [Required(ErrorMessage ="Enter Password!")]
    public string Password { get; set; }
}
