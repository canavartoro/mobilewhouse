using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using MobileWhouse.Util;
using MobileWhouse.Log;
using MobileWhouse.Data;

namespace MobileWhouse.Models
{
    internal class worder_ac_op
    {
        public worder_ac_op() { }

        public worder_ac_op(package_m package) 
        {
            worder_m_id = package.worder_m_id;
            worder_op_d_id = package.worder_op_d_id;
            operation_id = package.operation_id;
            operation_no = package.operation_no;
            item_id = package.item_id;
            unit_id = package.unit_id;
            start_date = package.create_date;
            create_date = package.create_date;
            packages = new List<package_m>();
        }

        public worder_ac_op(System.Data.DataRow row)
        {
            if (row != null)
            {
                if (row[0] != DBNull.Value)
                    _worder_ac_op_id = StringUtil.ToInteger(row[0]);
                if (row[1] != DBNull.Value)
                    _create_user_id = StringUtil.ToInteger(row[1]);
                if (row[2] != DBNull.Value)
                    _create_date = Convert.ToDateTime(row[2], ClientApplication.Instance.Culture);
                if (row[3] != DBNull.Value)
                    _worder_m_id = StringUtil.ToInteger(row[3]);
                if (row[4] != DBNull.Value)
                    _worder_no = row[4].ToString();
                if (row[5] != DBNull.Value)
                    item_id = StringUtil.ToInteger(row[5]);
                if (row[6] != DBNull.Value)
                    _item_code = row[6].ToString();
                if (row[7] != DBNull.Value)
                    _item_name = row[7].ToString();
                if (row[8] != DBNull.Value)
                    _qty = StringUtil.ToDecimal(row[8]);
                if (row[9] != DBNull.Value)
                    _qty_net = StringUtil.ToDecimal(row[9]);
                if (row[10] != DBNull.Value)
                    _unit_id = StringUtil.ToInteger(row[10]);
                if (row[11] != DBNull.Value)
                    _worder_op_d_id = StringUtil.ToInteger(row[11]);
                if (row[12] != DBNull.Value)
                    _operation_id = StringUtil.ToInteger(row[12]);
                if (row[13] != DBNull.Value)
                    _operation_no = StringUtil.ToInteger(row[13]);
                if (row[14] != DBNull.Value)
                    _wstation_id = StringUtil.ToInteger(row[14]);
                if (row[15] != DBNull.Value)
                    _start_date = Convert.ToDateTime(row[15], ClientApplication.Instance.Culture);
                if (row[16] != DBNull.Value)
                    _shifts_id = StringUtil.ToInteger(row[16]);
            }
            packages = new List<package_m>();
        }

        private int _worder_ac_op_id = 0;
        private int _create_user_id = 0;
        private DateTime _create_date;
        private int _worder_m_id = 0;
        private string _worder_no = "";
        private int _item_id = 0;
        private string _item_code = "";
        private string _item_name = "";
        private decimal _qty = 0M;
        private decimal _qty_net = 0M;
        private int _unit_id = 0;
        private int _worder_op_d_id = 0;
        private int _operation_id = 0;
        private int _operation_no = 0;
        private int _wstation_id = 0;
        private DateTime _start_date;
        private int _shifts_id = 0;
        private int _is_approved = 0;
        private int _is_break = 0;
        private int _worder_break_id = 0;
        private decimal _density = 0M;

        public int worder_ac_op_id
        {
            get { return _worder_ac_op_id; }
            set { _worder_ac_op_id = value; }
        }
        public int create_user_id
        {
            get { return _create_user_id; }
            set { _create_user_id = value; }
        }
        public DateTime create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }
        public int worder_m_id
        {
            get { return _worder_m_id; }
            set { _worder_m_id = value; }
        }
        public string worder_no
        {
            get { return _worder_no; }
            set { _worder_no = value; }
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
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public decimal qty_net
        {
            get { return _qty_net; }
            set { _qty_net = value; }
        }
        public int unit_id
        {
            get { return _unit_id; }
            set { _unit_id = value; }
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
        public int wstation_id
        {
            get { return _wstation_id; }
            set { _wstation_id = value; }
        }
        public DateTime start_date
        {
            get { return _start_date; }
            set { _start_date = value; }
        }
        public int shifts_id
        {
            get { return _shifts_id; }
            set { _shifts_id = value; }
        }
        public int is_approved
        {
            get { return _is_approved; }
            set { _is_approved = value; }
        }
        public int is_break
        {
            get { return _is_break; }
            set { _is_break = value; }
        }
        public int worder_break_id
        {
            get { return _worder_break_id; }
            set { _worder_break_id = value; }
        }
        public decimal density
        {
            get { return _density; }
            set { _density = value; }
        }

        private List<package_m> packages = null;
        public List<package_m> Packages
        {
            get { return packages; }
            set { packages = value; }
        }

        private List<worder_employee> employee = null;
        public List<worder_employee> Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public static worder_ac_op GetProducts(int wstation_id)
        {

            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"SELECT op.""worder_ac_op_id"",op.""create_user_id"",op.""create_date"",op.""worder_m_id"",m.""worder_no"",
op.""item_id"",it.""item_code"",it.""item_name"",op.""qty"",op.""qty_net"",op.""unit_id"",op.""worder_op_d_id"",op.""operation_id"",op.""operation_no"",op.""wstation_id"",op.""start_date"",op.""shifts_id"",op.""is_approved"",it.""density"",op.""worder_break_id"" 
FROM ""uyumsoft"".""zz_worder_ac_op"" op LEFT JOIN 
uyumsoft.""prdt_worder_m"" m ON op.""worder_m_id"" = m.""worder_m_id"" LEFT JOIN 
uyumsoft.""invd_item"" it ON op.""item_id"" = it.""item_id"" 
WHERE op.""wstation_id"" = '{0}' AND op.""is_closed"" = 0 ", wstation_id);

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
                    if (res.Value != null && res.Value.Rows.Count > 0)
                    {
                        List<worder_ac_op> acop = DataProvider.TableToList(res.Value, typeof(worder_ac_op)) as List<worder_ac_op>;
                        if (acop != null && acop.Count > 0) return acop[0];
                        //return new worder_ac_op(res.Value.Rows[0]);
                    }
                }
            }
            return null;
        }

        public void GetEmployee()
        {
            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"SELECT prd_employee_id,start_date,end_date,status FROM zz_worder_employee WHERE worder_ac_op_id = 13 ", _worder_ac_op_id);

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
                    if (res.Value != null && res.Value.Rows.Count > 0)
                    {
                        employee = DataProvider.TableToList(res.Value, typeof(worder_employee)) as List<worder_employee>;
                    }
                }
            }
        }
    }

    internal class worder_employee
    {
        public worder_employee() { }

        private int _prd_employee_id = 0;
        public int prd_employee_id
        {
            get { return _prd_employee_id; }
            set { _prd_employee_id = value; }
        }

        private DateTime _start_date;
        public DateTime start_date
        {
            get { return _start_date; }
            set { _start_date = value; }
        }

        private DateTime _end_date;
        public DateTime end_date
        {
            get { return _end_date; }
            set { _end_date = value; }
        }

        private int _status = 0;
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}

/*
 
CREATE SEQUENCE IF NOT EXISTS "uyumsoft"."zz_worder_ac_op_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_worder_ac_op_id_seq"', 1, false);


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
  CONSTRAINT "zz_package_m_pkey" PRIMARY KEY ("package_id")
)
;

ALTER TABLE "uyumsoft"."zz_package_m" 
  OWNER TO "uyum";

CREATE UNIQUE INDEX "ix_barcode" ON "uyumsoft"."zz_package_m" USING btree (
  "package_no" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);


SELECT * FROM "uyumsoft"."zz_worder_ac_op"

DROP SEQUENCE IF EXISTS "uyumsoft"."zz_worder_ac_op_id_seq";

DROP TABLE IF EXISTS "uyumsoft"."zz_worder_ac_op";

SELECT * FROM information_schema.TABLES 

SELECT op."worder_ac_op_id",op."create_user_id",op."create_date",op."worder_m_id",m."worder_no",
op."item_id",it."item_code",it."item_name",op."qty",op."qty_net",op."unit_id",op."worder_op_d_id",op."operation_id",op."wstation_id",op."start_date",op."shifts_id"
FROM "uyumsoft"."zz_worder_ac_op" op LEFT JOIN 
uyumsoft."prdt_worder_m" m ON op."worder_m_id" = m."worder_m_id" LEFT JOIN 
uyumsoft."invd_item" it ON op."item_id" = it."item_id" 
WHERE op."wstation_id" = '327' AND op."is_closed" = 0 



 */