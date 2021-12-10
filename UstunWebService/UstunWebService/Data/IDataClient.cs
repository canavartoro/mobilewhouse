using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UstunWebService.Data
{
    public interface IDataClient : IDisposable
    {
        bool IsConnected { get; }
        string SqlString { get; set; }

        bool Connect();
        void Close();

        IDataReader Select(string commandText, IDbDataParameter[] parameters);
        IDataReader Select(IDbDataParameter[] parameters);
        IDataReader Select(string commandText);

        List<T> Select<T>();
        object Select(Type type);
        List<T> Select<T>(string commandText);

        DataTable FillTable(string commandText, IDbDataParameter[] parameters);
        DataTable FillTable(IDbDataParameter[] parameters);
        DataTable FillTable(string commandText);
        DataTable FillTable();

        bool Execute(string commandText, IDbDataParameter[] parameters);
        bool Execute(IDbDataParameter[] parameters);
        bool Execute(string commandText);
        bool Execute();

        object ExecuteScalar(string commandText, IDbDataParameter[] parameters);
        object ExecuteScalar(IDbDataParameter[] parameters);
        object ExecuteScalar(string commandText);
        object ExecuteScalar();

        int Count(string sql);

        void Begin();

        void Commit();

        void Rollback();

        void AddParam(string name, object val);
        void AddParam(string name, System.Data.DbType dbType, ParameterDirection direction);
        void ClearParameters();
    }
}