using System;
using System.Collections.Generic;
using Composite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string IdiomaPredeterminado { get; set; }

        public string Nombre { get; set; }

        //Agregar los dato fundamentales para cualquier usuario: nombre, contraseña, email, etc.

        public List<Component> Privilegios { get; set; } = new List<Component>();

        public List<Patente> TodasPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            RecorrerComponentesParaPatentes(Privilegios, patentes);

            return patentes;
        }

        private void RecorrerComponentesParaPatentes(List<Component> componentes, List<Patente> patentes)
        {
            foreach (var componente in componentes)
            {
                if (componente is Patente)
                {
                    Patente patenteObj = (Patente)componente;

                    // Si la patente no está en la lista, la agregamos
                    // Comprobamos para lograr una funcionalidad similar a distinct, pero sin usar LINQ, para evitar problemas de rendimiento al cargar todas las patentes

                    if (!patentes.Exists(o => o.IdPatente == patenteObj.IdPatente))
                        patentes.Add(componente as Patente);
                }
                else if (componente is Familia)
                {
                    RecorrerComponentesParaPatentes(((Familia)componente).GetComponentes(), patentes);
                }
            }
        }

        public List<Familia> TodasFamilias()
        {
            List<Familia> familias = new List<Familia>();

            RecorrerComponentesParaFamilias(Privilegios, familias);

            return familias;
        }

        private void RecorrerComponentesParaFamilias(List<Component> componentes, List<Familia> familias)
        {
            foreach (var componente in componentes)
            {
                if (componente is Familia)
                {
                    Familia familiaObj = (Familia)componente;

                    // Comprobamos para lograr una funcionalidad similar a distinct, pero sin usar LINQ, para evitar problemas de rendimiento al cargar todas las patentes y familias de un usuario
                    if (!familias.Exists(o => o.IdFamilia == familiaObj.IdFamilia))
                        familias.Add(componente as Familia);

                    RecorrerComponentesParaFamilias(((Familia)componente).GetComponentes(), familias);
                }
            }
        }
    }
}
