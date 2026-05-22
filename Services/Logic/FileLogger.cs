using Services.DataAccess.Implementations;
using Services.DataAccess.Interfaces;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal class FileLogger : ILogger
    {
        //Configuración para la creación y escritura
        private FileLoggerRepository fileLoggerRepository;
        public FileLogger()
        {
            string _fileName = ConfigurationManager.AppSettings["FileName"];
            string minimalLogLevelString = ConfigurationManager.AppSettings["MinimalLogLevel"].ToString();
            LogLevel _minimalLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), minimalLogLevelString);
            //Se puede implementar una factory para crear el FileLoggerRepository, pero como es un proyecto pequeño, lo creo directamente acá
            fileLoggerRepository = new FileLoggerRepository(_fileName, _minimalLogLevel.ToString());
        }

        public void Debug(string message)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Debug);
        }

        public void Debug(string message, Exception exception)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Debug, exception);
        }

        public void Error(string message)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Error);
        }

        public void Error(string message, Exception exception)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Error, exception);
        }

        public void Fatal(string message)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Fatal);
        }

        public void Fatal(string message, Exception exception)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Fatal, exception);
        }

        public void Info(string message)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Info);
        }

        public void Info(string message, Exception exception)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Info, exception);
        }

        public void Warn(string message)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Warn);
        }

        public void Warn(string message, Exception exception)
        {
            fileLoggerRepository.WriteLog(message, LogLevel.Warn, exception);
        }
    }
}
