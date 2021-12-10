using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Objects
{
    public class WstationInf
    {
        public int Id { get; set; }
        public string WstationCode { get; set; }
        public string Description { get; set; }
        public int WcenterId { get; set; }
        public string WcenterCode { get; set; }
        public string WcenterDesc { get; set; }
        public int MaterialOutputWhouseId { get; set; }
        public string MaterialOutputWhouseCode { get; set; }
    }
}