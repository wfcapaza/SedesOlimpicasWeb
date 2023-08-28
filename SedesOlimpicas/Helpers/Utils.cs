using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SedesOlimpicas
{
    public class Utils
    {
        public static string ConvertirSha256(string texto)
        {
            StringBuilder textoEncriptado = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding= Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(texto));

                foreach (byte b in result)
                {
                    textoEncriptado.Append(b.ToString("X2"));
                }

                return textoEncriptado.ToString();
            }
        }
    }
}