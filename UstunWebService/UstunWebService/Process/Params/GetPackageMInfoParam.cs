using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class GetPackageMInfoParam : ServiceParam
    {
        public GetPackageMInfoParam() { }

        public int WhouseId { get; set; }

        public string PackageNo { get; set; }

        public bool BomPacKageTraMGetItems { get; set; }
        
    }
}