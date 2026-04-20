using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factory
{
    public static class FactoryDataAccess
    {
        public static ICustomerRepository CustomerRepository { get; set; }

        static FactoryDataAccess()
        {
            //Acá viene toda la lógica dinámica que veremos con REFLECTION
            //Para instanciar dinámicamente diferente tipos de implementaciones

            //if configuracion == "SQLSERVER"
            // Retornamos todas las instancias de sql server

            //Versión 1.0
            //Por ahora esto queda hardcode en MEMORIA

            //Versión 2.0
            //Cambiamos nuestra impementación por un singleton a SQL SERVEr
            CustomerRepository = DataAccess.Implementaciones.SqlServer.CustomerRepository.Current;
        }
    }
}
