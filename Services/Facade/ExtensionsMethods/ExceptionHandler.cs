using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.ExtensionsMethods
{
    public static class ExceptionHandler
    {
        public static void Handle(this Exception ex)
        {
            // Implement your exception handling logic here

            //Desde acá vamos a llamar al manager de excepciones, que se encargará de aplicar la política de excepciones correspondiente
            ExceptionManager.HandleException(ex);
        }
    }
}
