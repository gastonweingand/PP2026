using Services.DataAccess.Interfaces;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Implementations
{
    internal class FileLoggerRepository
    {
        private string _fileName;
        private LogLevel _minimalLogLevel;

        public FileLoggerRepository(string fileName, string minimalLogLevel = "Info")
        {
            _fileName = fileName;
            _minimalLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), minimalLogLevel);
            EnsureDirectoryExists();
        }

        public void WriteLog(LogEntry entry)
        {
            try
            {
                if (entry.LogLevel < _minimalLogLevel)
                {
                    return;
                }

                lock (_fileName)
                {
                    File.AppendAllText(_fileName, entry.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
                throw ex;
            }
        }

        public void WriteLog(string message, LogLevel logLevel, Exception exception = null)
        {
            var entry = new LogEntry
            {
                TimeStamp = DateTime.Now,
                LogLevel = logLevel,
                Message = message,
                Exception = exception
            };

            WriteLog(entry);
        }

        private void EnsureDirectoryExists()
        {
            var directory = Path.GetDirectoryName(_fileName);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
