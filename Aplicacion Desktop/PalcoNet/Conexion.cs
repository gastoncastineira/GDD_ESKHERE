using System;
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
        private static string conectionString = ConfigurationManager.AppSettings["conexion"];
        protected SqlConnection sqlconection = new SqlConnection(conectionString);

        protected Conexion(){}

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
                return $"LIKE %{var}%";
            }
            public static string Exacto(string var)
            {
                return $" = {var}";
            }
        }

        public static class Tabla
        {
            public static string Cliente { get { return "Cliente"; } }
            public static string Grado { get { return "Grado"; } }
            public static string Empresa { get { return "Empresa"; } }
            public static string Rol { get { return "Rol"; } }
        }
        
        protected string ponerFiltros(string comando, Dictionary<string,string> filtros)
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
                data.Values.ToList().ForEach(k => comandoString += $"@{k.ToString()}, ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ");";
                SqlCommand command = new SqlCommand(comandoString, sqlconection);
                data.Values.ToList().ForEach(k => command.Parameters.AddWithValue($"@{k.ToString()}", k));
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        public bool Modificar(string pk, string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoUpdate) + $" '{tabla}' SET ";
                foreach(KeyValuePair<string, object> entry in data)
                {
                    comandoString += $"{entry.Key} = @{entry.Value.ToString()}, ";
                }
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + " WHERE id = @id";
                SqlCommand command = new SqlCommand(comandoString, sqlconection);
                data.Values.ToList().ForEach(k => command.Parameters.AddWithValue($"@{k.ToString()}", k));
                command.Parameters.AddWithValue("@id", pk);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void LlenarDataGridView(string tabla, ref DataGridView dataGrid, Dictionary<string, string> filtros)
        {
            string comandoString = comandoSelect + $" * FROM {tabla} WHERE ";
            comandoString = ponerFiltros(comandoString, filtros);       
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlconection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = comandoString;
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGrid.DataSource = dtRecord;
        }
    }

    public class Conexion<T> : Conexion
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
