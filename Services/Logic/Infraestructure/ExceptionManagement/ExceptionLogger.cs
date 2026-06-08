using Services.DataAccess.Implementations;
using Services.DomainModel;

namespace Services.Logic.Infrastructure.ExceptionManagement
{
    public static class ExceptionLogger
    {
        private static FileLoggerRepository _fileLogger;

        public static void Initialize(string filePath = "Logs/exceptions.log", string minimalLogLevel = "Info")
        {
            _fileLogger = new FileLoggerRepository(filePath, minimalLogLevel);
        }

        public static void Log(ExceptionContext context)
        {
            if (_fileLogger == null)
            {
                Initialize();
            }

            var entry = new LogEntry
            {
                TimeStamp = context.Timestamp,
                LogLevel = context.LogLevel,
                Message = context.Exception.Message,
                Exception = context.Exception,
                MethodName = context.MethodName,
                ClassName = context.ClassName,
                Arguments = context.Arguments
            };

            _fileLogger.WriteLog(entry);
        }

        public static void Log(string message, LogLevel level)
        {
            if (_fileLogger == null)
            {
                Initialize();
            }

            var entry = new LogEntry
            {
                TimeStamp = System.DateTime.Now,
                LogLevel = level,
                Message = message
            };

            _fileLogger.WriteLog(entry);
        }
    }
}

