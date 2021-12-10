using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class QrCodeModel
    {
        public string SerialStart { get; set; }
        public string SerialEnd { get; set; }
        public int CounterCount { get; set; }
        public int PartCount { get; set; }
        public string BrandCode { get; set; }
    }
}