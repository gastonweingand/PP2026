using System;
using Services.DomainModel;

namespace Services.Logic.Infrastructure.ExceptionManagement
{
    public class ExceptionContext
    {
        public Exception Exception { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public object[] Arguments { get; set; }
        public DateTime Timestamp { get; set; }
        public LogLevel LogLevel { get; set; }

        public ExceptionContext()
        {
            Timestamp = DateTime.Now;
            Arguments = System.Array.Empty<object>();
        }
    }
}

