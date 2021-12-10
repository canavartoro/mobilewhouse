using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class PackageDetailModel
    {
        public string PackageNo { get; set; }
        public int PackageMId { get; set; }
        public int PackageDId { get; set; }
        public int LineNo { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public decimal Qty { get; set; }
        public int LotId { get; set; }
        public string LotCode { get; set; }
        public int LocationId { get; set; }
        public bool Selected { get; set; } = false;

        public int ItemAttribute1Id { get; set; }
        public string ItemAttribute1Code { get; set; }
        public int ItemAttribute2Id { get; set; }
        public string ItemAttribute2Code { get; set; }
        public int ItemAttribute3Id { get; set; }
        public string ItemAttribute3Code { get; set; }
        public int QualityId { get; set; }
        public string QualityCode { get; set; }
        public int ColorId { get; set; }
        public string ColorCode { get; set; }
        public bool HasDetail { get; set; } = false;
        public bool Revort { get; set; } = false;
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int PackageTypeId { get; set; }
        public int FreePrmMId { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal QtyFreePrm { get; set; }
        public decimal Tare { get; set; }
        public string Note { get; set; }
    }
}