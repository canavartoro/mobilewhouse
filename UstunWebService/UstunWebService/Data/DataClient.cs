using UstunWebService.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

namespace UstunWebService.Data
{
    [DebuggerDisplay("IsConnected={IsConnected},Sql={SqlString}")]
    public class DataClient : IDataClient
    {
        private IDbCommand command = null;
        private IDbConnection connection = null;
        private string message = "";
        private Stopwatch stopwatch;
        private readonly object readonlyObject = new object();
        private DbProviderFactory providerFactory = null;
        private string connString = null, providerName = null;

        public string Message => message;

        public bool IsConnected => connection != null && connection.State == System.Data.ConnectionState.Open;

        public IDbConnection Connection => connection;

        public DatabaseType DBType => connection is OracleConnection ? DatabaseType.Oracle : DatabaseType.Postgre;

        public string SqlString { get; set; } = string.Empty;

        public DataClient()
        {
            Connect();
        }

        public DataClient(IDbConnection conn)
        {
            connection = conn;
            Connect();
        }

        public bool Connect()
        {
            try
            {
                lock (readonlyObject)
                {
                    if (string.IsNullOrWhiteSpace(connString) && System.Configuration.ConfigurationManager.ConnectionStrings["uyum"] != null)
                    {
                        if (!string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ProviderName))
                            providerName = System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ProviderName;
                        connString = System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ConnectionString;
                    }

                    if (providerFactory == null)
                        providerFactory = DbProviderFactories.GetFactory(providerName);

                    if (connection == null)
                    {
                        connection = providerFactory.CreateConnection();
                        connection.ConnectionString = connString;
                    }
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    if (command == null)
                        command = connection.CreateCommand();
                }
                return connection != null && connection.State == System.Data.ConnectionState.Open;
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
                return false;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Logger.E(exception);
                return false;
            }
        }

        public void Close()
        {
            try
            {
                if (command != null)
                {
                    command.Transaction?.Rollback();
                    command.Dispose();
                }

                if (connection != null)
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();

                    connection.Dispose();
                }
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Logger.E(exception);
            }
        }

        public IDataReader Select(string commandText, IDbDataParameter[] parameters)
        {
            SqlString = commandText;
            return Select(parameters);
        }
        public IDataReader Select(IDbDataParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = SqlString;

                if (parameters != null)
                {
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                return command.ExecuteReader();
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                ExecutionLog(0);
                command?.Parameters.Clear();
            }
            return null;
        }
        public IDataReader Select(string commandText)
        {
            SqlString = commandText;
            return Select((IDbDataParameter[])null);
        }
        public IDataReader Select()
        {
            return Select(SqlString, (IDbDataParameter[])null);
        }

        public List<T> Select<T>(string commandText, IDbDataParameter[] parameters)
        {
            List<T> list = null;
            try
            {

                if (!IsConnected && !Connect()) return null;

                command.CommandText = commandText;

                if (parameters != null)
                {
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                using (var dr = command.ExecuteReader())
                {
                    if (dr != null)
                    {
                        list = new List<T>();

                        var type = typeof(T);
                        var primitive = IsSimpleType(type);
                        var xmlschema = dr.GetSchemaTable();
                        while (dr.Read())
                        {
                            var newObject = default(T);
                            if (!primitive)
                            {
                                newObject = (T)Activator.CreateInstance(typeof(T));
                            }

                            if (xmlschema != null)
                            {
                                for (var column = 0; column < xmlschema.Rows.Count; column++)
                                {
                                    if (dr.IsDBNull(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])))
                                        continue;

                                    if (primitive)
                                    {
                                        if (type.IsAssignableFrom(dr
                                            .GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"]))
                                            .GetType()))
                                        {
                                            newObject = (T)Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), type);
                                        }
                                    }
                                    else
                                    {
                                        var property = type.GetProperty(xmlschema.Rows[column]["ColumnName"].ToString());
                                        if (property != null)
                                        {
                                            try
                                            {
                                                property.SetValue(newObject, Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), property.PropertyType), null);
                                            }
                                            catch (Exception e)
                                            {
                                                Logger.E(e);
                                            }
                                        }
                                    }
                                }
                            }

                            list.Add(newObject);
                        }
                    }
                }
                ExecutionLog(list?.Count ?? 0);
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                ExecutionLog(list?.Count ?? 0);
                command?.Parameters.Clear();
            }
            return list;
        }
        public List<T> Select<T>(string commandText)
        {
            return Select<T>(commandText, (IDbDataParameter[])null);
        }
        public List<T> Select<T>()
        {
            return Select<T>(SqlString, (IDbDataParameter[])null);
        }
        public object Select(Type type)
        {
            IList list = null;
            try
            {

                if (!IsConnected && !Connect()) return null;

                command.CommandText = SqlString;

                SqlStringLog();

                using (var dr = command.ExecuteReader())
                {
                    if (dr != null)
                    {
                        Type d1 = typeof(List<>);
                        list = (IList)Activator.CreateInstance(d1.MakeGenericType(type));
                        var primitive = IsSimpleType(type);
                        var xmlschema = dr.GetSchemaTable();
                        while (dr.Read())
                        {
                            object newObject = null;
                            if (!primitive)
                            {
                                newObject = Activator.CreateInstance(type);
                            }

                            if (xmlschema != null)
                            {
                                for (var column = 0; column < xmlschema.Rows.Count; column++)
                                {
                                    if (dr.IsDBNull(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])))
                                        continue;

                                    if (primitive)
                                    {
                                        if (type.IsAssignableFrom(dr
                                            .GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"]))
                                            .GetType()))
                                        {
                                            newObject = Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), type);
                                        }
                                    }
                                    else
                                    {
                                        var property = type.GetProperty(xmlschema.Rows[column]["ColumnName"].ToString());
                                        if (property != null)
                                        {
                                            try
                                            {
                                                //if (property.PropertyType.IsAssignableFrom(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])).GetType()))
                                                //{
                                                property.SetValue(newObject, Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), property.PropertyType), null);
                                                //}
                                            }
                                            catch (Exception e)
                                            {
                                                Logger.E(e);
                                            }
                                            //property.SetValue(newObject, dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), null);
                                        }
                                    }
                                }
                            }

                            list.Add(newObject);
                        }
                    }
                }
                ExecutionLog(list?.Count ?? 0);
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                ExecutionLog(list?.Count ?? 0);
                command?.Parameters.Clear();
            }
            return list;
        }

        public DataTable FillTable(string commandText, IDbDataParameter[] parameters)
        {
            SqlString = commandText;
            return FillTable(parameters);
        }
        public DataTable FillTable(IDbDataParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = SqlString;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                IDbDataAdapter adapter = providerFactory.CreateDataAdapter();
                adapter.SelectCommand = command;
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                DataTable table = dataSet?.Tables[0];
                ExecutionLog(table?.Rows.Count ?? 0);

                return table;
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command?.Parameters.Clear();
            }
            return null;
        }
        public DataTable FillTable(string commandText)
        {
            SqlString = commandText;
            return FillTable((OracleParameter[])null);
        }
        public DataTable FillTable()
        {
            return FillTable((OracleParameter[])null);
        }

        public bool Execute(string commandText, IDbDataParameter[] parameters)
        {
            SqlString = commandText;
            return Execute(parameters);
        }
        public bool Execute(IDbDataParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return false;

                command.CommandText = SqlString;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                int rowAffect = command.ExecuteNonQuery();

                ExecutionLog(rowAffect);

                return rowAffect > 0;
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command?.Parameters.Clear();
            }
            return false;
        }
        public bool Execute(string commandText)
        {
            SqlString = commandText;
            return Execute((OracleParameter[])null);
        }
        public bool Execute()
        {
            return Execute((OracleParameter[])null);
        }

        public object ExecuteScalar(string commandText, IDbDataParameter[] parameters)
        {
            SqlString = commandText;
            return ExecuteScalar(parameters);
        }
        public object ExecuteScalar(IDbDataParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.Parameters.Clear();
                command.CommandText = SqlString;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();
                return command.ExecuteScalar();
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                ExecutionLog(0);
                command?.Parameters.Clear();
            }
            return null;
        }
        public object ExecuteScalar(string commandText)
        {
            SqlString = commandText;
            return ExecuteScalar();
        }
        public object ExecuteScalar()
        {
            return ExecuteScalar((IDbDataParameter[])null);
        }

        public int Count(string sql)
        {
            return Count(sql, (IDbDataParameter[])null);
        }

        public int Count(string sql, IDbDataParameter[] parameters)
        {
            var obj = ExecuteScalar(sql, parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return -1;
        }

        #region Transaction
        public void Begin()
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Transaction = connection.BeginTransaction();
            }
            catch (DbException DbException)
            {
                message = DbException.Message;
                Logger.E(DbException);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }

        public void Commit()
        {
            try
            {
                command?.Transaction?.Commit();
            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }

        public void Rollback()
        {
            try
            {
                command?.Transaction?.Rollback();
            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        #region Parameters
        public IDbDataParameter CreateDbParameter(string name, object val)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                var param = command.CreateParameter();
                param.ParameterName = name;
                if (object.ReferenceEquals(val, null))
                    param.Value = DBNull.Value;
                else
                    param.Value = val;
                return param;
            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            return null;
        }
        public void AddParam(string name, object val)
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.Add(new OracleParameter(name, val));
            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        public void AddParam(string name, System.Data.DbType dbType, ParameterDirection direction)
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.Add(new OracleParameter() { ParameterName = name, DbType = dbType, Direction = direction });

            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        public void ClearParameters()
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.Clear();
            }
            catch (DbException exceed)
            {
                message = exceed.Message;
                Logger.E(exceed);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        public static implicit operator bool(DataClient data)
        {
            return data != null && data.IsConnected;
        }

        [DebuggerStepThrough()]
        private void SqlStringLog([CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            stopwatch = Stopwatch.StartNew();
            if (command != null)
            {
                if (command.Parameters.Count > 0)
                {
                    var sb = new StringBuilder();
                    foreach (IDataParameter prm in command.Parameters) sb.AppendFormat("\tName:{0},Value:{1}\t", prm.ParameterName, prm.Value);
                    Logger.I(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                }
                else
                {
                    Logger.I(string.Concat("Command:", command.CommandText, ", Caller: ", callerName, ", lineNumber : ", lineNumber));

                }
            }

        }

        [DebuggerStepThrough()]
        private void ExecutionLog(int rowaffected, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            stopwatch.Stop();
            Logger.I(string.Concat("Execution Row:", rowaffected, ", Time: ", stopwatch.Elapsed.Seconds, ", Caller: ", callerName, ", lineNumber : ", lineNumber));
        }

        [DebuggerStepThrough()]
        private bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                ((IList)new[]
                {
                    typeof(string),
                    typeof(decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }).Contains(type) ||
                type.IsEnum ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }


        #region IDisposable
        ~DataClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                command?.Dispose();

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }

                command = null;
                connection = null;
            }

            disposed = true;
        }



        #endregion
    }
}