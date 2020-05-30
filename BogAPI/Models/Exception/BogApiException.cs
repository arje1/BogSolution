using System;

namespace BogAPI.Models
{
    public class BogApiException : Exception
    {
        public ErrorModel ErrorModel { get; set; }
        public Exception Exception { get; set; }
        public BogApiException() { }
        public BogApiException(Exception exception, ErrorModel errorModel)
        {
            Exception = exception;
            ErrorModel = errorModel;
        }
    }
}
