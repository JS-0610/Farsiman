using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Prueba1.Encrypt
{
    public class Encrypt
    {
        public static string GetCodingPass(string str)
        {
            SHA256 cadena = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stre = null;
            StringBuilder sb = new StringBuilder();
            stre = cadena.ComputeHash(encoding.GetBytes(str));
            for (int i=0; i<stre.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stre[i]);
            }
            return sb.ToString();
        }
    }
}