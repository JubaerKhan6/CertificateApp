using System.ComponentModel.DataAnnotations;

namespace LoginService.Models.AuthModels
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is Required!")]
        public string? username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required!")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        public string? password { get; set; }
    }
}
