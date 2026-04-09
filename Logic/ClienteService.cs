using DataAccess;
using DomainModel;
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
                //Escribir las reglas que me permitan aceptar un nuevo Cliente...
                if (!cliente.CUIT.StartsWith("27") && !cliente.CUIT.StartsWith("20"))
                {
                    throw new ArgumentException("CUIT inválido");
                }

                repositorioCliente.Agregar(cliente);
            }
            catch (Exception ex)
            {
                //Registrar las excepciones!!!!
                throw ex;
            }
        }
        public List<Cliente> ObtenerTodos()
        {
            return repositorioCliente.ObtenerTodos();
        }

    }
}
