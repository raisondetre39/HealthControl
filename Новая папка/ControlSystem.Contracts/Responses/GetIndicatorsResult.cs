using ControlSystem.Contracts.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControlSystem.Contracts.Responses
{
    public class GetIndicatorsResult
    {
        public IEnumerable<Indicator> Indicators { get; set; }

        [JsonIgnore]
        public int Count { get; set; }
    }
}
