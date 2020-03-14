namespace ControlSystem.Contracts.Requests
{
    public class IndicatorRequest
    {
        public string IndicatorName { get; set; }

        public int MaxValue { get; set; }

        public int MinValue { get; set; }
    }
}
