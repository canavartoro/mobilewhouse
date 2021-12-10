using UstunWebService.Models;
using UstunWebService.SenfoniGS;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Data.Common;
using System.Text;
using Npgsql;
using System.Runtime.CompilerServices;
using System.Collections;
using UstunWebService.Data;

namespace UstunWebService.Helpers
{
    public static class QueryHelper
    {
        public static DataTable RunCommandToDataTable(IDbCommand cmd)
        {
            try
            {
                long totalMemory = GC.GetTotalMemory(true);
                var stopwatch = Stopwatch.StartNew();
                var satartTime = DateTime.Now;
                var endTime = DateTime.Now;

                string connString = "defaultconnection", providerName = "defaultprovider";
                if (System.Configuration.ConfigurationManager.ConnectionStrings["uyum"] != null)
                {
                    if (!string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ProviderName))
                        providerName = System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ProviderName;
                    connString = System.Configuration.ConfigurationManager.ConnectionStrings["uyum"].ConnectionString;
                }
                DbProviderFactory providerFactory = DbProviderFactories.GetFactory(providerName);
                IDbDataAdapter dr = providerFactory.CreateDataAdapter();
                dr.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dr.Fill(ds);
                cmd.Dispose();

                long b2 = GC.GetTotalMemory(true);
                stopwatch.Stop();
                endTime = DateTime.Now;
                System.Diagnostics.Trace.WriteLine(string.Format("RunCommandToDataTable->Sql={0},DataSet:{1}", cmd.CommandText, ds != null ? ds.Tables.Count : 0));
                System.Diagnostics.Trace.WriteLine($"RunCommandToDataTable->Start:{satartTime.ToString("HH:mm:ss")},End:{endTime.ToString("HH:mm:ss")},Memory-1: {b2} Memory-2: {totalMemory}, ElapsedMillisecond:{stopwatch.ElapsedMilliseconds}");

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).Append(",Sql:").Append(cmd.CommandText).ToString());
                throw ex;
            }
        }
        public static List<T> dataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in table.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in table.Columns)
                    {
                        if (col.DataType == typeof(int))
                        {
                            if (dr[col] != null && dr[col] != DBNull.Value)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            else
                            {
                                row.Add(col.ColumnName, 0);
                            }
                        }
                        else if (col.DataType == typeof(decimal))
                        {
                            if (dr[col] != null && dr[col] != DBNull.Value)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            else
                            {
                                row.Add(col.ColumnName, 0);
                            }
                        }
                        else if (col.DataType == typeof(DateTime))
                        {
                            if (dr[col] != null && dr[col] != DBNull.Value)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            else
                            {
                                row.Add(col.ColumnName, DateTime.MinValue);
                            }
                        }
                        else
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }

                    }
                    rows.Add(row);
                }
                var settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local
                };
                list = (List<T>)Newtonsoft.Json.JsonConvert.DeserializeObject(serializer.Serialize(rows), typeof(List<T>), settings);
                return list;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                throw ex;
            }
        }
        public static object SetDataRow(string ColumnName, DataRow row, DbType type)
        {
            object value = null;

            if (type == DbType.Int32)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToInt32(row[ColumnName]) > 0 ? Convert.ToInt32(row[ColumnName]) : 0;
            }
            else if (type == DbType.Int64)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToInt64(row[ColumnName]) > 0 ? Convert.ToInt64(row[ColumnName]) : 0;
            }
            else if (type == DbType.String)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && !string.IsNullOrEmpty(row[ColumnName].ToString()) ? row[ColumnName].ToString() : string.Empty;
            }
            else if (type == DbType.Date || type == DbType.DateTime)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToDateTime(row[ColumnName]) != DateTime.MinValue ? Convert.ToDateTime(row[ColumnName]) : (DateTime?)null;
            }
            else if (type == DbType.Decimal)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToDecimal(row[ColumnName]) > 0 ? Convert.ToDecimal(row[ColumnName]) : 0;
            }
            else if (type == DbType.Double)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToDouble(row[ColumnName]) > 0 ? Convert.ToDouble(row[ColumnName]) : 0;
            }
            else if (type == DbType.Boolean)
            {
                value = row != null && row[ColumnName] != null && row[ColumnName] != DBNull.Value && Convert.ToBoolean(row[ColumnName]) ? true : false;
            }

            return value;
        }
        public static object SetDataRow(int Columnindex, DataRow row, DbType type)
        {
            object value = null;

            if (type == DbType.Int32)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToInt32(row[Columnindex]) > 0 ? Convert.ToInt32(row[Columnindex]) : 0;
            }
            else if (type == DbType.Int64)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToInt64(row[Columnindex]) > 0 ? Convert.ToInt64(row[Columnindex]) : 0;
            }
            else if (type == DbType.String)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && !string.IsNullOrEmpty(row[Columnindex].ToString()) ? row[Columnindex].ToString() : string.Empty;
            }
            else if (type == DbType.Date || type == DbType.DateTime)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToDateTime(row[Columnindex]) != DateTime.MinValue ? Convert.ToDateTime(row[Columnindex]) : (DateTime?)null;
            }
            else if (type == DbType.Decimal)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToDecimal(row[Columnindex]) > 0 ? Convert.ToDecimal(row[Columnindex]) : 0;
            }
            else if (type == DbType.Double)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToDouble(row[Columnindex]) > 0 ? Convert.ToDouble(row[Columnindex]) : 0;
            }
            else if (type == DbType.Boolean)
            {
                value = row != null && row[Columnindex] != null && row[Columnindex] != DBNull.Value && Convert.ToBoolean(row[Columnindex]) ? true : false;
            }

            return value;
        }
        public static string GetExceptionMessage(Exception ex)
        {
            return ex != null && ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message : ex != null && !string.IsNullOrEmpty(ex.Message) ? ex.Message : null;
        }
        public static ServiceResult<List<BranchModel>> GetBranchList(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<BranchModel>> serviceResult = new ServiceResult<List<BranchModel>>();
            //IDbCommand command = null;
            try
            {
                StringBuilder sql = new StringBuilder(@"SELECT GB.BRANCH_ID   as ""BranchId"",
                                                               GB.BRANCH_CODE as ""BranchCode"",
                                                               GB.BRANCH_DESC as ""BranchDesc"",
                                                               GB.CO_ID       as ""CoId"",
                                                               GC.CO_CODE     as ""CoCode"",
                                                               GC.CO_DESC     as ""CoDesc""
                                                          FROM GNLD_BRANCH GB
                                                          LEFT JOIN GNLD_COMPANY GC
                                                          ON GB.CO_ID = GC.CO_ID
                                                         WHERE GB.ISPASSIVE = 0");

                if (data.Connection is OracleConnection)
                {
                    sql.Append($@" AND BRANCH_ID IN (SELECT BRANCH_ID FROM TABLE(RP_GNLD_AUTHENTICATION_FNC ( {token.UserId}, 36 ) )) ");
                }

                if (filter.searchText != null && filter.searchText != string.Empty && filter.searchText != "")
                {
                    sql.Append($@" and (lower(GB.BRANCH_CODE) like lower('%{filter.searchText}%') or lower(GB.BRANCH_DESC)  like lower('%{filter.searchText}%'))");
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<BranchModel>(sql.ToString());
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
                //if (command != null)
                //    command.Dispose();
            }
        }
        public static ServiceResult<List<WhouseModel>> GetWhouseList(int BranchId, DataClient data)
        {
            ServiceResult<List<WhouseModel>> serviceResult = new ServiceResult<List<WhouseModel>>();
            try
            {
                string sql = $@"select 
                                W.WHOUSE_ID ""WHOUSE_ID""
                                ,W.WHOUSE_CODE ""WHOUSE_CODE""
                                ,W.DESCRIPTION ""DESCRIPTION""
                                from
                                INVD_BRANCH_WHOUSE  BW
                                INNER JOIN INVD_WHOUSE W ON W.WHOUSE_ID = BW.WHOUSE_ID
                                WHERE BW.BRANCH_ID = '{BranchId}' ";
                serviceResult.Success = true;
                serviceResult.Result = data.Select<WhouseModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterModel"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static ServiceResult<List<PurchaseOrderMListModel>> GetPurchaseOrderMList(PurchaseOrderMFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<PurchaseOrderMListModel>> serviceResult = new ServiceResult<List<PurchaseOrderMListModel>>();

            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = $@"SELECT 
                                cast(M.DOC_DATE as date) ""DOC_DATE""
                                ,M.DOC_NO ""DOC_NO""
                                ,E.ENTITY_NAME ""ENTITY_NAME""
                                ,E.ENTITY_ID ""ENTITY_ID""
                                ,M.ORDER_M_ID ""ORDER_M_ID""
                                ,M.DELIVERY_DATE ""DELIVERY_DATE""
                                ,M.CUR_TRA_ID ""CUR_TRA_ID""
                                FROM
                                           PSMT_ORDER_M     M
                                INNER JOIN FIND_ENTITY      E ON E.ENTITY_ID = M.ENTITY_ID
                                LEFT JOIN TEMP_DOCUMENT_D   TD ON M.ORDER_M_ID = TD.SOURCE_M_ID
                                WHERE 
                                     M.PURCHASE_SALES = 1
                                AND M.ORDER_STATUS = 1
                                AND TD.DOCUMENT_D_ID IS NULL
                                AND M.BRANCH_ID      = {filterModel.BranchId}
                                ";

                if (filterModel.DocNo != null && filterModel.DocNo != string.Empty)
                {
                    sql += $" and LOWER(M.DOC_NO) like LOWER('%{filterModel.DocNo}%')";
                }
                if (filterModel.DocDate > 0)
                {
                    sql += $" and M.DOC_DATE >= :DocDate";
                    //command.Parameters.Add(new OracleParameter
                    //{
                    //    ParameterName = "DocDate",
                    //    IsNullable = true,
                    //    DbType = DbType.Date,
                    //    OracleDbType = OracleDbType.Date,
                    //    Value = UnixTimeStampToDateTime(filterModel.DocDate)
                    //});

                    parameters.Add(data.CreateDbParameter("DocDate", UnixTimeStampToDateTime(filterModel.DocDate)));
                }
                if (filterModel.EntityId > 0)
                {
                    sql += $" and M.ENTITY_ID = {filterModel.EntityId}";
                }
                else
                {
                    if (filterModel.EntityCode != null && filterModel.EntityCode != string.Empty)
                    {
                        sql += $" and LOWER(E.ENTITY_CODE) like LOWER('%{filterModel.EntityCode}%')";
                    }
                    if (filterModel.EntityName != null && filterModel.EntityName != string.Empty)
                    {
                        sql += $" and LOWER(E.ENTITY_NAME) like LOWER('%{filterModel.EntityName}%')";
                    }
                }

                sql += " ORDER BY M.DOC_DATE, E.ENTITY_NAME";

                serviceResult.Result = data.Select<PurchaseOrderMListModel>(sql, parameters.ToArray());
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<EntityListModel>> GetEntityList(ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<EntityListModel>> serviceResult = new ServiceResult<List<EntityListModel>>();
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = $@"SELECT 
                                 E.ENTITY_CODE 
                                ,E.ENTITY_NAME
                                ,E.ENTITY_ID
                                ,CE.CO_ID
                                FROM
                                            FIND_CO_ENTITY CE 
                                INNER JOIN  FIND_ENTITY    E  ON E.ENTITY_ID = CE.ENTITY_ID 
                                WHERE 
                                    CE.CO_ID     = :CoId
                                ";

                parameters.Add(data.CreateDbParameter("CoId", filterModel.co_id));
                if (!string.IsNullOrEmpty(filterModel.searchText))
                {
                    parameters.Add(data.CreateDbParameter("SEARCH_FILTER_TEXT", filterModel.searchText));
                    sql += " AND ( LOWER(E.ENTITY_NAME ) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(E.ENTITY_CODE ) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) ";
                }
                serviceResult.Success = true;
                serviceResult.Result = data.Select<EntityListModel>(sql, parameters.ToArray());
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<DocTraModel>> GetDocTraList(ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<DocTraModel>> serviceResult = new ServiceResult<List<DocTraModel>>();
            string sql = "";
            try
            {
                //TODO hareket kodlari
                sql = $@"select
                D.DOC_TRA_ID DOC_TRA_ID
                ,D.DOC_TRA_CODE DOC_TRA_CODE
                ,D.DESCRIPTION DOC_TRA_NAME
                ,C.CO_ID
                ,C.IS_DOC_NO_MOVE_TO_VOUCHER_NO
                from
                GNLD_CO_DOC_TRA  C
                INNER JOIN GNLD_DOC_TRA D ON C.DOC_TRA_ID = D.DOC_TRA_ID
                WHERE D.SOURCE_APP = 1000 AND D.PURCHASE_SALES = {filter.purchaseSales} AND C.CO_ID = {filter.co_id}";

                if (!string.IsNullOrEmpty(filter.searchText))
                {
                    sql += $@"AND (D.DOC_TRA_CODE LIKE '%{filter.searchText}%' or D.DESCRIPTION LIKE '%{filter.searchText}%') ";

                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<DocTraModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).Append(",Sql:").Append(sql).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<PurchaseOrderDListModel>> GetPurchaseOrderDList(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<PurchaseOrderDListModel>> serviceResult = new ServiceResult<List<PurchaseOrderDListModel>>();
            try
            {
                ServiceResult<List<PurchaseOrderDListModel>> orderDetailList = new ServiceResult<List<PurchaseOrderDListModel>>();
                string sql = $@"SELECT
                                 D.ORDER_M_ID
                                ,D.ORDER_D_ID
                                ,I.ITEM_CODE
                                ,I.ITEM_NAME
                                ,I.ITEM_ID
                                ,D.QTY_PRM-(CASE WHEN D.QTY>0 THEN ((D.QTY_PRM / D.QTY)*D.QTY_SHIPPING) ELSE 0 END) AS QTY
                                ,U.DESCRIPTION  AS UNIT_DESC
                                ,D.LINE_TYPE
                                ,D.BRANCH_ID
                                ,0 AS QTY_READ
                                ,U.UNIT_ID
                                ,cast(M.DOC_DATE as date) DOC_DATE
                                ,TO_CHAR(M.DOC_DATE, 'DD-MM-YYYY')	 as DOC_DATE_S
                                ,M.DOC_NO
                                ,E.ENTITY_CODE
                                ,E.ENTITY_NAME
                                ,E.ENTITY_ID
                                ,M.ORDER_M_ID
                                ,M.DELIVERY_DATE
                                ,M.CUR_TRA_ID
                                ,{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE1_ID,0) ""ITEM_ATTRIBUTE1_ID""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(ATTRIBUTE1.ITEM_ATTRIBUTE_CODE,'') ITEM_ATTRIBUTE1_CODE
								,{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE2_ID,0) ""ITEM_ATTRIBUTE2_ID"" 
								,{QueryHelper.GetIsNullCommand(data.Connection)}(ATTRIBUTE2.ITEM_ATTRIBUTE_CODE,'') ITEM_ATTRIBUTE2_CODE
								,{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE3_ID,0) ""ITEM_ATTRIBUTE3_ID""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(ATTRIBUTE3.ITEM_ATTRIBUTE_CODE,'') ITEM_ATTRIBUTE3_CODE
								,{QueryHelper.GetIsNullCommand(data.Connection)}(D.LOT_ID,0) ""LOT_ID""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(LOT.LOT_CODE,'') ""LOT_CODE""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(D.QUALITY_ID,0) ""QUALITY_ID""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(QUALITY.QUALITY_CODE,'') ""QUALITY_CODE""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(D.COLOR_ID,0) ""COLOR_ID""
								,{QueryHelper.GetIsNullCommand(data.Connection)}(COLOR.COLOR_CODE,'') ""COLOR_CODE""
                                FROM
                                             PSMT_ORDER_D    D 
                                INNER JOIN   PSMT_ORDER_M    M  ON M.ORDER_M_ID = D.ORDER_M_ID 
                                INNER JOIN   FIND_ENTITY     E  ON M.ENTITY_ID = E.ENTITY_ID
                                INNER JOIN   INVD_ITEM       I  ON I.ITEM_ID = D.ITEM_ID
                                INNER JOIN   INVD_UNIT       U  ON U.UNIT_ID = I.UNIT_ID
                                LEFT JOIN INVD_ITEM_ATTRIBUTE ATTRIBUTE1 ON D.ITEM_ATTRIBUTE1_ID = ATTRIBUTE1.ITEM_ATTRIBUTE_ID
								LEFT JOIN INVD_ITEM_ATTRIBUTE ATTRIBUTE2 ON D.ITEM_ATTRIBUTE2_ID = ATTRIBUTE2.ITEM_ATTRIBUTE_ID
								LEFT JOIN INVD_ITEM_ATTRIBUTE ATTRIBUTE3 ON D.ITEM_ATTRIBUTE3_ID = ATTRIBUTE3.ITEM_ATTRIBUTE_ID
								LEFT JOIN INVD_LOT LOT ON D.LOT_ID = LOT.LOT_ID
								LEFT JOIN INVD_QUALITY QUALITY ON D.QUALITY_ID = QUALITY.QUALITY_ID
								LEFT JOIN INVD_COLOR COLOR ON D.COLOR_ID = COLOR.COLOR_ID
                                WHERE 
                                     M.BRANCH_ID      = {filter.branch_id}
                                AND  M.ENTITY_ID      = {filter.entity_id}
                                AND  D.WHOUSE_ID      = {token.WhouseId}
                                AND  M.PURCHASE_SALES = {filter.purchaseSales}
                                AND  M.ORDER_STATUS   = 1
                                AND  D.ORDER_STATUS   = 1
                                AND D.LINE_TYPE = 1 ";
                if (filter.orderMasterNoList != null && filter.orderMasterNoList.Count > 0)
                {
                    sql = string.Concat(sql, " AND D.ORDER_M_ID IN (", string.Join(",", filter.orderMasterNoList), ")");
                }
                sql = string.Concat(sql, " ORDER BY M.DOC_DATE DESC");
                //--AND M.REQUEST_STATUS =4 ";
                orderDetailList.Success = true;
                orderDetailList.Result = data.Select<PurchaseOrderDListModel>(sql);
                TempDocumentMModel masterTemp = new TempDocumentMModel();
                masterTemp.BRANCH_ID = token.BranchId;
                //masterTemp.USER_ID = filterModel.USER_ID;
                masterTemp.WHOUSE_ID = token.WhouseId;
                if (filter.purchaseSales == 1)
                {
                    masterTemp.DOCUMENT_TYPE = 10;
                }
                else
                {
                    masterTemp.DOCUMENT_TYPE = 40;

                }
                serviceResult.Success = true;
                serviceResult.Result = orderDetailList.Result;
                //if (orderDetailList.Result.Count > 0)
                //{
                //    //ServiceResult<TempDocumentMModel> masterResult = new ServiceResult<TempDocumentMModel>();

                //    //masterResult = InsertMasterTempDocument(masterTemp, connection);
                //    //if (masterResult.Success && masterResult.Result != null)
                //    //{
                //    //    masterTemp = masterResult.Result;
                //    //    serviceResult.Result = masterTemp;
                //    //    serviceResult.Success = masterResult.Success;
                //        foreach (PurchaseOrderDListModel item in orderDetailList.Result)
                //        {
                //            TempDocumentDModel detail = new TempDocumentDModel();
                //            detail.BRANCH_ID = token.BranchId;
                //            detail.DOCUMENT_M_ID = masterTemp.DOCUMENT_M_ID;
                //            detail.ITEM_ID = item.ITEM_ID;
                //            detail.LOT_ID = 0;
                //            detail.ORDER_D_ID = item.ORDER_D_ID;
                //            detail.ORDER_M_ID = item.ORDER_M_ID;
                //            detail.QTY = item.QTY;
                //            detail.SOURCE_D_ID = item.ORDER_D_ID;
                //            detail.SOURCE_M_ID = item.ORDER_M_ID;
                //            detail.UNIT_ID = item.UNIT_ID;
                //            detail.USER_ID = token.UserId;
                //            detail.DOC_DATE = item.DOC_DATE;
                //            detail.DOC_NO = item.DOC_NO;
                //            detail.DOC_DATE = item.DOC_DATE;
                //       //     ServiceResult<TempDocumentDModel> detailRes = InsertDetailTempDocument(detail, connection);
                //       //     if (detailRes.Success != true)
                //       //     {
                //       //         serviceResult.Success = false;
                //       //         serviceResult.ErrorMessage = detailRes.ErrorMessage;
                //       ////         DeleteTempMaster(masterTemp, connection);
                //       //     }
                //        }
                //    //}
                //    //else
                //    //{
                //    //    serviceResult.Success = false;
                //    //    serviceResult.ErrorMessage = masterResult.ErrorMessage;
                //    //}
                //}
                //else
                //{
                //    serviceResult.Success = false;
                //    serviceResult.ErrorMessage = "Seçilen cariyte ait sipariş bulunamamıştır.";
                //}
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<ItemDemandListModel>> GetItemDemandList(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<ItemDemandListModel>> serviceResult = new ServiceResult<List<ItemDemandListModel>>();
            try
            {
                ServiceResult<List<ItemDemandListModel>> itemDemandList = new ServiceResult<List<ItemDemandListModel>>();
                string sql = $@"SELECT *
                      FROM (SELECT INVT_ITEM_DEMAND2_M.ITEM_DEMAND2_M_ID,
                                   INVT_ITEM_DEMAND2_M.WHOUSE_ID,
                                   INVT_ITEM_DEMAND2_M.CAT_CODE1_ID,
                                   INVT_ITEM_DEMAND2_M.CAT_CODE2_ID,
                                   INVT_ITEM_DEMAND2_M.CONFIRM_DATE,
                                   INVT_ITEM_DEMAND2_M.SHIPPING_DATE,
                                   INVT_ITEM_DEMAND2_M.CONFIRM_NO,
                                   INVT_ITEM_DEMAND2_M.DEMAND_STATU,
                                   INVT_ITEM_DEMAND2_M.DOC_DATE,
                                   INVT_ITEM_DEMAND2_M.DOC_NO,
                                   INVT_ITEM_DEMAND2_M.NOTE1,
                                   INVT_ITEM_DEMAND2_M.NOTE2,
                                   INVT_ITEM_DEMAND2_M.NOTE3,
                                   INVT_ITEM_DEMAND2_M.NOTE4,
                                   INVT_ITEM_DEMAND2_M.DENY_STATUS,
                                   INVD_WHOUSE.WHOUSE_CODE,
                                   INVD_WHOUSE.DESCRIPTION AS WHOUSE_DESC,
                                   GNLD_BRANCH.BRANCH_CODE,
                                   GNLD_COMPANY.CO_CODE,
                                   GNLD_CATEGORY1.CAT_CODE AS CATCODE1,
                                   GNLD_CATEGORY2.CAT_CODE AS CATCODE2,
                                   GNLD_DOC_TRA.DOC_TRA_CODE AS DOC_TRA_CODE1,
                                   ROW_NUMBER() over(ORDER BY GNLD_BRANCH.BRANCH_CODE ASC, INVT_ITEM_DEMAND2_M.CONFIRM_DATE DESC, INVT_ITEM_DEMAND2_M.DOC_DATE DESC, INVT_ITEM_DEMAND2_M.DEMAND_STATU ASC) URNK
                              FROM INVT_ITEM_DEMAND2_M
                              LEFT OUTER JOIN UYUMSOFT.GNLD_COMPANY
                                ON INVT_ITEM_DEMAND2_M.CO_ID = GNLD_COMPANY.CO_ID
                              LEFT OUTER JOIN UYUMSOFT.GNLD_BRANCH
                                ON INVT_ITEM_DEMAND2_M.BRANCH_ID = GNLD_BRANCH.BRANCH_ID
                              LEFT OUTER JOIN UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY1
                                ON INVT_ITEM_DEMAND2_M.CAT_CODE1_ID = GNLD_CATEGORY1.CAT_CODE_ID
                              LEFT OUTER JOIN UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY2
                                ON INVT_ITEM_DEMAND2_M.CAT_CODE2_ID = GNLD_CATEGORY2.CAT_CODE_ID
                              LEFT OUTER JOIN UYUMSOFT.INVD_WHOUSE
                                ON INVT_ITEM_DEMAND2_M.WHOUSE_ID = INVD_WHOUSE.WHOUSE_ID
                              LEFT OUTER JOIN UYUMSOFT.GNLD_DOC_TRA
                                ON INVT_ITEM_DEMAND2_M.DOC_TRA_ID = GNLD_DOC_TRA.DOC_TRA_ID
                             WHERE (INVT_ITEM_DEMAND2_M.CO_ID = {token.CoId} AND
                                   INVT_ITEM_DEMAND2_M.DEMAND_STATU IN (3, 4) AND
                                   GNLD_BRANCH.BRANCH_ID = {filter.branch_id})
                             ORDER BY GNLD_BRANCH.BRANCH_CODE          ASC,
                                      INVT_ITEM_DEMAND2_M.CONFIRM_DATE DESC,
                                      INVT_ITEM_DEMAND2_M.DOC_DATE     DESC,
                                      INVT_ITEM_DEMAND2_M.DEMAND_STATU ASC) TOPSQL
                     WHERE URNK <= 100";

                itemDemandList.Success = true;
                itemDemandList.Result = data.Select<ItemDemandListModel>(sql);
                TempDocumentMModel masterTemp = new TempDocumentMModel();
                masterTemp.BRANCH_ID = token.BranchId;
                //masterTemp.USER_ID = filterModel.USER_ID;
                masterTemp.WHOUSE_ID = token.WhouseId;
                //if (filter.purchaseSales == 1)
                //{ Sevk
                //    masterTemp.DOCUMENT_TYPE = 80;
                //}
                //else
                //{ Kabul
                //    masterTemp.DOCUMENT_TYPE = 90;

                //}
                serviceResult.Success = true;
                serviceResult.Result = itemDemandList.Result;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static List<ItemDemandDListModel> GetItemDemandDList(int ItemDemandMId, DataClient data)
        {
            string sql = string.Format(@"SELECT INVT_ITEM_DEMAND2_D.ITEM_DEMAND2_D_ID,
                               INVT_ITEM_DEMAND2_D.AMT,
                               INVT_ITEM_DEMAND2_D.IS_MANUEL_PRICE,
                               INVT_ITEM_DEMAND2_D.BRANCH_ID,
                               INVT_ITEM_DEMAND2_D.WHOUSE_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_ID,
                               INVT_ITEM_DEMAND2_D.CAT_CODE1_ID,
                               INVT_ITEM_DEMAND2_D.CAT_CODE2_ID,
                               INVT_ITEM_DEMAND2_D.COLOR_ID,
                               INVT_ITEM_DEMAND2_D.CONTACT_ID,
                               INVT_ITEM_DEMAND2_D.ENTITY_ID,
                               INVT_ITEM_DEMAND2_D.CO_ID,
                               INVT_ITEM_DEMAND2_D.DOC_DATE,
                               INVT_ITEM_DEMAND2_D.DOC_NO,
                               INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE1_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE2_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE3_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_DEMAND2_M_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_DEMAND_D_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE1_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE2_ID,
                               INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE3_ID,
                               INVT_ITEM_DEMAND2_D.LINE_NO,
                               INVT_ITEM_DEMAND2_D.LOT_ID,
                               INVT_ITEM_DEMAND2_D.NOTE1,
                               INVT_ITEM_DEMAND2_D.PACKAGE_TYPE_ID,
                               INVT_ITEM_DEMAND2_D.PROJECT_M_ID,
                               INVT_ITEM_DEMAND2_D.QTY,
                               INVT_ITEM_DEMAND2_D.QTY_CONFIRM,
                               INVT_ITEM_DEMAND2_D.QTY_FREE_PRM,
                               INVT_ITEM_DEMAND2_D.QTY_FREE_SEC,
                               INVT_ITEM_DEMAND2_D.QUALITY_ID,
                               INVT_ITEM_DEMAND2_D.REASON_ID,
                               INVT_ITEM_DEMAND2_D.SHIPPING_DATE,
                               INVT_ITEM_DEMAND2_D.UNIT_ID,
                               INVT_ITEM_DEMAND2_D.UNIT_PRICE,
                               INVT_ITEM_DEMAND2_D.PRICE_LIST_D_ID,
                               INVD_WHOUSE1.WHOUSE_CODE                     AS WHOUSE_CODE1,
                               GNLD_BRANCH.BRANCH_CODE,
                               INVD_COLOR.COLOR_CODE,
                               GNLD_CONTACT.CONTACT_NAME,
                               GNLD_COMPANY.CO_CODE,
                               INVD_ITEM.ITEM_CODE,
                               INVD_ITEM.ITEM_NAME,
                               INVD_ITEM.OLD_ITEM_CODE,
                               INVD_PACKAGE_TYPE.PACKAGE_TYPE_CODE,
                               FIND_PROJECT_M.PROJECT_CODE,
                               INVD_QUALITY.QUALITY_CODE,
                               INVD_UNIT.UNIT_CODE                          AS UNIT_CODE,
                               FIND_ENTITY.ENTITY_CODE,
                               GNLD_CATEGORY1.CAT_CODE                      AS CATCODE1,
                               GNLD_CATEGORY2.CAT_CODE                      AS CATCODE2,
                               INVD_ITEM_ATTRIBUTE1.ITEM_ATTRIBUTE_CODE     AS ITEM_ATTRIBUTE_CODE1,
                               INVD_ITEM_ATTRIBUTE2.ITEM_ATTRIBUTE_CODE     AS ITEM_ATTRIBUTE_CODE2,
                               INVD_ITEM_ATTRIBUTE3.ITEM_ATTRIBUTE_CODE     AS ITEM_ATTRIBUTE_CODE3,
                               INVD_LOT.LOT_CODE,
                               GNLD_REASON.REASON_CODE,
                               INVD_ITEM_GNL_ATTRIBUTE1.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_GNL_CODE1,
                               INVD_ITEM_GNL_ATTRIBUTE2.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_GNL_CODE2,
                               INVD_ITEM_GNL_ATTRIBUTE3.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_GNL_CODE3,
                               INVT_ITEM_DEMAND2_D.QTY_PRM,
                               INVT_ITEM_DEMAND2_D.KEY,
                               INVT_ITEM_DEMAND2_D.QTY_SHIPPING,
                               INVT_ITEM_DEMAND2_D.WHOUSE2_ID,
                               INVD_WHOUSE2.WHOUSE_CODE                     AS WHOUSE_CODE2,
                               INVT_ITEM_DEMAND2_D.DEMAND_STATU,
                               INVT_ITEM_DEMAND2_D.DENY_STATUS,
                               INVT_ITEM_DEMAND2_D.CUR_RATE_TYPE_ID,
                               INVT_ITEM_DEMAND2_D.CUR_TRA_ID,
                               GNLD_CURRENCY.CUR_CODE                       AS CUR_CODE,
                               INVT_ITEM_DEMAND2_D.SOURCE_APP,
                               INVT_ITEM_DEMAND2_D.SOURCE_M_ID,
                               INVT_ITEM_DEMAND2_D.SOURCE_D_ID
                          FROM INVT_ITEM_DEMAND2_D
                          LEFT OUTER JOIN UYUMSOFT.GNLD_COMPANY
                            ON INVT_ITEM_DEMAND2_D.CO_ID = GNLD_COMPANY.CO_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_BRANCH
                            ON INVT_ITEM_DEMAND2_D.BRANCH_ID = GNLD_BRANCH.BRANCH_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY1
                            ON INVT_ITEM_DEMAND2_D.CAT_CODE1_ID = GNLD_CATEGORY1.CAT_CODE_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY2
                            ON INVT_ITEM_DEMAND2_D.CAT_CODE2_ID = GNLD_CATEGORY2.CAT_CODE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_COLOR
                            ON INVT_ITEM_DEMAND2_D.COLOR_ID = INVD_COLOR.COLOR_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_CONTACT
                            ON INVT_ITEM_DEMAND2_D.CONTACT_ID = GNLD_CONTACT.CONTACT_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE1
                            ON INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE1_ID =
                               INVD_ITEM_ATTRIBUTE1.ITEM_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE2
                            ON INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE2_ID =
                               INVD_ITEM_ATTRIBUTE2.ITEM_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE3
                            ON INVT_ITEM_DEMAND2_D.ITEM_ATTRIBUTE3_ID =
                               INVD_ITEM_ATTRIBUTE3.ITEM_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_PACKAGE_TYPE
                            ON INVT_ITEM_DEMAND2_D.PACKAGE_TYPE_ID =
                               INVD_PACKAGE_TYPE.PACKAGE_TYPE_ID
                          LEFT OUTER JOIN UYUMSOFT.FIND_PROJECT_M
                            ON INVT_ITEM_DEMAND2_D.PROJECT_M_ID = FIND_PROJECT_M.PROJECT_M_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_QUALITY
                            ON INVT_ITEM_DEMAND2_D.QUALITY_ID = INVD_QUALITY.QUALITY_ID
                          LEFT OUTER JOIN UYUMSOFT.FIND_ENTITY
                            ON INVT_ITEM_DEMAND2_D.ENTITY_ID = FIND_ENTITY.ENTITY_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_LOT
                            ON INVT_ITEM_DEMAND2_D.LOT_ID = INVD_LOT.LOT_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_REASON
                            ON INVT_ITEM_DEMAND2_D.REASON_ID = GNLD_REASON.REASON_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM
                            ON INVT_ITEM_DEMAND2_D.ITEM_ID = INVD_ITEM.ITEM_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_WHOUSE INVD_WHOUSE1
                            ON INVT_ITEM_DEMAND2_D.WHOUSE_ID = INVD_WHOUSE1.WHOUSE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_WHOUSE INVD_WHOUSE2
                            ON INVT_ITEM_DEMAND2_D.WHOUSE2_ID = INVD_WHOUSE2.WHOUSE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_UNIT
                            ON INVT_ITEM_DEMAND2_D.UNIT_ID = INVD_UNIT.UNIT_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE1
                            ON INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE1_ID =
                               INVD_ITEM_GNL_ATTRIBUTE1.ITEM_GNL_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE2
                            ON INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE2_ID =
                               INVD_ITEM_GNL_ATTRIBUTE2.ITEM_GNL_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE3
                            ON INVT_ITEM_DEMAND2_D.ITEM_GNL_ATTRIBUTE3_ID =
                               INVD_ITEM_GNL_ATTRIBUTE3.ITEM_GNL_ATTRIBUTE_ID
                          LEFT OUTER JOIN UYUMSOFT.GNLD_CURRENCY
                            ON INVT_ITEM_DEMAND2_D.CUR_TRA_ID = GNLD_CURRENCY.CUR_ID
                         WHERE INVT_ITEM_DEMAND2_D.DEMAND_STATU IN (3, 4) AND INVT_ITEM_DEMAND2_D.ITEM_DEMAND2_M_ID = {0}", ItemDemandMId);

            return data.Select<ItemDemandDListModel>(sql);
        }
        public static ServiceResult<List<ItemListModel>> GetItemList(ItemFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<ItemListModel>> serviceResult = new ServiceResult<List<ItemListModel>>();
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = $@" SELECT
                                 I.ITEM_CODE  
                                ,I.ITEM_NAME     
                                ,BR.BARCODE   
                                ,BR.ITEM_BARCODE_ID
                                ,I.ITEM_ID
                                ,0 WHOUSE_ID 
                                ,0 ISLOT_MONDATORY
                                ,case when BR.UNIT_ID > 0 then BR.UNIT_ID else BI.UNIT_ID end as UNIT_ID
                                ,nvl(U.RATE2,1) AS QTY
                                ,U2.UNIT_ID DEFAULT_UNIT_ID
                                ,U2.UNIT_CODE DEFAULT_UNIT_CODE
                                ,U2.DESCRIPTION DEFAULT_UNIT_NAME
                                FROM
                                    INVD_BRANCH_ITEM      BI
                                    INNER JOIN INVD_ITEM          I  ON I.ITEM_ID    = BI.ITEM_ID
                                    LEFT JOIN INVD_ITEM_BARCODE  BR on BR.ITEM_ID = I.ITEM_ID
                                    LEFT JOIN INVD_ITEM_UNIT     U  ON U.ITEM_ID    = I.ITEM_ID  AND BR.UNIT_ID = U.UNIT2_ID
                                    LEFT JOIN INVD_UNIT          U2 ON I.UNIT_ID = U2.UNIT_ID          
                                WHERE
                                BI.BRANCH_ID = {filterModel.BranchId}
                                
                                ";
                //AND W.WHOUSE_ID = {filterModel.WhouseId}

                if (filterModel.ItemId > 0)
                {
                    parameters.Add(data.CreateDbParameter("ItemId", filterModel.ItemId));
                    sql += " AND I.ITEM_ID LIKE '%' || :ItemId || '%'";
                }
                else
                {
                    if (filterModel.ItemName != null && filterModel.ItemName != "")
                    {
                        parameters.Add(data.CreateDbParameter("ItemCode", filterModel.ItemName));
                        sql += " AND (I.ITEM_CODE LIKE '%' || :ItemCode || '%'";
                    }
                    if (filterModel.ItemName != null && filterModel.ItemName != "")
                    {
                        parameters.Add(data.CreateDbParameter("ItemName", filterModel.ItemName));
                        sql += " OR lower(I.ITEM_NAME) LIKE lower('%' || :ItemName || '%'))";
                    }
                    if (filterModel.BARCODE != null && filterModel.BARCODE != "")
                    {
                        parameters.Add(data.CreateDbParameter("BARCODE", filterModel.BARCODE.TrimStart().Trim().TrimEnd()));
                        sql += " AND BR.BARCODE LIKE '%' || :BARCODE || '%'";
                    }
                }

                //sql += " GROUP BY I.ITEM_CODE,I.ITEM_NAME";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<ItemListModel>(sql, parameters.ToArray());
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<ItemQualityModel>> GetItemQualityList(ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<ItemQualityModel>> serviceResult = new ServiceResult<List<ItemQualityModel>>();
            try
            {
                string sql = $@"SELECT IQ.QUALITY_ID ""QUALITY_ID"", Q.QUALITY_CODE ""QUALITY_CODE"", Q.DESCRIPTION ""DESCRIPTION"", IQ.DESCRIPTION AS ""DESCRIPTION2"" FROM INVD_ITEM_QUALITY IQ INNER JOIN INVD_QUALITY Q ON IQ.QUALITY_ID = Q.QUALITY_ID WHERE IQ.ISPASSIVE = 0 AND IQ.ITEM_ID = {filterModel.item_id}";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<ItemQualityModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<ItemLotModel>> GetItemLotList(ItemLotFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<ItemLotModel>> serviceResult = new ServiceResult<List<ItemLotModel>>();
            try
            {

                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = @"SELECT L.LOT_ID ""LOT_ID"",L.LOT_CODE ""LOT_CODE"",L.DESCRIPTION ""DESCRIPTION"",I.ITEM_NAME ""ITEM_NAME"",I.ITEM_CODE ""ITEM_CODE"",I.ITEM_ID ""ITEM_ID"",B.BARCODE ""BARCODE"" FROM INVD_LOT L LEFT JOIN  INVD_ITEM I ON I.ITEM_ID = L.ITEM_ID LEFT JOIN INVD_ITEM_BARCODE B ON B.LOT_ID = L.LOT_ID ";
                string Where = "WHERE";
                if (filterModel.LOT_CODE != null && filterModel.LOT_CODE != "")
                {
                    parameters.Add(data.CreateDbParameter("LOT_CODE", filterModel.LOT_CODE));
                    Where += Where != "WHERE" ? " AND I.LOT_CODE LIKE '%' || :LOT_CODE || '%'" : " I.LOT_CODE LIKE '%' || :LOT_CODE || '%'";
                }
                if (filterModel.DESCRIPTION != null && filterModel.DESCRIPTION != "")
                {
                    parameters.Add(data.CreateDbParameter("DESCRIPTION", filterModel.DESCRIPTION));
                    Where += Where != "WHERE" ? " AND I.DESCRIPTION LIKE '%' || :DESCRIPTION || '%'" : " I.DESCRIPTION LIKE '%' || :DESCRIPTION || '%'";
                }
                if (filterModel.ITEM_ID > 0)
                {
                    parameters.Add(data.CreateDbParameter("ITEM_ID", filterModel.ITEM_ID));
                    Where += Where != "WHERE" ? " AND I.ITEM_ID = :ITEM_ID" : " I.ITEM_ID = :ITEM_ID"; ;
                }
                if (filterModel.ITEM_ID > 0 && filterModel.BARCODE != null)
                {
                    parameters.Add(data.CreateDbParameter("BARCODE", filterModel.BARCODE.TrimStart().Trim().TrimEnd()));
                    Where += Where != "WHERE" ? " AND B.BARCODE = ':BARCODE'" : " B.BARCODE = ':BARCODE'"; ;
                }
                if (Where != "WHERE")
                {
                    sql += Where;
                }
                sql += " ORDER BY L.LOT_CODE,L.DESCRIPTION";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<ItemLotModel>(sql, parameters.ToArray());
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<ProjectListModel>> GetProjectList(Token token, ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<ProjectListModel>> serviceResult = new ServiceResult<List<ProjectListModel>>();
            try
            {
                string sql = $@" SELECT
                                M.PROJECT_M_ID ""PROJECT_M_ID""
                                ,M.PROJECT_CODE ""PROJECT_CODE""
                                ,M.DESCRIPTION ""DESCRIPTION""
                                ,CM.CO_ID ""CO_ID""
                                FROM
                                FIND_CO_PROJECT_M CM 
                                INNER JOIN FIND_PROJECT_M M  ON M.PROJECT_M_ID = CM.PROJECT_M_ID
                                WHERE CM.CO_ID = {token.CoId}
                                ";
                if (!string.IsNullOrEmpty(filterModel.searchText))
                {
                    sql += $@"AND (M.PROJECT_CODE ='{filterModel.searchText}' or M.DESCRIPTION = '{filterModel.searchText}') ";

                }
                serviceResult.Success = true;
                serviceResult.Result = data.Select<ProjectListModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<TempDocumentMModel>> GetTempDocumentMList(int UserId, int BranchId, DataClient data)
        {
            ServiceResult<List<TempDocumentMModel>> serviceResult = new ServiceResult<List<TempDocumentMModel>>();
            try
            {
                string sql = $@" SELECT
                                 M.DOCUMENT_M_ID        AS ""DOCUMENT_M_ID"",
                                 M.DOCUMENT_TYPE        AS ""DOCUMENT_TYPE"",
                                 M.USER_ID              AS ""USER_ID"",
                                 M.DOC_DATE             AS ""DOC_DATE"",
                                 M.DOC_NO               AS ""DOC_NO"",
                                 M.WHOUSE_ID            AS ""WHOUSE_ID"",
                                 M.WHOUSE_ID2           AS ""WHOUSE_ID2"",
                                 M.PROJECT_M_ID         AS ""PROJECT_M_ID"",
                                 M.BRANCH_ID            AS ""BRANCH_ID""
                                 
                                 FROM TEMP_DOCUMENT_M M
                                 WHERE M.USER_ID = {UserId}
                                 
                                 UNION ALL
                                 
                                 SELECT 
                                 M.CCNB_COUNTER_M_T_ID  AS ""DOCUMENT_M_ID"",
                                 100     	            AS ""DOCUMENT_TYPE"",
                                 0                      AS ""USER_ID"",
                                 M.DOC_DATE             AS ""DOC_DATE"",
                                 M.DOC_NO               AS ""DOC_NO"",
                                 M.WHOUSE_ID            AS ""WHOUSE_ID"",
                                 M.WHOUSE_ID2           AS ""WHOUSE_ID2"",
                                 M.PROJECT_M_ID         AS ""PROJECT_M_ID"",
                                 M.BRANCH_ID            AS ""BRANCH_ID""
                                 
                                 FROM FINT_CCNB_COUNTER_M_T M
                                 WHERE M.USER_ID = {UserId}
                                ";
                if (BranchId > 0)
                {
                    sql += $" and M.BRANCH_ID = {BranchId}";
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentMModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<TempDocumentMModel>> GetTempDocumentM(int TempDocumentMıd, DataClient data)
        {
            ServiceResult<List<TempDocumentMModel>> serviceResult = new ServiceResult<List<TempDocumentMModel>>();
            try
            {
                string sql = $@" SELECT
                                    M.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                    M.DOCUMENT_TYPE ""DOCUMENT_TYPE"",
                                    M.USER_ID ""USER_ID"",
                                    TO_CHAR(M.DOC_DATE,'DD.MM.YYYY') AS ""DOC_DATE"",                               
                                    M.DOC_NO ""DOC_NO"",
                                    M.DOC_TRA_CODE ""DOC_TRA_CODE"",
                                    M.DOC_TRA_ID ""DOC_TRA_ID"",
                                    M.WHOUSE_ID ""WHOUSE_ID"",
                                    M.WHOUSE_ID2 ""WHOUSE_ID2"",
                                    M.PROJECT_M_ID ""PROJECT_M_ID"",
                                    M.BRANCH_ID ""BRANCH_ID"",
                                    M.SERIAL_NUMBER ""SERIAL_NUMBER"",
                                    M.SORT_NO ""SORT_NO"",
                                    M.TRANSACTION_ID ""TRANSACTION_ID"",
                                    M.ENTITY_ID ""ENTITY_ID"",
                                    M.NOTE_LARGE ""NOTE_LARGE"",
                                    M.ASSET_LOCATION_ID ""ASSET_LOCATION_ID"",
                                    M.DOC_NO_ID ""DOC_NO_ID""
                                    FROM TEMP_DOCUMENT_M M
                                    WHERE M.DOCUMENT_M_ID = {TempDocumentMıd}
                                ";

                //Logger.WriteFileLog(new StringBuilder().Append("Sonuç:").Append(Logger.ToJson(dt)).Append(",SQL:").Append(sql).ToString());

                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentMModel>(sql);//dataTableToList<TempDocumentMModel>(dt);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<TempDocumentDModel>> GetTempDocumentDList(int UserId, int BranchId, int TempDocumentMId, DataClient data)
        {
            ServiceResult<List<TempDocumentDModel>> serviceResult = new ServiceResult<List<TempDocumentDModel>>();

            //string sql1 = $@"DELETE FROM TEMP_DOCUMENT_D WHERE QTY_READ=0";


            try
            {
                string sql = $@" SELECT
                                        D.DOCUMENT_D_ID ""DOCUMENT_D_ID"",
                                        D.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.WHOUSE_CODE,'') ""WHOUSE_CODE"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.USER_ID,0) ""USER_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.SOURCE_M_ID,0) ""SOURCE_M_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OM.ORDER_M_ID,0) ""ORDER_M_ID"",
                                        CAST({QueryHelper.GetIsNullCommand(data.Connection)}(OM.DOC_DATE,TO_DATE('01.01.1900', 'DD.MM.YYYY')) AS DATE) ""DOC_DATE"",
                                        OM.DOC_NO ""DOC_NO"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.SOURCE_D_ID,0) ""SOURCE_D_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OD.ORDER_D_ID,0) ""ORDER_D_ID"",
                                        D.ITEM_ID ""ITEM_ID"",
                                        I.ITEM_NAME ""ITEM_NAME"",
                                        I.ITEM_CODE ""ITEM_CODE"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.LOT_ID,0) ""LOT_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(L.DESCRIPTION,'') ""LOT_NAME"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.QTY_READ,0) ""QTY_READ"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.BRANCH_ID,0) ""BRANCH_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.UNIT_ID,0) ""UNIT_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(U.DESCRIPTION,'') ""UNIT_NAME"",
                                        CASE WHEN OD.ORDER_D_ID IS NULL THEN D.QTY_PRM ELSE 
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0)-(CASE WHEN OD.QTY>0 THEN (({QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0) / {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY,1)) * {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_SHIPPING,0)) ELSE 0 END) END AS ""QTY"",
                                        CASE WHEN OD.ORDER_D_ID IS NULL THEN (D.QTY_PRM - D.QTY_READ) ELSE 
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0)-(CASE WHEN OD.QTY>0 THEN (({QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0) / {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY,1)) * {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_SHIPPING,0)) ELSE 0 END) END AS ""QTY_PRM"",
                                        D.ASSET_GNL_CARD_ID ""ASSET_GNL_CARD_ID"",
                                        G.ASSET_GNL_CODE ""ASSET_GNL_CODE"",
                                        G.ASSET_GNL_DESC ""ASSET_GNL_DESC"",
                                        D.ASSET_LOCATION_ID ""ASSET_LOCATION_ID"",
                                        CASE WHEN {QueryHelper.GetIsNullCommand(data.Connection)}(D.LOT_ID,0) = 0 THEN D.LOT_CODE ELSE CAST(L.LOT_CODE AS VARCHAR(100)) END ""LOT_CODE"",
                                        AL.LOCATION_CODE ""LOCATION_CODE"",
                                        AL.LOCATION_NAME ""LOCATION_NAME"", 
                                        D.BARCODE_NO ""BARCODE_NO"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE1_ID,0) ""ATTRIBUTE1_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(A1.ITEM_ATTRIBUTE_CODE,'') ""ATTRIBUTE1_CODE"",
										{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE2_ID,0) ""ATTRIBUTE2_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(A2.ITEM_ATTRIBUTE_CODE,'') ""ATTRIBUTE2_CODE"",
										{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE3_ID,0) ""ATTRIBUTE3_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(A3.ITEM_ATTRIBUTE_CODE,'') ""ATTRIBUTE3_CODE"",
										{QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_QUALITY_ID,0) ""QUALITY_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(QUALITY.QUALITY_CODE,'') ""QUALITY_CODE"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.COLOR_ID,0) ""COLOR_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(C.COLOR_CODE,'') ""COLOR_CODE""

                                        FROM TEMP_DOCUMENT_D D
                                        LEFT JOIN              PSMT_ORDER_D    OD ON OD.ORDER_D_ID = d.SOURCE_D_ID
                                        LEFT JOIN   PSMT_ORDER_M    OM  ON OM.ORDER_M_ID = D.SOURCE_M_ID 
                                        LEFT JOIN   INVD_ITEM       I  ON I.ITEM_ID = D.ITEM_ID
                                        LEFT JOIN   INVD_UNIT       U  ON U.UNIT_ID = D.UNIT_ID
                                        LEFT JOIN   INVD_LOT        L  ON L.LOT_ID  = D.LOT_ID
                                        LEFT JOIN   INVD_COLOR      C  ON D.COLOR_ID = C.COLOR_ID
                                        LEFT JOIN   INVD_ITEM_ATTRIBUTE A1  ON D.ITEM_ATTRIBUTE1_ID = A1.ITEM_ATTRIBUTE_ID
                                        LEFT JOIN   INVD_ITEM_ATTRIBUTE A2  ON D.ITEM_ATTRIBUTE2_ID = A2.ITEM_ATTRIBUTE_ID
                                        LEFT JOIN   INVD_ITEM_ATTRIBUTE A3  ON D.ITEM_ATTRIBUTE3_ID = A3.ITEM_ATTRIBUTE_ID
                                        LEFT JOIN INVD_QUALITY QUALITY ON D.ITEM_QUALITY_ID = QUALITY.QUALITY_ID
                                        LEFT JOIN ASTD_ASSET_GNL_CARD G ON D.ASSET_GNL_CARD_ID = G.ASSET_GNL_CARD_ID

                                        LEFT JOIN ASTD_ASSET_LOCATION AL ON AL.ASSET_LOCATION_ID = D.ASSET_LOCATION_ID

                                        
                                        WHERE D.USER_ID = {UserId}
                                        
                                ";
                if (BranchId > 0)
                {
                    sql += $" and D.BRANCH_ID = {BranchId}";
                }
                if (TempDocumentMId > 0)
                {
                    sql += $" and D.DOCUMENT_M_ID = {TempDocumentMId}";
                }

                //Logger.WriteFileLog(new StringBuilder().Append("detay okuma:").Append(sql).Append("Detay:").Append(Logger.ToJson(dt)).ToString());

                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentDModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<BarcodeTypeModel>> GetBarcodeTypeList(DataClient data)
        {
            ServiceResult<List<BarcodeTypeModel>> serviceResult = new ServiceResult<List<BarcodeTypeModel>>();
            try
            {
                string sql = $@" select INV_BARCODE_TYPE_ID ""INV_BARCODE_TYPE_ID"",INV_BARCODE_TYPE_CODE ""INV_BARCODE_TYPE_CODE"",DESCRIPTION ""DESCRIPTION"" from INVD_BARCODE_TYPE ";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<BarcodeTypeModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<UnitModel>> GetItemUnitList(int ItemId, DataClient data)
        {
            ServiceResult<List<UnitModel>> serviceResult = new ServiceResult<List<UnitModel>>();
            try
            {
                string sql = $@"SELECT IU.ITEM_UNIT_ID ""ITEM_UNIT_ID"",IU.UNIT2_ID ""UNIT_ID"",U.UNIT_CODE ""UNIT_CODE"", U.DESCRIPTION ""UNIT_NAME"",I.ITEM_ID ""ITEM_ID"",I.ITEM_CODE ""ITEM_CODE"",I.ITEM_NAME ""ITEM_NAME"" 
                                FROM INVD_ITEM_UNIT IU
                                INNER JOIN INVD_UNIT U ON IU.UNIT2_ID = U.UNIT_ID
                                INNER JOIN INVD_ITEM I ON IU.ITEM_ID = I.ITEM_ID

                                WHERE I.ITEM_ID = {ItemId}                               
                                ";
                serviceResult.Success = true;
                serviceResult.Result = data.Select<UnitModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<bool> DocNoControl(Token token, string docno, DataClient data)
        {
            // Belge oluşturulurken doküman adı kontrolü yapılacak.
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                serviceResult.Success = true;

                string sql = $@"SELECT DOC_NO FROM INVT_ITEM_M WHERE DOC_NO='{docno}' AND BRANCH_ID = {token.BranchId} AND CO_ID = {token.CoId} {QueryHelper.GetLimitCommand(data.Connection)}";

                object DocNo = data.ExecuteScalar();

                if (DocNo != null)
                {
                    Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append("Belge No Mevcut!").Append("Detay:").ToString());
                    serviceResult.Success = false;
                    serviceResult.Result = false;
                    serviceResult.ErrorMessage = "Belge No Mevcut!";
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Result = true;
                    serviceResult.ErrorMessage = "Belge No kullanılabilir.";
                    return serviceResult;
                }

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.Result = false;
                serviceResult.ErrorMessage = exc.Message;
                return serviceResult;
            }

        }

        public static ServiceResult<TempDocumentMModel> InsertMasterTempDocument(TempDocumentMModel model, DataClient data)
        {
            ServiceResult<TempDocumentMModel> serviceResult = new ServiceResult<TempDocumentMModel>();
            try
            {
                IDbDataParameter[] parameters = new IDbDataParameter[24];
                parameters[0] = data.CreateDbParameter("DOCUMENT_TYPE", model.DOCUMENT_TYPE);
                parameters[1] = data.CreateDbParameter("USER_ID", model.USER_ID);
                if (model.DOC_DATE != null)
                {
                    DateTime date = DateTime.Parse(model.DOC_DATE, new CultureInfo("en-US", true));
                    parameters[2] = data.CreateDbParameter("DOC_DATE", date);
                }
                else
                {
                    parameters[2] = data.CreateDbParameter("DOC_DATE", DBNull.Value);
                }
                parameters[3] = data.CreateDbParameter("DOC_NO", model.DOC_NO);
                parameters[4] = data.CreateDbParameter("WHOUSE_ID", model.WHOUSE_ID);
                parameters[5] = data.CreateDbParameter("WHOUSE_ID2", model.WHOUSE_ID2);
                parameters[6] = data.CreateDbParameter("PROJECT_M_ID", model.PROJECT_M_ID);
                parameters[7] = data.CreateDbParameter("BRANCH_ID", model.BRANCH_ID);
                parameters[8] = data.CreateDbParameter("ENTITY_ID", model.ENTITY_ID);
                parameters[9] = data.CreateDbParameter("TRANSACTION_ID", model.TRANSACTION_ID);
                parameters[10] = data.CreateDbParameter("DOC_TRA_CODE", model.DOC_TRA_CODE);
                parameters[11] = data.CreateDbParameter("SERIAL_NUMBER", model.SERIAL_NUMBER);
                parameters[12] = data.CreateDbParameter("SORT_NO", model.SORT_NO);
                parameters[13] = data.CreateDbParameter("NOTE_LARGE", model.NOTE_LARGE);
                parameters[14] = data.CreateDbParameter("VEHICLE_ID", model.VEHICLE_ID);
                parameters[15] = data.CreateDbParameter("LICENSE_PLATE", model.LICENSE_PLATE);
                parameters[16] = data.CreateDbParameter("SHIPPINGDESC1", model.SHIPPINGDESC1);
                parameters[17] = data.CreateDbParameter("DRIVERIDENTIFYNO", model.DRIVERIDENTIFYNO);
                parameters[18] = data.CreateDbParameter("DRIVERNAME", model.DRIVERNAME);
                parameters[19] = data.CreateDbParameter("DRIVERFAMILYNAME", model.DRIVERFAMILYNAME);
                parameters[20] = data.CreateDbParameter("DRIVERGSMNO", model.DRIVERGSMNO);
                parameters[21] = data.CreateDbParameter("TRANSPORTEQUIPMENT", model.TRANSPORTEQUIPMENT);
                parameters[22] = data.CreateDbParameter("REGISTERNAME", model.REGISTERNAME);
                parameters[23] = data.CreateDbParameter("ISSUETIME", DateTime.Now);

                if (data.Execute($@"INSERT INTO TEMP_DOCUMENT_M
                                    (DOCUMENT_TYPE,DOCUMENT_M_ID,USER_ID,DOC_DATE,DOC_NO,DOC_NO_ID,WHOUSE_ID, WHOUSE_ID2,PROJECT_M_ID,BRANCH_ID,ENTITY_ID,TRANSACTION_ID,DOC_TRA_ID,DOC_TRA_CODE,SERIAL_NUMBER,SORT_NO,NOTE_LARGE,ASSET_LOCATION_ID,VEHICLE_ID,LICENSE_PLATE,SHIPPINGDESC1,DRIVERIDENTIFYNO,DRIVERNAME,DRIVERFAMILYNAME,DRIVERGSMNO,TRANSPORTEQUIPMENT,REGISTERNAME,ISSUETIME)
                                    VALUES
                                    (:DOCUMENT_TYPE,TEMP_DOCUMENT_M_ID_TEMP_DOC_M.NEXTVAL,:USER_ID,:DOC_DATE,:DOC_NO,'{model.DOC_NO_ID}',:WHOUSE_ID,:WHOUSE_ID2,:PROJECT_M_ID,:BRANCH_ID,:ENTITY_ID,:TRANSACTION_ID,{model.DOC_TRA_ID},:DOC_TRA_CODE,:SERIAL_NUMBER,:SORT_NO,:NOTE_LARGE,{model.ASSET_LOCATION_ID},:VEHICLE_ID,:LICENSE_PLATE,:SHIPPINGDESC1,:DRIVERIDENTIFYNO,:DRIVERNAME,:DRIVERFAMILYNAME,:DRIVERGSMNO,:TRANSPORTEQUIPMENT,:REGISTERNAME,:ISSUETIME)", parameters))
                {
                    serviceResult.Success = true;
                    serviceResult.Result = data.Select<TempDocumentMModel>($@"select  M.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                        M.DOCUMENT_TYPE ""DOCUMENT_TYPE"",
                                        M.USER_ID ""USER_ID"",
                                        M.DOC_DATE ""DOC_DATE"",
                                        M.DOC_NO ""DOC_NO"",
                                        M.WHOUSE_ID ""WHOUSE_ID"",
                                        M.WHOUSE_ID2 ""WHOUSE_ID2"",
                                        M.PROJECT_M_ID ""PROJECT_M_ID"",
                                        M.BRANCH_ID ""BRANCH_ID"",
                                        M.ENTITY_ID ""ENTITY_ID"",
                                        M.SERIAL_NUMBER ""SERIAL_NUMBER"",
                                        M.SORT_NO ""SORT_NO"",
                                        M.TRANSACTION_ID ""TRANSACTION_ID"",
M.VEHICLE_ID ""VEHICLE_ID"",M.LICENSE_PLATE ""LICENSE_PLATE"",M.SHIPPINGDESC1 ""SHIPPINGDESC1"",M.DRIVERIDENTIFYNO ""DRIVERIDENTIFYNO"",M.DRIVERNAME ""DRIVERNAME"",M.DRIVERFAMILYNAME ""DRIVERFAMILYNAME"",M.DRIVERGSMNO ""DRIVERGSMNO"",M.TRANSPORTEQUIPMENT ""TRANSPORTEQUIPMENT"",M.REGISTERNAME ""REGISTERNAME"",M.ISSUETIME ""ISSUETIME""
                                        from (

                                        SELECT M.DOCUMENT_M_ID,
                                        M.DOCUMENT_TYPE,
                                        M.USER_ID,
                                        M.DOC_DATE,
                                        M.DOC_NO,
                                        M.WHOUSE_ID,
                                        M.WHOUSE_ID2,
                                        M.PROJECT_M_ID,
                                        M.BRANCH_ID,
                                        M.SERIAL_NUMBER,
                                        M.SORT_NO,
                                        M.ENTITY_ID,
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(M.TRANSACTION_ID,0) TRANSACTION_ID,
                                        M.VEHICLE_ID,M.LICENSE_PLATE,M.SHIPPINGDESC1,M.DRIVERIDENTIFYNO,M.DRIVERNAME,M.DRIVERFAMILYNAME,M.DRIVERGSMNO,M.TRANSPORTEQUIPMENT,M.REGISTERNAME,M.ISSUETIME
FROM TEMP_DOCUMENT_M M WHERE M.USER_ID = {model.USER_ID} and M.BRANCH_ID = {model.BRANCH_ID}
                                        order by M.DOCUMENT_M_ID desc
                                        ) M WHERE 1 = 1 {QueryHelper.GetLimitCommand(data.Connection)}").FirstOrDefault();

                }
                else
                {
                    serviceResult.Success = false;
                    serviceResult.ErrorMessage = data.Message;
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<string> GetCycleDocNo(DataClient data)
        {
            ServiceResult<string> serviceResult = new ServiceResult<string>();
            try
            {
                string docNo = null;
                object idval = null;

                if (data.Connection is OracleConnection)
                {
                    idval = data.ExecuteScalar("select last_number + 1 \"id\" from user_sequences where sequence_name = 'TEMP_DOCUMENT_M_ID_TEMP_DOC_M'");
                }
                else if (data.Connection is NpgsqlConnection)
                {
                    idval = data.ExecuteScalar("SELECT last_value + 1 \"id\" FROM temp_document_m_document_m_id_seq");
                }
                if (idval != null)
                {
                    docNo = string.Format("S{0:00000000000}", idval);
                }

                serviceResult.Success = true;
                serviceResult.Result = docNo;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<int> InsertDetailTempDocument(TempDocumentDModel model, DataClient data)
        {
            string sql = "", sql2 = "";
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {
                var parameters = new IDbDataParameter[1];

                int QTY = Convert.ToInt32(model.QTY_READ);

                sql = $@"INSERT INTO TEMP_DOCUMENT_D (
                                                            DOCUMENT_M_ID,
                                                            DOCUMENT_D_ID,
                                                            USER_ID,
                                                            SOURCE_M_ID,
                                                            SOURCE_D_ID,
                                                            ITEM_ID,
                                                            LOT_ID,
                                                            LOT_CODE,
                                                            QTY_READ,
                                                            BRANCH_ID,
                                                            UNIT_ID,
                                                            ASSET_GNL_CARD_ID,
                                                            ASSET_LOCATION_ID,
                                                            BARCODE_NO,
                                                            QTY_PRM,
                                                            NOTE,
                                                            ITEM_ATTRIBUTE1_ID,
                                                            ITEM_ATTRIBUTE2_ID,
                                                            ITEM_ATTRIBUTE3_ID,
                                                            ITEM_QUALITY_ID,
                                                            WHOUSE_CODE,
                                                            WHOUSE_CODE2,
                                                            SHIPPING_DATE
                                                            )
                                                            VALUES(
                                                            {model.DOCUMENT_M_ID},
                                                            TEMP_DOCUMENT_D_ID_TEMP_DOC_D.NEXTVAL,
                                                            {model.USER_ID},
                                                            {model.SOURCE_M_ID},
                                                            {model.SOURCE_D_ID},
                                                            {model.ITEM_ID},
                                                            {model.LOT_ID},
                                                            '{GetString(model.LOT_CODE)}',
                                                            {QTY},
                                                            {model.BRANCH_ID},
                                                            {model.UNIT_ID},
                                                            {model.ASSET_GNL_CARD_ID},
                                                            {model.ASSET_LOCATION_ID},
                                                            '{model.BARCODE_NO}',
                                                            {model.QTY_PRM.ToString(CultureInfo.CreateSpecificCulture("en-US"))},
                                                            '{model.NOTE}',
                                                            '{model.ATTRIBUTE1_ID}',
                                                            '{model.ATTRIBUTE2_ID}',
                                                            '{model.ATTRIBUTE3_ID}',
                                                            '{model.QUALITY_ID}',
                                                            '{model.WHOUSE_CODE}',
                                                            '{model.WHOUSE_CODE2}',
                                                            :SHIPPING_DATE
                                                            )";


                if (model.SHIPPING_DATE != null)
                {
                    DateTime date = model.SHIPPING_DATE;
                    parameters[0] = data.CreateDbParameter("SHIPPING_DATE", date);
                }
                else
                {
                    parameters[0] = data.CreateDbParameter("SHIPPING_DATE", null);
                }

                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "NOTE",
                //    IsNullable = true,
                //    DbType = DbType.String,
                //    OracleDbType = OracleDbType.Varchar2,
                //    Value = model.NOTE
                //});

                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "DOCUMENT_M_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.DOCUMENT_M_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "USER_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.USER_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "SOURCE_M_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.SOURCE_M_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "SOURCE_D_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.SOURCE_D_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "ITEM_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.ITEM_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "LOT_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.LOT_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "QTY_READ",
                //    IsNullable = true,
                //    DbType = DbType.Decimal,
                //    OracleDbType = OracleDbType.Decimal,
                //    Value = model.QTY_READ
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "BRANCH_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.BRANCH_ID
                //});
                //command.Parameters.Add(new OracleParameter
                //{
                //    ParameterName = "UNIT_ID",
                //    IsNullable = true,
                //    DbType = DbType.Int32,
                //    OracleDbType = OracleDbType.Int32,
                //    Value = model.UNIT_ID
                //});
                if (!data.Execute(sql, parameters))
                    throw new Exception("Geçici Belge Detayı oluşturulamadı!");

                sql2 = $@"SELECT D.DOCUMENT_D_ID ""DOCUMENT_D_ID"",
                                        D.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                        D.USER_ID ""USER_ID"",
                                        D.SOURCE_M_ID ""SOURCE_M_ID"",
                                        D.ORDER_M_ID ""ORDER_M_ID"",
                                        D.DOC_DATE ""DOC_DATE"",
                                        D.DOC_NO ""DOC_NO"",
                                        D.SOURCE_D_ID ""SOURCE_D_ID"",
                                        D.ORDER_D_ID ""ORDER_D_ID"",
                                        D.ITEM_ID ""ITEM_ID"",
                                        D.ITEM_NAME ""ITEM_NAME"",
                                        D.ITEM_CODE ""ITEM_CODE"",
                                        D.""LOT_ID"" ""LOT_ID"",
                                        D.""LOT_NAME"" ""LOT_NAME"",
                                        D.""LOT_CODE"" ""LOT_CODE"",
                                        D.QTY_READ ""QTY_READ"",
                                        D.BRANCH_ID ""BRANCH_ID"",
                                        D.UNIT_ID ""UNIT_ID"",
                                        D.UNIT_NAME ""UNIT_NAME"",
                                        D.QTY ""QTY"",
                                        D.""ITEM_ATTRIBUTE1_ID"" ""ITEM_ATTRIBUTE1_ID"",
                                        D.""ITEM_ATTRIBUTE2_ID"" ""ITEM_ATTRIBUTE2_ID"",
                                        D.""ITEM_ATTRIBUTE3_ID"" ""ITEM_ATTRIBUTE3_ID"",
                                        D.""ITEM_QUALITY_ID"" ""ITEM_QUALITY_ID"",
                                        D.""COLOR_ID"" ""COLOR_ID"",
                                        D.""COLOR_CODE"" ""COLOR_CODE""
                                         FROM (
                                       SELECT
                                        D.DOCUMENT_D_ID,
                                        D.DOCUMENT_M_ID,
                                        D.USER_ID,
                                        D.SOURCE_M_ID,
                                        OM.ORDER_M_ID,
                                        OM.DOC_DATE,
                                        OM.DOC_NO,
                                        D.SOURCE_D_ID,
                                        OD.ORDER_D_ID,
                                        D.ITEM_ID,
                                        I.ITEM_NAME,
                                        I.ITEM_CODE,
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.LOT_ID,0) AS ""LOT_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(L.DESCRIPTION,'') AS ""LOT_NAME"",
                                        CASE WHEN D.LOT_ID = 0 THEN {QueryHelper.GetIsNullCommand(data.Connection)}(D.LOT_CODE,'') ELSE CAST({QueryHelper.GetIsNullCommand(data.Connection)}(L.LOT_CODE,'') AS VARCHAR(100)) END AS ""LOT_CODE"",
                                        D.QTY_READ,
                                        D.BRANCH_ID,
                                        D.UNIT_ID,
                                        U.DESCRIPTION UNIT_NAME,
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0)-(CASE WHEN OD.QTY>0 THEN (({QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_PRM,0) / {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY,1)) * {QueryHelper.GetIsNullCommand(data.Connection)}(OD.QTY_SHIPPING,0)) ELSE 0 END) AS QTY,
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE1_ID,0) AS ""ITEM_ATTRIBUTE1_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE2_ID,0) AS ""ITEM_ATTRIBUTE2_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_ATTRIBUTE3_ID,0) AS ""ITEM_ATTRIBUTE3_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.ITEM_QUALITY_ID,0) AS ""ITEM_QUALITY_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.COLOR_ID,0) AS ""COLOR_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(C.COLOR_CODE,'') AS ""COLOR_CODE"" 
                                        FROM TEMP_DOCUMENT_D D
                                        LEFT JOIN              PSMT_ORDER_D    OD ON OD.ORDER_D_ID = d.SOURCE_D_ID
                                        LEFT JOIN   PSMT_ORDER_M    OM  ON OM.ORDER_M_ID = D.SOURCE_M_ID 
                                        LEFT JOIN   INVD_ITEM       I  ON I.ITEM_ID = D.ITEM_ID
                                        LEFT JOIN   INVD_UNIT       U  ON U.UNIT_ID = D.UNIT_ID
                                        LEFT JOIN   INVD_LOT        L  ON L.LOT_ID  = D.LOT_ID                                        
                                        LEFT JOIN   INVD_COLOR      C  ON C.COLOR_ID = D.COLOR_ID
                                        WHERE D.USER_ID = {model.USER_ID} and D.BRANCH_ID = {model.BRANCH_ID} and D.DOCUMENT_M_ID = {model.DOCUMENT_M_ID}
                                        ORDER BY DOCUMENT_D_ID DESC ) D --WHERE 1 = 1 {QueryHelper.GetLimitCommand(data.Connection)}";
                //Logger.WriteFileLog(new StringBuilder().Append("Bilgi:").Append(sql2).ToString());
                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentDModel>(sql2).FirstOrDefault()?.DOCUMENT_D_ID ?? 0;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace)
                    .Append(",Sql1:").Append(sql).Append(",Sql2:").Append(sql2).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<TempDocumentDModel> UpdateTempDetail(TempDocumentDModel model, DataClient data, bool isdelete = false)
        {
            ServiceResult<TempDocumentDModel> serviceResult = new ServiceResult<TempDocumentDModel>();
            try
            {
                //                string sql = $@"UPDATE TEMP_DOCUMENT_D SET 
                //QTY_READ = :QTY_READ, ITEM_ATTRIBUTE1_ID = :ATTRIBUTE1_ID, ITEM_ATTRIBUTE2_ID = :ATTRIBUTE2_ID, ITEM_ATTRIBUTE3_ID = :ATTRIBUTE3_ID, LOT_ID = :LOT_ID, ITEM_QUALITY_ID = :QUALITY_ID 
                //where DOCUMENT_D_ID= :DOCUMENT_D_ID";
                string sql = null;
                if (isdelete)
                {
                    sql = $@"UPDATE TEMP_DOCUMENT_D SET 
                QTY_READ = QTY_READ - {model.QTY_READ.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, 
                ITEM_ATTRIBUTE1_ID = {model.ATTRIBUTE1_ID}, 
                ITEM_ATTRIBUTE2_ID = {model.ATTRIBUTE2_ID}, 
                ITEM_ATTRIBUTE3_ID = {model.ATTRIBUTE3_ID}, 
                LOT_ID = {model.LOT_ID}, 
                LOT_CODE = '{GetString(model.LOT_CODE)}',
                ITEM_QUALITY_ID = {model.QUALITY_ID} 
                WHERE DOCUMENT_D_ID = {model.DOCUMENT_D_ID} 
                AND (ITEM_ATTRIBUTE1_ID = 0 OR ITEM_ATTRIBUTE1_ID = {model.ATTRIBUTE1_ID})
                AND (ITEM_ATTRIBUTE2_ID = 0 OR ITEM_ATTRIBUTE2_ID = {model.ATTRIBUTE2_ID})
                AND (ITEM_ATTRIBUTE3_ID = 0 OR ITEM_ATTRIBUTE3_ID = {model.ATTRIBUTE3_ID})
                AND (LOT_ID = 0 OR LOT_ID = {model.LOT_ID})
                AND (ITEM_QUALITY_ID = 0 OR ITEM_QUALITY_ID = {model.QUALITY_ID})";
                }
                else
                {
                    sql = $@"UPDATE TEMP_DOCUMENT_D SET 
                QTY_READ = QTY_READ + {model.QTY_READ.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, 
                ITEM_ATTRIBUTE1_ID = {model.ATTRIBUTE1_ID}, 
                ITEM_ATTRIBUTE2_ID = {model.ATTRIBUTE2_ID}, 
                ITEM_ATTRIBUTE3_ID = {model.ATTRIBUTE3_ID}, 
                LOT_ID = {model.LOT_ID},
                LOT_CODE = '{GetString(model.LOT_CODE)}', 
                ITEM_QUALITY_ID = {model.QUALITY_ID} 
                WHERE DOCUMENT_D_ID = {model.DOCUMENT_D_ID} 
                AND (ITEM_ATTRIBUTE1_ID = 0 OR ITEM_ATTRIBUTE1_ID = {model.ATTRIBUTE1_ID})
                AND (ITEM_ATTRIBUTE2_ID = 0 OR ITEM_ATTRIBUTE2_ID = {model.ATTRIBUTE2_ID})
                AND (ITEM_ATTRIBUTE3_ID = 0 OR ITEM_ATTRIBUTE3_ID = {model.ATTRIBUTE3_ID})
                AND (LOT_ID = 0 OR LOT_ID = {model.LOT_ID})
                AND (ITEM_QUALITY_ID = 0 OR ITEM_QUALITY_ID = {model.QUALITY_ID})";
                }

                if (!data.Execute(sql))
                {
                    var result = InsertDetailTempDocument(model, data);
                    if (result != null && result.Success)
                    {
                        serviceResult.Success = true;
                    }
                    else
                    {
                        serviceResult.ErrorMessage = result.ErrorMessage;
                        serviceResult.Success = false;
                    }
                }
                else
                {
                    serviceResult.Success = true;
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<bool> DeleteTempDetail(TempDocumentDModel model, DataClient data)
        {
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                //Logger.WriteFileLog(new StringBuilder().Append("Belge detay sil:").Append(sql).AppendFormat("DOCUMENT_D_ID:{0}", model.DOCUMENT_D_ID).Append("Detay:").Append(resp).ToString());

                serviceResult.Success = data.Execute($@"DELETE FROM TEMP_DOCUMENT_D WHERE DOCUMENT_D_ID= '{model.DOCUMENT_D_ID}'");
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<TempDocumentMModel> DeleteTempMaster(TempDocumentMModel model, DataClient data)
        {
            ServiceResult<TempDocumentMModel> serviceResult = new ServiceResult<TempDocumentMModel>();
            try
            {
                data.Begin();
                data.Execute($@"DELETE FROM TEMP_DOCUMENT_D WHERE DOCUMENT_M_ID={model.DOCUMENT_M_ID}");
                data.Execute($@"DELETE FROM TEMP_DOCUMENT_M WHERE DOCUMENT_M_ID ={model.DOCUMENT_M_ID}");
                data.Commit();
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
                data.Rollback();
            }
        }
        public static ServiceResult<bool> TransferToErp(Token token, int TempDocumentMId, DataClient data)
        {
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                ServiceResult<List<TempDocumentMModel>> list = GetTempDocumentM(TempDocumentMId, data);
                if (list.Success && list.Result != null && list.Result.Count > 0)
                {
                    WhouseTransactionModel transaction = new WhouseTransactionModel();
                    transaction.ProjectTransactionId = Convert.ToInt32(ConfigurationManager.AppSettings["ProjectTransactionId"].ToString());
                    transaction.IndependentEntryTransactionId = Convert.ToInt32(ConfigurationManager.AppSettings["IndependentEntryTransactionId"].ToString());
                    transaction.IndependentOutTransactionId = Convert.ToInt32(ConfigurationManager.AppSettings["IndependentOutTransactionId"].ToString());
                    transaction.WhouseTransferTransactionId = Convert.ToInt32(ConfigurationManager.AppSettings["WhouseTransferTransactionId"].ToString());
                    transaction.WhouseCountingTransactionId = Convert.ToInt32(ConfigurationManager.AppSettings["WhouseCountingTransactionId"].ToString());
                    TempDocumentMModel tempMaster = list.Result.FirstOrDefault();
                    if (tempMaster.DOCUMENT_TYPE == 2)
                    {
                        tempMaster.TRANSACTION_ID = transaction.ProjectTransactionId;
                    }
                    else if (tempMaster.DOCUMENT_TYPE == 3)
                    {
                        tempMaster.TRANSACTION_ID = transaction.IndependentEntryTransactionId;
                    }
                    else if (tempMaster.DOCUMENT_TYPE == 4)
                    {
                        tempMaster.TRANSACTION_ID = transaction.IndependentOutTransactionId;
                    }
                    else if (tempMaster.DOCUMENT_TYPE == 5)
                    {
                        tempMaster.TRANSACTION_ID = transaction.WhouseTransferTransactionId;
                    }
                    else if (tempMaster.DOCUMENT_TYPE == 6)
                    {
                        tempMaster.TRANSACTION_ID = transaction.WhouseCountingTransactionId;
                    }
                    if ((tempMaster.DOCUMENT_TYPE > 1) && tempMaster.DOCUMENT_TYPE < 7)
                    {
                        data.Execute($"UPDATE TEMP_DOCUMENT_M set TRANSACTION_ID = {tempMaster.TRANSACTION_ID} where DOCUMENT_M_ID = {tempMaster.DOCUMENT_M_ID}");
                    }
                    var senfoniResult = SaveTransactionToSenfoni(token, tempMaster.DOCUMENT_M_ID, data);
                    if (senfoniResult.Success)
                    {
                        DeleteTempMaster(tempMaster, data);
                        serviceResult.Success = true;
                    }
                    else
                    {
                        serviceResult.Success = false;
                        serviceResult.ErrorMessage = senfoniResult.ErrorMessage;
                    }
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = false;
                    serviceResult.ErrorMessage = list.ErrorMessage;
                    return serviceResult;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<bool> UpdateTempMasterForSave(TempDocumentMModel tempDocumentM, int UserId, string Password, DataClient data)
        {
            string sql = "";
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                DateTime date = DateTime.Now;
                DateTime.TryParse(tempDocumentM.DOC_DATE, out date);

#warning ozellik kalite ve parti eklenecek
                string transactionSql = "";
                if (tempDocumentM.TRANSACTION_ID > 0)
                {
                    transactionSql = ",TRANSACTION_ID = " + tempDocumentM.TRANSACTION_ID;
                }

                var paramaters = new IDbDataParameter[15];
                paramaters[0] = data.CreateDbParameter("DOC_TRA_CODE", tempDocumentM.DOC_TRA_CODE);
                paramaters[1] = data.CreateDbParameter("ENTITY_ID", tempDocumentM.ENTITY_ID);
                paramaters[2] = data.CreateDbParameter("DOC_NO", tempDocumentM.DOC_NO);
                paramaters[3] = data.CreateDbParameter("SERIAL_NUMBER", tempDocumentM.SERIAL_NUMBER);
                paramaters[4] = data.CreateDbParameter("VEHICLE_ID", tempDocumentM.VEHICLE_ID);
                paramaters[5] = data.CreateDbParameter("LICENSE_PLATE", tempDocumentM.LICENSE_PLATE);
                paramaters[6] = data.CreateDbParameter("SHIPPINGDESC1", tempDocumentM.SHIPPINGDESC1);
                paramaters[7] = data.CreateDbParameter("DRIVERIDENTIFYNO", tempDocumentM.DRIVERIDENTIFYNO);
                paramaters[8] = data.CreateDbParameter("DRIVERNAME", tempDocumentM.DRIVERNAME);
                paramaters[9] = data.CreateDbParameter("DRIVERFAMILYNAME", tempDocumentM.DRIVERFAMILYNAME);
                paramaters[10] = data.CreateDbParameter("DRIVERGSMNO", tempDocumentM.DRIVERGSMNO);
                paramaters[11] = data.CreateDbParameter("TRANSPORTEQUIPMENT", tempDocumentM.TRANSPORTEQUIPMENT);
                paramaters[12] = data.CreateDbParameter("REGISTERNAME", tempDocumentM.REGISTERNAME);
                paramaters[13] = data.CreateDbParameter("SORT_NO", tempDocumentM.SORT_NO);
                paramaters[14] = data.CreateDbParameter("DOCUMENT_M_ID", tempDocumentM.DOCUMENT_M_ID);

                serviceResult.Success = data.Execute($@"UPDATE TEMP_DOCUMENT_M SET DOC_DATE = TO_DATE('{date.ToString("yyyy-MM-dd")}','YYYY-MM-DD'), DOC_TRA_CODE = :DOC_TRA_CODE, ENTITY_ID = :ENTITY_ID, DOC_NO = :DOC_NO, SERIAL_NUMBER = :SERIAL_NUMBER, VEHICLE_ID = :VEHICLE_ID, LICENSE_PLATE = :LICENSE_PLATE, SHIPPINGDESC1 = :SHIPPINGDESC1, DRIVERIDENTIFYNO = :DRIVERIDENTIFYNO, DRIVERNAME = :DRIVERNAME, DRIVERFAMILYNAME = :DRIVERFAMILYNAME, DRIVERGSMNO = :DRIVERGSMNO, TRANSPORTEQUIPMENT = :TRANSPORTEQUIPMENT, REGISTERNAME = :REGISTERNAME, ISSUETIME = TO_DATE('{DateTime.Now.ToString("yyyy-MM-dd")}','YYYY-MM-DD'),
SORT_NO=:SORT_NO{transactionSql} where DOCUMENT_M_ID= :DOCUMENT_M_ID", paramaters);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).Append(",Sql:").Append(sql).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<bool> updateTempMasterForIndependentOperation(int TempDocumentMId, int entityId, int whouse2Id, int projectId, DataClient data)
        {
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                var paramaters = new IDbDataParameter[4];
                paramaters[0] = data.CreateDbParameter("ENTITY_ID", entityId);
                paramaters[1] = data.CreateDbParameter("PROJECT_ID", projectId);
                paramaters[2] = data.CreateDbParameter("WHOUSE_ID2", whouse2Id);
                paramaters[3] = data.CreateDbParameter("DOCUMENT_M_ID", TempDocumentMId);

                serviceResult.Success = data.Execute($@"UPDATE TEMP_DOCUMENT_m SET ENTITY_ID = :ENTITY_ID,PROJECT_ID = :PROJECT_ID, WHOUSE_ID2: WHOUSE_ID2 where DOCUMENT_M_ID= :DOCUMENT_M_ID", paramaters);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<string> SaveBarcode(int ItemId, int UnitId, int BarcodeTypeId, decimal qty, string Barcode, bool IsControlled, int UserId, DataClient data)
        {
            ServiceResult<string> serviceResult = new ServiceResult<string>();
            try
            {
                List<ItemBarcodeModel> itemBarcodeList = data.Select<ItemBarcodeModel>($@"select * from INVD_ITEM_BARCODE where ITEM_ID = {ItemId} and BARCODE = '{Barcode.Trim()}'");
                if (itemBarcodeList != null && itemBarcodeList.Count > 0)
                {
                    serviceResult.Success = false;
                    serviceResult.ErrorMessage = "Bu barkod bu ürün için daha önce kullanılmıştır tekrar kullanılamaz.";
                }
                else
                {
                    itemBarcodeList = data.Select<ItemBarcodeModel>($@"select * from INVD_ITEM_BARCODE where ITEM_ID = {ItemId} and UNIT_ID = {UnitId}");
                    if (itemBarcodeList != null && itemBarcodeList.Count > 0)
                    {
                        serviceResult.Success = false;
                        serviceResult.ErrorMessage = "Bu ürün için bu birimde daha önce barkod kaydı yapılmıştır tekrar kayıt yapılamaz.";
                    }
                    else
                    {
                        List<ItemListModel> itemBarcodeListOther = data.Select<ItemListModel>($@"select B.ITEM_ID,I.ITEM_CODE,I.ITEM_NAME from INVD_ITEM_BARCODE B INNER JOIN INVD_ITEM I ON I.ITEM_ID = B.ITEM_ID where BARCODE = '{Barcode.Trim()}'");
                        if (itemBarcodeListOther != null && itemBarcodeListOther.Count > 0)
                        {
                            if (IsControlled == true)
                            {
                                serviceResult.Success = data.Execute($@"INSERT INTO INVD_ITEM_BARCODE (CREATE_USER_ID,
                                                                                CREATE_DATE,
                                                                                BARCODE,
                                                                                COLOR_ID,
                                                                                CUR_ID,
                                                                                ITEM_ATTRIBUTE1_ID,
                                                                                ITEM_ATTRIBUTE2_ID,
                                                                                ITEM_ATTRIBUTE3_ID,
                                                                                ITEM_GNL_ATTRIBUTE1_ID,
                                                                                ITEM_GNL_ATTRIBUTE2_ID,
                                                                                ITEM_GNL_ATTRIBUTE3_ID,
                                                                                ITEM_ID,
                                                                                LINE_NO,
                                                                                LOT_ID,
                                                                                PACKAGE_TYPE_ID,
                                                                                QTY,
                                                                                QUALITY_ID,
                                                                                UNIT_ID,
                                                                                INV_BARCODE_TYPE_ID,
                                                                                BRAND_ID) 
                                                                                VALUES
                                                                                ({UserId},
                                                                                CURRENT_TIMESTAMP,
                                                                                '{Barcode.Trim()}',
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                {ItemId},
                                                                                1,
                                                                                0,
                                                                                0,
                                                                                {qty},
                                                                                0,
                                                                                {UnitId},
                                                                                {BarcodeTypeId},
                                                                                0)");

                            }
                            else
                            {
                                serviceResult.Success = false;
                                serviceResult.ErrorMessage = "Bu barkod diğer ürünlerde kullanılmaktadır. Yinede devam etmek istiyor musunuz?";
                                //itemBarcodeListOther.ForEach(x => {
                                //    serviceResult.Result.Add(x.ITEM_CODE + "_" + x.ITEM_NAME);
                                //});
                                serviceResult.Result = String.Join("<br>", itemBarcodeListOther.Select(x => x.ITEM_CODE + "_" + x.ITEM_NAME).ToList());
                            }
                        }
                        else
                        {
                            serviceResult.Success = data.Execute($@"INSERT INTO INVD_ITEM_BARCODE (CREATE_USER_ID,
                                                                                CREATE_DATE,
                                                                                BARCODE,
                                                                                COLOR_ID,
                                                                                CUR_ID,
                                                                                ITEM_ATTRIBUTE1_ID,
                                                                                ITEM_ATTRIBUTE2_ID,
                                                                                ITEM_ATTRIBUTE3_ID,
                                                                                ITEM_GNL_ATTRIBUTE1_ID,
                                                                                ITEM_GNL_ATTRIBUTE2_ID,
                                                                                ITEM_GNL_ATTRIBUTE3_ID,
                                                                                ITEM_ID,
                                                                                LINE_NO,
                                                                                LOT_ID,
                                                                                PACKAGE_TYPE_ID,
                                                                                QTY,
                                                                                QUALITY_ID,
                                                                                UNIT_ID,
                                                                                INV_BARCODE_TYPE_ID,
                                                                                BRAND_ID) 
                                                                                VALUES
                                                                                ({UserId},
                                                                                CURRENT_TIMESTAMP,
                                                                                '{Barcode}',
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                {ItemId},
                                                                                1,
                                                                                0,
                                                                                0,
                                                                                {qty},
                                                                                0,
                                                                                {UnitId},
                                                                                {BarcodeTypeId},
                                                                                0)");
                        }
                    }
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //serviceResult ex.Message;
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message;
                return serviceResult;
            }
            finally
            {

            }
            return null;
        }
        public static ServiceResult<bool> SaveTransactionToSenfoni(Token token, int tempDocumentMId, DataClient data)
        {
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            serviceResult.Result = false;
            try
            {
                string passwordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(token.Password, "sha1");
                GeneralSenfoniService senfoniService = new GeneralSenfoniService();

                TempDocumentM tempDocumentM = GetTempDocumentM(data, tempDocumentMId);
                List<TempDocumentD> tempDocumentDList = GenerateTempDocumentDList(data, tempDocumentMId);

                if (tempDocumentM.DocumentType == TempDocumentType.SatinAlmaKabul)
                {
                    ItemDef waybillForOrder = GenerateItemDefForOrder(tempDocumentM, tempDocumentDList, data);

                    ServiceRequestOfItemDef context = new ServiceRequestOfItemDef();
                    context.Value = waybillForOrder;
                    context.Token = new SenfoniGS.Token();
                    context.Token.UserName = token.Username;
                    context.Token.Password = token.Password;
                    var result = senfoniService.SaveWaybill(context);
                    serviceResult.Success = result.Result;
                    serviceResult.ErrorMessage = result.Message;
                }
                if (tempDocumentM.DocumentType == TempDocumentType.ProjeCikis ||
                   tempDocumentM.DocumentType == TempDocumentType.BagimsizGiris ||
                   tempDocumentM.DocumentType == TempDocumentType.BagimsizCikis ||
                   tempDocumentM.DocumentType == TempDocumentType.DepolarArasıTransfer
                   || tempDocumentM.DocumentType == TempDocumentType.Bagimsizİslem)
                {
                    ItemDef itemDef = GenerateItemDef(tempDocumentM, tempDocumentDList);
                    ServiceRequestOfItemDef context = new ServiceRequestOfItemDef();
                    context.Value = itemDef;
                    context.Token = new SenfoniGS.Token();
                    context.Token.UserName = token.Username;
                    context.Token.Password = token.Password;

                    var result = senfoniService.SaveItemM(context);
                    serviceResult.Success = result.Result;
                    serviceResult.ErrorMessage = result.Message;
                }
                if (tempDocumentM.DocumentType == TempDocumentType.DepoSayim)
                {
                    ItemDef itemDef = GenerateItemDef(tempDocumentM, tempDocumentDList);
                    ServiceRequestOfItemDef context = new ServiceRequestOfItemDef();
                    context.Value = itemDef;
                    context.Token = new SenfoniGS.Token();
                    context.Token.UserName = token.Username;
                    context.Token.Password = token.Password;

                    var result = senfoniService.SaveCycleCountM(context);
                    serviceResult.Success = result.Result;
                    serviceResult.ErrorMessage = result.Message;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message;
            }
            finally
            {
            }

            return serviceResult;
        }
        private static TempDocumentM GetTempDocumentM(DataClient data, int tempDocumentMId)
        {
            return data.Select<TempDocumentM>($@"SELECT T.DOCUMENT_M_ID,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.DOCUMENT_TYPE,0) AS DOCUMENT_TYPE,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.USER_ID,0) AS USER_ID,
                                               T.DOC_DATE,
                                               T.DOC_NO,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.WHOUSE_ID,0) as WHOUSE_ID,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.WHOUSE_ID2,0) AS WHOUSE_ID2,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.PROJECT_M_ID,0) AS PROJECT_M_ID,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.BRANCH_ID,0) AS BRANCH_ID,
                                               T.SERIAL_NUMBER,
                                               T.SORT_NO,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.TRANSACTION_ID,0) AS TRANSACTION_ID,
                                               B.BRANCH_CODE,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(C.CO_ID,0) AS CO_ID,
                                               C.CO_CODE,
                                               DT.DOC_TRA_CODE,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(DT.PURCHASE_SALES,0) AS PURCHASE_SALES,
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(DT.INVENTORY_STATUS,0) AS INVENTORY_STATUS
                                          FROM TEMP_DOCUMENT_M T
                                          LEFT JOIN GNLD_BRANCH B ON B.BRANCH_ID = T.BRANCH_ID
                                          LEFT JOIN GNLD_COMPANY C On C.CO_ID = B.CO_ID
                                          LEFT JOIN GNLD_DOC_TRA DT ON DT.DOC_TRA_ID = T.TRANSACTION_ID
                                         WHERE T.DOCUMENT_M_ID = {tempDocumentMId}").FirstOrDefault();
        }
        private static List<TempDocumentD> GenerateTempDocumentDList(DataClient data, int tempDocumentMId)
        {
            return data.Select<TempDocumentD>($@"SELECT T.DOCUMENT_D_ID ""Id"",
                                               T.DOCUMENT_M_ID ""TempDocumentMId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.USER_ID,0) AS ""UserId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.SOURCE_M_ID,0) AS ""SourceMId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.SOURCE_D_ID,0) AS ""SourceDId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.ITEM_ID,0) AS ""ItemId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.LOT_ID,0) AS ""LotId"",
                                               T.QTY_READ ""QtyRead"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.BRANCH_ID,0) AS ""BranchId"",
                                               {QueryHelper.GetIsNullCommand(data.Connection)}(T.UNIT_ID,0) AS ""UnitId""
                                          FROM TEMP_DOCUMENT_D T
                                          WHERE T.DOCUMENT_M_ID = {tempDocumentMId}
                                            AND T.QTY_READ > 0");
        }
        private static ItemDef GenerateItemDef(TempDocumentM tempDocumentM, List<TempDocumentD> tempDocumentDList)
        {
            ItemDef itemDef = new ItemDef();
            itemDef.Address1 = "";
            itemDef.Address2 = "";
            itemDef.Address3 = "";
            itemDef.CoCode = tempDocumentM.CoCode;
            itemDef.BranchCode = tempDocumentM.BranchCode;
            itemDef.CityId = 0;
            itemDef.CountyId = 0;
            itemDef.TownId = 0;
            itemDef.CurCode = "";
            itemDef.CurId = 0;
            itemDef.CurRateTypeId = 0;
            itemDef.CurTra = 1;
            itemDef.EntityId = 0;
            itemDef.DocTraCode = tempDocumentM.DocTraCode;
            itemDef.DueDate = DateTime.MinValue;
            itemDef.DocNo = tempDocumentM.DocNo;
            itemDef.DocDate = tempDocumentM.DocDate;
            itemDef.ReceiptDate = DateTime.MinValue;
            itemDef.Note1 = "";
            itemDef.Note2 = "";
            itemDef.SalesPersonCode = "";
            itemDef.ShippingAddress1 = "";
            itemDef.ShippingAddress2 = "";
            itemDef.ShippingAddress3 = "";
            itemDef.ShippingCityId = 0;
            itemDef.ShippingCountyId = 0;
            itemDef.ShippingTownId = 0;
            itemDef.IsWaybil = false;
            itemDef.SourceApp = SourceApplication.Stok;
            itemDef.SourceApp2 = 0;
            itemDef.SourceApp3 = SourceApplication.Stok;
            itemDef.WhouseId = tempDocumentM.WhouseId;
            itemDef.WhouseId2 = tempDocumentM.WhouseId2;

            List<ItemDetailDef> itemDetailDefList = new List<ItemDetailDef>();
            int lineNo = 0;
            for (int i = 0; i < tempDocumentDList.Count; i++)
            {
                lineNo += 10;

                ItemDetailDef itemDetailDef = new ItemDetailDef();
                itemDetailDef.LineNo = lineNo;
                itemDetailDef.LineType = LineType.S;
                itemDetailDef.WhouseId = tempDocumentM.WhouseId;
                itemDetailDef.CurCode = "";
                itemDetailDef.CurTraId = 0;
                itemDetailDef.CurRateTra = 1;
                itemDetailDef.CurRateTypeId = 0;
                //itemDetailDef.DcardCode = orderD.DcardCode;
                itemDetailDef.DcardId = tempDocumentDList[i].ItemId;
                itemDetailDef.Note1 = "";
                itemDetailDef.Qty = tempDocumentDList[i].QtyRead;
                //itemDetailDef.UnitCode = orderDList[i].UnitCode;
                itemDetailDef.UnitId = tempDocumentDList[i].UnitId;
                itemDetailDef.UnitPrice = 0;
                itemDetailDef.UnitPriceTra = 0;
                itemDetailDef.VatStatus = VatStatus.Hariç;
                itemDetailDef.VatCode = "";
                itemDetailDef.VatRate = 0;
                itemDetailDef.VatDiscCode = "";
                itemDetailDef.SourceMId = 0;
                itemDetailDef.SourceDId = 0;
                itemDetailDef.LotId = tempDocumentDList[i].LotId;
                itemDetailDef.ProjectMId = tempDocumentM.ProjectMId;
                itemDetailDefList.Add(itemDetailDef);
            }
            itemDef.Details = itemDetailDefList.ToArray();
            return itemDef;
        }
        private static ItemDef GenerateItemDefForOrder(TempDocumentM tempDocumentM, List<TempDocumentD> tempDocumentDList, DataClient data)
        {

            List<int> orderDIdList = tempDocumentDList.Select(x => x.SourceDId).ToList();
            List<OrderD> orderDList = GetOrderDList(orderDIdList, data);



            ItemDef itemDef = new ItemDef();
            itemDef.Address1 = "";
            itemDef.Address2 = "";
            itemDef.Address3 = "";
            itemDef.CoCode = tempDocumentM.CoCode;
            itemDef.BranchCode = tempDocumentM.BranchCode;
            itemDef.CityId = 0;
            itemDef.CountyId = 0;
            itemDef.TownId = 0;
            itemDef.CurCode = "";
            itemDef.CurId = orderDList[0].CurTraId;
            itemDef.CurRateTypeId = orderDList[0].CurRateTypeId;
            itemDef.CurTra = orderDList[0].CurRateTra;
            itemDef.EntityId = orderDList[0].EntityId;
            itemDef.DocTraCode = tempDocumentM.DocTraCode;
            itemDef.DueDate = orderDList[0].DueDate;
            itemDef.DocNo = tempDocumentM.DocNo;
            itemDef.DocDate = tempDocumentM.DocDate;
            itemDef.ReceiptDate = tempDocumentM.DocDate;
            itemDef.Note1 = "";
            itemDef.Note2 = "";
            itemDef.SalesPersonCode = "";
            itemDef.ShippingAddress1 = "";
            itemDef.ShippingAddress2 = "";
            itemDef.ShippingAddress3 = "";
            itemDef.ShippingCityId = 0;
            itemDef.ShippingCountyId = 0;
            itemDef.ShippingTownId = 0;
            itemDef.IsWaybil = true;
            itemDef.SourceApp = SourceApplication.SatışSiparişi;
            itemDef.SourceApp2 = 0;
            itemDef.SourceApp3 = SourceApplication.İrsaliye;
            List<ItemDetailDef> itemDetailDefList = new List<ItemDetailDef>();
            int lineNo = 0;
            for (int i = 0; i < tempDocumentDList.Count; i++)
            {
                lineNo += 10;
                OrderD orderD = orderDList.FirstOrDefault(x => x.SourceDId == tempDocumentDList[i].SourceDId);

                ItemDetailDef itemDetailDef = new ItemDetailDef();
                itemDetailDef.LineNo = lineNo;
                itemDetailDef.LineType = orderD.LineType;
                itemDetailDef.WhouseCode = orderD.WhouseCode;
                itemDetailDef.WhouseId = orderD.WhouseId;
                itemDetailDef.CurCode = orderD.CurCode;
                itemDetailDef.CurTraId = orderD.CurTraId;
                itemDetailDef.CurRateTra = orderD.CurRateTra;
                itemDetailDef.CurRateTypeId = orderD.CurRateTypeId;
                //itemDetailDef.DcardCode = orderD.DcardCode;
                itemDetailDef.DcardId = tempDocumentDList[i].ItemId;
                itemDetailDef.Note1 = orderD.Note1;
                itemDetailDef.Qty = tempDocumentDList[i].QtyRead;
                //itemDetailDef.UnitCode = orderDList[i].UnitCode;
                itemDetailDef.UnitId = tempDocumentDList[i].UnitId;
                itemDetailDef.UnitPrice = orderD.UnitPrice;
                itemDetailDef.UnitPriceTra = orderD.UnitPriceTra;
                itemDetailDef.VatStatus = orderD.VatStatus;
                itemDetailDef.VatCode = orderD.VatCode;
                itemDetailDef.VatRate = orderD.VatRate;
                itemDetailDef.VatDiscCode = orderD.VatDiscCode;
                itemDetailDef.SourceMId = orderD.SourceMId;
                itemDetailDef.SourceDId = orderD.SourceDId;
                itemDetailDef.LotId = tempDocumentDList[i].LotId;

                itemDetailDefList.Add(itemDetailDef);
            }
            itemDef.Details = itemDetailDefList.ToArray();
            return itemDef;
        }
        private static List<OrderD> GetOrderDList(List<int> orderDIdList, DataClient data)
        {
            string sql = string.Format(@"select T.ORDER_D_ID ""ORDER_D_ID"",
                                                   T.ORDER_M_ID ""ORDER_M_ID"",
                                                   T.AMT ""AMT"",
                                                   T.AMT_DISC1 ""AMT_DISC1"",
                                                   T.AMT_DISC1_TRA ""AMT_DISC1_TRA"",
                                                   T.AMT_DISC2 ""AMT_DISC2"",
                                                   T.AMT_DISC2_TRA ""AMT_DISC2_TRA"",
                                                   T.AMT_DISC3 ""AMT_DISC3"",
                                                   T.AMT_DISC3_TRA ""AMT_DISC3_TRA"",
                                                   T.AMT_TRA ""AMT_TRA"",
                                                   T.AMT_VAT ""AMT_VAT"",
                                                   T.AMT_WITH_DISC_TRA ""AMT_WITH_DISC_TRA"",
                                                   T.WHOUSE_ID ""WHOUSE_ID"",
                                                   T.ITEM_ID ""ITEM_ID"",
                                                   T.CAT_CODE1_ID ""CAT_CODE1_ID"",
                                                   T.CAT_CODE2_ID ""CAT_CODE2_ID"",
                                                   T.COLOR_ID ""COLOR_ID"",
                                                   T.COST_CENTER_ID ""COST_CENTER_ID"",
                                                   T.CUR_TRA_ID ""CUR_TRA_ID"",
                                                   T.CUR_RATE_TYPE_ID ""CUR_RATE_TYPE_ID"",
                                                   T.CUR_RATE_TRA ""CUR_RATE_TRA"",
                                                   T.LINE_TYPE ""LINE_TYPE"",
                                                   T.DCARD_ID ""DCARD_ID"",
                                                   T.DISC1_ID ""DISC1_ID"",
                                                   T.DISC1_RATE ""DISC1_RATE"",
                                                   T.DISC2_ID ""DISC2_ID"",
                                                   T.DISC2_RATE ""DISC2_RATE"",
                                                   T.DISC3_ID ""DISC3_ID"",
                                                   T.DISC3_RATE ""DISC3_RATE"",
                                                   T.DUE_DAY ""DUE_DAY"",
                                                   T.GAIN_LOSS_TYPE_ID ""GAIN_LOSS_TYPE_ID"",
                                                   T.ITEM_ATTRIBUTE1_ID ""ITEM_ATTRIBUTE1_ID"",
                                                   T.ITEM_ATTRIBUTE2_ID ""ITEM_ATTRIBUTE2_ID"",
                                                   T.ITEM_ATTRIBUTE3_ID ""ITEM_ATTRIBUTE3_ID"",
                                                   T.ITEM_GNL_ATTRIBUTE1_ID ""ITEM_GNL_ATTRIBUTE1_ID"",
                                                   T.ITEM_GNL_ATTRIBUTE2_ID ""ITEM_GNL_ATTRIBUTE2_ID"",
                                                   T.ITEM_GNL_ATTRIBUTE3_ID ""ITEM_GNL_ATTRIBUTE3_ID"",
                                                   T.LINE_NO ""LINE_NO"",
                                                   T.QTY ""QTY"",
                                                   T.QTY_PRM ""QTY_PRM"",
                                                   T.QUALITY_ID ""QUALITY_ID"",
                                                   T.UNIT_ID ""UNIT_ID"",
                                                   T.UNIT_PRICE ""UNIT_PRICE"",
                                                   T.UNIT_PRICE_TRA ""UNIT_PRICE_TRA"",
                                                   T.VAT_ID ""VAT_ID"",
                                                   T.VAT_RATE ""VAT_RATE"",
                                                   M.ENTITY_ID ""ENTITY_ID"",
                                                   T.DOC_DATE ""DOC_DATE"",
                                                   T.DUE_DATE ""DUE_DATE""
                                              from psmt_order_d t
                                               left join PSMT_ORDER_M M ON M.ORDER_M_ID = T.ORDER_M_ID
                                             where t.order_d_id IN ({0})
                                            ", string.Join(",", orderDIdList));
            List<OrderD> list = new List<OrderD>();
            IDataReader reader = data.Select(sql);
            while (reader.Read())
            {
                OrderD detail = new OrderD();
                detail.SourceDId = Convert.ToInt32(reader[0]);
                detail.SourceMId = Convert.ToInt32(reader[1]);
                detail.Amt = Convert.ToDecimal(reader[2]);
                detail.AmtDisc1 = Convert.ToDecimal(reader[3]);
                detail.AmtDisc1Tra = Convert.ToDecimal(reader[4]);
                detail.AmtDisc2 = Convert.ToDecimal(reader[5]);
                detail.AmtDisc2Tra = Convert.ToDecimal(reader[6]);
                detail.AmtDisc3 = Convert.ToDecimal(reader[7]);
                detail.AmtDisc3Tra = Convert.ToDecimal(reader[8]);
                detail.AmtTra = Convert.ToDecimal(reader[9]);
                detail.AmtVat = Convert.ToDecimal(reader[10]);
                detail.AmtWithDisc = Convert.ToDecimal(reader[11]);
                detail.WhouseId = Convert.ToInt32(reader[12]);
                detail.ItemId = Convert.ToInt32(reader[13]);
                detail.CatCode1Id = Convert.ToInt32(reader[14]);
                detail.CatCode2Id = Convert.ToInt32(reader[15]);
                detail.ColorId = Convert.ToInt32(reader[16]);
                detail.CostCenterId = Convert.ToInt32(reader[17]);
                detail.CurTraId = Convert.ToInt32(reader[18]);
                detail.CurRateTypeId = Convert.ToInt32(reader[19]);
                detail.CurRateTra = Convert.ToDecimal(reader[20]);
                if (Convert.ToInt32(reader[21]) == 1)
                    detail.LineType = LineType.S;
                if (Convert.ToInt32(reader[21]) == 2)
                    detail.LineType = LineType.M;
                if (Convert.ToInt32(reader[21]) == 3)
                    detail.LineType = LineType.H;
                detail.DcardId = Convert.ToInt32(reader[22]);
                detail.Disc1Id = Convert.ToInt32(reader[23]);
                detail.Disc1Rate = Convert.ToDecimal(reader[24]);
                detail.Disc2Id = Convert.ToInt32(reader[25]);
                detail.Disc2Rate = Convert.ToDecimal(reader[26]);
                detail.Disc3Id = Convert.ToInt32(reader[27]);
                detail.Disc3Rate = Convert.ToDecimal(reader[28]);
                detail.DueDay = Convert.ToInt32(reader[29]);
                detail.GainLossTypeId = Convert.ToInt32(reader[30]);
                detail.ItemAttribute1Id = Convert.ToInt32(reader[31]);
                detail.ItemAttribute2Id = Convert.ToInt32(reader[32]);
                detail.ItemAttribute3Id = Convert.ToInt32(reader[33]);
                detail.ItemGnlAttribute1Id = Convert.ToInt32(reader[34]);
                detail.ItemGnlAttribute1Id = Convert.ToInt32(reader[35]);
                detail.ItemGnlAttribute1Id = Convert.ToInt32(reader[36]);
                detail.LineNo = Convert.ToInt32(reader[37]);
                detail.Qty = Convert.ToDecimal(reader[38]);
                detail.QtyPrm = Convert.ToDecimal(reader[39]);
                detail.QualityId = Convert.ToInt32(reader[40]);
                detail.UnitId = Convert.ToInt32(reader[41]);
                detail.UnitPrice = Convert.ToInt32(reader[42]);
                detail.UnitPriceTra = Convert.ToInt32(reader[43]);
                detail.VatId = Convert.ToInt32(reader[44]);
                detail.VatRate = Convert.ToDecimal(reader[45]);
                detail.EntityId = Convert.ToInt32(reader[46]);
                detail.DocDate = Convert.ToDateTime(reader[47]);
                detail.DueDate = Convert.ToDateTime(reader[48]);
                list.Add(detail);
            }
            if (reader != null) reader.Close();

            return list;
        }
        public static ServiceResult<List<OrderM>> GetOrderMList(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<OrderM>> result = new ServiceResult<List<OrderM>>();
            try
            {
                string sql = string.Format(@"SELECT 
	M.ORDER_M_ID AS ""OrderMId"",M.DOC_NO AS ""DocNo"",M.DOC_DATE AS ""DocDate"",M.DUE_DATE AS ""DueDate"",
    {2}(M.NOTE1, '') AS ""Note1"", {2}(M.NOTE2, '') AS ""Note2"", {2}(M.NOTE3, '') AS ""Note3""
    FROM    PSMT_ORDER_M M WHERE M.PURCHASE_SALES = {0} AND M.ORDER_STATUS = 1 AND ENTITY_ID	= {1} ", filter.purchaseSales, filter.entity_id, QueryHelper.GetIsNullCommand(data.Connection));

                Logger.WriteFileLog(new StringBuilder().Append("Siapriş Liste:").Append(sql).ToString());

                result.Success = true;
                result.Result = data.Select<OrderM>(sql);
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                result.Success = false;
                result.ErrorMessage = exc.Message;
            }

            return result;
        }
        private static string GenerateInFilter(List<int> orderDIdList)
        {
            string paramList = string.Empty;
            for (int i = 0; i < orderDIdList.Count; i++)
            {
                if (i == 0)
                    paramList = orderDIdList[i].ToString();
                else
                    paramList += "," + orderDIdList[i].ToString();
            }
            return paramList;
        }
        private static TempDocumentD GenerateTempDocumentD(IDataReader reader)
        {
            TempDocumentD tempDocumentD = new TempDocumentD();
            tempDocumentD.Id = Convert.ToInt32(reader[0]);
            tempDocumentD.TempDocumentMId = Convert.ToInt32(reader[1]);
            tempDocumentD.UserId = Convert.ToInt32(reader[2]);
            tempDocumentD.SourceMId = Convert.ToInt32(reader[3]);
            tempDocumentD.SourceDId = Convert.ToInt32(reader[4]);
            tempDocumentD.ItemId = Convert.ToInt32(reader[5]);
            tempDocumentD.LotId = Convert.ToInt32(reader[6]);
            tempDocumentD.QtyRead = Convert.ToDecimal(reader[7]);
            tempDocumentD.BranchId = Convert.ToInt32(reader[8]);
            tempDocumentD.UnitId = Convert.ToInt32(reader[9]);
            return tempDocumentD;
        }
        private static TempDocumentM GenerateTempDocumentM(IDataReader reader)
        {
            TempDocumentM tempDocumentM = new TempDocumentM();
            tempDocumentM.Id = Convert.ToInt32(reader[0]);
            tempDocumentM.DocumentType = (TempDocumentType)Convert.ToInt32(reader[1]);
            tempDocumentM.UserId = Convert.ToInt32(reader[2]);
            tempDocumentM.DocDate = reader[3] != null ? !string.IsNullOrEmpty(reader[3].ToString()) ? Convert.ToDateTime(reader[3]) : DateTime.MinValue : DateTime.MinValue;
            tempDocumentM.DocNo = Convert.ToString(reader[4]);
            tempDocumentM.WhouseId = Convert.ToInt32(reader[5]);
            tempDocumentM.WhouseId2 = Convert.ToInt32(reader[6]);
            tempDocumentM.ProjectMId = Convert.ToInt32(reader[7]);
            tempDocumentM.BranchId = Convert.ToInt32(reader[8]);
            tempDocumentM.SerialNumber = Convert.ToString(reader[9]);
            tempDocumentM.SortNo = Convert.ToString(reader[10]);
            tempDocumentM.TransactionId = Convert.ToInt32(reader[11]);
            tempDocumentM.BranchCode = Convert.ToString(reader[12]);
            tempDocumentM.CoId = Convert.ToInt32(reader[13]);
            tempDocumentM.CoCode = Convert.ToString(reader[14]);
            tempDocumentM.DocTraCode = Convert.ToString(reader[15]);
            tempDocumentM.PurchaseSales = (PurchaseSales)Convert.ToInt32(reader[16]);
            tempDocumentM.InventoryStatus = (InventoryStatus)Convert.ToInt32(reader[17]);
            return tempDocumentM;
        }
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static ServiceResult<List<BrandModel>> GetBrandList(BrandModel filterModel, DataClient data)
        {
            ServiceResult<List<BrandModel>> serviceResult = new ServiceResult<List<BrandModel>>();
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = $@" SELECT 
                                 BRAND_ID ""BRAND_ID"",
                                 BRAND_CODE ""BRAND_CODE"",
                                 DESCRIPTION ""DESCRIPTION""
                                 FROM
                                 INVD_BRAND
                                 WHERE ISPASSIVE = 0";

                if (!string.IsNullOrEmpty(filterModel.DESCRIPTION))
                {
                    parameters.Add(data.CreateDbParameter("SEARCH_FILTER_TEXT", filterModel.DESCRIPTION));
                    sql += " AND ( LOWER(BRAND_CODE) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(DESCRIPTION) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) ";
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<BrandModel>(sql, parameters.ToArray());
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }
        public static ServiceResult<List<BranchItemModel>> GetBranchItemList(int BranchId, DataClient data)
        {
            ServiceResult<List<BranchItemModel>> serviceResult = new ServiceResult<List<BranchItemModel>>();
            try
            {
                serviceResult.Result = data.Select<BranchItemModel>($@" SELECT DISTINCT
                                 I.ITEM_ID       AS ""ItemId""
                                ,I.ITEM_CODE    AS ""ItemCode""
                                ,I.ITEM_NAME    AS ""ItemName""
                                ,U.DESCRIPTION  AS ""UnitName""
                                FROM  INVD_BRANCH_ITEM BI
                                INNER JOIN INVD_ITEM   I ON BI.ITEM_ID = I.ITEM_ID
                                INNER JOIN INVD_UNIT   U ON U.UNIT_ID  = I.UNIT_ID
                                WHERE BI.BRANCH_ID = '{BranchId}' ");
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {

            }
        }

        public static ServiceResult<List<ItemAttrModel>> GetItemAttribute(ListFilterModel filter, Token token, DataClient data)
        {
            ServiceResult<List<ItemAttrModel>> serviceResult = new ServiceResult<List<ItemAttrModel>>();
            try
            {
                serviceResult.Success = true;
                serviceResult.Result = data.Select<ItemAttrModel>($@"SELECT ITEM_ATTRIBUTE_ID ""ITEM_ATTRIBUTE_ID"",ITEM_ATTRIBUTE_CODE ""ITEM_ATTRIBUTE_CODE"",DESCRIPTION ""DESCRIPTION"",ATTRIBUTE_GRP ""ATTRIBUTE_GRP"" FROM UYUMSOFT.INVD_ITEM_ATTRIBUTE ATT WHERE ITEM_ID = {filter.item_id} ");
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<BranchWhouseModel>> GetBranchWhouseList(ListFilterModel filter, Token token, DataClient data)
        {
            ServiceResult<List<BranchWhouseModel>> serviceResult = new ServiceResult<List<BranchWhouseModel>>();
            try
            {
                if (filter.filterId == 1)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append($@"SELECT bwh_location_id ""WhouseId"",location_code ""WhouseCode"",l.whouse_id ""BranchId"",w.whouse_code || ' ' || {GetIsNullCommand(data.Connection)}(w.description, '') ""WhouseName"" 
FROM INVD_BWH_LOCATION l INNER JOIN invd_whouse w ON l.whouse_id = w.whouse_id INNER JOIN RP_INVD_WHOUSE    RP  ON BW.WHOUSE_ID = RP.WHOUSE_ID
WHERE(l.branch_id = {filter.branch_id}) ");

                    if (token.WhouseId > 0)
                    {
                        sql.AppendFormat("AND (l.whouse_id = {0}) ", token.WhouseId);
                    }

                    if (!string.IsNullOrWhiteSpace(filter.searchText))
                    {
                        sql.AppendFormat("AND (l.location_code LIKE '%{0}%' OR w.whouse_code LIKE '%{0}%' OR w.description LIKE '%{0}%') ", filter.searchText);
                    }

                    if (data.Connection is OracleConnection)
                    {
                        sql.Append(" AND ROWNUM < 1000");
                    }

                    sql.Append("ORDER BY l.whouse_id,l.location_hall_no,l.location_layer_no,l.location_section_no,l.location_sequence_no ");

                    if (data.Connection is NpgsqlConnection)
                    {
                        sql.Append(" LIMIT 1000");
                    }

                    data.Begin();
                    data.Execute(string.Format("CALL RPA_INVD_WHOUSE({0})", token.UserId));

                    serviceResult.Result = data.Select<BranchWhouseModel>(sql.ToString());
                    serviceResult.Success = true;
                    data.Commit();
                }
                else
                {
                    string sql = $@" SELECT 
                                 W.WHOUSE_ID     AS ""WhouseId""
                                ,W.WHOUSE_CODE   AS ""WhouseCode""
                                ,W.DESCRIPTION   AS ""WhouseName""
                                ,BW.BRANCH_ID    AS ""BranchId""
                                FROM INVD_BRANCH_WHOUSE     BW
                                INNER JOIN RP_INVD_WHOUSE RP
                                     ON BW.WHOUSE_ID = RP.WHOUSE_ID
                                INNER JOIN   INVD_WHOUSE            W  ON BW.WHOUSE_ID = W.WHOUSE_ID
                                WHERE 
                                BW.BRANCH_ID = {filter.branch_id} and BW.WHOUSE_ID != {token.WhouseId}";
                    if (filter.searchText != null && filter.searchText != string.Empty && filter.searchText != "")
                    {
                        sql += $@" and (lower(W.WHOUSE_CODE) like lower('%{filter.searchText}%') or lower(W.DESCRIPTION) like lower('%{filter.searchText}%'))";
                    }

                    data.Begin();
                    data.Execute(string.Format("CALL RPA_INVD_WHOUSE({0})", token.UserId));

                    serviceResult.Result = data.Select<BranchWhouseModel>(sql);
                    serviceResult.Success = serviceResult.Result != null && serviceResult.Result.Count > 0;
                    data.Commit();
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
                data.Rollback();
            }
        }
        public static ServiceResult<List<BhwItemModel>> GetBwhItemList(Token token, ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<BhwItemModel>> serviceResult = new ServiceResult<List<BhwItemModel>>();
            try
            {
                IDbDataParameter[] paramaters = null;
                string sql = $@" SELECT 
                                 BW.BWH_ITEM_ID ""BhwItemId""
                                ,I.ITEM_ID         AS ""ItemId""
                                ,I.ITEM_CODE       AS ""ItemCode""
                                ,I.ITEM_NAME       AS ""ItemName""
                                ,W.WHOUSE_CODE     AS ""WhouseCode""
                                ,W.DESCRIPTION     AS ""WhouseName""
                                ,U.DESCRIPTION     AS ""UnitName""
                                ,U.UNIT_ID         AS ""UnitId""
                                ,1        AS ""Qty""
                                FROM
                                                INVD_BWH_ITEM    BW
                                INNER JOIN      INVD_ITEM        I   ON BW.ITEM_ID    =  I.ITEM_ID
                                INNER JOIN      INVD_UNIT        U   ON U.UNIT_ID     =  I.UNIT_ID
                                INNER JOIN      INVD_WHOUSE      W   ON BW.WHOUSE_ID  =  W.WHOUSE_ID 
                                WHERE BW.BRANCH_ID = {token.BranchId} and BW.WHOUSE_ID = {token.WhouseId}";

                if (!string.IsNullOrEmpty(filterModel.searchText))
                {
                    paramaters = new IDbDataParameter[1];
                    paramaters[0] = data.CreateDbParameter("SEARCH_FILTER_TEXT", filterModel.searchText);
                    sql += " AND ( LOWER(I.ITEM_CODE ) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(I.ITEM_NAME) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) ";
                }
                else
                {
                    if (data.Connection is OracleConnection)
                    {
                        sql += " AND ROWNUM <= 100";
                    }
                    else if (data.Connection is NpgsqlConnection)
                    {
                        sql += " limit 100";
                    }

                }

                serviceResult.Result = data.Select<BhwItemModel>(sql, paramaters);
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<ProjectModel>> GetProjectList(DataClient data)
        {
            ServiceResult<List<ProjectModel>> serviceResult = new ServiceResult<List<ProjectModel>>();
            IDbCommand command = null;
            try
            {
                serviceResult.Result = data.Select<ProjectModel>($@"  SELECT
                                  P.PROJECT_M_ID    AS PROJECT_ID
                                 ,P.PROJECT_CODE   AS PROJECT_CODE
                                 ,P.DESCRIPTION    AS PROJECT_NAME
                                 FROM FIND_PROJECT_M   P ");
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<CoEntityModel>> GetCoEntityList(ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<CoEntityModel>> serviceResult = new ServiceResult<List<CoEntityModel>>();
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = $@"SELECT 
                                 E.ENTITY_CODE ""EntityCode"" 
                                ,E.ENTITY_NAME ""EntityName""
                                ,E.ENTITY_ID ""EntityId""
                                ,CE.CO_ID ""CO_ID""
                                FROM
                                            FIND_CO_ENTITY CE 
                                INNER JOIN  FIND_ENTITY    E  ON E.ENTITY_ID = CE.ENTITY_ID 
                                WHERE 
                                    CE.CO_ID     = {filter.co_id}
                                ";

                if (!string.IsNullOrEmpty(filter.searchText))
                {
                    parameters = new IDbDataParameter[1];
                    parameters[0] = data.CreateDbParameter("SEARCH_FILTER_TEXT", filter.searchText);
                    sql += " AND ((( LOWER(E.ENTITY_NAME ) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(E.ENTITY_CODE ) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ))) ";
                }

                serviceResult.Result = data.Select<CoEntityModel>(sql, parameters);
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<CoDocTraModel>> GetCoDocTraList(int CompanyId, DataClient data)
        {
            ServiceResult<List<CoDocTraModel>> serviceResult = new ServiceResult<List<CoDocTraModel>>();
            try
            {
                string sql = $@"  SELECT 
                                  D.DOC_TRA_ID       AS ""DocTraId""
                                 ,D.DOC_TRA_CODE     AS ""DocTraCode""
                                 ,D.DESCRIPTION      AS ""DocTraName""
                                 ,D.SOURCE_APP       AS ""SourceApp""
                                 FROM         GNLD_CO_DOC_TRA   C 
                                 INNER JOIN   GNLD_DOC_TRA      D ON C.DOC_TRA_ID = D.DOC_TRA_ID
                                 WHERE
                                 C.CO_ID = {CompanyId} ";

                serviceResult.Result = data.Select<CoDocTraModel>(sql);
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = GetExceptionMessage(ex);
                //EventLog.WriteEntry("Application", GetExceptionMessage(ex), EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<AssetLocationModel>> GetAssetLocationList(ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<AssetLocationModel>> serviceResult = new ServiceResult<List<AssetLocationModel>>();
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = $@" SELECT  
                                AL.ASSET_LOCATION_ID ""ASSET_LOCATION_ID"",
                                AL.LOCATION_CODE ""LOCATION_CODE"",
                                AL.LOCATION_NAME ""LOCATION_NAME"",
                                AL.BARCODE_NO ""BARCODE_NO"",
                                AL.LOCATION_SIZE ""LOCATION_SIZE"",
                                AL.EMPLOYEES_NUMBER ""EMPLOYEES_NUMBER"",
                                AL.REGISTER_ID ""REGISTER_ID""
                                FROM ASTD_ASSET_LOCATION AL WHERE AL.ASSET_LOCATION_ID > 0";

                if (!string.IsNullOrEmpty(filterModel.searchText))
                {
                    parameters = new IDbDataParameter[1];
                    parameters[0] = data.CreateDbParameter("SEARCH_FILTER_TEXT", filterModel.searchText);
                    sql += " AND ( LOWER(LOCATION_CODE) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(LOCATION_NAME) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) ";
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<AssetLocationModel>(sql, parameters);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }
        public static ServiceResult<List<AssetCardModel>> searchAssetLocationMethod(ListFilterModel filterModel, Token token, DataClient data)
        {
            ServiceResult<List<AssetCardModel>> serviceResult = new ServiceResult<List<AssetCardModel>>();
            try
            {
                string sql = $@" SELECT  
                                A.ASSET_GNL_CARD_ID ""ASSET_GNL_CARD_ID"",
                                A.ASSET_CARD_ID ""ASSET_CARD_ID"",
                                A.SERIAL_NO ""SERIAL_NO"",
                                G.ASSET_GNL_CODE ""ASSET_GNL_CODE"",
                                G.ASSET_GNL_DESC ""ASSET_GNL_DESC"",
                                A.ASSET_LOCATION_ID ""ASSET_LOCATION_ID"",
                                L.LOCATION_CODE ""LOCATION_CODE"",
                                L.LOCATION_NAME ""LOCATION_NAME""
                                FROM       ASTD_ASSET_CARD     A
                                INNER JOIN ASTD_ASSET_GNL_CARD G ON A.ASSET_GNL_CARD_ID = G.ASSET_GNL_CARD_ID
                                LEFT JOIN  ASTD_ASSET_LOCATION L ON A.ASSET_LOCATION_ID = L.ASSET_LOCATION_ID
                                WHERE
                                (A.SERIAL_NO = '{filterModel.barcode}' or G.ASSET_GNL_CODE = '{filterModel.barcode}') and A.BRANCH_ID = {token.BranchId}";
                
                serviceResult.Success = true;
                serviceResult.Result = data.Select<AssetCardModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }
        public static ServiceResult<int> InsertTempDocumentM(TempDocumentMModel model, DataClient data)
        {
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {//DUZELT returning var
                DateTime date = DateTime.Parse(model.DOC_DATE, new CultureInfo("en-US", true));
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string sql = $@"INSERT INTO TEMP_DOCUMENT_M
                                    (DOCUMENT_TYPE,USER_ID,DOC_DATE,DOC_NO,WHOUSE_ID, WHOUSE_ID2,PROJECT_M_ID,BRANCH_ID,ENTITY_ID,TRANSACTION_ID,SERIAL_NUMBER,SORT_NO)
                                    VALUES
                                    (:DOCUMENT_TYPE,:USER_ID,:DOC_DATE,:DOC_NO,:WHOUSE_ID,:WHOUSE_ID2,:PROJECT_M_ID,:BRANCH_ID,:ENTITY_ID,:TRANSACTION_ID,:SERIAL_NUMBER,:SORT_NO)
                                   RETURNING TEMP_DOCUMENT_M_ID ";

                parameters.Add(data.CreateDbParameter("DOCUMENT_TYPE", model.DOCUMENT_TYPE));
                parameters.Add(data.CreateDbParameter("USER_ID", model.USER_ID));
                parameters.Add(data.CreateDbParameter("DOC_DATE", date != null && date != DateTime.MinValue ? date : DateTime.Now));
                parameters.Add(data.CreateDbParameter("DOC_NO", model.DOC_NO));
                parameters.Add(data.CreateDbParameter("WHOUSE_ID", model.WHOUSE_ID));
                parameters.Add(data.CreateDbParameter("WHOUSE_ID2", model.WHOUSE_ID2));
                parameters.Add(data.CreateDbParameter("PROJECT_M_ID", model.PROJECT_M_ID));
                parameters.Add(data.CreateDbParameter("BRANCH_ID", model.BRANCH_ID));
                parameters.Add(data.CreateDbParameter("ENTITY_ID", model.ENTITY_ID));
                parameters.Add(data.CreateDbParameter("TRANSACTION_ID", model.TRANSACTION_ID));
                parameters.Add(data.CreateDbParameter("SERIAL_NUMBER", model.SERIAL_NUMBER));
                parameters.Add(data.CreateDbParameter("SORT_NO", model.SORT_NO));

                serviceResult.Success = true;
                serviceResult.Result = data.Count(sql, parameters.ToArray());
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<AssetCardModel>> UpdateAssetLocation(ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<List<AssetCardModel>> serviceResult = new ServiceResult<List<AssetCardModel>>();
            try
            {
                string sql = $@" UPDATE  ASTD_ASSET_CARD SET ASSET_LOCATION_ID = {filterModel.location_id}  WHERE ASSET_CARD_ID = {filterModel.item_id}";

                serviceResult.Result = new List<AssetCardModel>();
                serviceResult.Success = data.Execute(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }

        public static ServiceResult<int> DeleteTempDetailForItem(TempDocumentDModel model, DataClient data)
        {
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {
                string sql = $@"DELETE FROM TEMP_DOCUMENT_D WHERE DOCUMENT_M_ID= {model.DOCUMENT_M_ID} AND ASSET_GNL_CARD_ID = {model.ITEM_ID}";

                serviceResult.Success = data.Execute(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<ItemBarcodeModel>> searchItemMethod(ListFilterModel filterModel, Token token, DataClient data)
        {
            /*
             select
                                bw.bwh_item_id,
                                bw.branch_id,
                                bw.whouse_id,
                                ib.barcode,
                                i.item_id,
                                u.unit_id,
                                w.whouse_code,
                                w.description,
                                i.item_code,
                                i.item_name,
                                u.unit_code,
                                u.description,
                                0 as qty_prm,
                                COALESCE(i.unit_id,0)  as read_unit_id,
                                ib.qty,
ib.item_attribute1_id,
																ib.item_attribute2_id,
																ib.item_attribute3_id,
																ib.quality_id,
																ib.color_id,
																ib.lot_id
                                from invd_bwh_item            bw 
                                inner join invd_item          i  on i.item_id       = bw.item_id 
                                left  join invd_item_barcode  ib on ib.item_id      = bw.item_id
                                left join invd_unit          u  on u.unit_id       = ib.unit_id
                                inner join invd_whouse        w  on w.whouse_id     = bw.whouse_id
                                where
                                bw.branch_id=6749 and
                                bw.whouse_id=3865 and
                                (ib.barcode='4015-1-117779-1' or i.item_code = '4015-1-117779-1')

                                Detay:[{"bwh_item_id":1313616,"branch_id":6749,"whouse_id":3865,"barcode":"4015-1-117779-1","item_id":117779,"unit_id":165,"whouse_code":"C-1000","description":"KALİTE DEPO","item_code":"H90 01 001 01 00 00001","item_name":"KUVARS 38 MICRON","unit_code":"KG","description1":"KG","qty_prm":0,"read_unit_id":165,"qty":1272.0,"item_attribute1_id":0,"item_attribute2_id":0,"item_attribute3_id":0,"quality_id":153,"color_id":0,"lot_id":82552}]
             */
            ServiceResult<List<ItemBarcodeModel>> serviceResult = new ServiceResult<List<ItemBarcodeModel>>();
            try
            {
                string sql = $@" select
                                bw.bwh_item_id,
                                bw.branch_id,
                                bw.whouse_id,
                                ib.barcode,
                                i.item_id,
                                CASE WHEN u.unit_id IS NULL THEN i.unit_id ELSE u.unit_id END ""UNIT_ID"",
                                w.whouse_code,
                                w.description,
                                i.item_code,
                                i.item_name,
                                CASE WHEN u.unit_id IS NULL THEN u2.unit_code ELSE u.unit_code END ""UNIT_CODE"",
                                u.description,
                                0 as qty_prm,
                                {QueryHelper.GetIsNullCommand(data.Connection)}(i.unit_id,0)  as read_unit_id,
                                ib.qty,
                                ib.item_attribute1_id,
								ib.item_attribute2_id,
								ib.item_attribute3_id,
								ib.quality_id,
								ib.color_id,
								ib.lot_id,
                                il.lot_code
                                from invd_bwh_item            bw 
                                inner join invd_item          i  on i.item_id       = bw.item_id 
                                left  join invd_item_barcode  ib on ib.item_id      = bw.item_id
                                left join invd_unit          u  on u.unit_id       = ib.unit_id
                                inner join invd_whouse        w  on w.whouse_id     = bw.whouse_id
                                left join invd_unit u2 ON i.unit_id = u2.unit_id
                                left join invd_lot il on il.lot_id = ib.lot_id
                                where
                                bw.branch_id={token.BranchId} and
                                bw.whouse_id={token.WhouseId} and
                                (ib.barcode='{filterModel.barcode}' or i.item_code = '{filterModel.barcode}')";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<ItemBarcodeModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                serviceResult.Result = new List<ItemBarcodeModel>();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }
        public static ServiceResult<List<TempDocumentDModel>> GetTempDControlByItem(TempDocumentDModel model, Token token, DataClient data)
        {
            ServiceResult<List<TempDocumentDModel>> serviceResult = new ServiceResult<List<TempDocumentDModel>>();
            try
            {
#warning kalite ozellik ve parti eklenecek
                string sql = $"SELECT * FROM temp_document_d where document_d_id = {model.DOCUMENT_D_ID} and item_id = {model.ITEM_ID} and unit_id = {model.UNIT_ID}";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentDModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<TempDocumentDModel>> GetTempDocumentDTableItemList(Token token, DataClient data, int document_m_id, ListFilterModel filter)
        {
            ServiceResult<List<TempDocumentDModel>> serviceResult = new ServiceResult<List<TempDocumentDModel>>();
            try
            {
                string sql = $@" SELECT 
                                        D.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                        D.DOCUMENT_D_ID ""DOCUMENT_D_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.USER_ID,0) ""USER_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.SOURCE_M_ID,0) ""SOURCE_M_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OM.ORDER_M_ID,0) ""ORDER_M_ID"",
                                        cast(OM.DOC_DATE as date) ""DOC_DATE"",
                                        OM.DOC_NO ""DOC_NO"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.SOURCE_D_ID,0) ""SOURCE_D_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(OD.ORDER_D_ID,0) ""ORDER_D_ID"",
                                        D.ITEM_ID ""ITEM_ID"",
                                        I.ITEM_NAME ""ITEM_NAME"",
                                        I.ITEM_CODE ""ITEM_CODE"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.QTY_READ,0) ""QTY_READ"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.BRANCH_ID,0) ""BRANCH_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}( D.UNIT_ID,0) ""UNIT_ID"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(U.DESCRIPTION,'') ""UNIT_NAME"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.QTY_PRM,0) ""QTY"",
                                        {QueryHelper.GetIsNullCommand(data.Connection)}(D.QTY_PRM,0) ""QTY_PRM""

                                        FROM TEMP_DOCUMENT_D D
                                        LEFT JOIN              PSMT_ORDER_D    OD ON OD.ORDER_D_ID = d.SOURCE_D_ID
                                        LEFT JOIN   PSMT_ORDER_M    OM  ON OM.ORDER_M_ID = D.SOURCE_M_ID 
                                        LEFT JOIN   INVD_ITEM       I  ON I.ITEM_ID = D.ITEM_ID
                                        LEFT JOIN   INVD_UNIT       U  ON U.UNIT_ID = D.UNIT_ID
                                where document_m_id = {document_m_id}
                                ";
                if (filter.id > 0)
                {
                    sql = sql + $" and document_d_id = {filter.id}";
                }
                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentDModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<string> GetPackageDocNo(ListFilterModel filterModel, DataClient data)
        {
            ServiceResult<string> serviceResult = new ServiceResult<string>();
            try
            {
                string docNo = null;
                using (DocNumberGenerator gen = DocNumberGenerator.Instance(filterModel, data.Connection))
                {
                    docNo = gen.Generate();
                }

                serviceResult.Success = true;
                serviceResult.Result = docNo;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<List<DocTraModel>> GetDocTra2List(ListFilterModel filterModel, Token token, DataClient data)
        {
            ServiceResult<List<DocTraModel>> serviceResult = new ServiceResult<List<DocTraModel>>();
            try
            {
                //TODO hareket kodlari (2)
                IDbDataParameter[] parameters = null;
                string sql = $@"     select
                                     {QueryHelper.GetIsNullCommand(data.Connection)}(G.DOC_TRA_ID,0)          as ""DOC_TRA_ID""
                                    ,{QueryHelper.GetIsNullCommand(data.Connection)}(G.DESCRIPTION,'')        as ""DOC_TRA_NAME""
                                    ,{QueryHelper.GetIsNullCommand(data.Connection)}(G.DOC_TRA_CODE,'')       as ""DOC_TRA_CODE""
                                    ,{QueryHelper.GetIsNullCommand(data.Connection)}(G.INVENTORY_STATUS,0)    as ""INVENTORY_STATUS""
                                    ,{QueryHelper.GetIsNullCommand(data.Connection)}(F.IS_REQUIRED_ENTITY,0)  as ""IS_REQUIRED_ENTITY""
                                    ,{QueryHelper.GetIsNullCommand(data.Connection)}(F.IS_REQUIRED_PROJECT,0) as ""IS_REQUIRED_PROJECT""

                                    from GNLD_DOC_TRA G
                                    inner join FIND_CCNB_DOC_TRA2 F on F.doc_tra_id = G.doc_tra_id
                                    where 
                                    G.SOURCE_APP = 210      and 
                                    F.CO_ID = {token.CoId} and
                                    {QueryHelper.GetIsNullCommand(data.Connection)}(G.INVENTORY_STATUS,0) <> 0 ";


                if (!string.IsNullOrEmpty(filterModel.searchText))
                {
                    parameters = new IDbDataParameter[1];
                    parameters[0] = data.CreateDbParameter("SEARCH_FILTER_TEXT", filterModel.searchText);
                    sql += " AND ( LOWER(DOC_TRA_CODE) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) OR ( LOWER(DESCRIPTION) LIKE LOWER('%' || :SEARCH_FILTER_TEXT || '%') ) ";
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<DocTraModel>(sql, parameters);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Depo stok goruntuleme
        /// </summary>
        /// <param name="filterModel"></param>
        /// <param name="token"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static ServiceResult<List<BhwItemModel>> GetBwhItemInfo(ListFilterModel filterModel, Token token, DataClient data)
        {
            ServiceResult<List<BhwItemModel>> serviceResult = new ServiceResult<List<BhwItemModel>>();
            try
            {

                string itemcode = null;
                if (!string.IsNullOrWhiteSpace(filterModel.searchText))
                {
                    string sqlbarcode = string.Concat("SELECT B.ITEM_ID,M.ITEM_CODE FROM INVD_ITEM_BARCODE B INNER JOIN INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID WHERE B.BARCODE = '", filterModel.searchText.Replace("'", "`"), "'");

                    using (IDataReader dr = data.Select(sqlbarcode))
                    {
                        if (dr != null && dr.Read())
                        {
                            if (DBNull.Value != dr.GetValue(1))
                                itemcode = dr.GetValue(1).ToString();
                            dr.Close();
                        }
                    }
                }

                string sql = $@" Select
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.bwh_item_id,0)                as ""BhwItemId"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.item_id,0)                    as ""ItemId"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(i.item_code,'')                   as ""ItemCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(i.item_name,'')                   as ""ItemName"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(w.whouse_code,'')                 as ""WhouseCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(w.description,'')                 as ""WhouseName"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.qty_prm,0)                    as ""Qty"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(u.unit_code,'')                   as ""UnitCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(u.description,'')                 as ""UnitName"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.add_string01,'')              as ""AddStrin01""
                            from invd_bwh_item bwi
                            inner join invd_item        i on i.item_id    = bwi.item_id
                            inner join invd_whouse      w on w.whouse_id  = bwi.whouse_id
                            inner join invd_unit        u on u.unit_id    = i.unit_id
                            where bwi.branch_id={token.BranchId}
                            and   bwi.whouse_id={token.WhouseId}
                            and bwi.qty_prm !=0
                            ";

                if (itemcode != null)
                {
                    sql = string.Concat(sql, " and  i.item_code  = '", itemcode, "' ");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(filterModel.searchText))
                    {
                        sql = string.Concat(sql, " and  i.item_code  like '", filterModel.searchText, "%' ");
                    }
                }

                serviceResult.Success = true;
                serviceResult.Result = data.Select<BhwItemModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<BhwItemModel>> GetItemInfo(ListFilterModel filterModel, Token token, DataClient data)
        {
            ServiceResult<List<BhwItemModel>> serviceResult = new ServiceResult<List<BhwItemModel>>();
            try
            {
                string sql = $@" Select
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.bwh_item_id,0)                as ""BhwItemId"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.item_id,0)                    as ""ItemId"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(i.item_code,'')                   as ""ItemCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(i.item_name,'')                   as ""ItemName"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(w.whouse_code,'')                 as ""WhouseCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(w.description,'')                 as ""WhouseName"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(bwi.qty_prm,0)                    as ""Qty"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(u.unit_code,'')                   as ""UnitCode"",
                            {QueryHelper.GetIsNullCommand(data.Connection)}(u.description,'')                 as ""UnitName""
                            from invd_bwh_item bwi
                            inner join invd_item        i on i.item_id    = bwi.item_id
                            inner join invd_whouse      w on w.whouse_id  = bwi.whouse_id
                            inner join invd_unit        u on u.unit_id    = i.unit_id
                            where bwi.branch_id={token.BranchId}
                            and   i.item_id={filterModel.item_id}
                            and bwi.qty_prm !=0
                            ";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<BhwItemModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                return serviceResult;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<AssetCardModel>> GetLocationInfoList(ListFilterModel filterModel, Token token, DataClient data)
        {
            ServiceResult<List<AssetCardModel>> serviceResult = new ServiceResult<List<AssetCardModel>>();
            try
            {
                string sql = $@"select 
                                {QueryHelper.GetIsNullCommand(data.Connection)}(agc.asset_gnl_card_id,0) as ""ASSET_GNL_CARD_ID"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(agc.asset_gnl_card_id,0) as ""ASSET_GNL_CARD_ID"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(agc.asset_gnl_code,'')   as ""ASSET_GNL_CODE"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(agc.asset_gnl_desc,'')   as ""ASSET_GNL_DESC"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(ac.serial_no,'')         as ""SERIAL_NO"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(al.location_code,'')     as ""LOCATION_CODE"",
                                {QueryHelper.GetIsNullCommand(data.Connection)}(al.location_name,'')     as ""LOCATION_NAME""
                                from astd_asset_card ac
                                inner join astd_asset_gnl_card agc on agc.asset_gnl_card_id   = ac.asset_gnl_card_id
                                inner join astd_asset_location al  on al.asset_location_id    = ac.asset_location_id

                                WHERE
                                al.ASSET_LOCATION_ID = '{filterModel.location_id}' and ac.BRANCH_ID = {token.BranchId}";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<AssetCardModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
            }
            finally
            {
            }
        }

        public static ServiceResult<List<TempDocumentMModel>> GetTempDocumentMForHalfDocument(int UserId, DataClient data)
        {
            ServiceResult<List<TempDocumentMModel>> serviceResult = new ServiceResult<List<TempDocumentMModel>>();
            try
            {
                string sql = $@" SELECT
                                    M.DOCUMENT_M_ID ""DOCUMENT_M_ID"",
                                    M.DOCUMENT_TYPE ""DOCUMENT_TYPE"",
                                    M.USER_ID ""USER_ID"",
                                    M.DOC_DATE ""DOC_DATE"",
                                    M.DOC_NO ""DOC_NO"",
                                    {QueryHelper.GetIsNullCommand(data.Connection)}(M.WHOUSE_ID,0) AS ""WHOUSE_ID"",
                                    M.WHOUSE_ID2 ""WHOUSE_ID2"",
                                    M.PROJECT_M_ID ""PROJECT_M_ID"",
                                    M.BRANCH_ID ""BRANCH_ID"",
                                    M.SERIAL_NUMBER ""SERIAL_NUMBER"",
                                    M.SORT_NO ""SORT_NO"",
                                    M.TRANSACTION_ID ""TRANSACTION_ID"",
                                    M.ASSET_LOCATION_ID ""ASSET_LOCATION_ID"",
                                    GB.BRANCH_DESC AS ""BRANCH_NAME"",
                                    {QueryHelper.GetIsNullCommand(data.Connection)}(W.DESCRIPTION,'') AS ""WHOUSE_NAME"",
                                    GB.CO_ID ""CO_ID"",
                                    M.ENTITY_ID ""ENTITY_ID"",
                                    D.DOC_TRA_CODE ""DOC_TRA_CODE"",
                                    D.DESCRIPTION AS ""DOC_TRA_NAME""
                                    FROM TEMP_DOCUMENT_M M
                                    LEFT JOIN ASTD_ASSET_LOCATION A ON A.ASSET_LOCATION_ID = M.ASSET_LOCATION_ID
                                    INNER JOIN GNLD_BRANCH GB ON GB.BRANCH_ID = M.BRANCH_ID
                                    LEFT JOIN INVD_WHOUSE W ON W.WHOUSE_ID = M.WHOUSE_ID
                                    LEFT JOIN GNLD_DOC_TRA D ON D.DOC_TRA_ID = M.TRANSACTION_ID



                                    WHERE M.USER_ID = {UserId}
                                ";
                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentMModel>(sql);
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<PurchaseOrderDListModel> GetPurchaseOrderD(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<PurchaseOrderDListModel> serviceResult = new ServiceResult<PurchaseOrderDListModel>();
            try
            {//DUZELT to_char nvl is null var
                ServiceResult<List<PurchaseOrderDListModel>> orderDetailList = new ServiceResult<List<PurchaseOrderDListModel>>();
                string sql = $@"SELECT
                                 D.ORDER_M_ID ""ORDER_M_ID""
                                ,D.ORDER_D_ID ""ORDER_D_ID""
                                ,I.ITEM_CODE ""ITEM_CODE""
                                ,I.ITEM_NAME ""ITEM_NAME""
                                ,I.ITEM_ID ""ITEM_ID""
                                ,D.QTY_PRM - (CASE WHEN D.QTY > 0 THEN ((D.QTY_PRM / D.QTY) * D.QTY_SHIPPING) ELSE 0 END) AS ""QTY""
                                ,U.DESCRIPTION  AS ""UNIT_DESC""
                                ,D.LINE_TYPE ""LINE_TYPE""
                                ,D.BRANCH_ID ""BRANCH_ID""
                                ,0 AS ""QTY_READ""
                                ,U.UNIT_ID ""UNIT_ID""
                                ,cast(M.DOC_DATE as date) ""DOC_DATE""
                                ,TO_CHAR(M.DOC_DATE, 'DD-MM-YYYY')	 as ""DOC_DATE_S""
                                ,M.DOC_NO ""DOC_NO""
                                ,E.ENTITY_CODE ""ENTITY_CODE""
                                ,E.ENTITY_NAME ""ENTITY_NAME""
                                ,E.ENTITY_ID ""ENTITY_ID""
                                ,M.ORDER_M_ID ""ORDER_M_ID""
                                ,M.DELIVERY_DATE ""DELIVERY_DATE""
                                ,D.CUR_RATE_TRA ""CUR_RATE_TRA""
                                ,D.CUR_TRA_ID ""CUR_TRA_ID""
                                ,D.CUR_RATE_TYPE_ID ""CUR_RATE_TYPE_ID""
                                ,M.CUR_RATE_TRA AS ""CUR_RATE_TRA_M""
                                ,M.CUR_TRA_ID AS ""CUR_TRA_ID_M""
                                ,M.CUR_RATE_TYPE_ID AS ""CUR_RATE_TYPE_ID_M""
                                ,D.UNIT_PRICE ""UNIT_PRICE""
                                ,D.DUE_DATE ""DUE_DATE""
                                ,D.DUE_DAY ""DUE_DAY""
                                FROM
                                             PSMT_ORDER_D    D 
                                INNER JOIN   PSMT_ORDER_M    M  ON M.ORDER_M_ID = D.ORDER_M_ID 
                                INNER JOIN   FIND_ENTITY     E  ON M.ENTITY_ID = E.ENTITY_ID
                                INNER JOIN   INVD_ITEM       I  ON I.ITEM_ID = D.ITEM_ID
                                INNER JOIN   INVD_UNIT       U  ON U.UNIT_ID = I.UNIT_ID
                                WHERE 
                                     M.BRANCH_ID      = {filter.branch_id}
                                AND  M.ENTITY_ID      = {filter.entity_id}
                                AND  D.WHOUSE_ID      = {token.WhouseId}
                                AND  M.PURCHASE_SALES = {filter.purchaseSales}
                                AND  M.ORDER_STATUS   = 1
                                AND  D.ORDER_STATUS   = 1
                                AND D.LINE_TYPE = 1
                                --AND M.REQUEST_STATUS =4
                                AND D.ORDER_D_ID = {filter.id}
                                ";

                orderDetailList.Success = true;
                orderDetailList.Result = data.Select<PurchaseOrderDListModel>(sql);
                TempDocumentMModel masterTemp = new TempDocumentMModel();
                masterTemp.BRANCH_ID = token.BranchId;
                //masterTemp.USER_ID = filterModel.USER_ID;
                masterTemp.WHOUSE_ID = token.WhouseId;
                if (filter.purchaseSales == 1)
                {
                    masterTemp.DOCUMENT_TYPE = 10;
                }
                else
                {
                    masterTemp.DOCUMENT_TYPE = 40;

                }
                serviceResult.Success = true;
                serviceResult.Result = orderDetailList.Result.FirstOrDefault();

                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<CompanyModel> GetCompany(int CoId, DataClient data)
        {
            ServiceResult<CompanyModel> serviceResult = new ServiceResult<CompanyModel>();
            try
            {
                serviceResult.Success = true;
                serviceResult.Result = data.Select<CompanyModel>($@"SELECT
            C.CO_ID ""CO_ID""
            ,C.CO_CODE ""CO_CODE""
            ,C.CO_DESC ""CO_DESC""
            ,C.CUR_ID ""CUR_ID""
            ,C.CUR_RATE_TYPE_ID ""CUR_RATE_TYPE_ID""
            ,C.CUR_TRA_ID ""CUR_TRA_ID""
                                
                                FROM
                                             GNLD_COMPANY    C
                                             WHERE C.CO_ID = {CoId}").FirstOrDefault();
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<VehicleModel>> GetVehicleList(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<VehicleModel>> serviceResult = new ServiceResult<List<VehicleModel>>();
            try
            {

                serviceResult.Success = true;
                serviceResult.Result = data.Select<VehicleModel>("SELECT VEHICLE_ID,LICENSE_PLATE,DESCRIPTION,NOTE FROM PSMD_VEHICLE");

                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<int> InsertAssetCountM(TempDocumentMModel model, Token token, DataClient data)
        {
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {
                var parameter = new IDbDataParameter[1];
                string sql = $@"INSERT INTO ASTD_ASSET_CARD_COUNT_M (
                                                            create_user_id,
                                                            create_date,
                                                            branch_id,
                                                            co_id,
                                                            doc_no,
                                                            doc_date,
                                                            asset_location_id)
                                                            VALUES(
                                                            {token.UserId},
                                                            CURRENT_TIMESTAMP,
                                                            {token.BranchId},
                                                            {token.CoId},
                                                             '{model.DOC_NO}',
                                                             :DOC_DATE,
                                                            {model.ASSET_LOCATION_ID}                                                  
                                                            )";


                if (model.DOC_DATE != null)
                {
                    DateTime date = DateTime.Parse(model.DOC_DATE, new CultureInfo("en-US", true));
                    parameter[0] = data.CreateDbParameter("DOC_DATE", date);
                }
                else
                {
                    parameter[0] = data.CreateDbParameter("DOC_DATE", null);
                }

                data.Execute(sql, parameter);

                string sql2 = $@"select * from astd_asset_card_count_m order by asset_card_count_m_id desc  ";

                serviceResult.Success = true;
                serviceResult.Result = data.Select<TempDocumentDModel>(sql2).FirstOrDefault().ASSET_CARD_COUNT_M_ID;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<int> InsertAssetCountD(TempDocumentDModel model, Token token, DataClient data)
        {
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {//DUZELT sysdate var
                serviceResult.Success = data.Execute($@"INSERT INTO ASTD_ASSET_CARD_COUNT_D (
                                                            create_user_id,
                                                            create_date,
                                                            asset_card_count_m_id,
                                                            asset_gnl_card_id,
                                                            qty,
                                                            barcode_no,
                                                            asset_location_id)
                                                            VALUES(
                                                            {token.UserId},
                                                            CURRENT_TIMESTAMP,
                                                            {model.ASSET_CARD_COUNT_M_ID},
                                                            {model.ASSET_GNL_CARD_ID},
                                                            {model.QTY_READ},
                                                           '{model.BARCODE_NO}',
                                                            {model.ASSET_LOCATION_ID}                                                  
                                                            )");
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }
        public static ServiceResult<int> DeleteAssetCount(int AssetCardCountMId, DataClient data)
        {
            ServiceResult<int> serviceResult = new ServiceResult<int>();
            try
            {
                data.Execute($@"delete from  ASTD_ASSET_CARD_COUNT_M where asset_card_count_m_id = {AssetCardCountMId}  ");

                data.Execute($@"delete from  ASTD_ASSET_CARD_COUNT_D where asset_card_count_m_id = {AssetCardCountMId}  ");

                string sql2 = $@"delete from  ASTD_ASSET_CARD_COUNT_D where asset_card_count_m_id = {AssetCardCountMId}  ";

                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
            }
        }

        public static ServiceResult<List<RecordModel>> GetRecords(Token token, ListFilterModel filter, DataClient data)
        {
            ServiceResult<List<RecordModel>> result = new ServiceResult<List<RecordModel>>();
            result.Result = new List<RecordModel>();
            try
            {

                StringBuilder sql = null;

                if (filter.filterId == 30) // sayim belgesi
                {
                    sql = new StringBuilder();
                    sql.AppendFormat(@"SELECT m.cycle_count_m_id ""RecordModelId"",m.doc_no ""DocNo"",m.doc_date ""DocDate"",w.whouse_id ""WarehouseId"",w.whouse_code ""WarehouseCode"",w.description ""WarehouseName"",m.is_count_with_location ""EntityId"", m.note1 ""EntityCode"",m.note_large ""EntityName""
FROM uyumsoft.invt_cycle_count_m m LEFT JOIN uyumsoft.invd_whouse w ON m.whouse_id = w.whouse_id WHERE m.create_user_id = {0} order by m.create_date desc", token.UserId);
                }
                else
                {
                    sql = new StringBuilder();
                    sql.AppendFormat(@"SELECT m.item_m_id ""RecordModelId"",m.doc_no AS ""DocNo"",m.doc_date ""DocDate"",m.entity_id ""EntityId"",en.entity_code ""EntityCode"",en.entity_name ""EntityName"",
m.purchase_sales ""PurchaseSales"", m.is_waybil ""Irsaliye"", m.source_app ""Kaynak"", w.whouse_id ""WarehouseId"", w.whouse_code ""WarehouseCode"", w.description ""WarehouseName""
FROM
uyumsoft.invt_item_m m LEFT JOIN
uyumsoft.find_entity en ON m.entity_id = en.entity_id LEFT JOIN
uyumsoft.invd_whouse w ON m.whouse_id = w.whouse_id
WHERE /*m.create_user_id = {0} AND*/ m.is_waybil = {1} AND m.purchase_sales = {2} ", token.UserId, filter.filterId == 60 ? 0 : 1, filter.filterId == 60 ? 0 : filter.purchaseSales);

                    if (filter.entity_id > 0)
                    {
                        sql.AppendFormat(" AND (m.entity_id = '{0}')", filter.entity_id);
                    }
                    if (!string.IsNullOrWhiteSpace(filter.searchText))
                    {
                        sql.AppendFormat(" AND (m.doc_no LIKE '%{0}%')", filter.searchText.Replace("'", "`"));
                    }
                    sql.Append("order by m.create_date desc ");

                }

                if (sql != null)
                {
                    IDataReader reader = data.Select(sql.ToString());
                    while (reader.Read())
                    {
                        RecordModel doc = new RecordModel();
                        doc.RecordModelId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("RecordModelId")));
                        doc.DocNo = reader.GetValue(reader.GetOrdinal("DocNo")).ToString();
                        doc.DocDate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("DocDate")));
                        doc.EntityId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("EntityId")));
                        doc.EntityCode = reader.GetValue(reader.GetOrdinal("EntityCode")).ToString();
                        doc.EntityName = reader.GetValue(reader.GetOrdinal("EntityName")).ToString();
                        if (DBNull.Value != reader.GetValue(reader.GetOrdinal("WarehouseId")))
                        {
                            doc.WarehouseId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("WarehouseId")));
                            doc.WarehouseCode = reader.GetValue(reader.GetOrdinal("WarehouseCode")).ToString();
                            doc.WarehouseName = reader.GetValue(reader.GetOrdinal("WarehouseName")).ToString();
                        }
                        doc.DocumentType = filter.filterId;
                        result.Result.Add(doc);
                    }
                    if (reader != null) reader.Close();
                }

                result.Success = true;
                result.Result.TrimExcess();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                result.Success = false;
                result.ErrorMessage = exc.Message;
            }

            return result;
        }

        /// <summary>
        /// Ermaş özel palet sevk ekrani, uyum bağlantısı yok
        /// </summary>
        /// <param name="tempDocumentM"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static ServiceResult<bool> InsertErmasPaletSevk(TempDocumentMModel tempDocumentM, int userid, string username, string Password, DataClient data)
        {
            ServiceResult<bool> serviceResult = new ServiceResult<bool>();
            try
            {
                if (string.IsNullOrWhiteSpace(tempDocumentM.SERIAL_NUMBER))
                {
                    serviceResult.Success = false;
                    serviceResult.ErrorMessage = "Barkod listesi boş!";
                    return serviceResult;
                }
                string[] barcodes = tempDocumentM.SERIAL_NUMBER.Split(';');
                if (barcodes != null && barcodes.Length > 0)
                {
                    data.Begin();
                    DateTime date = DateTime.Now;
                    DateTime.TryParse(tempDocumentM.DOC_DATE, out date);

                    for (int loop = 0; loop < barcodes.Length; loop++)
                    {
                        var parameters = new IDbDataParameter[13];
                        parameters[0] = data.CreateDbParameter("item_m_id", tempDocumentM.DOCUMENT_M_ID);
                        parameters[1] = data.CreateDbParameter("doc_date", date);
                        parameters[2] = data.CreateDbParameter("doc_no", tempDocumentM.DOC_NO);
                        parameters[3] = data.CreateDbParameter("entity_id", tempDocumentM.ENTITY_ID);
                        parameters[4] = data.CreateDbParameter("entity_code", tempDocumentM.BRANCH_NAME);
                        parameters[5] = data.CreateDbParameter("license_plate", tempDocumentM.LICENSE_PLATE);
                        parameters[6] = data.CreateDbParameter("driver_name", tempDocumentM.DRIVERNAME);
                        parameters[7] = data.CreateDbParameter("package_no", barcodes[loop].TrimEnd().TrimStart().Trim());
                        parameters[8] = data.CreateDbParameter("description", tempDocumentM.DOC_TRA_CODE);
                        parameters[9] = data.CreateDbParameter("description2", tempDocumentM.DOC_TRA_NAME);
                        parameters[10] = data.CreateDbParameter("creator", username);
                        parameters[11] = data.CreateDbParameter("create_user_id", userid);
                        parameters[12] = data.CreateDbParameter("status", loop);
                        data.Execute("INSERT INTO \"uyumsoft\".\"zz_ermas_sevk\" (item_m_id,doc_date,doc_no,entity_id,entity_code,license_plate,driver_name,package_no,description,description2,creator,create_user_id,status) VALUES (@item_m_id,@doc_date,@doc_no,@entity_id,@entity_code,@license_plate,@driver_name,@package_no,@description,@description2,@creator,@create_user_id,@status)", parameters);
                    }
                }

                data.Commit();
                serviceResult.Success = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 2334);
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message.ToString();
                return serviceResult;

                //throw ex;
            }
            finally
            {
                data.Rollback();
            }

        }

        private static string limitCommand = null;
        public static string GetLimitCommand(IDbConnection connection)
        {
            if (object.ReferenceEquals(limitCommand, null))
            {
                if (connection is OracleConnection)
                {
                    limitCommand = " AND ROWNUM = 1";
                }
                else if (connection is NpgsqlConnection)
                {
                    limitCommand = " LIMIT 1";
                }
            }
            return limitCommand;
        }

        private static string isNullCommand = null;
        public static string GetIsNullCommand(IDbConnection connection)
        {
            if (object.ReferenceEquals(isNullCommand, null))
            {
                if (connection is OracleConnection)
                {
                    isNullCommand = "NVL";
                }
                else if (connection is NpgsqlConnection)
                {
                    isNullCommand = "COALESCE";
                }
            }
            return isNullCommand;
        }

        public static string GetString(string str)
        {
            if (!string.IsNullOrWhiteSpace(str)) return str.Replace("'", "`");

            return "";
        }

        [DebuggerStepThrough()]
        private static void SqlStringLog(OracleCommand command, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (command != null)
            {
                if (command.Parameters.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (IDataParameter prm in command.Parameters) sb.AppendFormat("\tName:{0},Value:{1}\t", prm.ParameterName, prm.Value);
                    System.Diagnostics.Trace.WriteLine(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                    Logger.WriteFileLog(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Concat("Command:", command.CommandText, ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                    Logger.WriteFileLog(string.Concat("Command:", command.CommandText, ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                }
            }
        }

        private static List<T> Select<T>(IDbConnection connection, string sql)
        {
            List<T> list = null;
            try
            {
                IDbCommand command = null;
                if (connection.State != ConnectionState.Open) connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;

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
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
            }
            finally
            {
                //command?.Parameters.Clear();
            }
            return list;
        }

        [DebuggerStepThrough()]
        private static bool IsSimpleType(Type type)
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

    }

    public class CounterParam
    {
        public string CounterParamStr { get; set; }
        public string BrandParamStr { get; set; }
    }
}