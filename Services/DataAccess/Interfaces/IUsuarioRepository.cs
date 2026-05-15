using Services.DomainModel;

namespace Services.DataAccess
{
    internal interface IUsuarioRepository
    {
        void RegistrarUsuario(Usuario usuario);

        //Un camino es en el acceso es comparar los hash en
        //el where del sql server
        Usuario GetByCredentials(string user, string password);

        //Camino 2: Traer el usuario por nombre y luego comparar el
        ////hash en la capa de servicio
    }
}