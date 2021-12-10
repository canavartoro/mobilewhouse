using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Objects
{
    public class WorderMInf
    {
        public WorderMInf() { }

        public int WORDER_AC_OP_ID { get; set; }
        public int WORDER_M_ID { get; set; }
        public string WORDER_NO { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string UNIT_CODE { get; set; }
        public decimal QTY { get; set; }
    }
}