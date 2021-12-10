using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class PackageTempAddItemInParam
    {
        public List<string> Ids { get; set; }
        public bool BomPacKageTraMGetItems { get; set; }
        public int WhouseId { get; set; }
    }
}