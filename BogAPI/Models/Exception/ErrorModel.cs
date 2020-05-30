using Microsoft.AspNetCore.Http;

namespace BogAPI.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public string Exception { get; set; } = "";
        public int ErrorCode { get; set; } = StatusCodes.Status400BadRequest;
    }
}
