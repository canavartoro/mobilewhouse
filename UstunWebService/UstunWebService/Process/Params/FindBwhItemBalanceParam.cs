using UstunWebService.UTerminalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class FindBwhItemBalanceParam : ServiceParam
    {
        public int WorderAcOpId { get; set; }
        public int WorderMId { get; set; }
        public int Metod { get; set; }
        public int MaterialOutputWhouseId { get; set; }
        public string MaterialOutputWhouseCode { get; set; }
        public int TargetWhouseId { get; set; }
        public string TargetWhouseCode { get; set; }
        public DateTime DocDate { get; set; }
        public string Note1 { get; set; }
        public int WstationId { get; set; }
        public string WstationCode { get; set; }
        public int DocTraId { get; set; }
        public string DocNo { get; set; }

        //public List<KmkWoAcAddMtrDInf> Details { get; set; }
    }
}