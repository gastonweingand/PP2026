using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Codigo { get; set; } 

        public String Nombre { get; set; }

        public String CUIT { get; set; }

        public DateTime FechaNacimiento { get; set; }

    }
}
