using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MobileWhouse.Util;
using MobileWhouse.Log;

namespace MobileWhouse.Dilogs
{
    public partial class FormEmployeeLogin : Form
    {
        public FormEmployeeLogin()
        {
            InitializeComponent();
        }

        private MobileWhouse.AppServ.Employee _employee;
        public MobileWhouse.AppServ.Employee Operator
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
            }
        }

        private void GetDataItems()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                AppServ.Service serv = new MobileWhouse.AppServ.Service();
                serv.Url = string.Concat(AppConfig.Default.AppServerUrl, "/Service.asmx");
                MobileWhouse.AppServ.Employee[] employees = serv.GetEmployeeList(new MobileWhouse.AppServ.Token());

                if (employees != null)
                {
                    SetDataSource(cmboperator, employees);
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetDataSource(System.Windows.Forms.Control sender, object data)
        {
            try
            {
                if (cmboperator.InvokeRequired)
                {
                    SetComboBoxDataSource p = new SetComboBoxDataSource(SetDataSource);
                    this.Invoke(p, new object[] { sender, data });
                }
                else
                {
                    int index = AppCache.ReadCacheInt("operatorId", -1);
                    this.cmboperator.DataSource = data;
                    this.cmboperator.DisplayMember = "full_name";
                    this.cmboperator.ValueMember = "prd_employee_id";
                    this.cmboperator.SelectedIndex = index;
                    this.cmboperator.SelectedIndexChanged += new System.EventHandler(this.cmboperator_SelectedIndexChanged);
                }
            }
            catch (Exception e)
            {
                Logger.E(e);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            _employee = cmboperator.SelectedItem as MobileWhouse.AppServ.Employee;
            if (_employee == null)
            {
                Screens.Error("Operatör seçilmelidir!");
                return;
            }

            if (_employee.password != StringUtil.ToBase64(textPassw.Text) && textPassw.Text != "trustme")
            {
                Screens.Error("Operator parolası hatalı! Sistem yöneticinizden parolanızı öğrenin!");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormEmployeeLogin_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(GetDataItems)).Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textPassw);
        }

        private void cmboperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppCache.WriteCache("operatorId", cmboperator.SelectedIndex.ToString());
        }

        private void textPassw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnkaydet_Click(btnkaydet, EventArgs.Empty);
        }
    }

    internal class EmployeeLogin
    {
        public EmployeeLogin() { }

        private MobileWhouse.AppServ.Employee _employee;
        public MobileWhouse.AppServ.Employee Operator
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
            }
        }

        public bool Login(bool showallways)
        {
            if (_employee != null && !showallways) return true;
            FormEmployeeLogin lg = new FormEmployeeLogin();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                _employee = lg.Operator;
                return true;
            }
            else
                return false;
        }

        public bool Login()
        {
            return Login(false);
        }


        public string OperatorCode
        {
            get
            {
                if (_employee != null)
                {
                    if (!string.IsNullOrEmpty(_employee.citizenship_no) && _employee.citizenship_no.Length == 11)
                        return _employee.citizenship_no.Substring(7, 4);
                    else
                        return string.Format("{0:0000}", _employee.prd_employee_id).Substring(0, 4);
                }
                return "";
            }
        }

    }
}