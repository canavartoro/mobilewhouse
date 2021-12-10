using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchDesc { get; set; }
        public int CoId { get; set; }
        public string CoCode { get; set; }
        public string CoDesc { get; set; }
    }
}