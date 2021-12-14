using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using MobileWhouse.ProdConnector;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PRD
{
    //http://10.0.0.250:400/GeneralCard.aspx?CommandName=PrdFreeBreakWorderCollection.New&ObjectId=0&WinId=11
    public partial class DurusControl : BaseControl
    {
        public DurusControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;

        private void GetBreakReason()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT BR.BREAK_REASON_CODE || ' ' || BR.DESCRIPTION AS TXT,BR.BREAK_REASON_ID,BR.BREAK_REASON_CODE,BR.DESCRIPTION,BR.IS_NOT_ACTUALCOST,
BR.IS_NOT_IN_EFFICIENCY,BR.IS_NOT_IN_CAPACITY,BR.IS_NOT_WO_DURATION_ADD,BR.IS_PLANNED,BR.IS_NOT_DATE_CONTROL 
FROM UYUMSOFT.PRDD_BREAK_REASON BR WHERE BR.BRANCH_ID = {0} AND BR.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = sbSqlString.ToString();
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        cmddurusneden.DataSource = res.Value;
                        cmddurusneden.DisplayMember = "TXT";
                        cmddurusneden.ValueMember = "BREAK_REASON_ID";
                        cmddurusneden.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                GetShifts();
            }
        }

        private void GetShifts()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT SH.SHIFTS_CODE || ' ' || SH.DESCRIPTION || ' ' || TO_CHAR(SH.START_DATE,'HH24:MI') || ' - ' || 
TO_CHAR(SH.END_DATE,'HH24:MI') AS TXT,SH.SHIFTS_ID,SH.SHIFTS_CODE,SH.DESCRIPTION,SH.CALENDAR_ID,SH.NET_TIME,SH.GROSS_TIME,
TO_CHAR(SH.START_DATE,'HH24:MI') AS START_TIME,TO_CHAR(SH.END_DATE,'HH24:MI') AS END_TIME FROM PRDD_SHIFTS SH
WHERE SH.BRANCH_ID = {0} AND SH.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = sbSqlString.ToString();
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        cmbvardiya.DataSource = res.Value;
                        cmbvardiya.DisplayMember = "TXT";
                        cmbvardiya.ValueMember = "SHIFTS_ID";
                        cmbvardiya.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                GetEmployee();
            }
        }

        private void GetEmployee()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT EM.PRD_EMPLOYEE_ID,EM.EMP_NAME || ' ' || EM.EMP_SURNAME AS TXT FROM UYUMSOFT.PRDD_EMPLOYEE EM WHERE EM.BRANCH_ID = {0} AND EM.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = sbSqlString.ToString();
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        cmbpersonel.DataSource = res.Value;
                        cmbpersonel.DisplayMember = "TXT";
                        cmbpersonel.ValueMember = "PRD_EMPLOYEE_ID";
                        cmbpersonel.SelectedIndex = -1;
                    }
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnistasyon_Click(object sender, EventArgs e)
        {
            using (FormSelectWstation frm = new FormSelectWstation())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                {
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                }
            }
        }

        private void DurusControl_OnLoad(object sender, EventArgs e)
        {
        }

        private void btntamam_Click(object sender, EventArgs e)
        {
            try
            {
                int calendarTypeId = 0;
                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmelidir!");
                    return;
                }

                if (cmddurusneden.SelectedItem == null)
                {
                    Screens.Error("Duruş nedeni seçilmelidir!");
                    return;
                }
                if (cmbvardiya.SelectedItem == null)
                {
                    Screens.Error("Vardiya kodu seçilmelidir!");
                    return;
                }
                //else
                //{
                //    DataRowView dr = cmbvardiya.SelectedItem as DataRowView;
                //    if (DBNull.Value != dr["CALENDAR_ID"])
                //        calendarTypeId = Convert.ToInt32(dr["CALENDAR_ID"]);
                //}

                Cursor.Current = Cursors.WaitCursor;

                ServiceRequestOfFreeBreakInf param = new ServiceRequestOfFreeBreakInf();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new FreeBreakInf();
                param.Value.StartDate = dateStart.Value;
                param.Value.EndDate = dateEnd.Value;
                param.Value.ShiftId = StringUtil.ToInteger(cmbvardiya.SelectedValue);
                param.Value.CalendarTypeId = calendarTypeId;
                param.Value.BreakReasonId = StringUtil.ToInteger(cmddurusneden.SelectedValue);
                if (cmbpersonel.SelectedItem != null)
                    param.Value.EmployeeId = StringUtil.ToInteger(cmbpersonel.SelectedValue);
                param.Value.WstationId = wstation.PrdGobalId;
                param.Value.WstationCode = wstation.PrdGobalCode;
                param.Value.NoteLarge1 = txtaciklama.Text;

                ServiceResultOfInt32 res = ClientApplication.Instance.ProdService.SaveFreeBreakWorder(param);

                if (res.Result == false)
                {
                    Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                }
                else
                {
                    Screens.Info(string.Concat("İşlem tamamlandı ", res.Value));
                    wstation = null;
                    txtistasyon.Text = "";
                    txtaciklama.Text = "";
                    dateStart.Value = dateEnd.Value = DateTime.Now;
                    cmbvardiya.SelectedIndex = -1;
                    cmddurusneden.SelectedIndex = -1;
                    cmbpersonel.SelectedIndex = -1;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
