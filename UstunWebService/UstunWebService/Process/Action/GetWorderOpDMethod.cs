using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class GetWorderOpDMethod : BaseMethod<Params.FindPrdWorderParam>
    {
        public GetWorderOpDMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var result = new JsonObject<List<WorderMInf>>();
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                StringBuilder sb = new StringBuilder();
                sb.Append($@"SELECT PRDT_WORDER_OP_D.WORDER_OP_D_ID, PRDT_WORDER_OP_D.WORDER_M_ID, PRDT_WORDER_M.WORDER_NO AS WORDER_NO, PRDT_WORDER_M.WORDER_TYPE AS WORDER_TYPE, PRDT_WORDER_M.WO_TYPE_ID AS WO_TYPE_ID, PRDT_WORDER_M.QTY AS WORDER_M_QTY, PRDT_WORDER_M.UNIT_ID AS WORDER_M_UNIT_ID, INVD_UNIT_WORDERM.UNIT_CODE AS WORDER_M_UNIT_CODE, PRDT_WORDER_M.ITEM_ID AS ITEM_ID, INVD_ITEM.ITEM_CODE AS ITEM_CODE, INVD_ITEM.ITEM_NAME AS ITEM_NAME, PRDT_WORDER_OP_D.OPERATION_ID, PRDT_WORDER_OP_D.OPERATION_NO, PRDD_OPERATION.OPERATION_CODE AS OPERATION_CODE, PRDD_OPERATION.DESCRIPTION AS OPERATION_DESCRIPTION, PRDT_WORDER_OP_D.OPERATION_SEQUENTIAL, PRDT_WORDER_OP_D.WCENTER_ID, PRDT_WORDER_OP_D.WSTATION_ID, PRDT_WORDER_OP_D.QTY_INPUT_OP, PRDT_WORDER_OP_D.QTY_TRF_OP, PRDT_WORDER_OP_D.QTY_MAN, PRDT_WORDER_OP_D.IS_FIRST_OPR, PRDT_WORDER_OP_D.IS_LAST_OPR, PRDT_WORDER_OP_D.IS_MILESTONE, PRDT_WORDER_OP_D.PREVIOUS_OP_NO_LIST 
FROM PRDT_WORDER_OP_D  LEFT OUTER JOIN  UYUMSOFT.PRDD_OPERATION ON PRDT_WORDER_OP_D.OPERATION_ID = PRDD_OPERATION.OPERATION_ID  LEFT OUTER JOIN  UYUMSOFT.PRDT_WORDER_M ON PRDT_WORDER_OP_D.WORDER_M_ID = PRDT_WORDER_M.WORDER_M_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM ON PRDT_WORDER_M.ITEM_ID = INVD_ITEM.ITEM_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_UNIT INVD_UNIT_WORDERM ON PRDT_WORDER_M.UNIT_ID = INVD_UNIT_WORDERM.UNIT_ID  
WHERE (PRDT_WORDER_OP_D.BRANCH_ID = {serviceparam.Token.BranchId} AND PRDT_WORDER_OP_D.ISPHANTOM = 0 AND PRDT_WORDER_OP_D.IS_OPR_CONF = 0 AND PRDT_WORDER_M.WORDER_STATUS = 2 AND PRDT_WORDER_M.OPEN_CLOSE = 1) ");
                if (!string.IsNullOrWhiteSpace(serviceparam.WorderNo))
                    sb.Append($" AND PRDT_WORDER_M.WORDER_NO LIKE '{serviceparam.WorderNo.Replace("'", "`")}%' ");
                sb.Append(" ORDER BY PRDT_WORDER_M.WORDER_NO ASC, PRDT_WORDER_OP_D.OPERATION_SEQUENTIAL ASC, PRDT_WORDER_OP_D.OPERATION_NO ASC ");

                var _SParam = new MobileWhouseService.ServiceRequestOfString();
                _SParam.Token = (MobileWhouseService.Token)serviceparam.Token;
                _SParam.Value = sb.ToString();
                _SParam.PageSize = 9999;

                var res = GetMobileWhouse().ExecuteSQL(_SParam);

                result.Status = res.Result;
                result.Message = res.Message;
                result.Values = new List<WorderMInf>();
                if (res.Value != null && res.Value.Rows.Count > 0)
                {
                    for (int i = 0; i < res.Value.Rows.Count; i++)
                    {
                        var item = new WorderMInf();
                        if (res.Value.Rows[i]["WORDER_M_ID"] != DBNull.Value)
                            item.WORDER_M_ID = Convert.ToInt32(res.Value.Rows[i]["WORDER_M_ID"]);
                        if (res.Value.Rows[i]["WORDER_NO"] != DBNull.Value)
                            item.WORDER_NO = res.Value.Rows[i]["WORDER_NO"].ToString();
                        if (res.Value.Rows[i]["WORDER_OP_D_ID"] != DBNull.Value)
                            item.WORDER_AC_OP_ID = Convert.ToInt32(res.Value.Rows[i]["WORDER_OP_D_ID"]);
                        if (res.Value.Rows[i]["ITEM_CODE"] != DBNull.Value)
                            item.ITEM_CODE = res.Value.Rows[i]["ITEM_CODE"].ToString();
                        if (res.Value.Rows[i]["ITEM_NAME"] != DBNull.Value)
                            item.ITEM_NAME = res.Value.Rows[i]["ITEM_NAME"].ToString();
                        if (res.Value.Rows[i]["WORDER_M_UNIT_CODE"] != DBNull.Value)
                            item.UNIT_CODE = res.Value.Rows[i]["WORDER_M_UNIT_CODE"].ToString();
                        if (res.Value.Rows[i]["WORDER_M_QTY"] != DBNull.Value)
                            item.QTY = Convert.ToDecimal(res.Value.Rows[i]["WORDER_M_QTY"]);

                        result.Values.Add(item);
                    }
                }
                result.Values.TrimExcess();

                return result.ToString();

                //var _SParam = new ServiceRequestOfWorderOpDParam();
                //_SParam.Token = (Prod.Token)serviceparam.Token;
                //_SParam.Value = new WorderOpDParam();
                //_SParam.Value.WorderNo = serviceparam.WorderNo;
                //_SParam.Value.WcenterId = 0;
                //_SParam.Value.WstationId = serviceparam.WstationId;
                //_SParam.PageSize = 9999;

                //var res = GetProductionService().GetWorderOpDInfo(_SParam);

                //result.Status = res.Result;
                //result.Message = res.Message;
                //result.Values = (from q in res.Value
                //                 select new WorderMInf
                //                 {
                //                     WORDER_M_ID     = q.WorderMId,
                //                     WORDER_NO = q.WorderNo,
                //                     WORDER_AC_OP_ID = q.WorderOpDId,
                //                     ITEM_CODE = q.ItemCode,
                //                     ITEM_NAME = q.ItemName,
                //                     UNIT_CODE = q.UnitCode,
                //                     QTY = q.QtyAvailable
                //                 }).ToList();

                //return result.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<List<WorderMInf>>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}