using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;

namespace MobileWhouse
{
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
        {
            InitializeComponent();

            //txtURL.Text = Properties.Settings.Default.WebServiceUrl;
            //textAppServ.Text = Properties.Settings.Default.AppServerUrl;
            //txtraporurl.Text = Properties.Settings.Default.ReportServUrl;
            txtURL.Text = AppConfig.Default.WebServiceUrl;
            textAppServ.Text = AppConfig.Default.AppServerUrl;
            txtprintserv.Text = AppConfig.Default.PrintServerHost;
            textPort.Text = AppConfig.Default.PrintServerPort.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.WebServiceUrl = txtURL.Text;
            //Properties.Settings.Default.AppServerUrl = textAppServ.Text;
            //Properties.Settings.Default.ReportServUrl = txtraporurl.Text;
            //Properties.Settings.Default.TraceLevel = cmbLog.SelectedIndex;
            //Properties.Settings.Default.Save();

            AppConfig.Default.WebServiceUrl = txtURL.Text;
            AppConfig.Default.AppServerUrl = textAppServ.Text;
            AppConfig.Default.PrintServerHost = txtprintserv.Text;
            AppConfig.Default.PrintServerPort = textPort.IntValue;
            AppConfig.Default.TraceLevel = cmbLog.SelectedIndex;
            AppConfig.Default.Save();
            ClientApplication.Instance.Relead();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            AppServ.Service serv = new MobileWhouse.AppServ.Service();
            serv.Url = string.Concat(AppConfig.Default.AppServerUrl, "/Service.asmx");
            string vers = serv.AppVersion("");
            if (vers == Program.Versiyon)
            {
                if (!Screens.Question(string.Format("PROGRAMINIZ GÜNCEL! GÜNCELLEMEK İSTİYOR MUSUNUZ? VERSİYON:{0}. PROGRAM VERSİYONU:{1}", vers, Program.Versiyon))) return;
            }

            new Updater.UpdateHelper().Update();
        }

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    AutoScaleMode = AutoScaleMode.Dpi;
            //    WindowState = FormWindowState.Normal;
            //    Location = new Point(0, 0);

            //    if (Screens.BuyukEkran)
            //        Size = new Size(800, 480);
            //}
            //catch (Exception exc)
            //{
            //    Screens.Error(exc);
            //}

            cmbLog.SelectedIndex = AppConfig.Default.TraceLevel;
        }

        private void btnbilgi_Click(object sender, EventArgs e)
        {
            Screens.Info(DeviceUtil.GetDeviceInfo());
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtURL);
        }

        private void t2_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textAppServ);
        }

        private void t3_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textPort);
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            ClientApplication.Instance.SendTrace();
        }

        private void t4_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtprintserv);
        }
    }
}