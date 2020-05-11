using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class todos_usuariosController : ApiController
    {
        /// <summary>
        /// Obtiene todo los usuarios
        /// </summary>
        public List<string> Get()
        {
            /// <summary>
            /// Obtiene todo los usuarios
            /// </summary>
            /// <returns>
            /// código y mensaje:
            ///     1:Cadena de información solicitada, NUMERO_EMPLEADO, NOMBRE, CORREO, AREA, STATUS
            ///     0:Existe un error, intentalo de nuevo
            /// </returns>
            /// <param name="id">Cadena cifrada en base 64.</param>
            conexion con = new conexion();
            SqlDataReader dr = con.get_todos_usuarios();
            if (dr.HasRows)
            {
                List<String> lista = new List<string>();
                while (dr.Read())
                {
                    //lista.Add("{");
                    lista.Add("codigo: 1");
                    lista.Add("NUMERO_EMPLEADO: " + dr[0]);
                    lista.Add("NOMBRE: " + dr[1]);
                    lista.Add("CORREO: " + dr[2]);
                    lista.Add("AREA: " + dr[3]);
                    lista.Add("STATUS: " + dr[5]);
                    // lista.Add("}");
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
