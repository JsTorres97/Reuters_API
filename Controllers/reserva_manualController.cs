using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reuters_api.Controllers
{
    public class reserva_manualController : ApiController
    {
        public List<string> Get(string id)
        {
            string cadena = cifrado.Base64Decode(id.ToString());
            string fecha, num_lugar, num_empleado, hora_e, hora_s;
            string[] datos = cadena.Split(',');
            fecha = datos[0];
            num_lugar = datos[1];
            num_empleado = datos[2];
            hora_e = datos[3];
            hora_s = datos[4];

            conexion con = new conexion();
            SqlDataReader dr = con.get_id_horario(hora_e, hora_s, fecha);
            List<String> lista = new List<string>();
            while (dr.Read())
            {
                string id_horario = dr[0].ToString();
                int k = con.inserta_reservacion_manual(num_lugar, num_empleado, id_horario);
                if(k == 2)
                {
                    lista.Add("ID_HORARIO: " + id_horario);
                    lista.Add("|");
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
