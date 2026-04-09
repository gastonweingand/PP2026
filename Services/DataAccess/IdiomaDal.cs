using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    internal static class IdiomaDal
    {
        /// <summary>
        /// 
        /// </summary>
        private static string folder = ConfigurationManager.AppSettings["I18NFolder"];

        private static string fileName = ConfigurationManager.AppSettings["I18NFileName"];


        /// <summary>
        /// idioma por ahora recibe la extensión del archivo. EJ: es-AR, en-US, etc. El texto es la palabra a traducir. El método devuelve la traducción de esa palabra en el idioma solicitado.
        /// </summary>
        /// <param name="idioma"></param>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string Traducir(string idioma, string texto)
        {
            string fileNameIdioma = Path.Combine(folder, fileName + "." + idioma);
            
            using(StreamReader sr = new StreamReader(fileNameIdioma))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');

                    if(parts.Length == 2 && parts[0].Trim().ToLower() == texto.ToLower())
                    {
                        //Si estoy acá significa que encontré la clave buscada.
                        return parts[1].Trim();
                    }
                }
            }
            throw new Exception($"No se encontró la traducción para el texto '{texto}' en el idioma '{idioma}'.");
        }



        public static List<string> ObtenerIdiomas()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            List<string> idiomas = new List<string>();

            foreach (FileInfo fo in directoryInfo.GetFiles())
            {
                idiomas.Add(fo.Extension);
            }

            return idiomas;
        }
    }
}
