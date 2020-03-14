using System.ComponentModel.DataAnnotations;

namespace ControlSystem.Contracts.Models
{
    public class CreateUserRequest
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Password can't contain more than 10 symbols")]
        [MinLength(5, ErrorMessage = "Password can't contain less than 5 symbols")]
        public string Password { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "First name can't contain more than 10 symbols")]
        [MinLength(2, ErrorMessage = "First name can't contain less than 2 symbols")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Last name can't contain more than 10 symbols")]
        [MinLength(5, ErrorMessage = "Last name can't contain less than 2 symbols")]
        public string LastName { get; set; }

        [Required]
        public int DiseaseId { get; set; }
    }
}
