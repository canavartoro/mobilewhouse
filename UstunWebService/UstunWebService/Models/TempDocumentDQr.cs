using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class TempDocumentDQr
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public int LotId { get; set; }
        public string LotCode { get; set; }
        public string SerialStart { get; set; }
        public string SerialEnd { get; set; }
        public int CounterCount { get; set; }
        public int TempDocumentMId { get; set; }
        public int TempDocumentDId { get; set; }
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public DateTime ProductionDate { get; set; }
        public int BranchId { get; set; }
        public int CoId { get; set; }
        public int EntityId { get; set; }
        public int UnitId { get; set; }
        public int WhouseId { get; set; }
    }
}