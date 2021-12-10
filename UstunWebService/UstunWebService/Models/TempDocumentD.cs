using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class TempDocumentD
    {
        public int Id { get; set; }
        public int TempDocumentMId { get; set; }
        public int UserId { get; set; }
        public int SourceMId { get; set; }
        public int SourceDId { get; set; }
        public int ItemId { get; set; }
        public int LotId { get; set; }
        public decimal QtyRead { get; set; }
        public int BranchId { get; set; }
        public int UnitId { get; set; }
        public DateTime DeliveryDate { get; set; }

  

    }
}