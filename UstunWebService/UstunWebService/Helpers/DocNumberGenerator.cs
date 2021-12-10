using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UstunWebService.Models;

namespace UstunWebService.Helpers
{
    public interface IDocNoGenerator
    {
        string Generate();
    }

    public abstract class DocNumberGenerator : IDocNoGenerator, IDisposable
    {
        public IDbConnection Connection { get; set; }
        public IDbCommand Command { get; set; }
        public ListFilterModel Filter { get; set; }

        public DocNumberGenerator() { }

        public static DocNumberGenerator Instance(ListFilterModel filterModel, IDbConnection connection)
        {
            DocNumberGenerator generator = null;
            if (connection is OracleConnection)
            {
                generator = new DocNumberOraGenerator();
            }
            else if (connection is NpgsqlConnection)
            {
                generator = new DocNumberPgGenerator();
            }
            generator.Connection = connection;
            generator.Filter = filterModel;
            return generator;
        }

        public virtual string Generate()
        {
            throw new NotImplementedException();
        }

        #region IDisposable
        ~DocNumberGenerator()
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
                if (!object.ReferenceEquals(Command, null))
                {
                    Command.Dispose();
                }

                if (!object.ReferenceEquals(Connection, null))
                {
                    if (Connection.State == ConnectionState.Open)
                        Connection.Close();
                    Connection.Dispose();
                }

                Filter = null;
                Command = null;
                Connection = null;
                NpgsqlConnection.ClearAllPools();
            }

            disposed = true;
        }
        #endregion
    }

    public class DocNumberOraGenerator : DocNumberGenerator
    {
        public override string Generate()
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            this.Command = this.Connection.CreateCommand();
            int rn = new Random().Next(10, 99);
            string docNo = null;
            if (Filter.id == 3) // ambalaj transfer
            {
                this.Command.CommandText = "select last_number + 1 \"id\" from user_sequences where sequence_name = 'PACKAGE_TRA_M_ID_INVT_PACKAGE'";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("AH{0}{1:0000000000}", rn, idval);
                }
            }
            else if (Filter.id == 5)
            {
                this.Command.CommandText = "select last_number + 1 \"id\" from user_sequences where sequence_name = 'PACKAGE_CYCLE_COUNT_M_ID_INVT'";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("AS{0}{1:0000000000}", rn, idval);
                }
            }
            else
            {
                this.Command.CommandText = "select last_number + 1 \"id\" from user_sequences where sequence_name = 'TEMP_DOCUMENT_M_ID_TEMP_DOC_M'";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("SH{0}{1:0000000000}", rn, idval);
                }
            }

            return docNo;
        }
    }

    public class DocNumberPgGenerator : DocNumberGenerator
    {
        public override string Generate()
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            this.Command = this.Connection.CreateCommand();
            int rn = new Random().Next(10, 99);
            string docNo = null;
            if (Filter.id == 3) // ambalaj transfer
            {
                this.Command.CommandText = "SELECT last_value + 1 \"id\" FROM invt_package_tra_m_package_tra_m_id_seq";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("AH{0}{1:0000000000}", rn, idval);
                }
            }
            else if (Filter.id == 5)
            {
                this.Command.CommandText = "SELECT last_value + 1 \"id\" FROM invt_package_cycle_count_m_package_cycle_count_m_id_seq";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("AS{0}{1:0000000000}", rn, idval);
                }
            }
            else
            {
                this.Command.CommandText = "SELECT last_value + 1 \"id\" FROM temp_document_m_document_m_id_seq";
                object idval = this.Command.ExecuteScalar();
                if (idval != null)
                {
                    docNo = string.Format("SH{0}{1:0000000000}", rn, idval);
                }
            }
            return docNo;
        }
    }
}