using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extentions
{
    public static class StringExtension
    {
        public static string Traducir(this string texto)
        {
            return Logic.IdiomaLogic.Traducir(texto);
        }
    }
}
