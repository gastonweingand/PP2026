using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Patromes
{
    internal static class ServicioBitacora
    {
        public static string BasePath { get; set; }

        static ServicioBitacora(){
            BasePath = @"C:\Bitacora\";
        }
    }
}
