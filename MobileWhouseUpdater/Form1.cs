using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Diagnostics;

namespace MobileWhouseUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            Process.GetCurrentProcess().Kill();
        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private static string AppPath
        {
            get
            {
                try
                {
                    string _Path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                    if (_Path.StartsWith("file"))
                    {
                        var xDevice = new Regex("[A-Z]");
                        string xPath = _Path.Replace("file:\\", "").Substring(0, 1);
                        if (xDevice.IsMatch(xPath))
                            _Path = _Path.Replace("file:\\", "");
                    }
                    return _Path;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Concat("Program yolu okunamadı! ", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return "";
                }
            }
        }

        string[] arguments = new string[] { @"uyumsoft.zip" };

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                lblbaslik.Text = arguments[0];
                if (!File.Exists(string.Concat(AppPath, arguments[0])))
                {
                    MessageBox.Show(string.Concat("Uygulama paketi bulunamadı! ", string.Concat(AppPath, arguments[0])), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    Process.GetCurrentProcess().Kill();
                    return;
                }
                ZipFile ExtractFiles = ZipFile.Read(String.Format("{0}\\{1}", AppPath, arguments[0]));
                foreach (ZipEntry _File in ExtractFiles)
                {
                    string file = String.Format("{0}\\{1}", AppPath, _File.FileName);
                    lblbilgi.Text = file;

                    if (File.Exists(file))
                        File.Delete(file);

                    _File.Extract(AppPath, ExtractExistingFileAction.OverwriteSilently);

                    Application.DoEvents();
                }
                try
                {
                    File.Delete(String.Format("{0}\\{1}", AppPath, arguments[0]));
                }
                catch 
                { 
                }
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = string.Concat(AppPath, "\\MobileWhouse.exe");
                Process.Start(p);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Concat("Program güncellenemedi! ", exc.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }
    }
}