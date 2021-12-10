using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class CoDocTraModel
    {
        public int DocTraId { get; set; }
        public string DocTraCode { get; set; }
        public string DocTraName { get; set; }
        public int SourceApp { get; set; }
    }
}