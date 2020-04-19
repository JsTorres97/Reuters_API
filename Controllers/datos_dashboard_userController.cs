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
            if (id.Equals("1")) 
            {
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
            if (id.Equals("2"))
            {
                conexion con = new conexion();
                SqlDataReader dr = con.get_usuario();
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
            if (id.Equals("3"))
            {
                conexion con = new conexion();
                SqlDataReader dr = con.get_hot_desk_disponibles();
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
            if (id.Equals("4"))
            {
                conexion con = new conexion();
                SqlDataReader dr = con.get_usuarios_en_la_oficina();
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
            if(id.Equals("5")){
                conexion con = new conexion();
                SqlDataReader dr = con.get_usuarios_activos();
                if (dr.HasRows)
                {
                    List<String> lista = new List<string>();
                    while (dr.Read())
                    {
                        //lista.Add("{");
                        lista.Add("codigo: 1");
                        lista.Add("NOMBRE: " + dr["NOMBRE"]);
                        lista.Add("AREA: " + dr["AREA"]);
                        lista.Add("NUM_EMPLEADO: " + dr["NUMERO_EMPLEADO"]);
                        lista.Add("|");
                    }
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
