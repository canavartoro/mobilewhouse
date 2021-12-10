using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class PackageTempAddItemInParam : ServiceParam
    {
        public int SourceApp { get; set; }
        public int SourceApp2 { get; set; }
        public int SourceMId { get; set; }

        public int SourceDId { get; set; }
        public int SourceM1Id { get; set; }
        public int WhouseId { get; set; }
        public string[] Ids { get; set; }

        public string Barcode { get; set; } //Barcode
        public string SerialNo { get; set; } //Seri No
        public decimal MultiplierBarcodeQty { get; set; } //Barkod Miktarı Çarpanı - El İle girilen

        public bool BomPacKageTraMGetItems { get; set; }
        public int ReadLocationId { get; set; } //Okuma Raf Id 
    }
}