
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class CompanyModel
    {

        public int CO_ID { get; set; }
        public string CO_CODE { get; set; }
        public string CO_DESC { get; set; }
        public int CUR_ID { get; set; }
        public int CUR_RATE_TYPE_ID { get; set; }
        public int CUR_TRA_ID { get; set; }
    }
}