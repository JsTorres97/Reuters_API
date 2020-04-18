using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class registra_movimientoController : ApiController
    {
        public List<string> Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;

            string cadena = cifrado.Base64Decode(id.ToString());
            string tipo, num_lugar, num_emp, id_horario;
            string[] datos = cadena.Split(',');
            //correo = ja[0]["CORREO"].ToString();
            //pass = ja[0]["PASS"].ToString();
            tipo = datos[0];
            num_lugar = datos[1];
            num_emp = datos[2];
            id_horario = datos[3];

            conexion con = new conexion();
            int res = con.registra_movimiento(tipo, num_lugar, num_emp, id_horario);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Operación registrada con exito",
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
