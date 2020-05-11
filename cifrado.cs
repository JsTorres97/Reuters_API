using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Reuters_api
{
    /// <summary>
    /// Clase que desencripta un texto
    /// </summary>
    public class cifrado
    {
        /// <summary>
        /// Desencripta una cadena 
        /// </summary>
        /// <returns>
        /// Cadena desencriptada
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        //public static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
    }
}