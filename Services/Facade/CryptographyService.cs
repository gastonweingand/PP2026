using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Logic.Infraestructure;

namespace Services.Facade
{
    public static class CryptographyService
    {

        public static string HashMd5(string textPlain)
        {
            return CryptographyLogic.HashMd5(textPlain);
        }

        public static string Encrypt(string clearText)
        {
            return CryptographyLogic.Encrypt(clearText);
        }

        public static string Decrypt(string clearText) {
            return CryptographyLogic.Decrypt(clearText);

        }
    }
}
