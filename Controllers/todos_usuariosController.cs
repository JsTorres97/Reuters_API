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
        public List<string> Get()
        {
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
