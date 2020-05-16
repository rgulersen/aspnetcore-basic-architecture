using System.ComponentModel.DataAnnotations;

namespace AspnetCoreBasicArchitecture.ViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30,MinimumLength =8)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
