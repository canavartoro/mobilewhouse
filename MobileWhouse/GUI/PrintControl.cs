using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;

namespace MobileWhouse.GUI
{
    public partial class PrintControl : UserControl
    {
        public PrintControl()
        {
            InitializeComponent();
        }
        private bool firstload = false;
        private void LoadPrinters()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                int printindex = -1;
                //string printername = RegisterCache.Cache.ReadRegister(this.Name, "");
                string printername = AppCache.ReadCache(this.Name, "");

                string[] printers = ClientApplication.Instance.ReportServ.GetPrinters();
                if (printers != null)
                {
                    cmbyazici.Items.Clear();
                    for (int i = 0; i < printers.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(printername) && printername == printers[i])
                        {
                            printerName = printername;
                            printindex = i;
                        }
                        cmbyazici.Items.Add(printers[i]);
                    }
                }
                cmbyazici.SelectedIndex = printindex;
                //cmbyazici.SelectedIndexChanged += new EventHandler(cmbyazici_SelectedIndexChanged);
                cmbyazici.TextChanged += new EventHandler(cmbyazici_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private string printerName = "";
        public string PrinterName
        {
            get { return printerName; }
        }

        public bool IsSelectPrinter
        {
            get { return !string.IsNullOrEmpty(printerName); }
        }

        void cmbyazici_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbyazici.Text))
                {
                    printerName = cmbyazici.SelectedItem.ToString();
                    AppCache.WriteCache(this.Name, printerName);
                }
                else
                {
                    printerName = "";
                    AppCache.WriteCache(this.Name, "");
                }
            }
            catch (Exception exc)
            {
                MobileWhouse.Util.Screens.Error(exc);
            }
        }

        private void PrintControl_Resize(object sender, EventArgs e)
        {
            if (!firstload)
            {
                firstload = true;
                if (!Utility.IsDesignMode)
                {
                    LoadPrinters();
                }
            }
        }

        public void Print(decimal reportCode, string procecureName, string[] parameterField, object[] parameterValue)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                string printing = ClientApplication.Instance.ReportServ.SendDirectReport2(printerName,
                    ClientApplication.Instance.ClientToken.UserId,
                    ClientApplication.Instance.Token.Password, reportCode, procecureName,
                    parameterField, parameterValue);
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void Print(int value)
        {
            string[] parameterField = new string[1];
            parameterField[0] = "pitemmid";

            object[] parameterValue = new object[1];
            parameterValue[0] = value;

            Print(221102615313372M, "rpp_prd_9009", parameterField, parameterValue);
        }

        public void Print(decimal reportCode, string procecureName, string parametername, object value)
        {
            string[] parameterField = new string[1];
            parameterField[0] = parametername;

            object[] parameterValue = new object[1];
            parameterValue[0] = value;

            Print(reportCode, procecureName, parameterField, parameterValue);
        }

        public void Print()
        {
            string[] parameterField = new string[1];
            parameterField[0] = "pitemmid";

            object[] parameterValue = new object[1];
            parameterValue[0] = 61;

            Print(221102615313372M, "rpp_prd_9009", parameterField, parameterValue);
        }
    }
}
