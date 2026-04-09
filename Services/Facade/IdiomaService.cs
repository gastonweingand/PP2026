using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class IdiomaService
    {
        public static string Traducir(string idioma, string texto)
        {
            return Logic.IdiomaLogic.Traducir(idioma, texto);
        }
        public static List<string> ObtenerIdiomas()
        {
            return Logic.IdiomaLogic.ObtenerIdiomas();
        }
    }
}
