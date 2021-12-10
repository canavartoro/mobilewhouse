using UstunWebService.Data;
using UstunWebService.Helpers;
using UstunWebService.Models;
using UstunWebService.Process.Objects;
using UstunWebService.UTerminalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class FindBwhItemBalanceMethod : BaseMethod<Params.FindBwhItemBalanceParam>
    {
        public FindBwhItemBalanceMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var result = new JsonObject<List<KmkWoAcAddMtrDInf>>();
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }
                

                var _SParam = new UTerminalService.ServiceRequestOfKmkWoAcAddMtrMParam();
                _SParam.Token = (UTerminalService.Token)serviceparam.Token;
                _SParam.Value = new UTerminalService.KmkWoAcAddMtrMParam();
                _SParam.Value.Method = serviceparam.Metod;
                _SParam.Value.MaterialOutputWhouseId = serviceparam.MaterialOutputWhouseId;
                _SParam.Value.WorderAcOpId = serviceparam.WorderAcOpId;
                _SParam.Value.WorderMId = serviceparam.WorderMId;
                _SParam.Value.WstationId = serviceparam.WstationId;
                _SParam.Value.TargetWhouseId = serviceparam.TargetWhouseId;

                if (serviceparam.Metod == 1 && serviceparam.Details.Count() > 0)
                {
                    _SParam.Value.Details = serviceparam.Details.ToArray();
                }


                var res = GetUTerminalService().KMKFindBwhItemBalance(_SParam);

                result.Status = res.Result;
                result.Message = !string.IsNullOrEmpty(res.Message) ? res.Message : string.Empty;
                result.Values = new List<KmkWoAcAddMtrDInf>();
                if (res.Value != null)
                    result.Values.AddRange(res.Value);
                else
                    result = new JsonObject<List<KmkWoAcAddMtrDInf>>();

                return result.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<List<KmkWoAcAddMtrDInf>>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}