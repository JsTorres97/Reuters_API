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
    /// Obtiene las próximas reservaciones del usuario
    /// </summary>
    public class proximas_reservacionesController : ApiController
    {
        /// <summary>
        /// Obtiene las próximas reservaciones del usuario
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Información solicitada, NUMERO_DE_RESERVACION, NUMERO_LUGAR, FECHA, HORA_ENTRADA, HORA_SALIDA
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Número de emplado.</param>
        public List<string> Get(string id)
        {
            conexion con = new conexion();
            SqlDataReader dr = con.get_proximas_reservaciones(id);
            if (dr.HasRows)
            {
                List<String> lista = new List<string>();
                while (dr.Read())
                {
                    //lista.Add("{");
                    lista.Add("codigo: 1");
                    lista.Add("NUMERO_DE_RESERVACION:" + dr[0]);
                    lista.Add("NUMERO_LUGAR: " + dr["NUMERO_LUGAR"]);
                    lista.Add("FECHA: " + dr["FECHA"]);
                    lista.Add("HORA_ENTRADA: " + dr["HORA_ENTRADA"]);
                    lista.Add("HORA_SALIDA: " + dr["HORA_SALIDA"]);
                    lista.Add("|");
                }
                

                return lista;
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

