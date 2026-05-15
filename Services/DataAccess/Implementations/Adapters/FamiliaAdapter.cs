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
    internal class FamiliaAdapter : IAdapter<Familia>
    {
        #region Singleton
        private readonly static FamiliaAdapter _instance = new FamiliaAdapter();

        public static FamiliaAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaAdapter()
        {
            //Implent here the initialization of your singleton
        }

        #endregion
        public Familia Get(object[] values)
        {
            Familia familia = new Familia();
            familia.IdFamilia = Guid.Parse(values[0].ToString());
            familia.Nombre = values[1].ToString();

            //Una familia puede tener familias hijas
            familia.AddRange(new FamiliaFamiliaRepository().GetByObject(familia));

            //Una familia puede tener patentes hijas
            familia.AddRange(new FamiliaPatenteRepository().GetByObject(familia));

            return familia;
        }
    }
}
