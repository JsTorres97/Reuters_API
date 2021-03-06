﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reuters_api
{
    /// <summary>
    /// Clase que ejecuta todas las funciones relacionadas con la base de datos
    /// </summary>
    public class conexion
    {
        string ConnectionString = "Data Source=localhost; Initial Catalog=Reuters; User=sa; pwd=Marzo*2020";

        SqlConnection con;
        /// <summary>
        /// Abre la conexión
        /// </summary>
        public void OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        /// <summary>
        /// Cierra la conexión
        /// </summary>
        public void CloseConnection()
        {
            con.Close();
        }
        /// <summary>
        /// Ejecuta el SP login_check
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con los datos del usuario
        /// </returns>
        /// <param name="correo">correo del usuario.</param>
        /// <param name="pass">password del usuario.</param>
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
        /// <summary>
        /// Ejecuta el SP insert_users
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="num">Número de empleado.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="correo">Correo del usuario.</param>
        /// <param name="area">Área del usuario.</param>
        /// <param name="pass">Contraseña del usuario.</param>
        /// <param name="status">Estatus del usuario.</param>
        /// <param name="isadmin">1:Si es administrador, 0:Si no es administrador.</param>
        /// <param name="isuser">1:Si es usuario, 0:Si no es usuario.</param>
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
        /// <summary>
        /// Ejecuta el SP insert_lugares
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="status">Estatus actual.</param>
        /// <param name="prioridad">Prioridad a asignar.</param>
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
        /// <summary>
        /// Ejecuta el SP update_status_hotdesk
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="numero_lugar">Número de lugar a actualizar.</param>
        /// <param name="status">Estatus a para cambiar.</param>
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
        /// <summary>
        /// Ejecuta el SP update_status_empleado
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="numero_usuario">Número de usuario.</param>
        public int cambia_status_usuario(string numero_usuario)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("update_status_empleado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", numero_usuario));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// Ejecuta el SP id_tbl_horario
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con los datos del usuario
        /// </returns>
        /// <param name="hora_e">Hora de entrada.</param>
        /// <param name="hora_s">Hora de salida.</param>
        /// <param name="fecha">Fecha.</param>
        public SqlDataReader get_id_horario(string hora_e, string hora_s, string fecha)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("id_tbl_horario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@HORA_E", hora_e));
            cmd.Parameters.Add(new SqlParameter("@HORA_S", hora_s));
            cmd.Parameters.Add(new SqlParameter("@FECHA", fecha));
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP todos_los_usuarios
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con los datos del usuario
        /// </returns>
        public SqlDataReader get_todos_usuarios()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("todos_los_usuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP update_usuario_password
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="numero_usuario">Número de usuario.</param>
        /// <param name="pass">Contraseña del usuario.</param>
        public int actualiza_pass(string numero_usuario, string pass)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("update_usuario_password", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", numero_usuario));
            cmd.Parameters.Add(new SqlParameter("@NEW_PASS", pass));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// Ejecuta el SP insert_reservacion_manual
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con los datos del insert
        /// </returns>
        /// <param name="numero_lugar">Número de lugar.</param>
        /// <param name="num_usuario">Número de usuario.</param>
        /// <param name="id_horario">ID de horario.</param>
        public SqlDataReader inserta_reservacion_manual(string  numero_lugar, string num_usuario, string id_horario)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("insert_reservacion_manual", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_LUGAR", numero_lugar));
            cmd.Parameters.Add(new SqlParameter("@NUM_EMPLEADO", num_usuario));
            cmd.Parameters.Add(new SqlParameter("@ID_HORARIO", id_horario));
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP select_todo_tbl_lugares
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con los números de lugar
        /// </returns>
        public SqlDataReader get_num_lugar()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("select_todo_tbl_lugares", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP select_lugar_automatico
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con un lugar aleatorio
        /// </returns>
        public SqlDataReader lugar_aleatorio()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("select_lugar_automatico", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP update_prioridad_lugar
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="lugar">Número de lugar.</param>
        public int update_prioridad(string lugar)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("update_prioridad_lugar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_LUGAR", lugar));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// Ejecuta el SP cancela_reservacion
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="numero_reservacion">Número de lugar.</param>
        public int cancela_reservacion(string numero_reservacion)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("cancela_reservacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUM_RESERVACION", numero_reservacion));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// Ejecuta el SP modificar_reservacion
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="numero_reservacion">Número de lugar.</param>
        /// <param name="nuevo_id">Número de reservación.</param>
        public int modifica_reservacion(string numero_reservacion, string nuevo_id)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("modificar_reservacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NUMERO_RESERVACION", numero_reservacion));
            cmd.Parameters.Add(new SqlParameter("@NUEVO_ID", nuevo_id));
            int i;
            i = cmd.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// Ejecuta el SP total_lugares
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con todos los lugares
        /// </returns>
        public SqlDataReader get_lugares()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("total_lugares", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP total_usuarios
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con todos los usuarios
        /// </returns>
        public SqlDataReader get_usuario()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("total_usuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP hot_desk_disponibles
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con un lugar aleatorio
        /// </returns>
        public SqlDataReader get_hot_desk_disponibles()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("hot_desk_disponibles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP usuarios_en_la_oficina
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con un los usuarios activos en la oficina
        /// </returns>
        public SqlDataReader get_usuarios_en_la_oficina()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("usuarios_en_la_oficina", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP usuarios_activos
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con un los usuarios activos en la oficina
        /// </returns>
        public SqlDataReader get_usuarios_activos()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("usuarios_activos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP proximas_reservaciones
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con las próximas reservaciones
        /// </returns>
        /// <param name="num_emp">Número de empleado.</param>
        public SqlDataReader get_proximas_reservaciones(string num_emp)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("proximas_reservaciones", con);
            cmd.Parameters.Add(new SqlParameter("@NUMERO_EMPLEADO", num_emp));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Ejecuta el SP insert_movimientos
        /// </summary>
        /// <returns>
        /// i:Número de columnas insertadas
        /// </returns>
        /// <param name="tipom">Tipo de movimiento.</param>
        /// <param name="num_lugar">Número de lugar.</param>
        /// <param name="num_emp">Número de empleado.</param>
        /// <param name="id_horario">ID de horario.</param>
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
        /// <summary>
        /// Ejecuta el SP select_all_tbl_lugares
        /// </summary>
        /// <returns>
        /// dr: SqlDataReader, con todos los lugares
        /// </returns>
        public SqlDataReader get_todos_lugares()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("select_all_tbl_lugares", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}