using ControlSystem.Contracts.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Contracts.Responses
{
    public class GetUsersResult
    {
        public IEnumerable<User> Users { get; set; }

        [JsonIgnore]
        public int Count { get; set; }
    }
}
