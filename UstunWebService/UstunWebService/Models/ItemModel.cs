using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ItemModel
    {
    }
    public class ItemListModel {
        public int ITEM_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string BARCODE { get; set; }
        public bool ISLOT_MONDATORY { get; set; }
        public int UNIT_ID { get; set; }
        public decimal QTY { get; set; }
        public int DEFAULT_UNIT_ID { get; set; }
        public string DEFAULT_UNIT_CODE { get; set; }
        public string DEFAULT_UNIT_NAME { get; set; }

    }

    public class ItemFilterModel {
        public int BranchId { get; set; }
        public int WhouseId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BARCODE { get; set; }

        public int ItemId { get; set; }
    }
    public class ItemLotFilterModel
    {
        public string LOT_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int ITEM_ID { get; set; }
        public string BARCODE { get; set; }
    }
    public class ItemLotModel
    {
        public int LOT_ID { get; set; }
        public string LOT_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string BARCODE { get; set; }
    }

    public class ItemQualityModel
    {
        public int QUALITY_ID { get; set; }
        public string QUALITY_CODE { get; set; }
        public string DESCRIPTION { get; set; }  
        public string DESCRIPTION2 { get; set; }
    }

    public class ItemAttrModel
    {
        public int ITEM_ATTRIBUTE_ID { get; set; }
        public string ITEM_ATTRIBUTE_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int ATTRIBUTE_GRP { get; set; }
    }
}