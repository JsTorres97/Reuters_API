using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class datos_dashboard_userController : ApiController
    {
        public List<string> Get(string id)
        {
            if (id.Equals("1")) {
                conexion con = new conexion();
                SqlDataReader dr = con.get_lugares();
                if (dr.HasRows)
                {
                    List<String> lista = new List<string>();
                    while (dr.Read())
                    {
                        //lista.Add("{");
                        lista.Add("codigo: 1");
                        lista.Add("TOTAL: " + dr[0]);
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
