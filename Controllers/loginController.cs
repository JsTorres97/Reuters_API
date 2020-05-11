using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Valida el login, con parametros desencriptados correo y password
    /// </summary>
    public class loginController : ApiController
    {
        /// <summary>
        /// Valida el login, con parametros desencriptados correo y password
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Cadena de información solicitada, NOMBRE, NUM_EMPLEADO, is_admin, is_user
        ///     0:Correo o password incorrectos
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List < string > Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;
            
            string cadena = cifrado.Base64Decode(id.ToString());
            string correo, pass;
            string[] datos = cadena.Split(',');
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
                    lista.Add("NOMBRE: " + dr["NOMBRE"]);
                    lista.Add("NUM_EMPLEADO: " + dr["NUMERO_EMPLEADO"]);
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
