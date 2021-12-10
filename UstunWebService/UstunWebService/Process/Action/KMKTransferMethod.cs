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
    public class KMKTransferMethod : BaseMethod<Params.KmkTransferParam>
    {
        public KMKTransferMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var transferMInfo = new ServiceRequestOfKmkTransferMInfo();
                transferMInfo.Token = (UTerminalService.Token)serviceparam.Token;
                transferMInfo.Value = new KmkTransferMInfo();
                transferMInfo.Value.DocDate = serviceparam.DocDate;
                transferMInfo.Value.DocNo = serviceparam.DocNo;
                transferMInfo.Value.DocTraId = serviceparam.DocTraId;
                transferMInfo.Value.DocTraCode = serviceparam.DocTraCode;
                transferMInfo.Value.WstationId = serviceparam.WstationId;
                transferMInfo.Value.WstationCode = serviceparam.WstationCode;
                transferMInfo.Value.MaterialOutputWhouseId = serviceparam.MaterialOutputWhouseId;
                transferMInfo.Value.MaterialOutputWhouseCode = serviceparam.MaterialOutputWhouseCode;
                transferMInfo.Value.OutputWhouseId = serviceparam.OutputWhouseId;
                transferMInfo.Value.OutputWhouseCode = serviceparam.OutputWhouseCode;
                transferMInfo.Value.Note1 = serviceparam.Note1;
                transferMInfo.Value.Note2 = serviceparam.Note2;
                List<KmkTransferDInfo> details = new List<KmkTransferDInfo>();
                if (serviceparam.Details != null && serviceparam.Details.Count > 0)
                {
                    for (int i = 0; i < serviceparam.Details.Count; i++)
                    {
                        details.Add(new KmkTransferDInfo()
                        {
                            KmkMaterialTraMId = serviceparam.Details[i].KmkMaterialTraMId,
                            ItemId = serviceparam.Details[i].ItemId,
                            ItemCode = serviceparam.Details[i].ItemCode,
                            LotId = serviceparam.Details[i].LotId,
                            LotCode = serviceparam.Details[i].LotCode,
                            ItemAttribute1Id = serviceparam.Details[i].ItemAttribute1Id,
                            ItemAttribute2Id = serviceparam.Details[i].ItemAttribute2Id,
                            ItemAttribute3Id = serviceparam.Details[i].ItemAttribute3Id,
                            ItemAttributeCode1 = serviceparam.Details[i].ItemAttributeCode1,
                            ItemAttributeCode2 = serviceparam.Details[i].ItemAttributeCode2,
                            ItemAttributeCode3 = serviceparam.Details[i].ItemAttributeCode3,
                            ColorCode = serviceparam.Details[i].ColorCode,
                            ColorId = serviceparam.Details[i].ColorId,
                            QualityCode = serviceparam.Details[i].QualityCode,
                            QualityId = serviceparam.Details[i].QualityId,
                            PackageTypeCode = serviceparam.Details[i].PackageTypeCode,
                            PackageTypeId = serviceparam.Details[i].PackageTypeId,
                            Qty = serviceparam.Details[i].Qty,
                            UnitId = serviceparam.Details[i].UnitId,
                            UnitCode = serviceparam.Details[i].UnitCode,
                            LineNo = serviceparam.Details[i].LineNo
                        });
                    }
                }
                transferMInfo.Value.Details = details.ToArray();

                var res = GetUTerminalService().KMKTransfer(transferMInfo);

                return new JsonObject<int>()
                {
                    Status = res != null ? res.Result : false,
                    Message = res != null ? res?.Message : "Sunucu hatası!",
                    Values = res != null ? res.Value : -1
                }.ToString();

            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<int>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}