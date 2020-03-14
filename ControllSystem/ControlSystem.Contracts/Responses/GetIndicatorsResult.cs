using ControlSystem.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Contracts.Responses
{
    public class GetIndicatorsResult
    {
        public IEnumerable<Indicator> Indicators { get; set; }

        public int Count { get; set; }
    }
}
