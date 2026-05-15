
using Services.DataAccess.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations.Adapters
{
    internal class UsuarioAdapter : IAdapter<Usuario>
    {
        #region Singleton
        private readonly static UsuarioAdapter _instance = new UsuarioAdapter();

        public static UsuarioAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private UsuarioAdapter()
        {
        }

        #endregion

        public Usuario Get(object[] values)
        {
            Usuario usuario = new Usuario
            (
                Guid.Parse(values[0].ToString()),
                values[1].ToString(),
                values[2].ToString(),
                values[3].ToString(),
                Convert.ToBoolean(values[4].ToString())
            );

            usuario.Privilegios = new List<Component>();
            usuario.Privilegios.AddRange(new UsuarioFamiliaRepository().GetByObject(usuario));
            usuario.Privilegios.AddRange(new UsuarioPatenteRepository().GetByObject(usuario));

            return usuario;
        }
    }
}
