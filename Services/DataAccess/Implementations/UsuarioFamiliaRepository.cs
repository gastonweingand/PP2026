
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
    internal class UsuarioFamiliaRepository : IJoinRepository<Familia, Usuario>
    {
        public void Add(Familia familia, Usuario usuario)
        {
            SqlHelper.ExecuteNonQuery("INSERT INTO UsuarioFamilia (IdUsuario, IdFamilia) VALUES (@IdUsuario, @IdFamilia)",
                CommandType.Text,
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@IdFamilia", familia.Id));
        }

        public void AddRange(List<Familia> children, Usuario parent)
        {
            throw new NotImplementedException();
        }

        public void Delete(Familia obj)
        {
            throw new NotImplementedException();
        }

        public List<Familia> GetByObject(Usuario obj)
        {
            List<Familia> familias = new List<Familia>();

            using(SqlDataReader dataReader = SqlHelper.ExecuteReader("SELECT IdFamilia FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario",
                CommandType.Text,
                new SqlParameter("@IdUsuario", obj.IdUsuario)))
            {
                while (dataReader.Read())
                {
                    Guid idFamilia = dataReader.GetGuid(0);

                    familias.Add(new FamiliaRepository().GetById(idFamilia));
                }
            }

            return familias;
        }
    }
}
