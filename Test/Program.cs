using DataAccess.Factory;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Por ahora vamos a probar nuestro DAO, después iremos a la capa lógica

            List<Cliente> clientes = FactoryDataAccess.CustomerRepository.GetAll();

            Recorrer(clientes);

            Cliente clienteNuevo = new Cliente();
            clienteNuevo.Codigo = Guid.NewGuid();
            clienteNuevo.Nombre = "Jorgito";

            //ADD
            FactoryDataAccess.CustomerRepository.Add(clienteNuevo);

            Recorrer(clientes);

            //UPDATE
            clienteNuevo.Nombre = "Otro nombre";
            FactoryDataAccess.CustomerRepository.Update(clienteNuevo);

            Recorrer(clientes);

            //DELETE
            FactoryDataAccess.CustomerRepository.Delete(clienteNuevo.Codigo);

            Recorrer(clientes);
        }

        private static void Recorrer(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"{cliente.Codigo} : {cliente.Nombre}");
            }
        }
    }
}
