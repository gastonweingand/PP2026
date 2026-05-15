
using Services.Dal.Implementations.Adapters;
using Services.DataAccess.DomainModel.Composite;
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
    internal class PatenteRepository : IPatenteRepository
    {
        public void Add(Patente entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Patente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patente GetById(Guid id)
        {
            string SelectByIdStatement = "SELECT IdPatente, DataKey, TipoAcceso FROM [dbo].[Patente] WHERE IdPatente = @IdPatente";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectByIdStatement,
                                                     CommandType.Text,
                                                     new SqlParameter[] { new SqlParameter("@IdPatente", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    return PatenteAdapter.Current.Get(data);
                }
                else
                {
                    return null; // or throw an exception if not found
                }
            }
        }

        public void Update(Patente entity)
        {
            throw new NotImplementedException();
        }
    }
}
