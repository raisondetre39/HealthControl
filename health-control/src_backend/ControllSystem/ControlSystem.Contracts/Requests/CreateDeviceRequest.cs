using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlSystem.Contracts.Requests
{
    public class CreateDeviceRequest
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Device name can't contain more than 10 symbols")]
        [MinLength(5, ErrorMessage = "Device name can't contain less than 5 symbols")]
        public string DeviceName { get; set; }

        [Required]
        public int UserId { get; set; }

        public IEnumerable<int> IndicatorIds { get; set; }
    }
}
