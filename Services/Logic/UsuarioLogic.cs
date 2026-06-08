using Services.Dal.Implementations;
using Services.DataAccess.Interfaces;
using Services.DomainModel;
using Services.DomainModel.Composite;
using Services.Exceptions.DataAccess;
using Services.Logic.Infrastructure.ExceptionManagement;
using System;
using System.Threading;

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
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

                if (usuario.IdUsuario == Guid.Empty)
                    throw new Exception("El usuario no pudo ser registrado.");

                _usuarioRepository.Add(usuario);
            }
            catch (DataAccessException daEx)
            {
                // Si el error viene de DAL, aplico una política...
                // 1) No registramos porque ya lo tuvo que haber registrado la DAL
                // 2) Envoltura y lanzamiento
                var context = new ExceptionContext
                {
                    Exception = daEx,
                    MethodName = nameof(RegistrarUsuario),
                    ClassName = nameof(UsuarioLogic),
                    LogLevel = LogLevel.Error,
                    Arguments = new object[] { usuario }
                };
                //Acá llamamos de nuevo al lloger, como idea para aplicar política...
                ExceptionLogger.Log(context);

                throw new Exception(
                    "No se pudo registrar el usuario. Intente más tarde o contacte al administrador.",
                    daEx
                );
            }
            catch (ArgumentNullException)
            {
                // Cualquiera sea de negocio se propagan. UsuarioExisteException, UsuarioBloqueadoException
                throw;
            }
            catch (Exception ex)
            {
                var context = new ExceptionContext
                {
                    Exception = ex,
                    MethodName = nameof(RegistrarUsuario),
                    ClassName = nameof(UsuarioLogic),
                    LogLevel = LogLevel.Error,
                    Arguments = new object[] { usuario }
                };
                ExceptionLogger.Log(context);

                throw;
            }
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
