using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class PackageFilterModel
    {
        public int ProcessType { get; set; }
        public string PackageNo { get; set; }
        public int PackageDId { get; set; }
        public int WhouseId { get; set; }
        public int Whouse2Id { get; set; }
        public DateTime DocDate { get; set; }
        public string DocNo { get; set; }
        public string Note { get; set; }
        public PackageDetailModel PackageM { get; set; }
        public List<PackageDetailModel> PackageDList { get; set; }
    }
}