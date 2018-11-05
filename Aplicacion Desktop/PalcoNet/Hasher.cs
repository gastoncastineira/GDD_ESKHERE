using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
    static class Hasher
    {
        public static string Hashear(string cadena)
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena));  
    
                StringBuilder builder = new StringBuilder();  
                bytes.ToList().ForEach(b => builder.Append(b.ToString("x2")));
                return builder.ToString();  
            }  
        }  
    }
}
