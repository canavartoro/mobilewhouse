using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    public class PurchaseOrderDModel
    {
        public PurchaseOrderDModel() { }

        public bool IsSelected { get; set; }
        public int ORDER_M_ID { get; set; }
        public int ORDER_D_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_ID { get; set; }
        public decimal QTY { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_DESC { get; set; }
        public decimal QTY_READ { get; set; }
        public int BRANCH_ID { get; set; }
        public string DOC_NO { get; set; }
        public DateTime DOC_DATE { get; set; }
        public string DOC_DATE_S { get; set; }
        public string ENTITY_CODE { get; set; }
        public string ENTITY_NAME { get; set; }
        public int ENTITY_ID { get; set; }
        public int CUR_TRA_ID { get; set; }
        public decimal CUR_RATE_TRA { get; set; }
        public int CUR_RATE_TYPE_ID { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public decimal UNIT_PRICE_TRA { get; set; }

        public int CUR_TRA_ID_M { get; set; }
        public decimal CUR_RATE_TRA_M { get; set; }
        public int CUR_RATE_TYPE_ID_M { get; set; }
        public DateTime DUE_DATE { get; set; }

        public int ITEM_ATTRIBUTE1_ID { get; set; }
        public string ITEM_ATTRIBUTE1_CODE { get; set; }
        public int ITEM_ATTRIBUTE2_ID { get; set; }
        public string ITEM_ATTRIBUTE2_CODE { get; set; }
        public int ITEM_ATTRIBUTE3_ID { get; set; }
        public string ITEM_ATTRIBUTE3_CODE { get; set; }

        public int LOT_ID { get; set; }
        public string LOT_CODE { get; set; }
        public int QUALITY_ID { get; set; }
        public string QUALITY_CODE { get; set; }
        public int COLOR_ID { get; set; }
        public string COLOR_CODE { get; set; }

        public int DUE_DAY { get; set; }
        public int TOLERANCE_MAX_PO { get; set; }
    }
}
