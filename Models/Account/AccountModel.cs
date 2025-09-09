using System.ComponentModel.DataAnnotations;

namespace Speccon.Learnership.FrontEnd.Models.Account
{
    public class PreUserEmailDto
    {
        public string Email { get; set; } = string.Empty;
    }

    public class PasswordModel
    {
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare(nameof(Password))]
        public string Password2 { get; set; } = string.Empty;
    }
}
