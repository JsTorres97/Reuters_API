using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class get_lugaresController : ApiController
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
                SqlDataReader dr = con.get_todos_lugares();
                if (dr.HasRows)
                {
                    List<String> lista = new List<string>();
                    while (dr.Read())
                    {
                        //lista.Add("{");
                        lista.Add("codigo: 1");
                        lista.Add("NUMERO_LUGAR: " + dr[0]);
                        lista.Add("STATUS: " + dr[1]);
                        lista.Add("PRIORIDAD: " + dr[2]);
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

 