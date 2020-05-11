using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Cancela la reservación
    /// </summary>
    public class cancelar_reservacionController : ApiController
    {
        /// <summary>
        /// Cancela la reservación
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Cancelación realizada con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Número de reservación</param>
        public List<string> Get(string id)
        {
            

            conexion con = new conexion();
            int res = con.cancela_reservacion(id);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Cancelación realizada con exito",
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
