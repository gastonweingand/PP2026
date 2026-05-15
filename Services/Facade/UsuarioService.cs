using Composite;
using Services.DomainModel;

namespace Services.Facade
{
    public static class UsuarioService
    {
        public static void RegistrarUsuario(Usuario usuario)
        {
            Logic.UsuarioLogic.RegistrarUsuario(usuario);
        }

        public static void AgregarFamilia(Familia familia, Usuario usuario)
        {
            Logic.UsuarioLogic.AgregarFamilia(familia, usuario);
        }

        public static void AgregarPatente(Patente patente, Usuario usuario)
        {
            Logic.UsuarioLogic.AgregarPatente(patente, usuario);
        }

        public static Usuario GetByCredentials(string user, string password)
        {
            return Logic.UsuarioLogic.GetByCredentials(user, password);
        }
    }
}
