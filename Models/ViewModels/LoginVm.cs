using System.ComponentModel.DataAnnotations;

namespace CookieReaders.Models
{
    public class LoginVm
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}