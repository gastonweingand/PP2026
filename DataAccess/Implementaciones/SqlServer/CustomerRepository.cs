using DataAccess.Implementaciones.SqlServer.Adaptadores;
using DataAccess.Interfaces;
using DataAccess.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            //get => "INSERT INTO [dbo].[Clientes] (Nombre, CUIT, FechaNacimiento) VALUES (@Nombre, @CUIT, @FechaNacimiento)";
            get => "DECLARE @NewID TABLE (IdCliente uniqueidentifier); " +
                      "INSERT INTO [dbo].[Clientes] (Nombre, CUIT, FechaNacimiento) " +
                      "OUTPUT INSERTED.IdCliente INTO @NewID " +
                      "VALUES (@Nombre, @CUIT, @FechaNacimiento);" +
                      "SELECT IdCliente FROM @NewID;";
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
            try
            {
                //Generamos el Id del cliente, aunque no es necesario porque lo genera la base de datos, pero lo hacemos para tenerlo disponible en el objeto antes de insertarlo en la base de datos
                //Desde programación generamos el GUID (Otra opción)

                //entity.IdCliente = Guid.NewGuid();

                object returnValue = SqlHelper.ExecuteScalar(InsertStatement, CommandType.Text,
                                                        new SqlParameter[] {
                                                            new SqlParameter("@Nombre", entity.Nombre),
                                                            new SqlParameter("@CUIT", entity.CUIT),
                                                            new SqlParameter("@FechaNacimiento", entity.FechaNacimiento)
                                                        });

                entity.IdCliente = Guid.Parse(returnValue.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            //En realidad, los delete no deberían exitir en las bases de datos salvo movimientos
            //de datos a bases históricas, pero para el ejemplo lo implementamos así

            int filasAfectadas = SqlHelper.ExecuteNonQuery(DeleteStatement, CommandType.Text,
                new SqlParameter[] {
                    new SqlParameter("@IdCliente", id)
                });

            //O bien, retornamos por método este int o hacemos alguna validación

            if (filasAfectadas > 1 || filasAfectadas == 0)
            {
                //Algo falló, porque se afectó más de un registro o no se afectó ningún registro, lo que indicaría que el IdCliente no existe en la base de datos
                throw new Exception("Error al eliminar el cliente, se afectó un número de registros inesperado: " + filasAfectadas);
            }
        }

        public Cliente GetById(Guid id)
        {
            try
            {
                //Objeto de retorno
                Cliente cliente = default;

                using (var dataReader = SqlHelper.ExecuteReader(SelectOneStatement,
                    CommandType.Text,
                    new SqlParameter[] {
                        new SqlParameter("@IdCliente", id)
                    }))
                {
                    if (dataReader.Read())
                    {
                        object[] datos = new object[dataReader.FieldCount];
                        dataReader.GetValues(datos);

                        cliente = ClienteAdaptador.Current.Fill(datos);
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetAll()
        {
            try
            {
                //Objeto de retorno
                List<Cliente> clientes = new List<Cliente>();

                using (var dataReader = SqlHelper.ExecuteReader(SelectAllStatement,
                    CommandType.Text, new SqlParameter[] { }))
                {
                    while (dataReader.Read())
                    {
                        //El jueves vamos a ver el patrón adapter -> mapper
                        object[] datos = new object[dataReader.FieldCount];
                        dataReader.GetValues(datos);

                        //Cliente clienteAdaptador = ClienteAdaptador.Current.Fill(datos);

                        clientes.Add(ClienteAdaptador.Current.Fill(datos));
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
