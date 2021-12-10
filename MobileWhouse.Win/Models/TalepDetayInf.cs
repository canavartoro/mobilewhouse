using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MobileWhouse.Util;

namespace MobileWhouse.Models
{
    internal class TalepDetayInf
    {
        public TalepDetayInf() { }

        public TalepDetayInf(DataRow dr)
        {
            if (dr != null)
            {
                if (!dr.IsNull("TRANSFER_D_ID"))
                    tRANSFER_D_ID = StringUtil.ToInteger(dr["TRANSFER_D_ID"]);
                if (!dr.IsNull("TRANSFER_M_ID"))
                    tRANSFER_M_ID = StringUtil.ToInteger(dr["TRANSFER_M_ID"]);
                if (!dr.IsNull("WORDER_M_ID"))
                    wORDER_M_ID = StringUtil.ToInteger(dr["WORDER_M_ID"]);
                if (!dr.IsNull("WORDER_NO"))
                    wORDER_NO = dr["WORDER_NO"].ToString();
                if (!dr.IsNull("WORDER_ITEM_ID"))
                    wORDER_ITEM_ID = StringUtil.ToInteger(dr["WORDER_ITEM_ID"]);
                if (!dr.IsNull("WORDER_ITEM_CODE"))
                    wORDER_ITEM_CODE = dr["WORDER_ITEM_CODE"].ToString();
                if (!dr.IsNull("WORDER_UNIT_ID"))
                    wORDER_UNIT_ID = StringUtil.ToInteger(dr["WORDER_UNIT_ID"]);
                if (!dr.IsNull("WORDER_QTY"))
                    WORDER_QTY = StringUtil.ToDecimal(dr["WORDER_QTY"]);
                if (!dr.IsNull("WORDER_M_ID"))
                    wORDER_M_ID = StringUtil.ToInteger(dr["WORDER_M_ID"]);
                if (!dr.IsNull("LINE_NO"))
                    lINE_NO = StringUtil.ToInteger(dr["LINE_NO"]);
                if (!dr.IsNull("ITEM_ID"))
                    iTEM_ID = StringUtil.ToInteger(dr["ITEM_ID"]);
                if (!dr.IsNull("ITEM_CODE"))
                    iTEM_CODE = dr["ITEM_CODE"].ToString();
                if (!dr.IsNull("ITEM_NAME"))
                    iTEM_NAME = dr["ITEM_NAME"].ToString();
                if (!dr.IsNull("BOM_LINE_TYPE"))
                    bOM_LINE_TYPE = StringUtil.ToInteger(dr["BOM_LINE_TYPE"]);
                if (!dr.IsNull("ITEM_BOM_M_ID"))
                    iTEM_BOM_M_ID = StringUtil.ToInteger(dr["ITEM_BOM_M_ID"]);
                if (!dr.IsNull("ALTERNATIVE_NO"))
                    aLTERNATIVE_NO = dr["ALTERNATIVE_NO"].ToString();
                if (!dr.IsNull("DESCRIPTION"))
                    dESCRIPTION = dr["DESCRIPTION"].ToString();
                if (!dr.IsNull("QTY_TYPE"))
                    qTY_TYPE = StringUtil.ToInteger(dr["QTY_TYPE"]);
                if (!dr.IsNull("QTY_TRAILING"))
                    qTY_TRAILING = StringUtil.ToDecimal(dr["QTY_TRAILING"]);
                if (!dr.IsNull("QTY_REQUIRED_TRAILING"))
                    qTY_REQUIRED_TRAILING = StringUtil.ToDecimal(dr["QTY_REQUIRED_TRAILING"]);
                if (!dr.IsNull("QTY_RECOMMEND"))
                    qTY_RECOMMEND = StringUtil.ToDecimal(dr["QTY_RECOMMEND"]);
                if (!dr.IsNull("UNIT_ID"))
                    uNIT_ID = StringUtil.ToInteger(dr["UNIT_ID"]);
                if (!dr.IsNull("UNIT_CODE"))
                    uNIT_CODE = dr["UNIT_CODE"].ToString();
                if (!dr.IsNull("WHOUSE_ID"))
                    wHOUSE_ID = StringUtil.ToInteger(dr["WHOUSE_ID"]);
                if (!dr.IsNull("WHOUSE_CODE"))
                    wHOUSE_CODE = dr["WHOUSE_CODE"].ToString();
                if (!dr.IsNull("WHOUSE_DESC"))
                    wHOUSE_DESC = dr["WHOUSE_DESC"].ToString();
                if (!dr.IsNull("WHOUSE2_ID"))
                    wHOUSE2_ID = StringUtil.ToInteger(dr["WHOUSE2_ID"]);
                if (!dr.IsNull("WHOUSE2_CODE"))
                    wHOUSE2_CODE = dr["WHOUSE2_CODE"].ToString();
                if (!dr.IsNull("COLOR_ID"))
                    cOLOR_ID = StringUtil.ToInteger(dr["COLOR_ID"]);
                if (!dr.IsNull("COLOR_CODE"))
                    cOLOR_CODE = dr["COLOR_CODE"].ToString();
                if (!dr.IsNull("LOT_ID"))
                    lOT_ID = StringUtil.ToInteger(dr["LOT_ID"]);
                if (!dr.IsNull("LOT_CODE"))
                    lOT_CODE = dr["LOT_CODE"].ToString();
                if (!dr.IsNull("PACKAGE_TYPE_ID"))
                    pACKAGE_TYPE_ID = StringUtil.ToInteger(dr["PACKAGE_TYPE_ID"]);
                if (!dr.IsNull("PACKAGE_TYPE_CODE"))
                    pACKAGE_TYPE_CODE = dr["PACKAGE_TYPE_CODE"].ToString();
                if (!dr.IsNull("QUALITY_ID"))
                    qUALITY_ID = StringUtil.ToInteger(dr["QUALITY_ID"]);
                if (!dr.IsNull("QUALITY_CODE"))
                    qUALITY_CODE = dr["QUALITY_CODE"].ToString();
                if (!dr.IsNull("ITEM_ATTRIBUTE1_ID"))
                    iTEM_ATTRIBUTE1_ID = StringUtil.ToInteger(dr["ITEM_ATTRIBUTE1_ID"]);
                if (!dr.IsNull("ITEM_ATTRIBUTE_CODE1"))
                    ITEM_ATTRIBUTE_CODE1 = dr["ITEM_ATTRIBUTE_CODE1"].ToString();
                if (!dr.IsNull("ITEM_ATTRIBUTE2_ID"))
                    iTEM_ATTRIBUTE2_ID = StringUtil.ToInteger(dr["ITEM_ATTRIBUTE2_ID"]);
                if (!dr.IsNull("ITEM_ATTRIBUTE_CODE2"))
                    iTEM_ATTRIBUTE_CODE2 = dr["ITEM_ATTRIBUTE_CODE2"].ToString();
                if (!dr.IsNull("ITEM_ATTRIBUTE3_ID"))
                    iTEM_ATTRIBUTE3_ID = StringUtil.ToInteger(dr["ITEM_ATTRIBUTE3_ID"]);
                if (!dr.IsNull("ITEM_ATTRIBUTE_CODE3"))
                    iTEM_ATTRIBUTE_CODE3 = dr["ITEM_ATTRIBUTE_CODE3"].ToString();
                if (!dr.IsNull("IS_AUTOMATIC"))
                    iS_AUTOMATIC = StringUtil.ToInteger(dr["IS_AUTOMATIC"]);
                barkods = new List<MobileWhouse.UTermConnector.PackageDetail>();
            }
        }

        private int tRANSFER_D_ID = 0;
        private int tRANSFER_M_ID = 0;
        private int wORDER_M_ID = 0;
        private string wORDER_NO = "";
        private int wORDER_ITEM_ID = 0;
        private string wORDER_ITEM_CODE = "";
        private int wORDER_UNIT_ID = 0;
        private decimal wORDER_QTY = 0;
        private int lINE_NO = 0;
        private int iTEM_ID = 0;
        private string iTEM_CODE = "";
        private string iTEM_NAME = "";
        private int bOM_LINE_TYPE = 0;
        private int iTEM_BOM_M_ID = 0;
        private string aLTERNATIVE_NO = "";
        private string dESCRIPTION = "";
        private int qTY_TYPE = 0;
        private decimal qTY_TRAILING = 0;
        private decimal qTY_REQUIRED_TRAILING = 0;
        private decimal qTY_RECOMMEND = 0;
        private decimal qTY_READ = 0;
        private int uNIT_ID = 0;
        private string uNIT_CODE = "";
        private int wHOUSE_ID = 0;
        private string wHOUSE_CODE = "";
        private string wHOUSE_DESC = "";
        private int wHOUSE2_ID = 0;
        private string wHOUSE2_CODE = "";
        private int cOLOR_ID = 0;
        private string cOLOR_CODE = "";
        private int lOT_ID = 0;
        private string lOT_CODE = "";
        private int pACKAGE_TYPE_ID = 0;
        private string pACKAGE_TYPE_CODE = "";
        private int qUALITY_ID = 0;
        private string qUALITY_CODE = "";
        private int iTEM_ATTRIBUTE1_ID = 0;
        private int iTEM_ATTRIBUTE2_ID = 0;
        private int iTEM_ATTRIBUTE3_ID = 0;
        private string iTEM_ATTRIBUTE_CODE1 = "";
        private string iTEM_ATTRIBUTE_CODE2 = "";
        private string iTEM_ATTRIBUTE_CODE3 = "";
        private int iS_AUTOMATIC = 0;
        private int lOCATION_ID = 0;
        private int pACKAGE_M_ID = 0;
        private string pACKAGE_NO = "";
        private List<MobileWhouse.UTermConnector.PackageDetail> barkods = null;

        public int TRANSFER_D_ID
        {
            get { return tRANSFER_D_ID; }
            set { tRANSFER_D_ID = value; }
        }
        public int TRANSFER_M_ID
        {
            get { return tRANSFER_M_ID; }
            set { tRANSFER_M_ID = value; }
        }
        public int WORDER_M_ID
        {
            get { return tRANSFER_M_ID; }
            set { tRANSFER_M_ID = value; }
        }
        public string WORDER_NO
        {
            get { return wORDER_NO; }
            set { wORDER_NO = value; }
        }
        public int WORDER_ITEM_ID
        {
            get { return wORDER_ITEM_ID; }
            set { wORDER_ITEM_ID = value; }
        }
        public string WORDER_ITEM_CODE
        {
            get { return wORDER_ITEM_CODE; }
            set { wORDER_ITEM_CODE = value; }
        }
        public int WORDER_UNIT_ID
        {
            get { return wORDER_UNIT_ID; }
            set { wORDER_UNIT_ID = value; }
        }
        public decimal WORDER_QTY
        {
            get { return wORDER_QTY; }
            set { wORDER_QTY = value; }
        }
        public int LINE_NO
        {
            get { return lINE_NO; }
            set { lINE_NO = value; }
        }
        public int ITEM_ID
        {
            get { return iTEM_ID; }
            set { iTEM_ID = value; }
        }
        public string ITEM_CODE
        {
            get { return iTEM_CODE; }
            set { iTEM_CODE = value; }
        }
        public string ITEM_NAME
        {
            get { return iTEM_NAME; }
            set { iTEM_NAME = value; }
        }
        public int BOM_LINE_TYPE
        {
            get { return bOM_LINE_TYPE; }
            set { bOM_LINE_TYPE = value; }
        }
        public int ITEM_BOM_M_ID
        {
            get { return iTEM_BOM_M_ID; }
            set { iTEM_BOM_M_ID = value; }
        }
        public string ALTERNATIVE_NO
        {
            get { return aLTERNATIVE_NO; }
            set { aLTERNATIVE_NO = value; }
        }
        public string DESCRIPTION
        {
            get { return dESCRIPTION; }
            set { dESCRIPTION = value; }
        }
        public int QTY_TYPE
        {
            get { return qTY_TYPE; }
            set { qTY_TYPE = value; }
        }
        public decimal QTY_TRAILING
        {
            get { return qTY_TRAILING; }
            set { qTY_TRAILING = value; }
        }
        public decimal QTY_REQUIRED_TRAILING
        {
            get { return qTY_REQUIRED_TRAILING; }
            set { qTY_REQUIRED_TRAILING = value; }
        }
        public decimal QTY_RECOMMEND
        {
            get { return qTY_RECOMMEND; }
            set { qTY_RECOMMEND = value; }
        }
        public decimal QTY_READ
        {
            get { return qTY_READ; }
            set { qTY_READ = value; }
        }
        public int UNIT_ID
        {
            get { return uNIT_ID; }
            set { uNIT_ID = value; }
        }
        public string UNIT_CODE
        {
            get { return uNIT_CODE; }
            set { uNIT_CODE = value; }
        }
        public int WHOUSE_ID
        {
            get { return wHOUSE_ID; }
            set { wHOUSE_ID = value; }
        }
        public string WHOUSE_CODE
        {
            get { return wHOUSE_CODE; }
            set { wHOUSE_CODE = value; }
        }
        public string WHOUSE_DESC
        {
            get { return wHOUSE_DESC; }
            set { wHOUSE_DESC = value; }
        }
        public int WHOUSE2_ID
        {
            get { return wHOUSE2_ID; }
            set { wHOUSE2_ID = value; }
        }
        public string WHOUSE2_CODE
        {
            get { return wHOUSE2_CODE; }
            set { wHOUSE2_CODE = value; }
        }
        public int COLOR_ID
        {
            get { return cOLOR_ID; }
            set { cOLOR_ID = value; }
        }
        public string COLOR_CODE
        {
            get { return cOLOR_CODE; }
            set { cOLOR_CODE = value; }
        }
        public int LOT_ID
        {
            get { return lOT_ID; }
            set { lOT_ID = value; }
        }
        public string LOT_CODE
        {
            get { return lOT_CODE; }
            set { lOT_CODE = value; }
        }
        public int PACKAGE_TYPE_ID
        {
            get { return pACKAGE_TYPE_ID; }
            set { pACKAGE_TYPE_ID = value; }
        }
        public string PACKAGE_TYPE_CODE
        {
            get { return pACKAGE_TYPE_CODE; }
            set { pACKAGE_TYPE_CODE = value; }
        }
        public int QUALITY_ID
        {
            get { return qUALITY_ID; }
            set { qUALITY_ID = value; }
        }
        public string QUALITY_CODE
        {
            get { return qUALITY_CODE; }
            set { qUALITY_CODE = value; }
        }
        public int ITEM_ATTRIBUTE1_ID
        {
            get { return iTEM_ATTRIBUTE1_ID; }
            set { iTEM_ATTRIBUTE1_ID = value; }
        }
        public int ITEM_ATTRIBUTE2_ID
        {
            get { return iTEM_ATTRIBUTE2_ID; }
            set { iTEM_ATTRIBUTE2_ID = value; }
        }
        public int ITEM_ATTRIBUTE3_ID
        {
            get { return iTEM_ATTRIBUTE3_ID; }
            set { iTEM_ATTRIBUTE3_ID = value; }
        }
        public string ITEM_ATTRIBUTE_CODE1
        {
            get { return iTEM_ATTRIBUTE_CODE1; }
            set { iTEM_ATTRIBUTE_CODE1 = value; }
        }
        public string ITEM_ATTRIBUTE_CODE2
        {
            get { return iTEM_ATTRIBUTE_CODE2; }
            set { iTEM_ATTRIBUTE_CODE2 = value; }
        }
        public string ITEM_ATTRIBUTE_CODE3
        {
            get { return iTEM_ATTRIBUTE_CODE3; }
            set { iTEM_ATTRIBUTE_CODE3 = value; }
        }
        public int IS_AUTOMATIC
        {
            get { return iS_AUTOMATIC; }
            set { iS_AUTOMATIC = value; }
        }
        public int LOCATION_ID
        {
            get { return lOCATION_ID; }
            set { lOCATION_ID = value; }
        }
        public int PACKAGE_M_ID
        {
            get { return pACKAGE_M_ID; }
            set { pACKAGE_M_ID = value; }
        }
        public string PACKAGE_NO
        {
            get { return pACKAGE_NO; }
            set { pACKAGE_NO = value; }
        }

        public List<MobileWhouse.UTermConnector.PackageDetail> PackageDetails
        {
            get { return barkods; }
            set { barkods = value; }
        }
    }
}
