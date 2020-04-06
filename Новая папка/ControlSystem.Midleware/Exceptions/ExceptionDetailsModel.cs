using Newtonsoft.Json;

namespace ControlSystem.Middleware.Exceptions
{
    public class ExeptionDetailsModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}