using System.ComponentModel.DataAnnotations;

namespace ControlSystem.Contracts.Models
{
    public class UpdateUserRequest
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
    //    [Range(5, 10, ErrorMessage = "Password should contain from 5 to 10 symbols")]
        public string Password { get; set; }

        [Required]
     //   [Range(2, 10, ErrorMessage = "First name should contain from 2 to 10 symbols")]
        public string FirstName { get; set; }

        [Required]
     //   [Range(2, 10, ErrorMessage = "Last name should contain from 2 to 10 symbols")]
        public string LastName { get; set; }
    }
}
