using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    /// <summary>
    ///  Realiza la reservación con la asignación automática del lugar, con parametros desencriptados fecha, num_empleado, hora_e, hora_s
    /// </summary>
    public class reserva_automaticaController : ApiController
    {
        /// <summary>
        ///  Realiza la reservación con la asignación automática del lugar, con parametros desencriptados fecha, num_empleado, hora_e, hora_s
        /// </summary>
        /// <returns>
        /// código y mensaje:
        ///     1:Reservación exitosa
        ///     0:Devuelve los id de horario que no se pudieron reservar
        /// </returns>
        /// <param name="id">Cadena cifrada en base 64.</param>
        public List<string> Get(string id)
        {
            string cadena = cifrado.Base64Decode(id.ToString());
            string fecha, num_empleado, hora_e, hora_s;
            string[] datos = cadena.Split(',');
            fecha = datos[0];
            num_empleado = datos[1];
            hora_e = datos[2];
            hora_s = datos[3];
            string num_lugar="";
            conexion con = new conexion();
            SqlDataReader dr2 = con.lugar_aleatorio();
            while (dr2.Read())
            {
                num_lugar = dr2[0].ToString();
            }
            SqlDataReader dr = con.get_id_horario(hora_e, hora_s, fecha);
            List<String> lista = new List<string>();
            while (dr.Read())
            {
                string id_horario = dr[0].ToString();
                //INSERTA EN MOVIMIENTOS
                SqlDataReader dr1 = con.inserta_reservacion_manual(num_lugar, num_empleado, id_horario);
                while (dr1.Read())
                {
                    if (dr1[0].ToString().Equals("0"))
                    {
                        lista.Add("ID_HORARIO: " + id_horario);
                        lista.Add("|");
                    }
                }

            }
            if ((lista != null) && (!lista.Any()))
            {
                lista.Add("codigo: 1");
                lista.Add("Reservación exitosa");
            }
            return lista;
        }
    }
}
