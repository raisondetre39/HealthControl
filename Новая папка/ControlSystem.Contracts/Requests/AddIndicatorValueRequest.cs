using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Contracts.Requests
{
    public class AddIndicatorValueRequest
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public bool IsCritical { get; set; }
    }
}
