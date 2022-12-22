using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;
public class UserEditViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }

    [Required(ErrorMessage = "Please Enter Your Password!")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Enter new password!")]
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "Enter new password again!")]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match. Please enter againg!")]
    public string ConfirmNewPassword { get; set; }
    public string Token { get; set; }
}
