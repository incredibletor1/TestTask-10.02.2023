

namespace TestTask_10._02._2023.Middlewares.Exceptions
{
    using System.Text.Json;

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
