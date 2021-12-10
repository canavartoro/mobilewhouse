using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class BranchWhouseModel
    {
        public int WhouseId { get; set; }
        public int BranchId { get; set; }
        public string WhouseCode { get; set; }
        public string WhouseName { get; set; }
    }
}