using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class GetPackageMInfoMethod : BaseMethod<Params.GetPackageMInfoParam>
    {
        public GetPackageMInfoMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var _SParam = new UTerminalService.ServiceRequestOfInPacKageM();
                _SParam.Token = (UTerminalService.Token)serviceparam.Token;
                _SParam.Value = new UTerminalService.InPacKageM();
                _SParam.Value.WhouseId = serviceparam.WhouseId;
                _SParam.Value.PackageNo = serviceparam.PackageNo;
                _SParam.Value.BomPacKageTraMGetItems = serviceparam.BomPacKageTraMGetItems;
                _SParam.Value.IsMultiInputOutputCriteria = true;
                _SParam.Value.MultiInputOutputCriteriaValues = new int[] { 1 /*Giriş*/}; //Sadece Girişler okutulmalı.

                var res = GetUTerminalService().GetPackageMInfo(_SParam);

                var result = new JsonObject<UTerminalService.OutPacKageD>();
                result.Status = res.Result;
                result.Message = res.Message;
                result.Values = res.Value;

                return result.ToString();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<UTerminalService.OutPacKageD>()
                {
                    Status = false,
                    Message = exc.Message                    
                }.ToString();
            }
        }
    }
}