using ControlSystem.Contracts.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControlSystem.Contracts.Responses
{
    public class GetDiseasesResult
    {
        public IEnumerable<Disease> Diseases { get; set; }

        [JsonIgnore]
        public int Count { get; set; }
    }
}
