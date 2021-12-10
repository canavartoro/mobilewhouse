using UstunWebService.SenfoniGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class OrderD
    {
        public int LineNo { get; set; }
        public int CurTraId { get; set; }
        public string CurCode { get; set; }
        public int CurRateTypeId { get; set; }
        public decimal CurRateTra { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public int CatCode1Id { get; set; }
        public string CatCode1 { get; set; }
        public int CatCode2Id { get; set; }
        public string CatCode2 { get; set; }
        public int SourceMId { get; set; }
        public int SourceDId { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterCode { get; set; }
        public int ProjectMId { get; set; }
        public string ProjectCode { get; set; }
        public int GainLossTypeId { get; set; }
        public string GainLossTypeCode { get; set; }
        public string AnalysisCode { get; set; }
        public int AnalysisId { get; set; }
        public string TaxTemplateName { get; set; }
        public int TaxTemplateMId { get; set; }
        public PlusMinus PlusMinus { get; set; }
        public LineType LineType { get; set; }
        public int DcardId { get; set; }
        public string DcardCode { get; set; }
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyPrm { get; set; }
        public decimal QtyFreePrm { get; set; }
        public int DueDay { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CampaignId { get; set; }

        public decimal UnitPriceTra { get; set; }
        public decimal UnitPrice { get; set; }
        private VatStatus _VatStatus = VatStatus.Hariç;
        public VatStatus VatStatus { get { return _VatStatus; } set { _VatStatus = value; } }
        public int VatId { get; set; }
        public string VatCode { get; set; }
        public decimal VatRate { get; set; }
        public decimal AmtVat { get; set; }

        public string AbtActCode { get; set; }
        public int AbtActId { get; set; }
        public int AbtBudgetId { get; set; }
        public string AbtBudgetCode { get; set; }
        public string OTVCode { get; set; }
        public string OIVCode { get; set; }
        public string VatDiscCode { get; set; }


        public int PriceListId { get; set; }
        public int PriceListDId { get; set; }
        public int WhouseId { get; set; }
        public string WhouseCode { get; set; }
        public int AbtBudgetD2Id { get; set; }

        public int Disc1Id { get; set; }
        public string Disc1Code { get; set; }
        public decimal Disc1Rate { get; set; }
        public decimal AmtDisc1 { get; set; }
        public decimal AmtDisc1Tra { get; set; }

        public int Disc2Id { get; set; }
        public string Disc2Code { get; set; }
        public decimal Disc2Rate { get; set; }
        public decimal AmtDisc2 { get; set; }
        public decimal AmtDisc2Tra { get; set; }

        public int Disc3Id { get; set; }
        public string Disc3Code { get; set; }
        public decimal Disc3Rate { get; set; }
        public decimal AmtDisc3 { get; set; }
        public decimal AmtDisc3Tra { get; set; }

        public decimal AmtDisc { get; set; }
        public decimal AmtWithDisc { get; set; }
        public decimal Amt { get; set; }
        public decimal AmtTra { get; set; }

        public int FormContractMId { get; set; }


        public int ItemAttribute1Id { get; set; }
        public string ItemAttributeCode1 { get; set; }
        public int ItemAttribute2Id { get; set; }
        public string ItemAttributeCode2 { get; set; }
        public int ItemAttribute3Id { get; set; }
        public string ItemAttributeCode3 { get; set; }
        public int ItemGnlAttribute1Id { get; set; }
        public string ItemGnlAttributeCode1 { get; set; }
        public int ItemGnlAttribute2Id { get; set; }
        public string ItemGnlAttributeCode2 { get; set; }
        public int ItemGnlAttribute3Id { get; set; }
        public string ItemGnlAttributeCode3 { get; set; }
        public string QualityCode = string.Empty;
        public int QualityId = 0;
        public int LotId = 0;
        public string LotCode = string.Empty;
        public int ColorId = 0;
        public string ColorCode = string.Empty;
        public string PackageTypeCode = string.Empty;
        public int PackageTypeId = 0;
        public DiscTypes DiscCalcType1 { get; set; }
        public DiscTypes DiscCalcType2 { get; set; }
        public DiscTypes DiscCalcType3 { get; set; }
        public string ReferanceDocNo { get; set; }
        public int ItemId { get; set; }
        public int ExpenseId { get; set; }
        public int EntityId { get; set; }
    }
}