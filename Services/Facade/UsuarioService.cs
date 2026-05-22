using Services.DomainModel.Composite;

namespace Services.Facade
{
    public static class UsuarioService
    {
        public static void AgregarFamilia(Familia familia, Usuario usuario)
        {
            Logic.UsuarioLogic.AgregarFamilia(familia, usuario);
        }

        public static void AgregarPatente(Patente patente, Usuario usuario)
        {
            Logic.UsuarioLogic.AgregarPatente(patente, usuario);
        }
    }
}
