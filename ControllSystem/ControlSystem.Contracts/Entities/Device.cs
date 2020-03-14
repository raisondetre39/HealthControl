using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("Devices")]
    public class Device : BaseEntity
    {
        [Column("device_name")]
        public string DeviceName { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public virtual ICollection<DeviceInicator> DeviceIndicators { get; set; }
    }
}
