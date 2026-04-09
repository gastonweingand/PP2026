using Services.DataAccess;
using Services.Facade;
using Services.Logic.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal static class IdiomaLogic
    {
        public static string Traducir(string texto)
        {
            try
            {
                return IdiomaDal.Traducir(texto);
            }
            catch (PalabraNoEncontradaException ex)
            {
                // Que podría hacer?
                // 1) Puedo agregar la clave en el idioma que se solicita actualmente, con valor vacío
                // 2) Puedo agregar la clave en el idioma padre y/o todos aquellos otros idiomas que no tengan la palabra
                // 3) Puedo no hacer nada
                // 4) Puedo llamar a un modelito LLM, buscar la traducción y agregarla como value en l paso 1 o 2
                
                // En nuestro DEMO tomamos la determinación de ir por la opción 1
                IdiomaDal.AgregarPalabra(texto);

                Console.WriteLine($"La palabra que no pudo traducirse fue: {ex.Palabra}. ");

                return texto; //En nuestro una palabra que no pudo traducirse, retorna la misma palabra
            }
            catch (Exception ex)
            {
                //Si estoy acá, es una exception más genérica. Para ver después
                //Bitácora y relanzamos la excepción

                throw ex;
            }
        }

        public static List<CultureInfo> ObtenerIdiomas()
        {
            return IdiomaDal.ObtenerIdiomas();
        }
    }
}
