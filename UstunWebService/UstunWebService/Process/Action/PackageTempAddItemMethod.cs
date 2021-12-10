using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using UstunWebService.Process.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class PackageTempAddItemMethod : BaseMethod<PackageTempAddItemParam>
    {
        public PackageTempAddItemMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var param = new UTerminalService.ServiceRequestOfPackageTempAddItemIn();
                param.Token = (UTerminalService.Token)serviceparam.Token;
                param.Value = new UTerminalService.PackageTempAddItemIn();
                param.Value.SourceApp = serviceparam.SourceApp;
                param.Value.SourceApp2 = serviceparam.SourceApp2;
                param.Value.SourceMId = serviceparam.SourceMId;
                param.Value.SourceDId = serviceparam.SourceDId;
                param.Value.SourceM1Id = serviceparam.SourceM1Id;
                param.Value.Barcode = serviceparam.Barcode;
                param.Value.SerialNo = serviceparam.SerialNo;
                param.Value.MultiplierBarcodeQty = serviceparam.MultiplierBarcodeQty;
                param.Value.ReadLocationId = serviceparam.ReadLocationId;

                var res = GetUTerminalService().PackageTempAddItem(param);

                return new JsonObject<string>()
                {
                    Status = res != null ? res.Result : false,
                    Message = res?.Message,
                    Values = ""
                }.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<string>()
                {
                    Status = false,
                    Message = exc.Message,
                    Values = exc.StackTrace
                }.ToString();
            }
        }
    }
}