
using Composite;
using Services.DataAccess.Interfaces;
using Services.DataAccess.Tools;
using Services.DomainModel;
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
