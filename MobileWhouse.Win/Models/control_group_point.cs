using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Log;
using MobileWhouse.Data;

namespace MobileWhouse.Models
{
    internal class control_group_point
    {
        public control_group_point() { }

        private int _control_group_point_id = 0;
        private string _control_point_code = "";
        private string _control_point_desc = "";
        private int _control_level_id = 0;
        private int _control_point_id = 0;
        private int _equipment_id = 0;
        private int _control_ptype = 0;
        private decimal _max_point_qty = 0M;
        private decimal _min_point_qty = 0M;
        private decimal _nominal_point_qty = 0M;
        private decimal _utolerance_qty = 0M;
        private decimal _dtolerance_qty = 0M;
        private int _point_type = 0;
        private decimal _control_qty = 0M;
        private bool _control_result = false;

        public int control_group_point_id
        {
            get { return this._control_group_point_id; }
            set { this._control_group_point_id = value; }
        }
        public string control_point_code
        {
            get { return this._control_point_code; }
            set { this._control_point_code = value; }
        }
        public string control_point_desc
        {
            get { return this._control_point_desc; }
            set { this._control_point_desc = value; }
        }
        public int control_level_id
        {
            get { return this._control_level_id; }
            set { this._control_level_id = value; }
        }
        public int control_point_id
        {
            get { return this._control_point_id; }
            set { this._control_point_id = value; }
        }
        public int equipment_id
        {
            get { return this._equipment_id; }
            set { this._equipment_id = value; }
        }
        public int control_ptype
        {
            get { return this._control_ptype; }
            set { this._control_ptype = value; }
        }
        public decimal max_point_qty
        {
            get { return this._max_point_qty; }
            set { this._max_point_qty = value; }
        }
        public decimal min_point_qty
        {
            get { return this._min_point_qty; }
            set { this._min_point_qty = value; }
        }
        public decimal nominal_point_qty
        {
            get { return this._nominal_point_qty; }
            set { this._nominal_point_qty = value; }
        }
        public decimal utolerance_qty
        {
            get { return this._utolerance_qty; }
            set { this._utolerance_qty = value; }
        }
        public decimal dtolerance_qty
        {
            get { return this._dtolerance_qty; }
            set { this._dtolerance_qty = value; }
        }
        public int point_type
        {
            get { return this._point_type; }
            set { this._point_type = value; }
        }
        public decimal control_qty
        {
            get { return this._control_qty; }
            set { this._control_qty = value; }
        }
        public bool control_result
        {
            get { return this._control_result; }
            set { this._control_result = value; }
        }

        public static List<control_group_point> GetPoints(int group_id)
        {

            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"SELECT gp.control_group_point_id,cp.control_point_code,cp.control_point_desc,gp.control_level_id,gp.control_point_id,gp.equipment_id,
gp.control_ptype,gp.max_point_qty,gp.min_point_qty,gp.nominal_point_qty,gp.utolerance_qty,
gp.dtolerance_qty,cp.point_type,cp.is_error_detail 
FROM qltd_control_group_points gp INNER JOIN qltd_control_points cp ON gp.control_point_id = cp.control_point_id 
WHERE gp.control_group_id = {0} ORDER BY cp.control_point_code ", group_id);

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
                        return DataProvider.TableToList(res.Value, typeof(control_group_point)) as List<control_group_point>;
                    }
                }
            }
            return null;
        }
    }
}
