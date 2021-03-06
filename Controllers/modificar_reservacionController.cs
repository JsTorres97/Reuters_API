﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    /// Modifica la reservación, con parametros desencriptados número de reservación y el nuevo id de horario
    /// </summary>
    public class modificar_reservacionController : ApiController
    {
        /// <summary>
        /// Modifica la reservación, con parametros desencriptados número de reservación y el nuevo id de horario
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Reservación actualizada con exito
        ///     0:Existe un error, intentalo de nuevo
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {
            //JArray ja = JArray.Parse(id) as JArray;

            string cadena = cifrado.Base64Decode(id.ToString());
            string num_reservacion, nuevo_id;
            string[] datos = cadena.Split(',');
            //correo = ja[0]["CORREO"].ToString();
            //pass = ja[0]["PASS"].ToString();
            num_reservacion = datos[0];
            nuevo_id = datos[1];

            conexion con = new conexion();
            int res = con.modifica_reservacion(num_reservacion, nuevo_id);
            if (res != 0)
            {
                return new List<string>
                {
                    "codigo: 1",
                    "mensaje: Reservación actualizada con exito",
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
