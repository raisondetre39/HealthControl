using System.ComponentModel.DataAnnotations;

namespace ControlSystem.Contracts.Requests
{
    public class UpdateDeviceRequest
    {
        [Required]
     //   [MaxLength(10, ErrorMessage = "Device name can't contain more than 10 symbols")]
     //   [MinLength(5, ErrorMessage = "Device name can't contain less than 5 symbols")]
        public string DeviceName { get; set; }
    }
}
