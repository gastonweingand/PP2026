using DataAccess.Factory;
using DomainModel;
using Services.DataAccess.DomainModel.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Patromes;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demo composite hacia la base de datos



















            ServicioIdioma servicioIdioma1 = ServicioIdioma.GetInstance();
            servicioIdioma1.BasePath = "C:\\Program Files\\Test";

            servicioIdioma1.VerPath();

            ServicioIdioma servicioIdioma2 = ServicioIdioma.GetInstance();
            servicioIdioma2.BasePath = "C:\\Program Files\\Test2";

            servicioIdioma2.VerPath();
            //Pero también vamos a ver qué path tiene la instancia 1
            servicioIdioma1.VerPath();

            Console.WriteLine(servicioIdioma1 == servicioIdioma2);

            ServicioBitacora.BasePath = servicioIdioma1.BasePath;

            Patente pantallaGestionVentas = new Patente();
            pantallaGestionVentas.Nombre = "frmVentas";

            Patente pantallaVisualizacionVentas = new Patente();
            pantallaVisualizacionVentas.Nombre = "frmVisualizacionVentas";

            Patente pantallaPerfil = new Patente();
            pantallaPerfil.Nombre = "frmPerfil";

            Familia familiaVentas = new Familia(pantallaGestionVentas);
            familiaVentas.Nombre = "Familia de ventas";

            Familia administrador = new Familia(familiaVentas);
            administrador.Nombre = "Administrador";

            Usuario usuario = new Usuario();
            usuario.Nombre = "jorgito";
            usuario.Privilegios.Add(familiaVentas);
            usuario.Privilegios.Add(pantallaVisualizacionVentas);
            usuario.Privilegios.Add(pantallaGestionVentas); //Pantalla gestión ya está dentro de la familia
            usuario.Privilegios.Add(administrador);

            //Si el modelo que van a gestionar desde usuario funciona
            //Deberíamos ver en pantalla que al recorrer los privilegios
            //Este usuario debería mostrar por pantalla los métodos que el profe dejó de tarea
            //usuario.TodasFamilias();
            List<Patente> patentes = usuario.Patentes;

            //Recorriendo todos los accesos a los que tiene permitido ingresar el usuario
            foreach (Patente patente in patentes)
            {
                Console.WriteLine(patente.Nombre);
            }

            List<Familia> familias = usuario.Familias;

            //Recorriendo todos los accesos a los que tiene permitido ingresar el usuario
            foreach (Familia familia in familias)
            {
                Console.WriteLine(familia.Nombre);
            }

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
