using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using PalcoNet.Generar_Publicacion;

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

        //Conversion de string a filtro de busqueda necesario
        public static class Filtro
        {
            public static string Libre(string var)
            {
                return "LIKE '%" + var + "%'";
            }
            public static string Exacto(string var)
            {
                return " = '" + var + "'";
            }
            public static string Distinto(string var)
            {
                return " != '" + var + "'";
            }
            public static string Between(string menor, string mayor)
            {
                return "BETWEEN " + menor + " AND " + mayor;
            }
            public static string MenorIgual(string valor)
            {
                return "<= " + valor;
            }

            internal static string MayorIgual(string valor)
            {
                return ">= " + valor;
            }
        }

        //Nombres de tablas basicas de la BD
        public static class Tabla
        {
            public static string Cliente { get { return "ESKHERE.[Cliente]"; } }
            public static string Compra { get { return "[ESKHERE].[Compra]"; } }
            public static string Grado { get { return "ESKHERE.[Publicacion_Grado]"; } }
            public static string Estado { get { return "ESKHERE.[Publicacion_Estado]"; } }
            public static string Empresa { get { return "ESKHERE.[Empresa]"; } }
            public static string Rol { get { return "ESKHERE.[Rol]"; } }
            public static string Funcion { get { return "ESKHERE.[funcion]"; } }
            public static string RolXFuncion { get { return "ESKHERE.[Rol_X_Funcion]"; } }
            public static string UsuarioXRol { get { return "ESKHERE.[rol_x_usuario]"; } }
            public static string Usuario { get { return "ESKHERE.[Usuario]"; } }
            public static string Factura { get { return "ESKHERE.[Factura]"; } }
            public static string Premios { get { return "ESKHERE.[Premios]"; } }
            public static string Vobtener_Puntos_cliente { get { return "[ESKHERE].obtener_Puntos_cliente"; } }
            public static string Puntos { get { return "ESKHERE.[Puntos]"; } }
            public static string PremiosPorCliente { get { return "[ESKHERE].PremiosPorCliente"; } }
            public static string CostoPremio { get { return "[ESKHERE].CostoPremio"; } }
            public static string Cliente_Premio { get { return "[ESKHERE].[cliente_premio]"; } }
            public static string Publicacion { get { return "ESKHERE.[Publicacion]"; } }
            public static string PublicacionFechas { get { return "ESKHERE.[Publicacion_Fechas]"; } }
            public static string Ubicacion { get { return "ESKHERE.[Ubicacion]"; } }
            public static string AniosQueSePublicaron { get { return "[ESKHERE].anios_que_se_publicaron_espectaculos"; } }
            public static string CliMayorCantCompras { get { return "[ESKHERE].clientes_con_mayor_cantidad_de_compras"; } }
            public static string CliMayorPtosVencidos { get { return "[ESKHERE].clientes_con_mayores_ptos_vencidos"; } }
            public static string EmpMayorCantUbiSinVender { get { return "[ESKHERE].empresas_con_mayor_cant_de_ubicaciones_sin_vender"; } }
            public static string AnioMinimo { get { return "[ESKHERE].anios_minimo_de_publicacion"; } }
            public static string HistorialCompras { get { return "[ESKHERE].Historial_Compras"; } }
            public static string FuncionesUsuarios { get { return "[ESKHERE].funciones_usuarios"; } }
            public static string RolesUsuario { get { return "[ESKHERE].Roles_usuario"; } }
            public static string Rubros { get { return "[ESKHERE].rubros"; } }
            public static string PublicacionesParaListar { get { return "[ESKHERE].Publicaciones_disponibles_para_listar"; } }
            public static string UbicacionesParaListar { get { return "[ESKHERE].Ubicaciones_por_publi_disponibles"; } }
            public static string idDelCliente { get { return "[ESKHERE].idClientexNombreUsuario_y_numTarjeta_para_compra"; } }
            public static string TipoUbicacion { get { return "[ESKHERE].Tipo_Ubicacion"; } }
            public static string CodigoPublicacion { get { return "[ESKHERE].Codigo_Publicacion"; } }
        }

        private string PonerFiltros(string comando, Dictionary<string, string> filtros)
        {
            comando += " WHERE ";
            foreach (KeyValuePair<string, string> entry in filtros)
            {
                comando += entry.Key + " " + entry.Value + " AND ";

            }
            comando = comando.Substring(0, comando.Length - 4);
            return comando;
        }


        //Recibe el nombre de la tabla sacada de Conexion.Tabla, y un diccionario con el par 
        //("nombre de columna en BD", dato a insertar)
        //retorna true si se pudo realizar, false si fallo
        public int Insertar(string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoInsert) + tabla + " (";
                data.Keys.ToList().ForEach(k => comandoString += k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                data.Keys.ToList().ForEach(k => comandoString += "@" + k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + "); SELECT SCOPE_IDENTITY();";
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
                            command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                        }
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

        }

        //Recibe el id de la fila, nombre de la tabla sacada de Conexion.Tabla, y 
        //un diccionario con el par ("nombre de columna en BD", dato a insertar
        //retorna true si se pudo realizar, false si fallo
        public bool Modificar(int pk, string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoUpdate) + tabla + " SET ";
                foreach (KeyValuePair<string, object> entry in data)
                {
                    comandoString += entry.Key + " = @" + entry.Key + ", ";
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
                            command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
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

        //Recibe el nombre de la tabla de Conexion.Tabla, el dataGrid POR REFERENCIA, y los filtros de busqueda sacados 
        //de Conexion.Filtro 
        public void LlenarDataGridView(string tabla, ref DataGridView dataGrid, Dictionary<string, string> filtros)
        {
            dataGrid.DataSource = conseguirTabla(tabla, filtros);
        }

        public DataTable conseguirTabla(string tabla, Dictionary<string, string> filtros)
        {
            string comandoString = string.Copy(comandoSelect) + " * FROM " + tabla;
            if (filtros != null && filtros.Count > 0)
                comandoString = PonerFiltros(comandoString, filtros);
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

                    return dtRecord;
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
                    if (resultado)
                        contraseñaAutogenerada = Convert.ToBoolean(command.Parameters["@autogenerada"].Value);
                    return resultado;
                }
            }
        }

        public bool eliminarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
        {
            string comando = "DELETE FROM " + tabla + " WHERE " + col1 + "= @pk1 AND " + col2 + " = @pk2";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = comando;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@pk1", pk1);
                        command.Parameters.AddWithValue("@pk2", pk2);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int InsertarUsuario(string usuario, string contraseña, string rol)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "[ESKHERE].insertar_usuario";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("@usuario", SqlDbType.NVarChar);
                        parameter1.Direction = ParameterDirection.Input;
                        parameter1.Value = usuario;
                        SqlParameter parameter2 = new SqlParameter("@contrasenia", SqlDbType.NVarChar);
                        parameter2.Direction = ParameterDirection.Input;
                        parameter2.Value = contraseña;
                        SqlParameter parameter3 = new SqlParameter("@nombreTipo", SqlDbType.NVarChar);
                        parameter3.Direction = ParameterDirection.Input;
                        parameter3.Value = rol;
                        SqlParameter retorno = new SqlParameter("@ReturnVal", SqlDbType.Int);
                        retorno.Direction = ParameterDirection.ReturnValue;

                        command.Parameters.Add(parameter1);
                        command.Parameters.Add(parameter2);
                        command.Parameters.Add(parameter3);
                        command.Parameters.Add(retorno);

                        command.ExecuteNonQuery();
                        return Convert.ToInt32(retorno.Value);
                    }
                    catch (SqlException)
                    {
                        return -1;
                    }

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
                    parameter1.Size = 20;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Output;
                    parameter2.Size = 5;
                    SqlParameter parameter3 = new SqlParameter("@id", SqlDbType.Int);
                    parameter3.Direction = ParameterDirection.Output;
                    SqlParameter parameter4 = new SqlParameter("@nombre", SqlDbType.NVarChar);
                    parameter4.Direction = ParameterDirection.Input;
                    parameter4.Value = nombre;
                    SqlParameter parameter5 = new SqlParameter("@apellido", SqlDbType.NVarChar);
                    parameter5.Direction = ParameterDirection.Input;
                    parameter5.Value = apellido;

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

        public bool ActualizarContraseña(string contraseña, string usuario)
        {
            string comando = string.Copy(comandoUpdate) + Tabla.Usuario + " SET contrasenia = @contrasenia, contrasena_autogenerada = 0 WHERE usuario = @ usuario";
            try
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@contrasenia", contraseña);
                        command.Parameters.AddWithValue("@usuario", usuario);

                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool existeRegistro(string tabla, List<string> columnas, Dictionary<string, string> filtros)
        {
            var datos = ConsultaPlana(tabla, columnas, filtros);
            return (datos[columnas[0]].Count > 0);
        }

        private void cambiarHabilitacion(string tabla, int id, string cambio)
        {
            string comandoString = string.Copy(comandoUpdate) + tabla + " SET habilitado = " + cambio + " WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void deshabilitar(string tabla, int id)
        {
            cambiarHabilitacion(tabla, id, "0");
        }

        public void habilitar(string tabla, int id)
        {
            cambiarHabilitacion(tabla, id, "1");
        }

        private Dictionary<string, List<object>> HacerDictinary(List<string> colum)
        {
            Dictionary<string, List<object>> retorno = new Dictionary<string, List<object>>();
            colum.ForEach(c => retorno.Add(c.Split(' ').Last(), new List<object>()));
            return retorno;
        }


        //Recibe el nombre de la tabla sacado de Conexion.Tabla, una lista de strings con los nombres de las columnas a buscar
        //y un diccionario con el par ("nombre de columna", valor) como filtro. Si no se quiere filtrar, se pasa null.
        //Retorna un diccionario con el par ("nombre de columna", lista de valores retornados)
        public Dictionary<string, List<object>> ConsultaPlana(string tabla, List<string> columnas, Dictionary<string, string> filtros)
        {
            Dictionary<string, List<object>> retorno = HacerDictinary(columnas);

            string comandoString = string.Copy(comandoSelect);

            columnas.ForEach(c => comandoString += c + ", ");
            comandoString = comandoString.Substring(0, comandoString.Length - 2);

            comandoString += " FROM " + tabla;
            if (filtros != null && filtros.Count > 0)
                comandoString = PonerFiltros(comandoString, filtros);

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;

                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                        columnas.ForEach(c => retorno[c.Split(' ').Last()].Add(reader[c.Split(' ').Last()]));
                }
            }
            return retorno;
        }

        public bool InsertarPublicaciones(int id_empresa, List<Generar_Publicacion.Publicacion> publicacion, List<DateTime> fechas, List<Generar_Publicacion.UbicacionIndividual> ubicaciones)
        {
            string comandoStringFecha = string.Copy(comandoInsert)
                + "ESKHERE.[Publicacion_Fechas] (fpublicacion, ffuncion) values (@fpublicacion, @ffuncion); SELECT SCOPE_IDENTITY()";

            string comandoStringPublicacion = string.Copy(comandoInsert) + Tabla.Publicacion
                + " (codigo, descripcion, publicacion_rubro, id_empresa_publicante, id_fecha, id_grado, id_estado) " +
                "VALUES (@codigo, @descripcion, @publicacion_rubro, @id_empresa_publicante, @id_fecha, @id_grado, @id_estado); SELECT SCOPE_IDENTITY()";

            string comandoStringUbicacion = string.Copy(comandoInsert) + "ESKHERE.[Ubicacion] " +
                "(ubicacion_fila, ubicacion_asiento, tipo, precio, ubicacion_sin_numerar, ubicacion_tipo_descripcion, id_publicacion) " +
                "values (@ubicacion_fila, @ubicacion_asiento, @tipo, @precio, @ubicacion_sin_numerar, @ubicacion_tipo_descripcion, @id_publicacion)";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Transaction = tr;
                    try
                    {
                        command.Parameters.AddWithValue("@fpublicacion", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@ffuncion", SqlDbType.NVarChar);

                        command.Parameters.AddWithValue("@codigo", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@descripcion", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@publicacion_rubro", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@id_empresa_publicante", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@id_fecha", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@id_grado", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@id_estado", SqlDbType.NVarChar);

                        command.Parameters.AddWithValue("@ubicacion_fila", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@ubicacion_asiento", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@tipo", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@precio", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@ubicacion_sin_numerar", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@ubicacion_tipo_descripcion", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@id_publicacion", SqlDbType.NVarChar);


                        for (int i = 0; i < publicacion.Count; i++)
                        {
                            command.CommandText = comandoStringFecha;
                            command.Parameters["@fpublicacion"].Value = fechas[i];
                            command.Parameters["@ffuncion"].Value = ConfigurationHelper.fechaActual;
                            int id = Convert.ToInt32(command.ExecuteScalar());

                            command.CommandText = comandoStringPublicacion;
                            command.Parameters["@id_fecha"].Value = id;
                            command.Parameters["@codigo"].Value = publicacion[i].codigo;
                            command.Parameters["@descripcion"].Value = publicacion[i].descripcion;
                            command.Parameters["@publicacion_rubro"].Value = publicacion[i].rubro;
                            command.Parameters["@id_empresa_publicante"].Value = id_empresa;
                            command.Parameters["@id_fecha"].Value = id;
                            command.Parameters["@id_grado"].Value = publicacion[i].grado;
                            command.Parameters["@id_estado"].Value = publicacion[i].estado;
                            id = Convert.ToInt32(command.ExecuteScalar());

                            command.CommandText = comandoStringUbicacion;
                            foreach (Generar_Publicacion.UbicacionIndividual u in ubicaciones)
                            {
                                command.Parameters["@ubicacion_fila"].Value = u.fila;
                                command.Parameters["@ubicacion_asiento"].Value = u.asiento;
                                command.Parameters["@tipo"].Value = u.tipo;
                                command.Parameters["@precio"].Value = u.precio;
                                command.Parameters["@ubicacion_sin_numerar"].Value = u.ubicacionSinNumerar;
                                command.Parameters["@ubicacion_tipo_descripcion"].Value = u.tipoDescripcion;
                                command.Parameters["@id_publicacion"].Value = id;

                                command.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        string a = e.StackTrace;
                        tr.Rollback();
                        return false;
                    }

                }
            }
        }

        public bool InsertarCompras(string id_Cliente, string cantidad, string formaPago, List<string> ubicaciones)
        {

            string comandoStringCompras = string.Copy(comandoInsert) + Tabla.Compra
                + " ([Fecha] ,[Compra_Cantidad],[Forma_Pago_Desc],[ID_Cliente],[ID_Ubicacion]) " +
                "VALUES (@fecha, @cantidad, @formaPagoDesc, @idCliente, @idUbicacion); SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Transaction = tr;
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@cantidad", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@formaPagoDesc", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@idCliente", SqlDbType.NVarChar);
                        command.Parameters.AddWithValue("@idUbicacion", SqlDbType.NVarChar);

                        for (int i = 0; i < ubicaciones.Count; i++)
                        {
                            command.CommandText = comandoStringCompras;

                            command.Parameters["@fecha"].Value = ConfigurationHelper.fechaActual;
                            command.Parameters["@cantidad"].Value = cantidad;
                            command.Parameters["@formaPagoDesc"].Value = formaPago;
                            command.Parameters["@idCliente"].Value = id_Cliente;
                            command.Parameters["@idUbicacion"].Value = ubicaciones[i];

                            command.ExecuteNonQuery();
                        
                        }
                        tr.Commit();
                    return true;
                }
                    catch (SqlException e)
                {
                    string a = e.StackTrace;
                    tr.Rollback();
                    return false;
                }

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
