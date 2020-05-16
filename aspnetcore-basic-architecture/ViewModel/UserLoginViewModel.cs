using System.ComponentModel.DataAnnotations;

namespace AspnetCoreBasicArchitecture.ViewModel
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
