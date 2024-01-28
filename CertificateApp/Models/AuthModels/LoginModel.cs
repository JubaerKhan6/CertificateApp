using System.ComponentModel.DataAnnotations;

namespace CertificateApp.Models.AuthModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is Required!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        public string? Password { get; set; }
        public string? Message { get; set; } = "";
    }
}
