using DataAccess.Factory;
using DomainModel;
using Services.DataAccess.DomainModel.Composite;
using Services.Facade;
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
            Console.WriteLine("DEMO COMPOSITE CON BASE DE DATOS");

            //1.Crear patentes (hojas del árbol de permisos)
            Patente patenteVentas = new Patente { DataKey = "frmVentas", TipoAcceso = TipoAcceso.Pantalla };
            Patente patenteVisVentas = new Patente { DataKey = "frmVisualizacionVentas", TipoAcceso = TipoAcceso.Pantalla };
            Patente patentePerfil = new Patente { DataKey = "frmPerfil", TipoAcceso = TipoAcceso.Pantalla };

            PatenteService.Add(patenteVentas);
            PatenteService.Add(patenteVisVentas);
            PatenteService.Add(patentePerfil);

            Console.WriteLine($"Patentes creadas: {patenteVentas.DataKey}, {patenteVisVentas.DataKey}, {patentePerfil.DataKey}");

            //2.Crear familias (nodos del árbol)
            Familia familiaVentasBD = new Familia { Nombre = "Familia de ventas" };
            Familia familiaAdminBD = new Familia { Nombre = "Administrador" };

            FamiliaService.Add(familiaVentasBD);
            FamiliaService.Add(familiaAdminBD);
            Console.WriteLine($"Familias creadas: {familiaVentasBD.Nombre}, {familiaAdminBD.Nombre}");

            //3.Asignar patentes a la familia de ventas
            FamiliaService.AgregarPatente(patenteVentas, familiaVentasBD);
            FamiliaService.AgregarPatente(patenteVisVentas, familiaVentasBD);
            Console.WriteLine($"Patentes asignadas a '{familiaVentasBD.Nombre}'");

            //4.Anidar la familia de ventas dentro de administrador
            FamiliaService.AgregarFamilia(familiaVentasBD, familiaAdminBD);
            Console.WriteLine($"'{familiaVentasBD.Nombre}' asignada como hija de '{familiaAdminBD.Nombre}'");

            //5.Crear usuario
            Usuario usuarioBD = new Usuario("jorgito_bd", "jorgito@empresa.com", "Pass1234");
            LoginService.RegistrarUsuario(usuarioBD);
            Console.WriteLine($"Usuario creado: {usuarioBD.Nombre} (Id: {usuarioBD.IdUsuario})");

            //6.Asignar privilegios al usuario
            UsuarioService.AgregarFamilia(familiaAdminBD, usuarioBD);   // accede a todo el árbol de admin
            UsuarioService.AgregarPatente(patentePerfil, usuarioBD);     // patente directa (sin familia)
            Console.WriteLine("Privilegios asignados al usuario");

            //7.Recuperar el usuario e hidratar el composite completo desde la BD
            Console.WriteLine("Recuperando usuario desde la BD");
            Usuario usuarioRecuperado = LoginService.ValidarCredenciales("jorgito_bd", "Pass1234");

            Console.WriteLine($"Usuario: {usuarioRecuperado.Nombre} | Email: {usuarioRecuperado.Email}");

            Console.WriteLine("Todas las patentes accesibles:");
            foreach (Patente p in usuarioRecuperado.Patentes)
                Console.WriteLine($"  - {p.DataKey} ({p.TipoAcceso})");

            Console.WriteLine("Todas las familias accesibles:");
            foreach (Familia f in usuarioRecuperado.Familias)
                Console.WriteLine($"  - {f.Nombre}");

            Console.WriteLine("FIN DEMO BD");

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
