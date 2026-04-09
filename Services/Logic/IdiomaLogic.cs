using Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal static class IdiomaLogic
    {
        public static string Traducir(string idioma, string texto)
        {
            try
            {
                return IdiomaDal.Traducir(idioma, texto);
            }
            catch (Exception ex)
            {
                //Tratarla, lo vemos el jueves
                throw ex;
            }
        }

        public static List<string> ObtenerIdiomas()
        {
            return IdiomaDal.ObtenerIdiomas();
        }
    }
}
