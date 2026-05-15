using Composite;
using Services.DataAccess.Interfaces;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations.Adapters
{
    internal class PatenteAdapter : IAdapter<Patente>
    {
        #region Singleton
        private readonly static PatenteAdapter _instance = new PatenteAdapter();

        public static PatenteAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteAdapter()
        {
            //Implent here the initialization of your singleton
        }

        #endregion
        public Patente Get(object[] values)
        {
            //Hidratación de nivel 1, simplemente hidratamos primitivos, no objetos relacionados
            Patente patente = new Patente();
            patente.IdPatente = Guid.Parse(values[0].ToString());
            patente.Nombre = values[1].ToString();
            patente.Descripcion = values[2].ToString();
            return patente;
        }
    }
}
