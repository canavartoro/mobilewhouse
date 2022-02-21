using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;
using MobileWhouse.Data;

namespace MobileWhouse.Models
{
    internal class prdd_employee
    {
        public prdd_employee() { }

        private int _prd_employee_id = 0;
        public int prd_employee_id
        {
            get { return _prd_employee_id; }
            set { _prd_employee_id = value; }
        }

        private string _citizenship_no = "";
        public string citizenship_no
        {
            get { return _citizenship_no; }
            set { _citizenship_no = value; }
        }

        private string _emp_name = "";
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; }
        }

        private string _emp_surname = "";
        public string emp_surname
        {
            get { return _emp_surname; }
            set { _emp_surname = value; }
        }

        private string _password = "";
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _employee_task_type_id = 0;
        public int employee_task_type_id
        {
            get { return _employee_task_type_id; }
            set { _employee_task_type_id = value; }
        }

        private bool _is_outsource_employee = false;
        public bool is_outsource_employee
        {
            get { return _is_outsource_employee; }
            set { _is_outsource_employee = value; }
        }

        public static prdd_employee GetEmployeeById(int employeeId)
        {
            try
            {
                Screens.ShowWait();

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat(@"SELECT prd_employee_id,citizenship_no,emp_name,emp_surname,""password"",employee_task_type_id,is_outsource_employee FROM prdd_employee WHERE prd_employee_id = '", employeeId, "' ");
                MobileWhouse.UyumConnector.ServiceResultOfDataTable emptbl = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (emptbl.Result && emptbl.Value != null && emptbl.Value.Rows.Count > 0)
                {
                    return (prdd_employee)DataProvider.TableToObject(emptbl.Value, typeof(prdd_employee));
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
            }
            return null;
        }
    }
}
