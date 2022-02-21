using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Log;
using System.IO;

namespace MobileWhouse.Controls
{
    public partial class InputControl : BaseControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(text.Text))
                {
                    AppServ.Service serv = new MobileWhouse.AppServ.Service();
                    serv.Url = string.Concat(AppConfig.Default.AppServerUrl, "/Service.asmx");
                    string save = serv.AppLogSave(text.Text);
                    if (!string.IsNullOrEmpty(save))
                    {
                        Screens.Error(string.Concat("Bilgiler sunucuya yazılamadı. ", save));
                        return;
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        private void btnac_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    using (Stream file = new FileStream(op.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader read = new StreamReader(file, Encoding.GetEncoding("windows-1254")))
                        {
                            text.Text = read.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }
    }
}
