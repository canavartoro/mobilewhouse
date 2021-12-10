using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class KmkTransferParam : ServiceParam
    {
        public DateTime DocDate { get; set; }
        public string DocNo { get; set; }
        public int DocTraId { get; set; }
        public string DocTraCode { get; set; }
        public int WstationId { get; set; }
        public string WstationCode { get; set; }
        public int MaterialOutputWhouseId { get; set; }
        public string MaterialOutputWhouseCode { get; set; }
        public int OutputWhouseId { get; set; }
        public string OutputWhouseCode { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }

        public List<KmkTransferDInfo> Details { get; set; }
    }

    public class KmkTransferDInfo
    {
        public int KmkMaterialTraMId { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int LotId { get; set; }
        public string LotCode { get; set; }
        public int ItemAttribute1Id { get; set; }
        public int ItemAttribute2Id { get; set; }
        public int ItemAttribute3Id { get; set; }
        public string ItemAttributeCode1 { get; set; }
        public string ItemAttributeCode2 { get; set; }
        public string ItemAttributeCode3 { get; set; }
        public string ColorCode { get; set; }
        public int ColorId { get; set; }
        public string QualityCode { get; set; }
        public int QualityId { get; set; }
        public string PackageTypeCode { get; set; }
        public int PackageTypeId { get; set; }
        public decimal Qty { get; set; }
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public int LineNo { get; set; }
    }
}