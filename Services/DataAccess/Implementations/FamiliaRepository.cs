using Services.Dal.Implementations.Adapters;
using Services.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using Services.DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Services.Dal.Implementations
{
    internal class FamiliaRepository : IFamiliaRepository
    {
        public void Add(Familia entity)
        {
            entity.Id = Guid.NewGuid();
            string commandText = "INSERT INTO Familia (IdFamilia, Nombre) VALUES (@IdFamilia, @Nombre)";
            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text,
                new SqlParameter("@IdFamilia", entity.Id),
                new SqlParameter("@Nombre", entity.Nombre));
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Familia> GetAll()
        {
            throw new NotImplementedException();
        }

        public Familia GetById(Guid id)
        {
            string SelectByIdStatement = "SELECT IdFamilia, Nombre FROM [dbo].[Familia] WHERE IdFamilia = @IdFamilia";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectByIdStatement,
                                                     CommandType.Text,
                                                     new SqlParameter[] { new SqlParameter("@IdFamilia", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    return FamiliaAdapter.Current.Get(data);
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(Familia entity)
        {
            throw new NotImplementedException();
        }
    }
}
