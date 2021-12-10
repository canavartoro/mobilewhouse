using UstunWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Helpers
{
    public class TempDataHelper
    {
        //internal static ServiceResult<bool> SaveLegalTemp(List<CCNBLegalTemp> legalTempList, Token token, OracleConnection conn)
        //{
        //    OracleCommand command = null;
        //    OracleTransaction Trans;
        //    ServiceResult<bool> serviceResult = new ServiceResult<bool>();
        //    Trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);


        //    try
        //    {
        //        serviceResult.Result = false;
        //        foreach (CCNBLegalTemp eleman in legalTempList)
        //        {
        //            string sourceguid = eleman.SourceGUID;
        //            DateTime DocDate = eleman.DocDate;
        //            string DocNo = eleman.DocNo;
        //            decimal Amt = eleman.Amt;
        //            string CCNBCardCode = eleman.CCNBCardCode;
        //            string SubscriberNo = eleman.SubscriberNo;
        //            string Note = eleman.Note;
        //            int FinMId = eleman.FinMId;
        //            string text = string.Format("INSERT INTO FIND_CCNB_LEGAL_TEMP (SOURCE_GUID , DOC_DATE,DOC_NO,AMT, CCNB_CARD_CODE,SUBSCRIBER_NO,NOTE,FIN_M_ID) VALUES (:sourceguid , :DocDate, :DocNo, :Amt, :CCNBCardCode,:SubscriberNo, :Note, :FinMId) ");
        //            command = new OracleCommand(text, conn);
        //            command.Parameters.Add(new OracleParameter { ParameterName = "sourceguid", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = sourceguid, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "DocDate", DbType = System.Data.DbType.Date, OracleDbType = OracleDbType.Date, Value = DocDate, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "DocNo", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = DocNo, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "Amt", DbType = System.Data.DbType.Decimal, OracleDbType = OracleDbType.Decimal, Value = Amt, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "CCNBCardCode", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = CCNBCardCode, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "SubscriberNo", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = SubscriberNo, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "Note", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = Note, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "FinMId", DbType = System.Data.DbType.Int32, OracleDbType = OracleDbType.Int32, Value = FinMId, IsNullable = false });
        //            int result = command.ExecuteNonQuery();
        //            if (result != 1)
        //            {
        //                serviceResult.Success = false;
        //            }

        //        }


        //        Trans.Commit();
        //        serviceResult.Success = true;
        //        return serviceResult;
        //    }
        //    catch (Exception ex)
        //    {

        //        serviceResult.Success = false;
        //        serviceResult.ErrorMessage = ex.Message;
        //        Trans.Rollback();
        //        return serviceResult;
        //    }

        //}

        //internal static ServiceResult<bool> SaveDeptCollTemp(CCNBDeptCollTemp[] DeptCollTempList, Token token, OracleConnection conn)
        //{
        //    OracleCommand command = null;
        //    OracleTransaction Trans;
        //    ServiceResult<bool> serviceResult = new ServiceResult<bool>();
        //    Trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);



        //    try
        //    {
        //        serviceResult.Result = false;
        //        foreach (CCNBDeptCollTemp eleman in DeptCollTempList)
        //        {
        //            string sourceguid = eleman.SourceGUID;
        //            DateTime DocDate = eleman.DocDate;
        //            decimal Amt = eleman.Amt;
        //            decimal AmtExpense = eleman.AmtExpense;
        //            decimal AmtInterest = eleman.AmtInterest;
        //            string CCNBCardCode = eleman.CCNBCardCode;
        //            string Note = eleman.Note; //sourceguid , DocDate,Amt,AmtExpense,AmtInterest CCNBCardCode,Note,FinMId
        //            int FinMId = eleman.FinMId;

        //            string text = string.Format("INSERT INTO FIND_CCNB_DEBT_COLL_TEMP (SOURCE_GUID , DOC_DATE, AMT, AMT_EXPENSE , AMT_INTEREST, CCNB_CARD_CODE,NOTE,FIN_M_ID) VALUES (:sourceguid , :DocDate,:Amt,:AmtExpense,:AmtInterest ,:CCNBCardCode,:Note,:FinMId)");
        //            command = new OracleCommand(text, conn);
        //            command.Parameters.Add(new OracleParameter { ParameterName = "sourceguid", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = sourceguid, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "DocDate", DbType = System.Data.DbType.Date, OracleDbType = OracleDbType.Date, Value = DocDate, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "Amt", DbType = System.Data.DbType.Decimal, OracleDbType = OracleDbType.Decimal, Value = Amt, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "AmtExpense", DbType = System.Data.DbType.Decimal, OracleDbType = OracleDbType.Decimal, Value = AmtExpense, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "AmtInterest", DbType = System.Data.DbType.Decimal, OracleDbType = OracleDbType.Decimal, Value = AmtInterest, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "CCNBCardCode", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = CCNBCardCode, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "Note", DbType = System.Data.DbType.String, OracleDbType = OracleDbType.Varchar2, Value = Note, IsNullable = false });
        //            command.Parameters.Add(new OracleParameter { ParameterName = "FinMId", DbType = System.Data.DbType.Int32, OracleDbType = OracleDbType.Int32, Value = FinMId, IsNullable = false });

        //            int result = command.ExecuteNonQuery();
        //            if (result != 1)
        //            {
        //                serviceResult.Success = false;
        //            }

        //        }


        //        Trans.Commit();
        //        serviceResult.Success = true;
        //        return serviceResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResult.Success = false;
        //        serviceResult.ErrorMessage = ex.Message;
        //        Trans.Rollback();
        //        return serviceResult;
        //    }

        //}

    }
}