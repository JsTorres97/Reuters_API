using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Cambia el estatus de un lugar, con parametros desencriptados lugar y estatus
    /// </summary>
    public class cambia_estatus_lugarController : ApiController
    {
        /// <summary>
        /// Cambia el estatus de un lugar, con parametros desencriptados lugar y estatus
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Lugar actualizado con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {

            string cadena = cifrado.Base64Decode(id.ToString());
            string lugar, status;
            string[] datos = cadena.Split(',');
            lugar = datos[0];
            status = datos[1];

            conexion con = new conexion();
            int res = con.cambia_status_hotdesk(lugar, status);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Lugar actualizado con exito",
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
