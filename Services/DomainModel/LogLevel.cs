using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    internal enum LogLevel
    {
        //Trace, Con motivos de paso a paso para ciertas circunstancias, no se utiliza en este proyecto
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
