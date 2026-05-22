using Services.Dal.Implementations;
using Services.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using System;

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
                throw new Exception("Usuario o contraseña incorrectos.");
            }
            else if (!usuario.Habilitado)
            {
                throw new Exception("Usuario no habilitado.");
            }

            return usuario;
        }

        public static void RegistrarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            _usuarioRepository.Add(usuario);

            if (usuario.IdUsuario == Guid.Empty)
                throw new Exception("El usuario no pudo ser registrado.");
        }

        public static void AgregarFamilia(Familia familia, Usuario usuario)
        {
            new UsuarioFamiliaRepository().Add(familia, usuario);
        }

        public static void AgregarPatente(Patente patente, Usuario usuario)
        {
            new UsuarioPatenteRepository().Add(patente, usuario);
        }
    }
}
