using Services.Dal.Implementations.Adapters;
using Services.DataAccess;
using Services.DataAccess.Tools;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public void RegistrarUsuario(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid(); // Generar un nuevo Id para el usuario
            string commandText = "INSERT INTO Usuario (IdUsuario, Nombre, Password, Email, Habilitado) VALUES (@IdUsuario, @Nombre, @Password, @Email, @Habilitado)";
            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Password", usuario.Password),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Habilitado", usuario.Habilitado)
            );
        }

        public Usuario GetByCredentials(string user, string password)
        {
            
            string commandText = "SELECT * FROM Usuario WHERE Nombre = @Nombre AND Password = @Password";

            using(SqlDataReader dataReader = SqlHelper.ExecuteReader(commandText, CommandType.Text,
                new SqlParameter("@Nombre", user),
                new SqlParameter("@Password", password)))
            {
                if (dataReader.Read())
                {
                    object[] data = new object[dataReader.FieldCount];
                    dataReader.GetValues(data);

                    return UsuarioAdapter.Current.Get(data);
                }
                return null;
            }
        }
    }
}
