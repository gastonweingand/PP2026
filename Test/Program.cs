using Composite;
using DataAccess.Factory;
using DomainModel;
using Services.DomainModel;
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
            List<Patente> patentes = usuario.TodasPatentes();

            //Recorriendo todos los accesos a los que tiene permitido ingresar el usuario
            foreach (Patente patente in patentes)
            {
                Console.WriteLine(patente.Nombre);
            }

            List<Familia> familias = usuario.TodasFamilias();

            //Recorriendo todos los accesos a los que tiene permitido ingresar el usuario
            foreach (Familia familia in familias)
            {
                Console.WriteLine(familia.Nombre);
            }

            //Demo composite hacia la base de datos
            Console.WriteLine("\n=== DEMO COMPOSITE CON BASE DE DATOS ===\n");

            // 1. Crear patentes (hojas del árbol de permisos)
            Patente patenteVentas = new Patente { Nombre = "frmVentas", Descripcion = "Gestión de ventas" };
            Patente patenteVisVentas = new Patente { Nombre = "frmVisualizacionVentas", Descripcion = "Visualización de ventas" };
            Patente patentePerfil = new Patente { Nombre = "frmPerfil", Descripcion = "Perfil de usuario" };

            PatenteService.Agregar(patenteVentas);
            PatenteService.Agregar(patenteVisVentas);
            PatenteService.Agregar(patentePerfil);
            Console.WriteLine($"Patentes creadas: {patenteVentas.Nombre}, {patenteVisVentas.Nombre}, {patentePerfil.Nombre}");

            // 2. Crear familias (nodos del árbol)
            Familia familiaVentas = new Familia { Nombre = "Familia de ventas" };
            Familia familiaAdmin = new Familia { Nombre = "Administrador" };

            FamiliaService.Agregar(familiaVentas);
            FamiliaService.Agregar(familiaAdmin);
            Console.WriteLine($"Familias creadas: {familiaVentas.Nombre}, {familiaAdmin.Nombre}");

            // 3. Asignar patentes a la familia de ventas
            FamiliaService.AgregarPatente(patenteVentas, familiaVentas);
            FamiliaService.AgregarPatente(patenteVisVentas, familiaVentas);
            Console.WriteLine($"Patentes asignadas a '{familiaVentas.Nombre}'");

            // 4. Asignar la familia de ventas como hija de administrador
            FamiliaService.AgregarFamilia(familiaVentas, familiaAdmin);
            Console.WriteLine($"'{familiaVentas.Nombre}' asignada como hija de '{familiaAdmin.Nombre}'");

            // 5. Crear usuario
            Usuario usuarioBD = new Usuario
            {
                Nombre = "jorgito_bd",
                Password = "Pass1234",
                Email = "jorgito@empresa.com",
                Habilitado = true
            };
            UsuarioService.RegistrarUsuario(usuarioBD);
            Console.WriteLine($"Usuario creado: {usuarioBD.Nombre} (Id: {usuarioBD.IdUsuario})");

            // 6. Asignar privilegios al usuario
            UsuarioService.AgregarFamilia(familiaAdmin, usuarioBD);   // accede a todo el árbol de admin
            UsuarioService.AgregarPatente(patentePerfil, usuarioBD);   // patente directa (sin familia)
            Console.WriteLine("Privilegios asignados al usuario");

            // 7. Recuperar el usuario desde la base de datos e hidratar el composite completo
            Console.WriteLine("\n--- Recuperando usuario desde la BD ---");
            Usuario usuarioRecuperado = UsuarioService.GetByCredentials("jorgito_bd", "Pass1234");

            if (usuarioRecuperado != null)
            {
                Console.WriteLine($"Usuario: {usuarioRecuperado.Nombre} | Email: {usuarioRecuperado.Email}");

                // Todas las patentes (recursivo por todo el árbol)
                Console.WriteLine("\nTodas las patentes accesibles:");
                foreach (Patente p in usuarioRecuperado.TodasPatentes())
                    Console.WriteLine($"  - {p.Nombre}: {p.Descripcion}");

                // Todas las familias (recursivo)
                Console.WriteLine("\nTodas las familias accesibles:");
                foreach (Familia f in usuarioRecuperado.TodasFamilias())
                    Console.WriteLine($"  - {f.Nombre}");
            }
            else
            {
                Console.WriteLine("No se encontró el usuario.");
            }

            Console.WriteLine("\n=== FIN DEMO BD ===\n");

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
