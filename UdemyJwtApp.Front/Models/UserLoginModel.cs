using System.ComponentModel.DataAnnotations;

namespace UdemyJwtApp.Front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Username Gereklidir")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Password Gereklidir")]
        public string Password { get; set; } = null!;
    }
}
