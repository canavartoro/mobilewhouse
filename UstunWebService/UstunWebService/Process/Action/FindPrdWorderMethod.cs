using UstunWebService.Data;
using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class FindPrdWorderMethod : BaseMethod<Params.FindPrdWorderParam>
    {
        public FindPrdWorderMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var result = new JsonObject<WorderMInf>();
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                using (var db = new DataClient())
                {
                    result.Values = db.Select<WorderMInf>(string.Format(@"select * from(select acop.worder_ac_op_id, acop.worder_m_id, wm.worder_no, ii.item_code, ii.item_name, ROWNUM from PRDT_WORDER_AC_OP acop
                                                        inner join PRDT_WORDER_M wm on wm.worder_m_id = acop.worder_m_id
                                                        inner join INVD_ITEM ii on ii.item_id = wm.item_id
                                                        where acop.co_id        = {0} and
                                                                acop.branch_id    = {1} and
                                                                acop.awstation_id = {2}
                                                        ORDER BY acop.co_id    ,
                                                                    acop.branch_id ,
                                                                    acop.awstation_id,
                                                                    acop.end_date desc,
                                                                    acop.worder_ac_op_id desc)
                                                        where rownum = 1", serviceparam.Token.CoId
                                                                        , serviceparam.Token.BranchId
                                                                        , serviceparam.WstationId))?.FirstOrDefault();


                    result.Status = true;
                    result.Message = "";

                }

                return result.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<WorderMInf>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}