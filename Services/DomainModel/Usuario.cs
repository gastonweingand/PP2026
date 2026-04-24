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
        public string IdiomaPredeterminado { get; set; }

        public string Nombre { get; set; }

        //Agregar los dato fundamentales para cualquier usuario: nombre, contraseña, email, etc.

        public List<Component> Privilegios { get; set; }

        public List<Patente> TodasPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            foreach (var componente in Privilegios)
            {
                if (componente is Patente)
                {
                    patentes.Add((Patente)componente);
                }
                else if (componente is Familia)
                {
                    //patentes.AddRange(((Familia)componente).GetPatentes());

                    //Pensar mecanismos recursivos..
                }
            }
            return patentes;
        }

        public List<Familia> TodasFamilias()
        {
            List<Familia> familias = new List<Familia>();
            foreach (var componente in Privilegios)
            {
                if (componente is Familia)
                {
                    //No estaría del todo bien, falta recursividad, pero por ahora se deja así.
                    familias.Add((Familia)componente);
                }
            }
            return familias;
        }
    }
}
