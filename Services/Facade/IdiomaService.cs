using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class IdiomaService
    {
        public static List<CultureInfo> ObtenerIdiomas()
        {
            return Logic.IdiomaLogic.ObtenerIdiomas();
        }
    }
}
