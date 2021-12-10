using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class BhwItemModel
    {
        public int BhwItemId { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string WhouseCode { get; set; }
        public string WhouseName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal Qty { get; set; }

        public int Attribute1Id { get; set; }
        public string Attribute1Code { get; set; }
        public int Attribute2Id { get; set; }
        public string Attribute2Code { get; set; }
        public int Attribute3Id { get; set; }
        public string Attribute3Code { get; set; }
        public int QualityId { get; set; }
        public string QualityCode { get; set; }
        public int LotId { get; set; }
        public string LotCode { get; set; }
        public string AddStrin01 { get; set; }
    }
}