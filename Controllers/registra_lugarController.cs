using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Registra un nuevo lugar, con parametrso desencriptados status, prioridad
    /// </summary>
    public class registra_lugarController : ApiController
    {
        /// <summary>
        /// Registra un nuevo lugar, con parametrso desencriptados status, prioridad
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Lugar registrado con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {

            string cadena = cifrado.Base64Decode(id.ToString());
            string status, prioridad;
            string[] datos = cadena.Split(',');
            status = datos[0];
            prioridad = datos[1];

            conexion con = new conexion();
            int res = con.insert_hotdesk(status, prioridad);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Lugar registrado con exito",
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
