using ControlSystem.Contracts.Enums;
using Newtonsoft.Json;

namespace ControlSystem.Contracts.Responses
{
    public class CreateDiseaseResult
    {
        public int DiseaseId { get; set; }

        [JsonIgnore]
        public CreateDiseaseStatus Status { get; set; }
    }
}
