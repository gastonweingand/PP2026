using Services.DomainModel.Composite;
using Services.DataAccess.Interfaces;
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
            Patente patente = new Patente();
            patente.Id = Guid.Parse(values[0].ToString());
            patente.DataKey = values[1].ToString();
            patente.TipoAcceso = (TipoAcceso)Enum.Parse(typeof(TipoAcceso), values[2].ToString());
            return patente;
        }
    }
}
