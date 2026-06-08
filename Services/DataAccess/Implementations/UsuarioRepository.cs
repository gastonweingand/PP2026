using Services.Dal.Implementations.Adapters;
using Services.DataAccess;
using Services.DataAccess.Interfaces;
using Services.DataAccess.Tools;
using Services.DomainModel.Composite;
using Services.Exceptions.DataAccess;
using Services.Logic.Infrastructure.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Dal.Implementations
{
    internal class UsuarioRepository : IUsuarioRepository
    {

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

        public void Add(Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();
                string commandText = "INSERT INTO Usuario (IdUsuario, Nombre, Password, Email, Habilitado) VALUES (@IdUsuario, @Nombre, @Password, @Email, @Habilitado)";
                SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, new SqlParameter("@IdUsuario", usuario.IdUsuario),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Password", usuario.Password),
                    new SqlParameter("@Email", usuario.Email),
                    new SqlParameter("@Habilitado", usuario.Habilitado)
                );
            }
            catch (SqlException sqlEx)
            {
                var context = new ExceptionContext
                {
                    Exception = sqlEx,
                    MethodName = nameof(Add),
                    ClassName = nameof(UsuarioRepository),
                    LogLevel = DomainModel.LogLevel.Error,
                    Arguments = new object[] { usuario }
                };
                ExceptionLogger.Log(context);

                throw new DataAccessException(
                    "No se pudo acceder a la base de datos. Por favor intente más tarde.",
                    sqlEx,
                    "DB_UNAVAILABLE"
                );
            }
            catch (Exception ex)
            {
                var context = new ExceptionContext
                {
                    Exception = ex,
                    MethodName = nameof(Add),
                    ClassName = nameof(UsuarioRepository),
                    LogLevel = DomainModel.LogLevel.Error,
                    Arguments = new object[] { usuario }
                };
                ExceptionLogger.Log(context);

                throw new DataAccessException(
                    "Error al guardar los datos.",
                    ex,
                    "DB_ERROR"
                );
            }
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
