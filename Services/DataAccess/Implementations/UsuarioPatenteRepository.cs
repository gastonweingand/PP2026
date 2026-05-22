
using Services.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using Services.DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Implementations
{
    internal class UsuarioPatenteRepository : IJoinRepository<Patente, Usuario>
    {
        public void Add(Patente patente, Usuario usuario)
        {
            SqlHelper.ExecuteNonQuery("INSERT INTO UsuarioPatente (IdUsuario, IdPatente) VALUES (@IdUsuario, @IdPatente)",
                CommandType.Text,
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@IdPatente", patente.Id));
        }

        public void AddRange(List<Patente> children, Usuario parent)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patente obj)
        {
            throw new NotImplementedException();
        }

        public List<Patente> GetByObject(Usuario obj)
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader dataReader = SqlHelper.ExecuteReader("SELECT IdPatente FROM UsuarioPatente WHERE IdUsuario = @IdUsuario",
                CommandType.Text,
                new SqlParameter("@IdUsuario", obj.IdUsuario)))
            {
                while (dataReader.Read())
                {
                    Guid idPatente = dataReader.GetGuid(0);

                    patentes.Add(new PatenteRepository().GetById(idPatente));
                }
            }

            return patentes;
        }
    }
}
