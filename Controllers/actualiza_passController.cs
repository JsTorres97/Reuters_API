using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class actualiza_passController : ApiController
    {
        public List<string> Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;

            string cadena = cifrado.Base64Decode(id.ToString());
            string num_emp, pass;
            string[] datos = cadena.Split(',');
            //correo = ja[0]["CORREO"].ToString();
            //pass = ja[0]["PASS"].ToString();
            num_emp = datos[0];
            pass = datos[1];

            conexion con = new conexion();
            int res = con.actualiza_pass(num_emp, pass);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Contraseña actualizada con exito",
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
