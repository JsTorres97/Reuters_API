using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class proximas_reservacionesController : ApiController
    {
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
                    lista.Add("NUMERO_DE_RESERVACION:" + dr["ID"]);
                    lista.Add("NUMERO_LUGAR: " + dr["NUMERO_LUGAR"]);
                    lista.Add("FECHA: " + dr["FECHA"]);
                    lista.Add("HORA_ENTRADA: " + dr["HORA_ENTRADA"]);
                    lista.Add("HORA_SALIDA: " + dr["HORA_SALIDA"]);
                }
                lista.Add("|");

                return lista;
            }
            else
            {
                return new List<string>
                {
                    "codigo: 0",
                    "mensaje: Correo o password incorrectos",
                };
            }
        }
    }
}

