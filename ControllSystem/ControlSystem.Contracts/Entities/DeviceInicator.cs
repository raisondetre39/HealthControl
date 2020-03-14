using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("DeviceIndicators")]
    public class DeviceInicator : BaseEntity
    {
        [JsonIgnore]
        public Device Device { get; set; }

        [Column("device_id")]
        public int DeviceId { get; set; }

        [JsonIgnore]
        public Indicator Indicator { get; set; }

        [Column("indicator_id")]
        public int IndicatorId { get; set; }

        public virtual IEnumerable<IndicatorValue> IndicatorValues { get; set; } = new List<IndicatorValue>();
    }
}
