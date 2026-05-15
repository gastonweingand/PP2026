using Services.Dal.Implementations;
using Services.DataAccess;
using Services.DataAccess.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal static class UsuarioLogic
    {
        private static IUsuarioRepository _usuarioRepository;

        static UsuarioLogic()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public static Usuario ValidarCredenciales(string user, string password)
        {
            //password = CryptographyService.HashMd5(password);

            Usuario usuario = _usuarioRepository.GetByCredentials(user, password);

            if (usuario == null)
            {
                //Escribir nuestra regla de negocio como exception
                //Generar excepciones custom
                throw new Exception("Usuario o contraseña incorrectos.");
            }
            else if (!usuario.Habilitado)
            {
                //Escribir nuestra regla de negocio como exception
                //Generar excepciones custom
                throw new Exception("Usuario no habilitado.");
            }

            return usuario;
        }

        public static void RegistrarUsuario(Usuario usuario)
        {
            //Hacer validaciones previas antes de registrar el usuario
            if (usuario == null)
            {
                //Escribir nuestra regla de negocio como exception
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            }

            _usuarioRepository.Add(usuario);

            if(usuario.IdUsuario == Guid.Empty)
            {
                //Escribir nuestra regla de negocio como exception
                throw new Exception("El usuario no pudo ser registrado.");
            }    
        }
    }
}
