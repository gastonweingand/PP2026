using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class LogEntry
    {
        public DateTime TimeStamp { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public object[] Arguments { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{TimeStamp:yyyy-MM-dd HH:mm:ss}] [{LogLevel}]");

            if (!string.IsNullOrEmpty(ClassName) && !string.IsNullOrEmpty(MethodName))
            {
                sb.AppendLine($"Method: {ClassName}.{MethodName}");
            }

            sb.AppendLine($"Message: {Message}");

            if (Exception != null)
            {
                sb.AppendLine($"Exception Type: {Exception.GetType().Name}");
                sb.AppendLine($"Exception Message: {Exception.Message}");

                if (Arguments != null && Arguments.Length > 0)
                {
                    sb.AppendLine("Arguments:");
                    for (int i = 0; i < Arguments.Length; i++)
                    {
                        sb.AppendLine($"  [{i}]: {Arguments[i] ?? "null"}");
                    }
                }

                if (Exception.InnerException != null)
                {
                    sb.AppendLine($"InnerException: {Exception.InnerException.Message}");
                    sb.AppendLine($"InnerException StackTrace: {Exception.InnerException.StackTrace}");
                }

                sb.AppendLine($"StackTrace: {Exception.StackTrace}");
            }

            sb.AppendLine(new string('-', 80));

            return sb.ToString();
        }
    }
}
