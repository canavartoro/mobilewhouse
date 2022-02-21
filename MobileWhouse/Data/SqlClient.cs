using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using MobileWhouse.Log;
using System.Reflection;
using System.Collections;

namespace MobileWhouse.Data
{
    public class SqlClient : IDisposable
    {
        private Stopwatch stopwatch;
        private SqlCommand command = null;
        private SqlConnection connection = null;
        private string message = "";
        private string sqlString = string.Empty;

        public string Message
        {
            get
            {
                return message;
            }
        }

        public bool IsConnected
        {
            get
            {
                return connection != null && connection.State == System.Data.ConnectionState.Open;
            }
        }

        public string SqlString
        {
            get { return sqlString; }
            set { sqlString = value; }
        }

        public SqlClient() { }

        public bool Connect()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(Statics.SqlConnectionString);
                }
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                if (command == null)
                    command = connection.CreateCommand();

                return connection != null && connection.State == System.Data.ConnectionState.Open;
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
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
                    if (command.Transaction != null)
                        command.Transaction.Rollback();
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

        public SqlDataReader Select(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return Select(parameters);
        }
        public SqlDataReader Select(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;

                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                return command.ExecuteReader();
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                if (command != null)
                    command.Parameters.Clear();
            }
            return null;
        }
        public SqlDataReader Select(string commandText)
        {
            SqlParameter[] parameters = null;
            SqlString = commandText;
            return Select(parameters);
        }

        public List<T> Select<T>(string commandText)
        {
            sqlString = commandText;
            return Select<T>();
        }
        public List<T> Select<T>()
        {
            List<T> list = null;
            try
            {

                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;

                SqlStringLog();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr != null)
                    {
                        list = new List<T>();
                        Type type = typeof(T);
                        var primitive = IsSimpleType(type);
                        //PropertyInfo[] pInfo = type.GetProperties();
                        DataTable tblschema = dr.GetSchemaTable();
                        while (dr.Read())
                        {
                            object newObject = null;
                            if (!primitive)
                            {
                                newObject = Activator.CreateInstance(type);
                            }
                            for (int clmn = 0; clmn < tblschema.Rows.Count; clmn++)
                            {
                                if (primitive)
                                {
                                    if (type.IsAssignableFrom(dr
                                        .GetValue(0)
                                        .GetType()))
                                    {
                                        newObject = Convert.ChangeType(dr.GetValue(0), type, null);
                                    }
                                }
                                else
                                {

                                    PropertyInfo property = type.GetProperty(tblschema.Rows[clmn]["ColumnName"].ToString());
                                    if (property != null)
                                    {
                                        //property.SetValue(newObject, dr.GetValue(Convert.ToInt32(tblschema.Rows[clmn]["ColumnOrdinal"])), null);
                                        property.SetValue(newObject, Convert.ChangeType(dr.GetValue(Convert.ToInt32(tblschema.Rows[clmn]["ColumnOrdinal"])), property.PropertyType, null), null);
                                    }
                                }
                            }
                            list.Add((T)newObject);
                        }
                    }
                }
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                if (command != null)
                    command.Parameters.Clear();
            }
            return list;
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
                                            newObject = Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), type, null);
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
                                                property.SetValue(newObject, Convert.ChangeType(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), property.PropertyType, null), null);
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
                ExecutionLog(list != null ? list.Count : 0);
            }
            catch (SqlException sqlexception)
            {
                message = sqlexception.Message;
                Logger.E(sqlexception);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                ExecutionLog(list != null ? list.Count : 0);
                if (command != null) command.Parameters.Clear();
            }
            return list;
        }

        public DataTable FillTable(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return FillTable(parameters);
        }
        public DataTable FillTable(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                if (command != null)
                    command.Parameters.Clear();
            }
            return null;
        }
        public DataTable FillTable(string commandText)
        {
            SqlParameter[] parameters = null;
            sqlString = commandText;
            return FillTable(parameters);
        }
        public DataTable FillTable()
        {
            SqlParameter[] parameters = null;
            return FillTable(parameters);
        }

        public bool Execute(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return Execute(parameters);
        }
        public bool Execute(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return false;

                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                if (command != null)
                    command.Parameters.Clear();
            }
            return false;
        }
        public bool Execute(string commandText)
        {
            SqlParameter[] parameters = null;
            sqlString = commandText;
            return Execute(parameters);
        }
        public bool Execute()
        {
            SqlParameter[] parameters = null;
            return Execute(parameters);
        }

        public object ExecuteScalar(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return ExecuteScalar(parameters);
        }
        public object ExecuteScalar(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.Parameters.Clear();
                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();
                return command.ExecuteScalar();
            }
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                if (command != null)
                    command.Parameters.Clear();
            }
            return null;
        }
        public object ExecuteScalar(string commandText)
        {
            sqlString = commandText;
            return ExecuteScalar();
        }
        public object ExecuteScalar()
        {
            SqlParameter[] parameters = null;
            return ExecuteScalar(parameters);
        }

        public int Count(string sql)
        {
            SqlString = sql;
            return Count();
        }

        public int Count()
        {
            object obj = ExecuteScalar();
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
            catch (SqlException sqlexc)
            {
                message = sqlexc.Message;
                Logger.E(sqlexc);
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
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Commit();
                }
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
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
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        #region Parameters
        public void AddParam(string name, object val)
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.AddWithValue(name, val);
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
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

                command.Parameters.Add(new SqlParameter() { ParameterName = name, DbType = dbType, Direction = direction });

            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
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
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        public static implicit operator bool(SqlClient sql)
        {
            return sql != null && sql.IsConnected;
        }

        private void SqlStringLog()
        {
            stopwatch = Stopwatch.StartNew();
            if (command != null)
            {
                if (command.Parameters.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (IDataParameter prm in command.Parameters) sb.AppendFormat("\tName:{0},Value:{1}\t", prm.ParameterName, prm.Value);
                    Logger.I(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString()));
                }
                else
                {
                    Logger.I(string.Concat("Command:", command.CommandText));

                }
            }

        }

        [DebuggerStepThrough()]
        private void ExecutionLog(int rowaffected)
        {
            stopwatch.Stop();
            Logger.I(string.Concat("Execution Row:", rowaffected, ", Time: ", stopwatch.Elapsed.Seconds, ", Caller: , lineNumber : 0"));
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
                    typeof(TimeSpan),
                    typeof(Guid)
                }).Contains(type) ||
                type.IsEnum ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }

        #region IDisposable
        ~SqlClient()
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
                if (command != null)
                {
                    command.Dispose();
                }

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


        #region IDisposable Members

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
