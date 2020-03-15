using ControlSystem.Contracts.Entities;
using System.Collections.Generic;

namespace ControlSystem.Contracts.Responses
{
    public class GetIndicatorsResult
    {
        public IEnumerable<Indicator> Indicators { get; set; }

        public int Count { get; set; }
    }
}
