using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Models;
using MobileWhouse.Util;
using MobileWhouse.Dilogs;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.QLT
{
    [UyumModule("QLT003", "MobileWhouse.Controls.QLT.DiscordReportsControl", "Kalite Uygunsuzluk")]
    public partial class DiscordReportsControl : BaseControl
    {
        public DiscordReportsControl()
        {
            InitializeComponent();
            txtStok.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            cmbDiscordReportOptions.SelectedIndex = 2;
            cmbDiscordReportSource.SelectedIndex = 2;
            cmbDiscordReportState.SelectedIndex = 1;
        }

        private EmployeeLogin operatorLogin = new EmployeeLogin();
        private MobileWhouse.UyumConnector.ItemInfo _SelectedItem;

        public override void OnItemBarkod(MobileWhouse.UyumConnector.ItemInfo item)
        {
            try
            {
                base.OnItemBarkod(item);
                _SelectedItem = item;
                txtStok.Text = _SelectedItem.Name;
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            #region Validating
            StringBuilder valid = new StringBuilder();

            for (int i = 0; i < tabPage1.Controls.Count; i++)
            {
                MobileWhouse.GUI.ComboControl cmb = tabPage1.Controls[i] as MobileWhouse.GUI.ComboControl;
                if (cmb != null && cmb.Tag != null && cmb.SelectedValue == null)
                {
                    valid.AppendLine(cmb.Tag.ToString());
                }
            }

            if (string.IsNullOrEmpty(textKonu.Text))
            {
                valid.AppendLine("Uygunsuzluk Konusu boş bırakılamaz!");
            }
            if (cmbDiscordReportOptions.SelectedIndex == -1)
            {
                valid.AppendLine("Rapor Seçeneği seçilmelidir!");
            }
            if (cmbDiscordReportSource.SelectedIndex == -1)
            {
                valid.AppendLine("Kaynak seçilmelidir!");
            }
            if (cmbDiscordReportState.SelectedIndex == -1)
            {
                valid.AppendLine("Rapor Durumu seçilmelidir!");
            }
            if (string.IsNullOrEmpty(textTanim.Text))
            {
                valid.AppendLine("Uygunsuzluk Tanımı boş bırakılamaz!");
            }
            if (_SelectedItem == null)
            {
                valid.AppendLine("Stok barkodu okutun!");
            }
            if (textmiktar.DecimalValue <= 0)
            {
                valid.AppendLine("Miktar boş bırakılamaz!");
            }
            if (valid.Length > 0)
            {
                valid.AppendLine("Bilgileri kontrol edin!");
                Screens.Error(valid.ToString());
                return;
            }
            #endregion

            if (!operatorLogin.Login()) return;
            if (!operatorLogin.Operator.qlt003)
            {
                Screens.Error("Bu işlem için yetkiniz yok!");
                return;
            }

            try
            {
                Screens.ShowWait();

                DiscordReports uygunsuz = new DiscordReports();
                uygunsuz.BranchId = ClientApplication.Instance.ClientToken.BranchId;
                uygunsuz.CoId = ClientApplication.Instance.ClientToken.CoId;
                uygunsuz.DeadlineDate = date.Value.Date;
                uygunsuz.DiscordReportDate = date.Value.Date;
                uygunsuz.DocNo = operatorLogin.Operator.citizenship_no;
                uygunsuz.DocDate = date.Value.Date;
                uygunsuz.DiscordDesc = textTanim.Text;
                uygunsuz.DiscordSubject = textKonu.Text;
                uygunsuz.DiscordReportNo = DateTime.Now.ToString("yyMMddHHmmssfff");

                uygunsuz.DiscordReportOptions = cmbDiscordReportOptions.SelectedIndex + 1;
                uygunsuz.DiscordReportSource = cmbDiscordReportSource.SelectedIndex + 1;
                uygunsuz.DiscordReportState = cmbDiscordReportState.SelectedIndex + 1;

                uygunsuz.DutyGruopId = 30;//parametreye alınacak
                uygunsuz.DepartmentId = 13;//parametreye alınacak
                uygunsuz.DepartmentCode = "ÜRETİM";//parametreye alınacak
                uygunsuz.Department2Id = 13;//parametreye alınacak
                uygunsuz.DepartmentCode2 = "ÜRETİM";//parametreye alınacak
                uygunsuz.DutyGruopCode = "KLT0001";//parametreye alınacak
                uygunsuz.WstationId = Convert.ToInt32(cmbistasyon.SelectedValue);
                uygunsuz.OperationId = Convert.ToInt32(cmboperasyon.SelectedValue);
                uygunsuz.OwnerId = ClientApplication.Instance.ClientToken.UserId;//Convert.ToInt32(cmbhazirlayan.SelectedValue);
                uygunsuz.SubjectId = Convert.ToInt32(cmbkonu.SelectedValue);
                uygunsuz.PrdEmployeeId = Convert.ToInt32(cmboperator.SelectedValue);
                uygunsuz.Qty = textmiktar.DecimalValue;
                uygunsuz.QtyScrap = texthurda.DecimalValue;
                uygunsuz.ItemId = _SelectedItem.Id;
                uygunsuz.ItemCode = _SelectedItem.Name;
                uygunsuz.Name = ClientApplication.Instance.Token.UserName;
                MobileWhouse.UyumWebService.UyumServiceResponseOfString res = ClientApplication.Instance.SaveWebService(uygunsuz);
                if (!res.Success)
                {
                    Screens.Error(res.Message);
                }
                else
                {
                    MainForm.ShowControl(new QLTControl());
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

        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new QLTControl());
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textKonu);
        }

        private void t2_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textTanim);
        }
    }
}
