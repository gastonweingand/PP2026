using Composite;
using DataAccess.Factory;
using DomainModel;
using Services.DomainModel;
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

            Patente pantallaGestionVentas = new Patente();
            pantallaGestionVentas.Nombre = "Pantalla de gestión de ventas";

            Patente pantallaVisualizacionVentas = new Patente();
            pantallaVisualizacionVentas.Nombre = "Pantalla de visualización de ventas";

            Familia familiaVentas = new Familia(pantallaGestionVentas);
            familiaVentas.Nombre = "Familia de ventas";

            Usuario usuario = new Usuario();
            usuario.Nombre = "jorgito";
            usuario.Privilegios.Add(familiaVentas);
            usuario.Privilegios.Add(pantallaVisualizacionVentas);

            //Si el modelo que van a gestionar desde usuario funciona
            //Deberíamos ver en pantalla que al recorrer los privilegios
            //Este usuario debería mostrar por pantalla los métodos que el profe dejó de tarea
            usuario.TodasFamilias();
            usuario.TodasPatentes();


            //Por ahora vamos a probar nuestro DAO, después iremos a la capa lógica

            List<Cliente> clientes = FactoryDataAccess.CustomerRepository.GetAll();

            Recorrer(clientes);

            Cliente clienteNuevo = new Cliente();
            clienteNuevo.Nombre = "Jorgito";
            clienteNuevo.FechaNacimiento = DateTime.Now.AddYears(-20);
            clienteNuevo.CUIT = "20123456789";

            //ADD
            //FactoryDataAccess.CustomerRepository.Add(clienteNuevo);

            clientes = FactoryDataAccess.CustomerRepository.GetAll();
            Recorrer(clientes);

            //UPDATE
            clienteNuevo.Nombre = "Otro nombre";
            FactoryDataAccess.CustomerRepository.Update(clienteNuevo);

            Recorrer(clientes);

            //DELETE
            FactoryDataAccess.CustomerRepository.Delete(clienteNuevo.IdCliente);

            Recorrer(clientes);
        }

        private static void Recorrer(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"{cliente.IdCliente} : {cliente.Nombre}");
            }
        }
    }
}
