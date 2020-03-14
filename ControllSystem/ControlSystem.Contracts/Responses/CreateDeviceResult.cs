using ControlSystem.Contracts.Enums;
using Newtonsoft.Json;

namespace ControlSystem.Contracts.Responses
{
    public class CreateDeviceResult
    {
        public int DeviceId { get; set; }

        [JsonIgnore]
        public CreateDeviceStatus Status { get; set; }
    }
}
