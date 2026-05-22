using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    internal class LogEntry
    {
        public DateTime TimeStamp { get; set; }

        public LogLevel LogLevel { get; set; }

        public string Message  { get; set; }

        public Exception Exception { get; set; }

        public override string ToString()
        {
            //Generamos formato del mensaje de log, por ejemplo: [2024-06-01 14:30:00] [Error] Ocurrió un error al procesar la solicitud. Detalles: System.NullReferenceException: Object reference not set to an instance of an object.
            StringBuilder sb = new StringBuilder();
            sb.Append($"[{TimeStamp:yyyy-MM-dd HH:mm:ss}] ");
            sb.Append($"[{LogLevel}] ");
            sb.Append($"{Message}");

            if (Exception != null)
            {
                sb.Append($" Detalles: {Exception.Message}");
                sb.Append($" StackTrace: {Exception.StackTrace}");
            }

            return sb.ToString();
        }
    }
}
