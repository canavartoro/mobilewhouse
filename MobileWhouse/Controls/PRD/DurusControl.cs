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
using MobileWhouse.Models;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    //http://10.0.0.250:400/GeneralCard.aspx?CommandName=PrdFreeBreakWorderCollection.New&ObjectId=0&WinId=11
    [UyumModule("PRD007", "MobileWhouse.Controls.PRD.DurusControl", "Duruş Tanımlama")]
    public partial class DurusControl : BaseControl
    {
        public DurusControl()
        {
            InitializeComponent();
        }

        private void GetProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_acop = worder_ac_op.GetProducts(wstation.PrdGobalId);
                if (worder_acop != null)
                {
                    if (worder_acop.is_break == 1)
                    {
                        Screens.Error("İstasyon duruşta!");
                        worder_acop = null;
                    }
                }
                else
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }
                if (worder_acop != null && worder_acop.is_break == 1)
                {
                    Screens.Error("İstasyon duruşta!");
                    worder_acop = null;
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

        private bool UpdProducts(int worder_break_id)
        {
            try
            {
                if (wstation == null) return false;
                if (worder_acop == null) return false;

                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat("UPDATE zz_worder_ac_op SET is_break = 1, is_approved = 0, worder_break_id = '",
                    worder_break_id, "' , update_user_id = '", ClientApplication.Instance.ClientToken.UserId,
                    "', update_date = CURRENT_TIMESTAMP WHERE worder_ac_op_id = '", worder_acop.worder_ac_op_id, "'");
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                        return false;
                    }
                    else
                    {
                        return true;
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
            return false;
        }

        private worder_ac_op worder_acop = null;
        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private EmployeeLogin operatorLogin = new EmployeeLogin();

        private int GetLineNo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT COUNT(*) t FROM PRDD_FREE_BREAK_WORDER WHERE co_id = '{0}' AND shifts_id = '{1}' ",
                    ClientApplication.Instance.ClientToken.CoId, StringUtil.ToInteger(cmbvardiya.SelectedValue));

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
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            return (StringUtil.ToInteger(res.Value.Rows[0][0]) + 1) * 10;
                        }
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
            return 10;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void DurusControl_OnLoad(object sender, EventArgs e)
        {
        }

        private void btntamam_Click(object sender, EventArgs e)
        {
            try
            {
                //int calendarTypeId = 0;
                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmelidir!");
                    return;
                }
                if (worder_acop == null)
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
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

                if (!operatorLogin.Login()) return;

                Cursor.Current = Cursors.WaitCursor;

                FreeBreakWorder durus = new FreeBreakWorder();
                durus.CoId = ClientApplication.Instance.ClientToken.CoId;
                durus.BranchId = ClientApplication.Instance.ClientToken.BranchId;
                durus.StartDate = dateStart.Value;
                durus.EndDate = dateEnd.Value;
                durus.NetTime = Convert.ToInt32(dateEnd.Value.Subtract(dateStart.Value).TotalMinutes);
                durus.ShiftsId = StringUtil.ToInteger(cmbvardiya.SelectedValue);
                durus.BreakReasonId = StringUtil.ToInteger(cmddurusneden.SelectedValue);
                if (cmbpersonel.SelectedItem != null)
                    durus.PrdEmployeeId = StringUtil.ToInteger(cmbpersonel.SelectedValue);
                durus.WstationId = wstation.PrdGobalId;
                durus.WstationCode = wstation.PrdGobalCode;
                durus.NoteLarge1 = operatorLogin.Operator.citizenship_no;
                durus.NoteLarge2 = txtaciklama.Text;
                durus.LineNo = GetLineNo();

                FreeBreakWorder dur = ClientApplication.Instance.SaveWebService(durus, typeof(FreeBreakWorder)) as FreeBreakWorder;
                if (dur != null && UpdProducts(dur.Id))
                {
                    Screens.Info(string.Concat("İşlem tamamlandı ", dur.Id));

                    txtistasyon.SetText("");
                    cmddurusneden.Text = "";
                    cmddurusneden.SelectedIndex = -1;
                    cmbvardiya.Text = "";
                    cmbvardiya.SelectedIndex = -1;
                    cmbpersonel.SelectedIndex = -1;
                    cmbpersonel.Text = "";
                    txtaciklama.Text = "";
                    dateStart.Value = DateTime.Now;
                    dateEnd.Value = DateTime.Now;

                    //MainForm.ShowControl(new PRD.PrdControl());
                    //wstation = null;
                    //worder_acop = null;
                    //txtistasyon.Text = "";
                    //txtaciklama.Text = "";
                    //dateStart.Value = dateEnd.Value = DateTime.Now;
                    //cmbvardiya.SelectedIndex = -1;
                    //cmbvardiya.Text = "";
                    //cmddurusneden.SelectedIndex = -1;
                    //cmddurusneden.Text = "";
                    //cmbpersonel.SelectedIndex = -1;
                    //cmbpersonel.Text = "";
                }

                //ServiceRequestOfFreeBreakInf param = new ServiceRequestOfFreeBreakInf();
                //param.Token = ClientApplication.Instance.ProdToken;
                //param.Value = new FreeBreakInf();
                //param.Value.StartDate = dateStart.Value;
                //param.Value.EndDate = dateEnd.Value;
                //param.Value.ShiftId = StringUtil.ToInteger(cmbvardiya.SelectedValue);
                //param.Value.CalendarTypeId = calendarTypeId;
                //param.Value.BreakReasonId = StringUtil.ToInteger(cmddurusneden.SelectedValue);
                //if (cmbpersonel.SelectedItem != null)
                //    param.Value.EmployeeId = StringUtil.ToInteger(cmbpersonel.SelectedValue);
                //param.Value.WstationId = wstation.PrdGobalId;
                //param.Value.WstationCode = wstation.PrdGobalCode;
                //param.Value.NoteLarge1 = txtaciklama.Text;

                //ServiceResultOfInt32 res = ClientApplication.Instance.ProdService.SaveFreeBreakWorder(param);

                //if (res.Result == false)
                //{
                //    Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                //}
                //else
                //{
                //    Screens.Info(string.Concat("İşlem tamamlandı ", res.Value));
                //    wstation = null;
                //    txtistasyon.Text = "";
                //    txtaciklama.Text = "";
                //    dateStart.Value = dateEnd.Value = DateTime.Now;
                //    cmbvardiya.SelectedIndex = -1;
                //    cmddurusneden.SelectedIndex = -1;
                //    cmbpersonel.SelectedIndex = -1;
                //}
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

        private void txtistasyon_OnSelected(object sender, object obj)
        {
            wstation = obj as MobileWhouse.ProdConnector.PrdGobalInfo;
            GetProducts();
        }

    }
}
