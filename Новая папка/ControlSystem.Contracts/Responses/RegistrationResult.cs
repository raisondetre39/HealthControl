using ControlSystem.Contracts.Enums;

namespace ControlSystem.Contracts.Responses
{
    public class RegistrationResult
    {
        public int UserId { get; set; }

        public string Token { get; set; }

        public RegistrationStatus Status { get; set; }
    }
}
