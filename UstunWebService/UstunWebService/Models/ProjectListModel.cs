using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ProjectListModel
    {
        public int PROJECT_M_ID { get; set; }

        public string PROJECT_CODE { get; set; }

        public string DESCRIPTION { get; set; }
        public int CO_ID { get; set; }
    }
    public class ProjectFilterModel
    {
        public string PROJECT_CODE { get; set; }

        public string DESCRIPTION { get; set; }
        public int CO_ID { get; set; }
    }
}