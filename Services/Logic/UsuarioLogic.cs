using Composite;
using Services.Dal.Implementations;
using Services.DataAccess;
using Services.DomainModel;

namespace Services.Logic
{
    internal static class UsuarioLogic
    {
        private static readonly IUsuarioRepository _repo = new UsuarioRepository();

        public static void RegistrarUsuario(Usuario usuario)
        {
            _repo.RegistrarUsuario(usuario);
        }

        public static void AgregarFamilia(Familia familia, Usuario usuario)
        {
            new UsuarioFamiliaRepository().Agregar(familia, usuario);
        }

        public static void AgregarPatente(Patente patente, Usuario usuario)
        {
            new UsuarioPatenteRepository().Agregar(patente, usuario);
        }

        public static Usuario GetByCredentials(string user, string password)
        {
            return _repo.GetByCredentials(user, password);
        }
    }
}
