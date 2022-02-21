using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;
using MobileWhouse.Log;
using MobileWhouse.Data;

namespace MobileWhouse.Models
{
    internal class package_m
    {
        public package_m() { }
        public package_m(System.Data.DataRow row)
        {
            if (row != null)
            {
                if (row["PACKAGE_ID"] != DBNull.Value)
                    _package_id = StringUtil.ToInteger(row["PACKAGE_ID"]);
                if (row["WORDER_AC_OP_ID"] != DBNull.Value)
                    _worder_ac_op_id = StringUtil.ToInteger(row["WORDER_AC_OP_ID"]);
                if (row["PACKAGE_NO"] != DBNull.Value)
                    _package_no = row["PACKAGE_NO"].ToString();
                if (row["PALETTE_NO"] != DBNull.Value)
                    _palette_no = row["PALETTE_NO"].ToString();
                if (row["ITEM_ID"] != DBNull.Value)
                    _item_id = StringUtil.ToInteger(row["ITEM_ID"]);
                if (row["ITEM_CODE"] != DBNull.Value)
                    _item_code = row["ITEM_CODE"].ToString();
                if (row["ITEM_NAME"] != DBNull.Value)
                    _item_name = row["ITEM_NAME"].ToString();
                if (row["UNIT_ID"] != DBNull.Value)
                    _unit_id = StringUtil.ToInteger(row["UNIT_ID"]);
                if (row["UNIT_CODE"] != DBNull.Value)
                    _unit_code = row["UNIT_CODE"].ToString();
                if (row["QTY"] != DBNull.Value)
                    _qty = StringUtil.ToDecimal(row["QTY"]);
                if (row["WORDER_M_ID"] != DBNull.Value)
                    _worder_m_id = Convert.ToInt32(row["WORDER_M_ID"]);
                if (row["WORDER_OP_D_ID"] != DBNull.Value)
                    _worder_op_d_id = StringUtil.ToInteger(row["WORDER_OP_D_ID"]);
                if (row["OPERATION_ID"] != DBNull.Value)
                    _operation_id = StringUtil.ToInteger(row["OPERATION_ID"]);
                if (row["OPERATION_NO"] != DBNull.Value)
                    _operation_no = StringUtil.ToInteger(row["OPERATION_NO"]);
                if (row["WORDER_NO"] != DBNull.Value)
                    _worder_no = row["WORDER_NO"].ToString();
                if (row["WHOUSE_ID"] != DBNull.Value)
                    _whouse_id = StringUtil.ToInteger(row["WHOUSE_ID"]);
                if (row["WHOUSE_CODE"] != DBNull.Value)
                    _whouse_code = row["WHOUSE_CODE"].ToString();
                if (row["WHOUSE_DESC"] != DBNull.Value)
                    _whouse_desc = row["WHOUSE_DESC"].ToString();
                if (row["CREATE_DATE"] != DBNull.Value)
                    _create_date = Convert.ToDateTime(row["CREATE_DATE"]);
                if (row["IS_CLOSED"] != DBNull.Value)
                    _is_closed = StringUtil.ToInteger(row["IS_CLOSED"]) == 1;
                if (row["IS_CREATED"] != DBNull.Value)
                    _is_created = StringUtil.ToInteger(row["IS_CREATED"]) == 1;
                if (row["IS_SCRAPT"] != DBNull.Value)
                    _is_scrapt = StringUtil.ToInteger(row["IS_SCRAPT"]) == 1;
                if (row["IS_REAL"] != DBNull.Value)
                    _is_real = StringUtil.ToInteger(row["IS_REAL"]) == 1;
            }
        }

        private int _package_id = 0;
        private int _worder_ac_op_id = 0;
        private string _package_no = "";
        private string _palette_no = "";
        private int _item_id = 0;
        private string _item_code = "";
        private string _item_name = "";
        private int _unit_id = 0;
        private string _unit_code = "";
        private decimal _qty = 0;
        private int _worder_m_id = 0;
        private int _worder_op_d_id = 0;
        private int _operation_id = 0;
        private int _operation_no = 0;
        private string _worder_no = "";
        private int _whouse_id = 0;
        private string _whouse_code = "";
        private string _whouse_desc = "";
        private bool _is_closed = false;
        private bool _is_created = false;
        private bool _is_scrapt = false;
        private bool _is_real = false;
        private int _worder_ac_bom_m_id = 0;
        private int _worder_ac_bom_d_id = 0;
        private int _scrap_result_type = 0;
        private int _scrap_reason_id = 0;
        private int _diff_item_id = 0;
        private int _diff_unit_id = 0;
        private int _worder_ac_bom_d_line_no = 0;
        private int _erp_worder_ac_op_id = 0;
        private DateTime _create_date;

        public DateTime create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }
        public int package_id
        {
            get { return _package_id; }
            set { _package_id = value; }
        }
        public int worder_ac_op_id
        {
            get { return _worder_ac_op_id; }
            set { _worder_ac_op_id = value; }
        }
        public string package_no
        {
            get { return _package_no; }
            set { _package_no = value; }
        }
        public string palette_no
        {
            get { return _palette_no; }
            set { _palette_no = value; }
        }
        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; }
        }
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }
        public int unit_id
        {
            get { return _unit_id; }
            set { _unit_id = value; }
        }
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; }
        }
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public int worder_m_id
        {
            get { return _worder_m_id; }
            set { _worder_m_id = value; }
        }
        public int worder_op_d_id
        {
            get { return _worder_op_d_id; }
            set { _worder_op_d_id = value; }
        }
        public int operation_id
        {
            get { return _operation_id; }
            set { _operation_id = value; }
        }
        public int operation_no
        {
            get { return _operation_no; }
            set { _operation_no = value; }
        }
        public string worder_no
        {
            get { return _worder_no; }
            set { _worder_no = value; }
        }
        public int whouse_id
        {
            get { return _whouse_id; }
            set { _whouse_id = value; }
        }
        public string whouse_code
        {
            get { return _whouse_code; }
            set { _whouse_code = value; }
        }
        public string whouse_desc
        {
            get { return _whouse_desc; }
            set { _whouse_desc = value; }
        }
        public bool is_closed
        {
            get { return _is_closed; }
            set { _is_closed = value; }
        }
        public bool is_created
        {
            get { return _is_created; }
            set { _is_created = value; }
        }
        public bool is_scrapt
        {
            get { return _is_scrapt; }
            set { _is_scrapt = value; }
        }
        public bool is_real
        {
            get { return _is_real; }
            set { _is_real = value; }
        }
        public int scrap_reason_id
        {
            get { return _scrap_reason_id; }
            set { _scrap_reason_id = value; }
        }
        public int scrap_result_type
        {
            get { return _scrap_result_type; }
            set { _scrap_result_type = value; }
        }
        public int worder_ac_bom_m_id
        {
            get { return _worder_ac_bom_m_id; }
            set { _worder_ac_bom_m_id = value; }
        }
        public int worder_ac_bom_d_id
        {
            get { return _worder_ac_bom_d_id; }
            set { _worder_ac_bom_d_id = value; }
        }
        public int diff_item_id
        {
            get { return _diff_item_id; }
            set { _diff_item_id = value; }
        }
        public int diff_unit_id
        {
            get { return _diff_unit_id; }
            set { _diff_unit_id = value; }
        }
        public int worder_ac_bom_d_line_no
        {
            get { return _worder_ac_bom_d_line_no; }
            set { _worder_ac_bom_d_line_no = value; }
        }
        public int erp_worder_ac_op_id
        {
            get { return _erp_worder_ac_op_id; }
            set { _erp_worder_ac_op_id = value; }
        }

        public static package_m GetPackage(string package_no)
        {
            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"SELECT pkg.package_id,pkg.palette_no,pkg.worder_ac_op_id,pkg.operation_id,pkg.operation_no,pkg.package_no,pkg.item_id,it.item_code,it.item_name,
pkg.unit_id,un.unit_code,pkg.qty,pkg.worder_m_id,pkg.worder_op_d_id,wm.worder_no,pkg.whouse_id,wh.whouse_code,wh.description whouse_desc,pkg.create_date,pkg.is_closed,pkg.is_created,
pkg.is_scrapt,pkg.is_real,pkg.scrap_reason_id,pkg.scrap_result_type,pkg.worder_ac_bom_m_id,pkg.worder_ac_bom_d_id,pkg.diff_item_id,pkg.diff_unit_id,pkg.worder_ac_bom_d_line_no,pkg.erp_worder_ac_op_id  
FROM uyumsoft.zz_package_m pkg LEFT JOIN invd_item it ON pkg.item_id = it.item_id LEFT JOIN 
invd_unit un ON pkg.unit_id = un.unit_id LEFT JOIN prdt_worder_m wm ON pkg.worder_m_id = wm.worder_m_id LEFT JOIN 
invd_whouse wh ON pkg.whouse_id = wh.whouse_id
WHERE pkg.package_no = '{0}' ", package_no.Replace("'", "`"));

            MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
            param.Token = ClientApplication.Instance.Token;
            param.Value = sbSqlString.ToString();
            Logger.I(param.Value);

            MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
            if (res != null)
            {
                if (res.Result == false)
                {
                    MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                }
                else
                {
                    return DataProvider.TableToObject(res.Value, typeof(package_m)) as package_m;
                }
            }
            return null;
        }

        public static void UpdatePackage(package_m package, int worderacopid)
        {
            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"UPDATE ""uyumsoft"".""zz_package_m"" SET is_real = 1, update_date = CURRENT_TIMESTAMP, update_user_id = '{0}',erp_worder_ac_op_id = {2} WHERE package_id = '{1}'",
                ClientApplication.Instance.ClientToken.UserId, package.package_id, worderacopid);

            MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
            param.Token = ClientApplication.Instance.Token;
            param.Value = sbSqlString.ToString();
            Logger.I(param.Value);

            MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
            if (res != null)
            {
                if (res.Result == false)
                {
                    MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                }
                else
                {
                    return;
                }
            }
        }
    }
}


/*
CREATE SEQUENCE "uyumsoft"."zz_package_m_package_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_package_m_package_id_seq"', 229, true);

ALTER SEQUENCE "uyumsoft"."zz_package_m_package_id_seq" OWNER TO "uyum"; 
  
CREATE SEQUENCE "uyumsoft"."zz_package_m_package_no_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_package_m_package_no_seq"', 229, true);

ALTER SEQUENCE "uyumsoft"."zz_package_m_package_no_seq" OWNER TO "uyum"; 
 
CREATE TABLE "uyumsoft"."zz_package_m" (
  "package_id" int4 NOT NULL DEFAULT nextval('zz_package_m_package_id_seq'::regclass),
  "create_user_id" int4,
  "update_user_id" int4,
  "create_date" timestamp(6),
  "update_date" timestamp(6),
  "worder_ac_op_id" int4,
  "bwh_location_id" int4,
  "color_id" int4,
  "description" varchar(50) COLLATE "pg_catalog"."default",
  "expration_date" timestamp(6),
  "gross_weight" numeric(18,2),
  "has_detail" int2,
  "input_output" int4,
  "item_attribute1_id" int4,
  "item_attribute2_id" int4,
  "item_attribute3_id" int4,
  "item_id" int4,
  "lot_id" int4,
  "net_weight" numeric(18,2),
  "package_no" varchar(20) COLLATE "pg_catalog"."default" DEFAULT concat('KL', lpad(((nextval('zz_package_m_package_no_seq'::regclass))::character varying)::text, 12, '0'::text)),
  "package_type_id" int4,
  "qty" numeric(18,5),
  "quality_id" int4,
  "source_app" int4,
  "whouse_id" int4 NOT NULL,
  "unit_id" int4,
  "qty_free_prm" numeric(18,5),
  "qty_free_sec" numeric(18,5),
  "qty_prm" numeric(18,5),
  "cat_code1_id" int4,
  "cat_code2_id" int4,
  "dcard_id" int4,
  "package_detail_type" int4,
  "worder_m_id" int4,
  "source_m_id" int4,
  "revort" int2,
  "tare" numeric(18,6),
  "source_d_id" int4 DEFAULT 0,
  "free_sec_m_id" int4,
  "free_prm_m_id" int4,
  "serial_m_id" int4,
  "is_reserved" int2 DEFAULT 0,
  "is_closed" int2 DEFAULT 0,
  "package_m_id" int4,
  "package_tra_m_id" int4,
  "package_tra_d_id" int4,
  "worder_op_d_id" int4,
  "operation_id" int4,
  "operation_no" int4,
  "is_created" int2 DEFAULT 0,
  "palette_no" varchar(16) COLLATE "pg_catalog"."default",
  "is_scrapt" int2,
  "is_real" int2,
  "worder_ac_bom_d_id" int4,
  "scrap_result_type" int4,
  "scrap_reason_id" int4,
  "diff_item_id" int4,
  "diff_unit_id" int4,
  "erp_worder_ac_op_id" int4,
  "worder_ac_bom_m_id" int4,
  CONSTRAINT "zz_package_m_pkey" PRIMARY KEY ("package_id")
)
;

ALTER TABLE "uyumsoft"."zz_package_m" 
  OWNER TO "uyum";

CREATE UNIQUE INDEX "ix_barcode" ON "uyumsoft"."zz_package_m" USING btree (
  "package_no" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);
 */