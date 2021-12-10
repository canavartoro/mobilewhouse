using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ListFilterModel
    {
        public string searchText { get; set; }
        public string barcode { get; set; }
        public int id { get; set; }
        public int filterId { get; set; }
        public int wstation_unit_id { get; set; }
        public int item_id { get; set; }
        public int branch_id { get; set; }
        public int co_id;
        public int entity_id;
        
        public int only_controlled { get; set; }
        public int worder_op_ac_status_control { get; set; }
        public int wstation_unit_worder_op_ac_control { get; set; }
        public int worder_op_ac_only_wstation_unit { get; set; }
        public int wstation_id { get; set; }
        public int location_type { get; set; }
        public int location_id { get; set; }
        public int only_working_employee { get; set; }
        public int only_not_break_reason_employee { get; set; }
        public int only_break_reason_employee { get; set; }
        public int control_only_active_worder_op_ac_for_location { get; set; }
        public int worder_op_ac_id { get; set; }

        public int daily_worder_id { get; set; }
        public int barcode_design_m_id { get; set; }
        public int wcenter_id { get; set; }

        public string doc_tra { get; set; }
        public string doc_date { get; set; }
        public int purchaseSales { get; set; }

        public int more_than_order_qty { get; set; }
        public List<int> orderMasterNoList { get; set; }



    }
}