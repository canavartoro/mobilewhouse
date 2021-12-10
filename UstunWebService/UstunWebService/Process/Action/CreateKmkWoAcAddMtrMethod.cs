using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using UstunWebService.UTerminalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class CreateKmkWoAcAddMtrMethod : BaseMethod<Params.FindBwhItemBalanceParam>
    {
        public CreateKmkWoAcAddMtrMethod(HttpContext context) : base(context) { }

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
                _SParam.Value.MaterialOutputWhouseCode = serviceparam.MaterialOutputWhouseCode;
                _SParam.Value.TargetWhouseId = serviceparam.TargetWhouseId;
                _SParam.Value.TargetWhouseCode = serviceparam.TargetWhouseCode;
                _SParam.Value.WstationId = serviceparam.WstationId;
                _SParam.Value.WstationCode = serviceparam.WstationCode;
                _SParam.Value.DocTraId = serviceparam.DocTraId;
                _SParam.Value.DocNo = serviceparam.DocNo;
                _SParam.Value.DocDate = serviceparam.DocDate;
                _SParam.Value.Details = serviceparam.Details?.ToArray();

                var res = GetUTerminalService().KMKFindBwhItemBalance(_SParam);

                result.Status = res.Result;
                result.Message = res.Message;
                result.Values = new List<KmkWoAcAddMtrDInf>();
                result.Values.AddRange(res.Value);

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