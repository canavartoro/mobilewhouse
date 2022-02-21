using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    public class ModulePermission
    {
        public ModulePermission() { }

        public int prd_employee_id { get; set; }
        public string emp_name { get; set; }
        public string emp_surname { get; set; }

        public bool psm002 { get; set; }
        public bool prd008 { get; set; }
        public bool prd007 { get; set; }
        public bool pkg002 { get; set; }
        public bool prd003 { get; set; }
        public bool qlt003 { get; set; }
        public bool qlt001 { get; set; }
        public bool prd006 { get; set; }
        public bool qlt002 { get; set; }
        public bool pkg003 { get; set; }
        public bool prd011 { get; set; }
        public bool prd002 { get; set; }
        public bool prd009 { get; set; }
        public bool prd010 { get; set; }
        public bool prd004 { get; set; }
        public bool psm001 { get; set; }
        public bool pkg004 { get; set; }
        public bool prd005 { get; set; }
        public bool pkg001 { get; set; }
        public bool prd001 { get; set; }
    }
}
