using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Actualiza las prioridades de los lugares
    /// </summary>
    public class actualiza_prioridadesController : ApiController
    {
        /// <summary>
        /// Actualiza las prioridades de los lugares
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:La prioridad de los lugares se ha actualizado correctamente
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        public List<string> Get()
        {
            int estado = 0;
            conexion con = new conexion();
            SqlDataReader dr = con.get_num_lugar();
            while (dr.Read()){
                string lugar = dr[0].ToString();
                int k = con.update_prioridad(lugar);
                if(k != 0)
                {
                    estado = 0;
                }
                else
                {
                    estado = 1;
                }
            }
            if (estado == 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: La prioridad de los lugares se ha actualizado correctamente",
                };
            }
            else if(estado == 1)
            {
                return new List<string>
                {
                    "codigo: 0",
                    "mensaje: Existe un error, intentalo de nuevo",
                };
            }
            return new List<string>
                {
                    "codigo: 0",
                    "mensaje: Existe un error, intentalo de nuevo",
                };

        }
    }
}

