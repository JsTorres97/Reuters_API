using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Actualiza la contraseña del usuario, con parametros desencriptados número de empleado y password
    /// </summary>
    public class actualiza_passController : ApiController
    {
        /// <summary>
        /// Actualiza la contraseña del usuario, con parametros desencriptados número de empleado y password
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Contraseña actualizada con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {

            string cadena = cifrado.Base64Decode(id.ToString());
            string num_emp, pass;
            string[] datos = cadena.Split(',');
            num_emp = datos[0];
            pass = datos[1];

            conexion con = new conexion();
            int res = con.actualiza_pass(num_emp, pass);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Contraseña actualizada con exito",
                };
            }
            else
            {
                return new List<string>
                {
                    "codigo: 0",
                    "mensaje: Existe un error, intentalo de nuevo",
                };
            }

        }
    }
}
