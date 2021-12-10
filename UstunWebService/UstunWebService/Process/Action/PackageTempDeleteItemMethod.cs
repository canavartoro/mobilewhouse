using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class PackageTempDeleteItemMethod : BaseMethod<Params.PackageTempAddItemInParam>
    {
        public PackageTempDeleteItemMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var _SParam = new UTerminalService.ServiceRequestOfPackageTempAddItemIn();
                _SParam.Token = (UTerminalService.Token)serviceparam.Token;
                _SParam.Value = new UTerminalService.PackageTempAddItemIn();
                _SParam.Value.SourceApp = serviceparam.SourceApp;//Sevk Emri
                _SParam.Value.SourceApp2 = serviceparam.SourceApp2; //Ambalaj
                _SParam.Value.SourceMId = serviceparam.SourceMId;
                _SParam.Value.SerialNo = serviceparam.SerialNo;
                _SParam.Value.MultiplierBarcodeQty = serviceparam.MultiplierBarcodeQty;          

                var res = GetUTerminalService().PackageTempDeleteItem(_SParam);

                var result = new JsonObject<bool>();
                result.Status = res.Result;
                result.Message = res.Message;
                result.Values = res.Value;

                return result.ToString();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<bool>()
                {
                    Status = false,
                    Message = exc.Message,
                    Values = false
                }.ToString();
            }
        }
    }
}