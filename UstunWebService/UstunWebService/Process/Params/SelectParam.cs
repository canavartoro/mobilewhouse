using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class SelectParam : ServiceParam
    {
        public SelectParam() { }
        public string Filter { get; set; }
        public int DepotId { get; set; }
        public int InfoId { get; set; }
        public DateTime SearchDate { get; set; }
        public string SearchEntity { get; set; }
        public int IsItemPicking { get; set; }
        public bool GetBaseInfo { get; set; }
    }
}