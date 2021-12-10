using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class FindPrdWorderParam :  ServiceParam
    {
        public int WstationId { get; set; }
        public string WorderNo { get; set; }
    }
}