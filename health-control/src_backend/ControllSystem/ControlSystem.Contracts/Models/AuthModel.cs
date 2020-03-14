using System.ComponentModel.DataAnnotations;

namespace ControlSystem.Contracts
{
    public class AuthModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
