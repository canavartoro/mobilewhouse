using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ReferralOrderDetail : OrderD
    {
        public string EntityName { get; set; }
        public string DocNo { get; set; }
        public decimal QtyShipping { get; set; }
    }
}