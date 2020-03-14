using ControlSystem.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Contracts.Responses
{
    public class GetDiseasesResult
    {
        public IEnumerable<Disease> Diseases { get; set; }

        public int Count { get; set; }
    }
}
