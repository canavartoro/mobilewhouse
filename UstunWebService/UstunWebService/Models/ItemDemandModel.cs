using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace UstunWebService.Models
{
    public class ItemDemandModel
    {
    }
    public class ItemDemandListModel // Sevk edilecek mallar listesi (onaylanmış mal talep planları)
    {
        public int ITEM_DEMAND2_M_ID { get; set; }
        public int WHOUSE_ID { get; set; }
        public DateTime CONFIRM_DATE { get; set; }
        public DateTime SHIPPING_DATE { get; set; }
        public string CONFIRM_NO { get; set; }
        public int DEMAND_STATU { get; set; }
        public DateTime DOC_DATE { get; set; }
        public string DOC_NO { get; set; }
        public int DENY_STATUS { get; set; }
        public string WHOUSE_CODE { get; set; }
        public string WHOUSE_DESC { get; set; }
        public string BRANCH_CODE { get; set; }
        public string CO_CODE { get; set; }
        public int CAT_CODE1_ID { get; set; }
        public int CAT_CODE2_ID { get; set; }
        public string CATCODE1 { get; set; }
        public string CATCODE2 { get; set; }
        public string DOC_TRA_CODE1 { get; set; }

        //public string NOTE1 { get; set; }
        //public string NOTE2 { get; set; }
        //public string NOTE3 { get; set; }
        //public string NOTE4 { get; set; }

    }

    public class ItemDemandDListModel //Sevk edilecek mallar listesi(detayları)
    {
        public int ORDER_M_ID { get; set; }
        public int ORDER_D_ID { get; set; }
        public int ITEM_ID { get; set; }
        public decimal QTY { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        //public decimal UNIT_PRICE { get; set; }
        public decimal QTY_READ { get; set; }
        public decimal QTY_CONFIRM { get; set; }
        public decimal QTY_PRM { get; set; }
        public decimal QTY_SHIPPING { get; set; }
        public int BRANCH_ID { get; set; }
        //public string DOC_NO { get; set; }
        //public DateTime DOC_DATE { get; set; }
        public int ENTITY_ID { get; set; }
        public int CUR_TRA_ID { get; set; }
        public string WHOUSE_CODE1 { get; set; }
        public string WHOUSE_CODE2 { get; set; }
        public int DEMAND_STATU { get; set; }
        public DateTime SHIPPING_DATE { get; set; }
        public DateTime DOC_DATE { get; set; }
        public int CUR_TRA_ID_M { get; set; }
        public decimal CUR_RATE_TRA_M { get; set; }
        public int CUR_RATE_TYPE_ID_M { get; set; }

        public int ITEM_ATTRIBUTE1_ID { get; set; }
        public string ITEM_ATTRIBUTE1_CODE { get; set; }
        public int ITEM_ATTRIBUTE2_ID { get; set; }
        public string ITEM_ATTRIBUTE2_CODE { get; set; }
        public int ITEM_ATTRIBUTE3_ID { get; set; }
        public string ITEM_ATTRIBUTE3_CODE { get; set; }

        public int LOT_ID { get; set; }
        public int QUALITY_ID { get; set; }
        public string QUALITY_CODE { get; set; }
        public int COLOR_ID { get; set; }
        public string COLOR_CODE { get; set; }

        public int DUE_DAY { get; set; }
    }

    [XmlType(TypeName = "Uyum")]
    public class ItemDemandObject
    {
        [XmlAttribute("Type")] public string Type { get; set; }
        public DateTime DemandDate { get; set; }
        public string DemandStatu { get; set; }
        public DateTime DocDate { get; set; }
        public string DocNo { get; set; }
        public string WhouseCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchCode2 { get; set; }
        public string CoCode { get; set; }
        public string ConfirmNo { get; set; }
        public string PlanUserFullname { get; set; }
        public SaveService.SourceApplication SourceApp { get; set; }
        public SaveService.SourceApplication SourceApp2 { get; set; }
        public string AmtTra { get; set; }
        public string DocTraWaybillCode { get; set; }
        [XmlElement]
        public ItemDemandDetailObject[] UyumDetailItem { get; set; }

    }

    //[XmlType(TypeName = "UyumDetailItem")]
    public class ItemDemandDetailObject
    {
        [XmlAttribute("DetailProperty")] public string DetailProperty { get; set; }
        public DateTime DocDate { get; set; }
        public decimal LineNo { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyConfirm { get; set; }
        public decimal QtyShipping { get; set; }
        public decimal BwhQtyPrm { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurTraCode { get; set; }
        public decimal AmtTra { get; set; }
        public string WhouseCode { get; set; } // Sevk eden depo(detay)
        public string WhouseCode2 { get; set; } // Talep eden depo(master)
        public string BranchCode { get; set; }
        public string BranchCode2 { get; set; }
        public string CoCode { get; set; }
        public string ItemCode { get; set; }
        public string UnitCode { get; set; }
        public decimal QtyPrm { get; set; }
    }
}
