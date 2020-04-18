using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace Reuters_api.Controllers
{
    public class loginController : ApiController
    {
        public List < string > Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;
            
            string cadena = cifrado.Base64Decode(id.ToString());
            string correo, pass;
            string[] datos = cadena.Split(',');
            //correo = ja[0]["CORREO"].ToString();
            //pass = ja[0]["PASS"].ToString();
            correo = datos[0];
            pass = datos[1];

            conexion con = new conexion();
            SqlDataReader dr =  con.login_check(correo, pass);
            if (dr.HasRows)
            {
                List<String> lista = new List<string>();
                while (dr.Read())
                {
                    //lista.Add("{");
                    lista.Add("codigo: 1");
                    lista.Add("is_admin: " + dr["IS_ADMIN"]);
                    lista.Add("is_user: " + dr["IS_USER"]);
                   // lista.Add("}");
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
        
    }
}
