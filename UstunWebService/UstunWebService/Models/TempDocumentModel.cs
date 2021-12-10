using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class TempDocumentModel
    {
    }
    public class TempDocumentMModel
    {
        public int DOCUMENT_M_ID { get; set; }
        public int DOCUMENT_TYPE { get; set; }
        public int USER_ID { get; set; }
        public string DOC_DATE { get; set; }
        public string DOC_NO { get; set; }
        public int WHOUSE_ID { get; set; }
        public int WHOUSE_ID2 { get; set; }
        public int PROJECT_M_ID { get; set; }
        public int BRANCH_ID { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public string SORT_NO { get; set; }
        public int TRANSACTION_ID { get; set; }
        public int ENTITY_ID { get; set; }
        public int ASSET_LOCATION_ID { get; set; }
        public string NOTE_LARGE { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }
        public string BRANCH_NAME { get; set; }
        public string WHOUSE_NAME { get; set; }
        public int DOC_TRA_ID { get; set; }
        public string DOC_TRA_CODE { get; set; }
        public string DOC_TRA_NAME { get; set; }
        public int VEHICLE_ID { get; set; }
        public string LICENSE_PLATE { get; set; }
        
        public string SHIPPINGDESC1 { get; set; } //Araç Açıklama
        public string DRIVERIDENTIFYNO { get; set; }
        public string DRIVERNAME { get; set; }
        public string DRIVERFAMILYNAME { get; set; }
        public string DRIVERGSMNO { get; set; }
        public string TRANSPORTEQUIPMENT { get; set; }

        public string ISSUETIME { get; set; } //E-İrsaliye Düzenleme saati
        public string REGISTERNAME { get; set; } //Teslim Eden


        public int CO_ID { get; set; }

        public string DUE_DATE { get; set; }
        public int DOC_NO_ID { get; set; }



    }
    public class TempDocumentDModel
    {
        public int DOCUMENT_D_ID { get; set; }
        public int DOCUMENT_M_ID { get; set; }
        public int USER_ID { get; set; }
        public int SOURCE_M_ID { get; set; }
        public int SOURCE_D_ID { get; set; }
        public int ORDER_M_ID { get; set; }
        public int ORDER_D_ID { get; set; }
        public DateTime DOC_DATE { get; set; }
        public string DOC_NO { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_CODE { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public int LOT_ID { get; set; }
        public string LOT_CODE { get; set; }
        public string LOT_NAME { get; set; }
        public decimal QTY_READ { get; set; }
        public decimal QTY { get; set; }
        public int BRANCH_ID { get; set; }
        public int ASSET_GNL_CARD_ID { get; set; }
        public int ASSET_LOCATION_ID { get; set; }
        public string BARCODE_NO { get; set; }
        public decimal QTY_PRM { get; set; }
        public string NOTE { get; set; }
        public string ASSET_GNL_CODE { get; set; }
        public string ASSET_GNL_DESC { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }
        public string WHOUSE_CODE { get; set; }
        public string WHOUSE_CODE2 { get; set; }
        public DateTime SHIPPING_DATE { get; set; }
        public int ASSET_CARD_COUNT_M_ID { get; set; }
        public string DUE_DATE { get; set; }

        public int ATTRIBUTE1_ID { get; set; }
        public string ATTRIBUTE1_CODE { get; set; }
        public int ATTRIBUTE2_ID { get; set; }
        public string ATTRIBUTE2_CODE { get; set; }
        public int ATTRIBUTE3_ID { get; set; }
        public string ATTRIBUTE3_CODE { get; set; }
        public int QUALITY_ID { get; set; }
        public string QUALITY_CODE { get; set; }
        public int COLOR_ID { get; set; }
        public string COLOR_CODE { get; set; }

    }

    public class TempDocumentDQrModel
    {
        public int DOCUMENT_D_QR_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string LOT_CODE { get; set; }
        public DateTime PRODUCTION_DATE { get; set; }
        public string PRODUCTION_DATE_STRING { get; set; }
        public string SERIAL_START { get; set; }
        public string SERIAL_END { get; set; }
        public int COUNTER_COUNT { get; set; }
        public int TEMP_DOCUMENT_M_ID { get; set; }
        public int TEMP_DOCUMENT_D_ID { get; set; }
        public string BRAND_CODE { get; set; }
        public int BRAND_ID { get; set; }
    }
}