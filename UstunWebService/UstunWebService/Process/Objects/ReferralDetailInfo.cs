using UstunWebService.MobileWhouseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Objects
{
    public class ReferralDetailInfo
    {
        public int ReferralDetailId { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal QtyOrder { get; set; }

        public decimal QtyRemainder { get; set; }
        public decimal QtyReferral { get; set; }
        public decimal QtyReferralTotal { get; set; }
        public decimal QtyShipping { get; set; } // Sevk Emri Miktarı

        public decimal QtySum { get; set; }
        public int WhouseId { get; set; }
        public string WhouseCode { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int PackageTypeId { get; set; }
        public string PackageTypeCode { get; set; }
        public string OrderNo { get; set; }
        public int LotId { get; set; }
        public string LotCode { get; set; }
        public int QtyRead { get; set; }
        public int ReferralMasterId { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public UstunWebService.UTerminalService.LineType Linetype { get; set; }
        public decimal UnitPriceTra { get; set; }
        public int UnitId { get; set; }
        public string VatCode { get; set; }
        public UstunWebService.UTerminalService.VatStatus VatStatus { get; set; }

        public string QualityCode { get; set; }
        public int QualityId { get; set; }

        public string ColorCode { get; set; }
        public int ColorId { get; set; }

        public string ItemAttribute1Code { get; set; }
        public int ItemAttribute1Id { get; set; }

        public string ItemAttribute2Code { get; set; }
        public int ItemAttribute2Id { get; set; }

        public string ItemAttribute3Code { get; set; }
        public int ItemAttribute3Id { get; set; }

        public int SourceDId { get; set; }

        public string IncotermsName { get; set; }
        public string PaymentMethodDesc { get; set; }

        public string ItemAddString01 { get; set; } //Stok Kart Ek alan-01

        public int TempCoDocTraIdWaybill { get; set; } //Satış Siparişi Varsayılan İrsaliye Hareket Id
        public string TempCoDocTraCodeWaybill { get; set; } //Satış Siparişi Varsayılan İrsaliye Hareket Kodu
        public bool IsserialTrack { get; set; } //Seri Takibi

        public decimal SalesToleranceMaxSo { get; set; } //Satış Fazla Sevk Yüzdesi.
        public decimal UnitFactor { get; set; } //Birim Hassasiyet

        public bool TempCoDocTraIsTransfer { get; set; } //Satış Siparişi Varsayılan İrsaliye Transfer mi?
    }
}