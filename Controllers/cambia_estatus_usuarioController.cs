using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Cambia el estatus del usuario
    /// </summary>
    public class cambia_estatus_usuarioController : ApiController
    {
        /// <summary>
        /// Cambia el estatus del usuario
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Usuario actualizado con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Número de empleado</param>
        public List<string> Get(string id)
        {

            conexion con = new conexion();
            int res = con.cambia_status_usuario(id);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Usuario actualizado con exito",
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
