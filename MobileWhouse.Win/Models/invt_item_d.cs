using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    public class invt_item_d
    {
        public invt_item_d() { }

        private int _item_d_id = 0;
        public int item_d_id
        {
            get { return _item_d_id; }
            set { _item_d_id = value; }
        }

        private int _item_id = 0;
        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }

        private string _item_code = "";
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; }
        }

        private string _item_name = "";
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }

        private int _unit_id = 0;
        public int unit_id
        {
            get { return _unit_id; }
            set { _unit_id = value; }
        }

        private string _unit_code = "";
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; }
        }

        private decimal _qty = 0;
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private int _line_no = 0;
        public int line_no
        {
            get { return _line_no; }
            set { _line_no = value; }
        }

        private int _lot_id = 0;
        public int lot_id
        {
            get { return _lot_id; }
            set { _lot_id = value; }
        }

        private string _lot_code = "";
        public string lot_code
        {
            get { return _lot_code; }
            set { _lot_code = value; }
        }

        private int _whouse_id = 0;
        public int whouse_id
        {
            get { return _whouse_id; }
            set { _whouse_id = value; }
        }

        private string _whouse_code = "";
        public string whouse_code
        {
            get { return _whouse_code; }
            set { _whouse_code = value; }
        }

        private int _source_d_id = 0;
        public int source_d_id
        {
            get { return _source_d_id; }
            set { _source_d_id = value; }
        }

        private int _source_m_id = 0;
        public int source_m_id
        {
            get { return _source_m_id; }
            set { _source_m_id = value; }
        }
    }
}
