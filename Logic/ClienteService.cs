using DataAccess;
using DomainModel;
using Logic.Exceptions;
using Services.DomainModel;
using Services.Facade.ExtensionsMethods;
using Services.Logic.Infrastructure.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClienteService
    {
        private ClienteDao repositorioCliente = new ClienteDao();
        public void Agregar(Cliente cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.CUIT))
                {
                    ExceptionLogger.Log($"Intento de agregar cliente con CUIT vacío", LogLevel.Info);
                    throw new CUITInvalidoException(cliente.CUIT ?? "vacío");
                }

                if (!cliente.CUIT.StartsWith("27") && !cliente.CUIT.StartsWith("20"))
                {
                    ExceptionLogger.Log($"Intento de agregar cliente con CUIT inválido: {cliente.CUIT}", LogLevel.Info);
                    throw new CUITInvalidoException(cliente.CUIT);
                }

                var clienteExistente = repositorioCliente.ObtenerTodos()
                    .FirstOrDefault(c => c.CUIT == cliente.CUIT);

                if (clienteExistente != null)
                {
                    ExceptionLogger.Log($"Intento de agregar cliente duplicado con CUIT: {cliente.CUIT}", LogLevel.Info);
                    throw new ClienteDuplicadoException(cliente.CUIT);
                }

                repositorioCliente.Agregar(cliente);
            }
            catch (CUITInvalidoException ex)
            {
                //Debería aplicar política de excepción de BLL
                ExceptionManager.HandleException(ex);
            }
            catch (ClienteDuplicadoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log($"Error inesperado en Agregar: {ex.Message}", LogLevel.Error);
                throw;
            }
        }
        public List<Cliente> ObtenerTodos()
        {
            return repositorioCliente.ObtenerTodos();
        }

    }
}
