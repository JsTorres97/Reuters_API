using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reuters_api
{
    public class conexion
    {
        string ConnectionString = "Data Source=localhost; Initial Catalog=Reuters; User=sa; pwd=Marzo*2020";

        SqlConnection con;
        
        public void OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
        public SqlDataReader login_check(string correo, string pass)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("login_check", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
            cmd.Parameters.Add(new SqlParameter("@PASS", pass));
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int insert_user(string num, string nombre, string correo, string area, string pass, string status, string isadmin, string isuser)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("insert_users", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", num));
            cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
            cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
            cmd.Parameters.Add(new SqlParameter("@AREA", area));
            cmd.Parameters.Add(new SqlParameter("@PASS", pass));
            cmd.Parameters.Add(new SqlParameter("@STATUS", status));
            cmd.Parameters.Add(new SqlParameter("@ISADMIN", isadmin));
            cmd.Parameters.Add(new SqlParameter("@ISUSER", isuser));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public int insert_hotdesk(string status, string prioridad)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("insert_lugares", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@STATUS", status));
            cmd.Parameters.Add(new SqlParameter("@PRIORIDAD", prioridad));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public int cambia_status_hotdesk(string numero_lugar, string status)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("update_status_hotdesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUM_LUGAR", numero_lugar));
            cmd.Parameters.Add(new SqlParameter("@STATUS", status));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public SqlDataReader get_lugares()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("total_lugares", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader get_usuario()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("total_usuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader get_hot_desk_disponibles()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("hot_desk_disponibles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader get_usuarios_en_la_oficina()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("usuarios_en_la_oficina", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader get_usuarios_activos()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("usuarios_activos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader get_proximas_reservaciones(string num_emp)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("proximas_reservaciones", con);
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", num_emp));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int registra_movimiento(string tipom, string num_lugar, string num_emp, string id_horario)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("insert_movimientos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TIPO", tipom));
            cmd.Parameters.Add(new SqlParameter("@NUMERO_LUGAR", num_lugar));
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", num_emp));
            cmd.Parameters.Add(new SqlParameter("@ID_HORARIO", id_horario));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}