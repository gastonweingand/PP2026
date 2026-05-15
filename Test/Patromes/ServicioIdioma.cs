using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Patromes
{
    internal class ServicioIdioma
    {
        public string BasePath { get; set; }
        //2)  La propia gestiona la instancia única
        private static ServicioIdioma _instance = new ServicioIdioma();

        private static object _instanceLock = new object();

        public void VerPath() {
            Console.WriteLine($"El path base es: {BasePath}");
        }

        // 1) Ctor privado para evitar que se creen instancias desde afuera
        private ServicioIdioma() { }

        //Además esta solución es thread safe, ya que la instancia se crea en el momento de la declaración, antes de que cualquier hilo pueda acceder a ella.
        public static ServicioIdioma GetInstance()
        {
            return _instance;
        }

        // 3) Método público para obtener la instancia única
        public static ServicioIdioma GetInstanceV1()
        {
            //Esta solución no es Thread Safe (Con un solo check sin interbloqueo)

            //th2
            //th1

            //Esta solución si es Thread Safe
            if (_instance == null)
            {
                //th2
                //th1
                lock (_instanceLock)
                {
                    //th2
                    //th1
                    if( _instance == null )
                    {
                        _instance = new ServicioIdioma();

                    }
                }
                //th2
            }

            return _instance;
        }
    }
}
