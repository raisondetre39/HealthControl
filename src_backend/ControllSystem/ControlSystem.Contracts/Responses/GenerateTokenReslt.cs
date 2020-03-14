using ControlSystem.Contracts.Enums;

namespace ControlSystem.Contracts.Responses
{
    public class GenerateTokenResult
    {
        public AuthenticationStatus Status { get; set; }

        public string Token { get; set; }

        public int Role { get; set; }
    }
}
