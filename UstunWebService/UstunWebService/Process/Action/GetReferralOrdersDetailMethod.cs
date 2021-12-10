using UstunWebService.Helpers;
using UstunWebService.MobileWhouseService;
using UstunWebService.Process.Objects;
using UstunWebService.Process.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class GetReferralOrdersDetailMethod : BaseMethod<Params.SelectParam>
    {
        public GetReferralOrdersDetailMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                var _SParam = new UTerminalService.ServiceRequestOfSelectParam();
                _SParam.Token = (UTerminalService.Token)serviceparam.Token;
                _SParam.Value = new UTerminalService.SelectParam();
                _SParam.Value.DepotId = serviceparam.DepotId;
                _SParam.Value.InfoId = serviceparam.InfoId;

                var res = GetUTerminalService().GetReferralOrdersDetail(_SParam);

                //var _Liste = from p in _SvkList.Value orderby p.ItemId select p;
                var result = new JsonObject<List<UstunWebService.Process.Objects.ReferralDetailInfo>>();

                return new JsonObject<List<UstunWebService.Process.Objects.ReferralDetailInfo>>()
                {
                    Status = res != null ? res.Result : false,
                    Message = res != null ? res?.Message : "Sunucu hatası!",
                    Values = res?.Value != null ? (from q in res.Value
                                                   orderby q.ItemId
                                                   select new UstunWebService.Process.Objects.ReferralDetailInfo
                                                   {
                                                       ReferralDetailId = q.ReferralDetailId,
                                                       ItemId = q.ItemId,
                                                       ItemCode = q.ItemCode,
                                                       ItemName = q.ItemName,
                                                       ArrivalDate = q.ArrivalDate,
                                                       OrderNo = q.OrderNo,
                                                       QtyOrder = q.QtyOrder,
                                                       WhouseId = q.WhouseId,
                                                       WhouseCode = q.WhouseCode,
                                                       QtyRemainder = q.QtyRemainder,
                                                       QtyReferral = q.QtyReferral,
                                                       QtyReferralTotal = q.QtyReferralTotal,

                                                       QtyShipping = q.QtyShipping,

                                                       PackageTypeId = q.PackageTypeId,
                                                       PackageTypeCode = q.PackageTypeCode,
                                                       QtySum = q.QtySum,
                                                       Linetype = q.Linetype,
                                                       VatStatus = q.VatStatus,
                                                       SourceDId = q.SourceDId,
                                                       QualityCode = q.QualityCode,
                                                       QualityId = q.QualityId,
                                                       LotCode = q.LotCode,
                                                       LotId = q.LotId,
                                                       ColorCode = q.ColorCode,
                                                       ColorId = q.ColorId,
                                                       ItemAttribute1Code = q.ItemAttribute1Code,
                                                       ItemAttribute1Id = q.ItemAttribute1Id,
                                                       ItemAttribute2Code = q.ItemAttribute2Code,
                                                       ItemAttribute2Id = q.ItemAttribute2Id,
                                                       ItemAttribute3Code = q.ItemAttribute3Code,
                                                       ItemAttribute3Id = q.ItemAttribute3Id,
                                                       Note1 = q.Note1,
                                                       IncotermsName = q.IncotermsName, //Teslim Şekli
                                                       PaymentMethodDesc = q.PaymentMethodDesc, //Ödeme Şekli
                                                       ItemAddString01 = q.ItemAddString01, //İşyeri Stok Kartı Ek Alan -01
                                                       TempCoDocTraIdWaybill = q.TempCoDocTraIdWaybill,
                                                       TempCoDocTraCodeWaybill = q.TempCoDocTraCodeWaybill,
                                                       IsserialTrack = q.IsserialTrack,

                                                       SalesToleranceMaxSo = q.SalesToleranceMaxSo,
                                                       UnitFactor = q.UnitFactor,
                                                       TempCoDocTraIsTransfer = q.TempCoDocTraIsTransfer
                                                   }).ToList() : new List<Objects.ReferralDetailInfo>()
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