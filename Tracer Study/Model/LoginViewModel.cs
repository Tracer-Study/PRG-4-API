using System.ComponentModel.DataAnnotations;

namespace PRG_4_API.Models
{
    public class LoginViewModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
