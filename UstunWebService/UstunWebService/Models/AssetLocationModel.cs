using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class AssetLocationModel
    {

        public int ASSET_LOCATION_ID { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }
        public string BARCODE_NO { get; set; }
        public decimal LOCATION_SIZE { get; set; }
        public int EMPLOYEES_NUMBER { get; set; }
        public int REGISTER_ID { get; set; }
        
    }
}