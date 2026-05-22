using Services.DataAccess.Implementations;
using Services.DomainModel;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class LoggerService
    {
        //FileLogger debería llamarse LoggerLogic y desde allí llamar a la factory
        private static readonly FileLogger fileLogger = new FileLogger();

        public static void Debug(string message)
        {
            fileLogger.Debug(message);
        }

        public static void Debug(string message, Exception exception)
        {
            fileLogger.Debug(message, exception);
        }

        public static void Error(string message)
        {
            fileLogger.Error(message);
        }

        public static void Error(string message, Exception exception)
        {
            fileLogger.Error(message, exception);
        }

        public static void Fatal(string message)
        {
            fileLogger.Fatal(message);
        }

        public static void Fatal(string message, Exception exception)
        {
            fileLogger.Fatal(message, exception);
        }

        public static void Info(string message)
        {
            fileLogger.Info(message);
        }

        public static void Info(string message, Exception exception)
        {
            fileLogger.Info(message, exception);
        }

        public static void Warn(string message)
        {
            fileLogger.Warn(message);
        }

        public static void Warn(string message, Exception exception)
        {
            fileLogger.Warn(message, exception);
        }
    }
}
