using ControlSystem.Contracts.Entities;
using System.Collections.Generic;

namespace ControlSystem.Contracts.Responses
{
    public class GetDiseasesResult
    {
        public IEnumerable<Disease> Diseases { get; set; }

        public int Count { get; set; }
    }
}
