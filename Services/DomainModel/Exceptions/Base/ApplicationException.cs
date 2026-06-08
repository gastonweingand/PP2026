using System;

namespace Services.Exceptions.Base
{
    public abstract class ApplicationException : Exception
    {
        public string Code { get; protected set; }
        public DateTime Timestamp { get; }

        protected ApplicationException(string message, string code = "UNKNOWN_ERROR")
            : base(message)
        {
            Code = code;
            Timestamp = DateTime.Now;
        }

        protected ApplicationException(string message, Exception innerException, string code = "UNKNOWN_ERROR")
            : base(message, innerException)
        {
            Code = code;
            Timestamp = DateTime.Now;
        }
    }
}
