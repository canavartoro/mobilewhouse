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
            txtraporurl.Text = AppConfig.Default.ReportServUrl;
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
            AppConfig.Default.ReportServUrl = txtraporurl.Text;
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
            cmbLog.SelectedIndex = AppConfig.Default.TraceLevel;
        }

        private void btnbilgi_Click(object sender, EventArgs e)
        {
            StringBuilder sbilgi = new StringBuilder();
            sbilgi.AppendFormat("Versiyon:{0}, Derleme:{1}", Program.Versiyon, Program.BuildNumber());
            sbilgi.Append(Environment.NewLine);
            sbilgi.AppendFormat("Cihaz İp:{0}", DeviceUtil.IpGetir());
            sbilgi.Append(Environment.NewLine);
            sbilgi.AppendFormat("Cihaz Id:{0}", DeviceUtil.GetDeviceId());
            sbilgi.Append(Environment.NewLine);
            sbilgi.AppendFormat("Ekran yükseklik:{0}, genişlik:{1}", Screen.PrimaryScreen.WorkingArea.Height, Screen.PrimaryScreen.WorkingArea.Width);
            Screens.Info(sbilgi.ToString());
        }
    }
}