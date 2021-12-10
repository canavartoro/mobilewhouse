using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UstunWebService.Helpers;

namespace UstunWebService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                IDbConnection conn = ConnectionHelper.Instance.GetConnection();

                IDbCommand command = conn.CreateCommand();

                if (conn is OracleConnection)
                {
                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'ISSUETIME'";
                    object vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE UYUMSOFT.TEMP_DOCUMENT_M ADD (ISSUETIME DATE NULL)";
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'VEHICLE_ID'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE ""UYUMSOFT"".""TEMP_DOCUMENT_M"" ADD (""VEHICLE_ID"" NUMBER(*,0)) ADD (""LICENSE_PLATE"" NVARCHAR2(30)) ADD (""SHIPPINGDESC1"" NVARCHAR2(100)) ADD (""DRIVERIDENTIFYNO"" NVARCHAR2(20)) ADD (""DRIVERNAME"" NVARCHAR2(40)) ADD (""DRIVERFAMILYNAME"" NVARCHAR2(60)) ADD (""DRIVERGSMNO"" NVARCHAR2(30)) ADD (""TRANSPORTEQUIPMENT"" NVARCHAR2(30)) ADD(""REGISTERNAME"" NVARCHAR2(50))";
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'DOC_TRA_ID'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE ""UYUMSOFT"".""TEMP_DOCUMENT_M"" ADD (""DOC_TRA_ID"" NUMBER)";
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'DOC_NO_ID'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE ""UYUMSOFT"".""TEMP_DOCUMENT_M"" ADD (""DOC_NO_ID"" NUMBER)";
                        command.ExecuteNonQuery();
                    }
                    
                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'DOC_TRA_CODE'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE ""UYUMSOFT"".""TEMP_DOCUMENT_M"" ADD (""DOC_TRA_CODE"" VARCHAR2(50))";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_M' AND COLUMN_NAME = 'DOC_TRA_ID'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        //ALTER TABLE UYUMSOFT.TEMP_DOCUMENT_D DROP (UPDATE_DATE);
                        command.CommandText = @"ALTER TABLE UYUMSOFT.TEMP_DOCUMENT_M ADD (DOC_TRA_ID NUMBER NULL)";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_D' AND COLUMN_NAME = 'UPDATE_DATE'";
                    vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        command.CommandText = @"ALTER TABLE ""UYUMSOFT"".""TEMP_DOCUMENT_D"" ADD (""UPDATE_DATE"" TIMESTAMP (6)) ADD (""LOT_CODE"" VARCHAR2(50)) ADD (""WHOUSE_CODE"" VARCHAR2(25)) ADD (""WHOUSE_CODE2"" VARCHAR2(50)) ADD (""SHIPPING_DATE"" TIMESTAMP (6))";
                        command.ExecuteNonQuery();
                    }

                    //command.CommandText = @"SELECT COUNT(*) ROW_COUNT FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'TEMP_DOCUMENT_D' AND COLUMN_NAME = 'UPDATE_DATE'";
                    //object vcount = command.ExecuteScalar();
                    //if (vcount != null && Convert.ToInt32(vcount) < 1)
                    //{
                    //    //ALTER TABLE UYUMSOFT.TEMP_DOCUMENT_D DROP (UPDATE_DATE);
                    //    command.CommandText = @"ALTER TABLE UYUMSOFT.TEMP_DOCUMENT_D ADD (UPDATE_DATE TIMESTAMP(6) DEFAULT CURRENT_TIMESTAMP)";
                    //    command.ExecuteNonQuery();
                    //}
                }
                else if (conn is NpgsqlConnection)
                {
                    command.CommandText = "SELECT COUNT(*) FROM information_schema.columns WHERE table_name = 'temp_document_d' and column_name = 'update_date'";
                    object vcount = command.ExecuteScalar();
                    if (vcount != null && Convert.ToInt32(vcount) < 1)
                    {
                        //ALTER TABLE "uyumsoft"."temp_document_d" DROP COLUMN "update_date";
                        command.CommandText = @"ALTER TABLE ""uyumsoft"".""temp_document_d"" ADD COLUMN ""update_date"" timestamp DEFAULT CURRENT_TIMESTAMP";
                        command.ExecuteNonQuery();
                    }
                }

                command.Dispose();
                conn.Close();
            }
            catch (Exception except)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Bağlantı hatası:").Append(except.Message).Append("Detay:").Append(except.StackTrace).ToString());
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append("Uygulama genel hata").ToString());
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.AllErrors.Length > 0)
                    {
                        for (int i = 0; i < HttpContext.Current.AllErrors.Length; i++)
                        {
                            Exception acException = HttpContext.Current.AllErrors[i];
                            if (acException != null)
                            {
                                if (acException.Message == "Dosya yok.")
                                {
                                    System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                    System.Diagnostics.Trace.WriteLine(acException.Message);
                                    System.Diagnostics.Trace.WriteLine(HttpContext.Current.Request.Url.ToString());
                                    System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                    System.Diagnostics.Trace.WriteLine(acException.StackTrace);
                                    Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(acException.Message).Append("Detay:").Append(acException.StackTrace).Append(",Path:").Append(HttpContext.Current.Request.Url.ToString()).ToString());
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                    System.Diagnostics.Trace.WriteLine(acException.Message);
                                    System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                    System.Diagnostics.Trace.WriteLine(acException.StackTrace);
                                    Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(acException.Message).Append("Detay:").Append(acException.StackTrace).Append(",Path:").Append(HttpContext.Current.Request.Url.ToString()).ToString());
                                }
                            }
                            Exception acInner = HttpContext.Current.AllErrors[i].InnerException;
                            if (acInner != null)
                            {
                                System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                System.Diagnostics.Trace.WriteLine(acInner.Message);
                                System.Diagnostics.Trace.WriteLine("----------------------------------------------->>!");
                                System.Diagnostics.Trace.WriteLine(acInner.StackTrace);
                                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(acInner.Message).Append("Detay:").Append(acInner.StackTrace).Append(",Path:").Append(HttpContext.Current.Request.Url.ToString()).ToString());
                            }
                        }
                    }
                    HttpContext.Current.Server.ClearError();
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Trace.WriteLine(exc.Message);
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).Append(",Path:").ToString());
                //throw exc;
            }
            finally
            {
                //System.Diagnostics.Process.Start(@"C:\Windows\System32\iisreset.exe");
                //System.Threading.Thread.Sleep(5000);
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}