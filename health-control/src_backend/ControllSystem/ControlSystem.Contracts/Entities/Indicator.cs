using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("Indicators")]
    public class Indicator : BaseEntity
    {
        [Column("indicator_name")]
        public string IndicatorName { get; set; }

        [Column("max_value")]
        public int MaxValue { get; set; }

        [Column("min_value")]
        public int MinValue { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeviceInicator> Devices { get; set; }
    }
}
