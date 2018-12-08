﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dapper;

namespace PalcoNet
{
    public class Conexion
    {
        private static Conexion instance = null;
        protected const string comandoInsert = "INSERT INTO ";
        protected const string comandoUpdate = "UPDATE ";
        protected const string comandoSelect = "SELECT ";
        private static string conectionString = ConfigurationHelper.ConnectionString;

        protected Conexion() { }

        public static Conexion getInstance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        public static class Filtro
        {
            public static string Libre(string var)
            {
                return $"LIKE '%{var}%'";
            }
            public static string Exacto(string var)
            {
                return $" = '{var}'";
            }
        }

        public static class Tabla
        {
            public static string Cliente { get { return "ESKHERE.[Cliente]"; } }
            public static string Grado { get { return "ESKHERE.[Publicacion_Grado]"; } }
            public static string Empresa { get { return "ESKHERE.[Empresa]"; } }
            public static string Rol { get { return "ESKHERE.[Rol]"; } }
        }

        protected string ponerFiltros(string comando, Dictionary<string, string> filtros)
        {
            foreach (KeyValuePair<string, string> entry in filtros)
            {
                comando += $"{entry.Key} {entry.Value} AND ";
            }
            comando = comando.Substring(0, comando.Length - 4);
            return comando;
        }

        public bool Insertar(string tabla, Dictionary<string, object> data)
        {

            try
            {
                string comandoString = string.Copy(comandoInsert) + $" {tabla} (";
                data.Keys.ToList().ForEach(k => comandoString += $"{k}, ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                data.Keys.ToList().ForEach(k => comandoString += $"@{k}, ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ")";
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = comandoString;
                        foreach (KeyValuePair<string, object> entry in data)
                        {
                            command.Parameters.AddWithValue($"@{entry.Key}", entry.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Modificar(int pk, string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoUpdate) + $" {tabla} SET ";
                foreach (KeyValuePair<string, object> entry in data)
                {
                    comandoString += $"{entry.Key} = @{entry.Key}, ";
                }
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + " WHERE id = @id";
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = comandoString;
                        command.Parameters.AddWithValue("@id", pk);
                        foreach (KeyValuePair<string, object> entry in data)
                        {
                            command.Parameters.AddWithValue($"@{entry.Key}", entry.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                string a = e.StackTrace;
                return false;
            }
            return true;
        }

        public void LlenarDataGridView(string tabla, ref DataGridView dataGrid, Dictionary<string, string> filtros)
        {
            string comandoString = comandoSelect + $" * FROM {tabla} WHERE ";
            comandoString = ponerFiltros(comandoString, filtros);
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = comandoString;
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);
                    dataGrid.DataSource = dtRecord;
                }
            }
        }

        public bool ValidarLogin(string usuario, string contraseña, ref bool contraseñaAutogenerada)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[ESKHERE].existe_usuario";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = usuario;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = contraseña;
                    SqlParameter parameter3 = new SqlParameter("@resultado", SqlDbType.Bit);
                    parameter3.Direction = ParameterDirection.Output;
                    SqlParameter parameter4 = new SqlParameter("@autogenerada", SqlDbType.Bit);
                    parameter4.Direction = ParameterDirection.Output;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                    bool resultado = Convert.ToBoolean(command.Parameters["@resultado"].Value);
                    if(resultado)
                        contraseñaAutogenerada = Convert.ToBoolean(command.Parameters["@autogenerada"].Value);
                    return resultado;
                }
            }
        }

        public int GenerarUsuarioAleatorio(string nombre, string apellido, ref string usuario, ref string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[ESKHERE].crear_usuario_aleatorio";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Output;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Output;
                    SqlParameter parameter3 = new SqlParameter("@id", SqlDbType.Int);
                    parameter3.Direction = ParameterDirection.Output;
                    SqlParameter parameter4 = new SqlParameter("@nombre", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = nombre;
                    SqlParameter parameter5 = new SqlParameter("@apellido", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = apellido;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);
                    command.Parameters.Add(parameter5);

                    command.ExecuteNonQuery();

                    usuario = Convert.ToString(command.Parameters["@Usuario"].Value);
                    contraseña = Convert.ToString(command.Parameters["@Contrasenia"].Value);
                    return Convert.ToInt32(command.Parameters["@id"].Value);
                }
            }
        }
    }
}

   /* public class Conexion<T> : Conexion
    {
        private static Conexion<T> instance = null;
        private IDbConnection connection;

        private Conexion() : base()
        {
            connection = sqlconection;
        }

        public static Conexion<T> GetInstance()
        {
            if (instance == null)
                instance = new Conexion<T>();
            return instance;
        }

        public List<T> consultaPlana(string tabla, List<string> columnas)
        {
            string comando = string.Copy(comandoSelect);
            columnas.ForEach(c => comando += $"{c}, ");
            comando = comando.Substring(0, comando.Length - 2) + $"FROM {tabla}";
            return connection.Query<T>(comando).ToList();
        }

        public List<T> consultaPlana(string tabla, List<string> columnas, Dictionary<string, string> filtros)
        {
            string comando = string.Copy(comandoSelect);
            columnas.ForEach(c => comando += $"{c}, ");
            comando = comando.Substring(0, comando.Length - 2) + $"FROM {tabla}";
            if(filtros.Count>0)
            {
                comando += " WHERE ";
                comando = ponerFiltros(comando, filtros);
            }
            return connection.Query<T>(comando).ToList();
        }
    }
}
*/