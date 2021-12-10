using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class PackageTempAddItemParam : ServiceParam
    {
        public PackageTempAddItemParam() { }

        public int SourceApp { get; set; }
        public int SourceApp2 { get; set; }
        public int SourceMId { get; set; }
        public int SourceDId { get; set; }
        public int SourceM1Id { get; set; }
        public string Barcode { get; set; }
        public string SerialNo { get; set; }
        public decimal MultiplierBarcodeQty { get; set; }
        public int ReadLocationId { get; set; }
    }
}