using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Registra a un nuevo usuario, con parametros desencriptados, numemp, nombre, correo, area, pass, status, isadmin, isuser
    /// </summary>
    public class registra_usuarioController : ApiController
    {
        /// <summary>
        /// Registra a un nuevo usuario, con parametros desencriptados, numemp, nombre, correo, area, pass, status, isadmin, isuser
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Usuario registrado con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;

            string cadena = cifrado.Base64Decode(id.ToString());
            string numemp, nombre, correo, area, pass, status, isadmin, isuser;
            string[] datos = cadena.Split(',');
            //correo = ja[0]["CORREO"].ToString();
            //pass = ja[0]["PASS"].ToString();
            numemp = datos[0];
            nombre = datos[1];
            correo = datos[2];
            area = datos[3];
            pass = datos[4];
            status = datos[5];
            isadmin = datos[6];
            isuser = datos[7];

            conexion con = new conexion();
            int res = con.insert_user(numemp, nombre, correo, area, pass, status, isadmin, isuser);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Usuario registrado con exito",
                };
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
