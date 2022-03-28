using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class Employee
    {
        public Employee() { }

        public int prd_employee_id { get; set; }

        public string citizenship_no { get; set; }

        public string emp_name { get; set; }

        public string emp_surname { get; set; }

        public string password { get; set; }

        public int employee_task_type_id { get; set; }

        public bool is_outsource_employee { get; set; }

        public string  full_name { get { return $"{emp_name} {emp_surname}"; } set { } }
      
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
        public bool psm002 { get; set; }
        public bool psm003 { get; set; }
        public bool pkg004 { get; set; }
        public bool prd005 { get; set; }
        public bool pkg001 { get; set; }
        public bool prd001 { get; set; }
        public bool inv001 { get; set; }
    }

    
}


/*
CREATE TABLE "uyumsoft"."zz_mob_module_permission" (
  "uid" uuid NOT NULL DEFAULT (md5(((random())::text || (clock_timestamp())::text)))::uuid,
  "operator_id" int4,
  "module_code" varchar(20) COLLATE "pg_catalog"."default",
  "is_administrative" bool,
  "psm001" bool,
  "psm002" bool,
  "psm003" bool,
  "prd008" bool,
  "prd007" bool,
  "pkg002" bool,
  "prd003" bool,
  "qlt003" bool,
  "qlt001" bool,
  "prd006" bool,
  "qlt002" bool,
  "pkg003" bool,
  "prd011" bool,
  "prd002" bool,
  "prd009" bool,
  "prd010" bool,
  "prd004" bool,
  "pkg004" bool,
  "prd005" bool,
  "pkg001" bool,
  "prd001" bool,
  "inv001" bool,
  CONSTRAINT "zz_mob_module_permission_pkey" PRIMARY KEY ("uid")
)
;

ALTER TABLE "uyumsoft"."zz_mob_module_permission" 
  OWNER TO "uyum";
	
*/
