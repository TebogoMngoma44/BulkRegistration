using System.ComponentModel.DataAnnotations;

namespace Speccon.Learnership.FrontEnd.Models.Account
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string message { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public List<string> roles { get; set; } = new List<string>();
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
