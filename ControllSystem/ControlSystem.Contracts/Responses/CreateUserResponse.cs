using ControlSystem.Contracts.Enums;
using Newtonsoft.Json;

namespace ControlSystem.Contracts.Responses
{
    public class CreateUserResponse
    {
        [JsonIgnore]
        public CreateUserStatus Status { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public string Token { get; set; }
    }
}
