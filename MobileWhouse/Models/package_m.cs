using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;

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
            get { return _package_id; }
            set { _package_id = value; }
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


    }
}
