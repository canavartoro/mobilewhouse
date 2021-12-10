using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class DocTraModel
    {
        public int BRANCH_ID { get; set; }
        public int CO_ID { get; set; }
        public int USER_ID { get; set; }
        public int DOC_TRA_ID { get; set; }
        public string DOC_TRA_CODE { get; set; }
        public string DOC_TRA_NAME { get; set; }

        public int INVENTORY_STATUS { get; set; }
        public bool IS_REQUIRED_ENTITY { get; set; }
        public bool IS_REQUIRED_PROJECT { get; set; }
        public bool IS_DOC_NO_MOVE_TO_VOUCHER_NO { get; set; }

    }
}