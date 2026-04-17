using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClienteDao
    {
        private List<Cliente> clienteList = new List<Cliente>();

        public void Agregar(Cliente cliente)
        {
            clienteList.Add(cliente);
        }

        public ClienteDao()
        {
            clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "A" });
            clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "B" });
            clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "C" });
            clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "D" });
            clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "E" });
        }

        public void Modificar(Cliente cliente)
        {
            Cliente clienteAModificar = ObtenerPorCodigo(cliente.Codigo);

            if (clienteAModificar != null)
            {
                clienteAModificar.FechaNacimiento = cliente.FechaNacimiento;
                clienteAModificar.Nombre = cliente.Nombre;
                clienteAModificar.CUIT = cliente.CUIT;
            }
            else throw new Exception();
        }

        public Cliente ObtenerPorCodigo(Guid codigo) {

            foreach (Cliente item in clienteList)
            {
                if (item.Codigo == codigo)
                    return item;
            }
            //Si estoy acá significa que no existe un cliente con ese código...
            return null;
        }

        public void Eliminar(Cliente cliente)
        {
            Cliente clienteAEliminar = ObtenerPorCodigo(cliente.Codigo);

            if (clienteAEliminar != null)
            {
                clienteList.Remove(clienteAEliminar);
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            return clienteList;
        }
    }
}
