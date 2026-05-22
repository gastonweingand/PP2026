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
        //true es para hacer append, es decir, escribir al final del archivo sin borrar lo que ya hay
        private StreamWriter streamWriter;
        
        private string _fileName;

        private LogLevel _minimalLogLevel;
        public FileLoggerRepository(string fileName, string minimalLogLevel)
        {
            _fileName = fileName;
            _minimalLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), minimalLogLevel);
            streamWriter = new StreamWriter(_fileName, true);
        }
        public void WriteLog(string message, LogLevel logLevel, Exception exception = null)
        {
            //Si el nivel de log es menor que el mínimo configurado, no se registra el mensaje
            try
            {
                if (logLevel < _minimalLogLevel)
                {
                    return;
                }

                //Si estoy acá, es porque la configuración permite a partir del minimalLogLevel registrar el mensaje, entonces creo una nueva entrada de log con la información correspondiente
                LogEntry entry = new LogEntry();
                entry.TimeStamp = DateTime.Now;
                entry.LogLevel = logLevel;
                entry.Message = message;
                entry.Exception = exception;

                streamWriter.WriteLine(entry);
                streamWriter.Flush();
            }
            catch (Exception ex)
            {
                //Escribir en el event viewer
                //Si ocurre un error al escribir en el archivo, se muestra un mensaje de error en la consola
                Console.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
                throw ex;
            }
        }

        //Pensar Métodos para la lectura

    }
}
