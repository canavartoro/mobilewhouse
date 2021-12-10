using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ItemBarcodeModel
    {
        public int BWH_ITEM_ID { get; set; }
        public int ITEM_ID { get; set; }
        public int WHOUSE_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string WHOUSE_CODE { get; set; }
        public int BARCODE_TYPE_ID { get; set; }
        public decimal QTY_READ { get; set; }
        public decimal QTY { get; set; }
        public decimal QTY_PRM { get; set; }
        public string BARCODE { get; set; }
        public int READ_UNIT_ID { get; set; }
        public int ITEM_COUNT { get; set; }

        public int ATTRIBUTE1_ID { get; set; }
        public string ATTRIBUTE1_CODE { get; set; }
        public int ATTRIBUTE2_ID { get; set; }
        public string ATTRIBUTE2_CODE { get; set; }
        public int ATTRIBUTE3_ID { get; set; }
        public string ATTRIBUTE3_CODE { get; set; }
        public int QUALITY_ID { get; set; }
        public string QUALITY_CODE { get; set; }
        public int LOT_ID { get; set; }
        public string LOT_CODE { get; set; }

    }
}