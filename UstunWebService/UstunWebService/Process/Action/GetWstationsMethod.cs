using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using UstunWebService.Prod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class GetWstationsMethod : BaseMethod<Params.SelectParam>
    {
        public GetWstationsMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var _SParam = new ServiceRequestOfPrdGobalParam();
                _SParam.Token = (Prod.Token)serviceparam.Token;
                _SParam.Value = new PrdGobalParam(); ;
                _SParam.Value.PrdGobalCode = serviceparam.SearchEntity;
                _SParam.Value.PrdGobalName = serviceparam.SearchEntity;
                _SParam.Value.PrdGobalType = 1;
                _SParam.Value.PageSize = 9999;

                var res = GetProductionService().GetPrdGobalInfo(_SParam);
           
                return new JsonObject<List<WstationInf>>()
                {
                    Status = res != null ? res.Result : false,
                    Message = res != null ? res?.Message : "Sunucu hatası!",
                    Values = res?.Value != null ? (from q in res.Value
                                                   select new WstationInf
                                                   {
                                                       Id = q.PrdGobalId,
                                                       WstationCode = q.PrdGobalCode,
                                                       Description = q.PrdGobalName,
                                                       WcenterId = q.PrdGobalId2,
                                                       WcenterCode = q.PrdGobalCode2,
                                                       WcenterDesc = q.PrdGobalName2,
                                                       MaterialOutputWhouseId = q.PrdGobalId3,
                                                       MaterialOutputWhouseCode = q.PrdGobalCode3
                                                   }).ToList() : new List<WstationInf>()
                }.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<List<Objects.WstationInf>>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}