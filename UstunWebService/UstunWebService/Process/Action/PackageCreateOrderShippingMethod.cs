using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class PackageCreateOrderShippingMethod : BaseMethod<Params.PackageCreateOrderShippingParam>
    {
        public PackageCreateOrderShippingMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var _SParam = new UTerminalService.ServiceRequestOfPackageCreateOrderShippingMOut();
                _SParam.Token = (UTerminalService.Token)serviceparam.Token;
                _SParam.Value = (UTerminalService.PackageCreateOrderShippingMOut)serviceparam;

                var res = GetUTerminalService().PackageCreateOrderShipping(_SParam);

                var result = new JsonObject<int>();
                result.Status = res.Result;
                result.Message = res.Message;
                result.Values = res.Value;

                return result.ToString();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<int>()
                {
                    Status = false,
                    Message = exc.Message,
                    Values = -1
                }.ToString();
            }
        }
    }
}