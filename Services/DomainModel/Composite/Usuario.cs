using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.DomainModel.Composite
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        private string password;



        /// <summary>
        /// Para gestionar el patrón composite debemos utilizar una lista de Component
        /// </summary>
        ///
        public List<Component> Privilegios { get; set; }

        /// <summary>
        /// Generar recursividad sobre el composite para obtener el menú de opciones
        /// </summary>
        public List<Patente> Patentes
        {
            get
            {
                List<Patente> patentes = new List<Patente>();
                RecorrerFamilias(patentes, Privilegios);
                return patentes;
            }
        }

        /// <summary>
        /// Recorre las familias y patentes de un usuario
        /// </summary>
        /// <param name="patentes">Lista de patentes</param>
        /// <param name="componentes">Lista de componentes que se recorren</param>
        private void RecorrerFamilias(List<Patente> patentes, List<Component> componentes)
        {
            foreach (var componente in componentes)
            {
                if (componente is Patente patente)
                {
                    if (!patentes.Exists(p => p.Id == patente.Id))
                        patentes.Add(patente);
                }
                else if (componente is Familia familia)
                {
                    RecorrerFamilias(patentes, familia.GetHijos());
                }
            }
        }

        public List<Familia> Familias
        {
            get
            {
                List<Familia> familias = new List<Familia>();
                RecorrerFamilias(familias, Privilegios);
                return familias;
            }
        }

        private void RecorrerFamilias(List<Familia> familias, List<Component> componentes)
        {
            foreach (var componente in componentes)
            {
                if (componente is Familia familia)
                {
                    if (!familias.Exists(p => p.Id == familia.Id))
                        familias.Add(familia);

                    RecorrerFamilias(familias, familia.GetHijos());
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                //password = CryptographyService.HashMd5(value);
            }
        }

        public bool Habilitado { get; set; }

        public Usuario(string nombre, string email, string password, bool habilitado = true)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Habilitado = habilitado;
        }

        public Usuario(Guid idUsuario, string nombre, string email, string password, bool habilitado = true) : this(nombre, email, password, habilitado)
        {
            IdUsuario = idUsuario;
        }

        //Necesito constructor por defecto para el ORM
        public Usuario()
        {

        }
    }
}

