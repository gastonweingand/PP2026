
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
    internal class FamiliaPatenteRepository : IJoinRepository<Patente, Familia>
    {
        public void Add(Patente patente, Familia familia)
        {
            SqlHelper.ExecuteNonQuery("INSERT INTO FamiliaPatente (IdFamilia, IdPatente) VALUES (@IdFamilia, @IdPatente)",
                CommandType.Text,
                new SqlParameter("@IdFamilia", familia.Id),
                new SqlParameter("@IdPatente", patente.Id));
            
            //Si tuviesemos más data en la entidad de la relación, necesitamos un tipo más (Z)
            //Precio unitario
            //Cantidad 
        }

        public void AddRange(List<Patente> children, Familia parent)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patente obj)
        {
            throw new NotImplementedException();
        }

        public List<Patente> GetByObject(Familia obj)
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader dataReader = SqlHelper.ExecuteReader("SELECT IdPatente FROM FamiliaPatente WHERE IdFamilia = @IdFamilia",
                CommandType.Text,
                new SqlParameter("@IdFamilia", obj.Id)))
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
