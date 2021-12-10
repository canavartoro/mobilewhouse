using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ReferralOrder : OrderM
    {
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingAddress3 { get; set; }
        public int EntityId { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string TransportTypeCode { get; set; }
        public string TransportTypeDesc { get; set; }
        public string TransporterCode { get; set; }
        public string TransporterDesc { get; set; }
    }
}