using DataAccess.Interfaces;
using DataAccess.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementaciones.SqlServer
{

	public sealed class CustomerRepository : ICustomerRepository
	{
        #region singleton
        private readonly static CustomerRepository _instance = new CustomerRepository();

		public static CustomerRepository Current
		{
			get
			{
				return _instance;
			}
		}

		private CustomerRepository()
		{
			//Implent here the initialization of your singleton
		}
        #endregion


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Clientes] (Nombre, CUIT, FechaNacimiento) VALUES (@Nombre, @CUIT, @FechaNacimiento)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Clientes] SET (Nombre, CUIT, FechaNacimiento) WHERE IdCliente = @IdCliente";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Clientes] WHERE IdCliente = @IdCliente";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdCliente, Nombre, CUIT, FechaNacimiento FROM [dbo].[Clientes] WHERE IdCliente = @IdCliente";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdCliente, Nombre, CUIT, FechaNacimiento FROM [dbo].[Clientes]";
        }
        #endregion


        public List<Cliente> GetByDate(DateTime fechaCreacionDesde, DateTime fechaCreacionHsta)
        {
            throw new NotImplementedException();
        }

        public void Add(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            //Objeto de retorno
            List<Cliente> clientes = new List<Cliente>();

            using(var dataReader = SqlHelper.ExecuteReader(SelectAllStatement,
                System.Data.CommandType.Text, new System.Data.SqlClient.SqlParameter[] {}))
            {
                while (dataReader.Read())
                {
                    //El jueves vamos a ver el patrón adapter -> mapper

                    Cliente cliente = new Cliente
                    {
                        IdCliente = dataReader.GetGuid(0),
                        Nombre = dataReader.GetString(1),
                        CUIT = dataReader.GetString(2),
                        FechaNacimiento = dataReader.GetDateTime(3)
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }
    }

}
