using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Updater;
using MobileWhouse.Util;
using MobileWhouse.Models;

namespace MobileWhouse
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            chkRememberMe.Checked = AppConfig.Default.RememberMe; //Properties.Settings.Default.RememberMe;
            if (AppConfig.Default.RememberMe)
            {
                txtUsername.Text = AppConfig.Default.LastUsername;
                txtBranch.Text = AppConfig.Default.BranchCode;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string userName = txtUsername.Text.Trim();
                string passWord = txtPassword.Text.Trim();
                string branchCode = txtBranch.Text.Trim();

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(branchCode))
                {
                    throw new Exception("Kullanıcı Adı ve İş Yeri Girmek Mecburidir!...");
                }

                ServiceRequestOfToken token = new ServiceRequestOfToken();
                token.Value = new Token();
                token.Value.BranchCode = branchCode;
                token.Value.Password = passWord;
                token.Value.UserName = userName;

                ServiceResultOfLoginResult result = ClientApplication.Instance.Service.Login(token);
                if (result.Result)
                {
                    if ((result.Value.ServerDate.Date != DateTime.Now.Date && result.Value.ServerDate.Hour != DateTime.Now.Hour) &&
                        Screens.Question(string.Concat("Cihaz tarihi ve sistem tarihi farklı. Sistem Tarih:", result.Value.ServerDate, ", Cihaz tarihi güncellensin mi?")))
                    {
                        DeviceUtil.SetDatetime(result.Value.ServerDate.ToString("dd.MM.yyyy HH:mm:ss"));
                    }

                    ClientApplication.Instance.ClientToken = result.Value;
                    token.Value.BranchId = result.Value.BranchId;
                    token.Value.CoId = result.Value.CoId;
                    token.Value.BranchDesc = result.Value.BranchDesc;
                    ClientApplication.Instance.Token = token.Value;

                    AppServ.Service serv = new MobileWhouse.AppServ.Service();
                    serv.Url = string.Concat(AppConfig.Default.AppServerUrl, "/Service.asmx");
                    string vers = serv.AppVersion("");
                    if (vers != Program.Versiyon)
                    {
                        Screens.Error(string.Format("PROGRAM GÜNCEL DEĞİL!!! VERSİYON:{0}. PROGRAM VERSİYONU:{1}. GÜNCELLEME BAŞLATILACAK.", vers, Program.Versiyon));
                        new Updater.UpdateHelper().Update();
                        return;
                    }

                    DialogResult = DialogResult.OK;
                    Close();

                    AppConfig.Default.RememberMe = chkRememberMe.Checked;
                    if (chkRememberMe.Checked)
                    {
                        AppConfig.Default.BranchCode = branchCode;
                        AppConfig.Default.LastUsername = userName;
                    }
                    //Properties.Settings.Default.Save();
                    AppConfig.Default.Save();
                }
                else
                {
                    throw new Exception(result.Message);
                }
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormAyarlar form = new FormAyarlar())
            {
                form.ShowDialog();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblbuild.Text = string.Concat("V:", Program.Versiyon, " B:", Program.BuildNumber());
            ClearupdFiles();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnOkey_Click(btnOkey, EventArgs.Empty);
        }

        private void ClearupdFiles()
        {
            FileHelper.DeleteFile("uyumsoft.zip");//eski guncelleme dosyasini kaldir
            FileHelper.DeleteFile("Ionic.Zip.dll");
            FileHelper.DeleteFile("Ionic.Zip.CF.dll");
            FileHelper.DeleteFile("MobileWhouseUpdater.exe");
            FileHelper.DeleteFile("MobileWhouseUpdater.Win.exe");
        }
    }
}