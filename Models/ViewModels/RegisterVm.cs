using System.ComponentModel.DataAnnotations;

namespace CookieReaders.Models
{
    public class RegisterVm : LoginVm
    {
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}