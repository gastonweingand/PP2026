
using Composite;
using Services.DataAccess.Interfaces;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations.Adapters
{
    /// <summary>
    /// 
    /// </summary>
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
            //Implent here the initialization of your singleton
        }

        #endregion
        /// <summary>
        /// Obtener un objeto Usuario a partir de un array de objetos
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Usuario Get(object[] values)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = Guid.Parse(values[0].ToString());
            usuario.Nombre = values[1].ToString();
            usuario.Password = values[2].ToString();
            usuario.Email = values[3].ToString();
            usuario.Habilitado = Convert.ToBoolean(values[4]);

            usuario.Privilegios = new List<Component>();
            usuario.Privilegios.AddRange(new UsuarioFamiliaRepository().GetByObject(usuario));
            usuario.Privilegios.AddRange(new UsuarioPatenteRepository().GetByObject(usuario));

            return usuario;
        }
    }
}
