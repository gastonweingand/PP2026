using Services.DomainModel.Composite;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class LoginService
    {
        public static Usuario ValidarCredenciales(string user, string password)
        {
            return UsuarioLogic.ValidarCredenciales(user, password);
        }

        public static void RegistrarUsuario(Usuario usuario)
        {
            UsuarioLogic.RegistrarUsuario(usuario);
        }
    }
}
