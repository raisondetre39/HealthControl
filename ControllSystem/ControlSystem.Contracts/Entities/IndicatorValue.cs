using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("IndicatorValues")]
    public class IndicatorValue : BaseEntity
    {
        [JsonIgnore]
        public DeviceInicator DeviceInicator { get; set; }

        [Column("device_indicator_id")]
        public int DeviceIndicatorId { get; set; }

        [Column("value")]
        public int Value { get; set; }

        [Column("date_created")]
        public DateTime Date { get; set; }
    }
}
