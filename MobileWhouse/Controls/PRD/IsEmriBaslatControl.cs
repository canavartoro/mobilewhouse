using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using System.Diagnostics;
using MobileWhouse.Models;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PRD
{
    public partial class IsEmriBaslatControl : BaseControl
    {
        public IsEmriBaslatControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private MobileWhouse.ProdConnector.WorderMInfo worderM = null;
        private MobileWhouse.ProdConnector.PrdGobalInfo employee = null;
        private worder_ac_op worder_acop = null;

        private void GetProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_acop = worder_ac_op.GetProducts(wstation.PrdGobalId);
                if (worder_acop != null)
                {
                    txtisemri.Text = string.Concat(worder_acop.worder_no, " ", worder_acop.qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                    txtstokkod.Text = string.Concat(worder_acop.item_code, " ", worder_acop.item_name);
                    btnbaslat.Text = "Bitir";
                    btnbaslat.NormalBtnColour = Color.FromArgb(255, 128, 128);
                    btnbaslat.NormalTxtColour = Color.Blue;
                    //btnbaslat2.Image = MobileWhouse.Properties.Resources.err;
                    GetEmployees();
                }
                else
                {
                    txtisemri.Text = "";
                    txtstokkod.Text = "";
                    //btnbaslat2.Image = MobileWhouse.Properties.Resources.ok;
                    btnbaslat.Text = "Başlat";
                    btnbaslat.NormalBtnColour = Color.FromArgb(192, 255, 192);
                    btnbaslat.NormalTxtColour = Color.Blue;
                    listpersonel.Items.Clear();
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

        private void GetEmployees()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT we.""worder_employee_id"",we.""line_no"",
we.""prd_employee_id"",CONCAT(emp.""emp_name"",' ', emp.""emp_surname"") ""fullname"",we.""status"",we.""start_date"" 
FROM ""uyumsoft"".""zz_worder_employee"" we LEFT JOIN ""uyumsoft"".""prdd_employee"" emp ON we.""prd_employee_id"" = emp.""prd_employee_id""
WHERE we.""worder_ac_op_id"" = {0} ", worder_acop.worder_ac_op_id);

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

                        listpersonel.BeginUpdate();
                        listpersonel.Items.Clear();
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            for (int i = 0; i < res.Value.Rows.Count; i++)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = res.Value.Rows[i][1].ToString();
                                item.SubItems.Add(res.Value.Rows[i][2].ToString());
                                item.SubItems.Add(res.Value.Rows[i][3].ToString());
                                item.ImageIndex = StringUtil.ToInteger(res.Value.Rows[i][4]);
                                item.Tag = res.Value.Rows[i];
                                listpersonel.Items.Add(item);
                            }
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
                listpersonel.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetWorderOpD()
        {
            try
            {
                if (wstation == null) return;
                if (worderM == null) return;

                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT opd.worder_op_d_id,opd.operation_id,opd.operation_no,opd.is_last_opr 
FROM prdt_worder_op_d opd INNER JOIN prdd_wstation_operation wsop ON opd.operation_id = wsop.operation_id 
WHERE worder_m_id = {0} AND wsop.wstation_id = {1} ", worderM.Id, wstation.PrdGobalId);

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
                            if (DBNull.Value != res.Value.Rows[0][0])
                                worderM.ProductRouteMId = StringUtil.ToInteger(res.Value.Rows[0][0]);
                            if (DBNull.Value != res.Value.Rows[0][1])
                                worderM.OperationId = StringUtil.ToInteger(res.Value.Rows[0][1]);
                            if (DBNull.Value != res.Value.Rows[0][2])
                                worderM.OperationNo = StringUtil.ToInteger(res.Value.Rows[0][2]);
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
                    btnbaslat.Enabled = true;
                    listpersonel.Items.Clear();
                    GetProducts();
                }
            }
        }

        private void btnisemri_Click(object sender, EventArgs e)
        {
            using (FormSelectWorder frm = new FormSelectWorder())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.WorderM != null)
                {
                    worderM = frm.WorderM;
                    txtisemri.Text = string.Concat(worderM.WorderNo, " ", worderM.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                    txtstokkod.Text = string.Concat(worderM.ItemCode, " ", worderM.ItemName);
                    GetWorderOpD();
                }
            }
        }

        private void txtstokkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnpersonel_Click(object sender, EventArgs e)
        {
            if (wstation == null)
            {
                Screens.Error("Önce iş istasyonu seçilmelidir!");
                btnistasyon_Click(btnistasyon, EventArgs.Empty);
                return;
            }

            using (FormSelectEmployee frm = new FormSelectEmployee())
            {
                frm.WstationId = wstation.PrdGobalId;
                if (frm.ShowDialog() == DialogResult.OK && frm.Employee != null)
                {
                    employee = frm.Employee;
                    txtpersonel.Text = string.Concat(employee.PrdGobalCode2, " ", employee.PrdGobalName, " ", employee.PrdGobalName2);
                }
            }
        }

        private void btnbaslat_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                if (btnbaslat.Text == "Başlat")
                {
                    sbSqlString.AppendFormat("UPDATE \"uyumsoft\".\"zz_worder_ac_op\" SET \"is_closed\" = 1 WHERE \"wstation_id\" = {0};", wstation.PrdGobalId);
                    sbSqlString.Append("INSERT INTO \"uyumsoft\".\"zz_worder_ac_op\" (\"create_user_id\",\"create_date\",\"worder_m_id\",\"item_id\",\"qty\",\"qty_net\",\"unit_id\",\"worder_op_d_id\",\"operation_id\",\"operation_no\",\"wstation_id\",\"start_date\",\"shifts_id\") VALUES (");
                    sbSqlString.AppendFormat("'{0}',", ClientApplication.Instance.ClientToken.UserId);
                    sbSqlString.AppendFormat("CURRENT_TIMESTAMP,'{0}','{1}','{2:0.#####}','0','{3}',", worderM.Id, worderM.ItemId, worderM.Qty, worderM.UnitId);
                    sbSqlString.AppendFormat("'{0}','{1}','{2}',", worderM.ProductRouteMId, worderM.OperationId, worderM.OperationNo);
                    sbSqlString.AppendFormat("'{0}',CURRENT_TIMESTAMP,'{1}')", wstation.PrdGobalId, 1);
                    sbSqlString.Append(" RETURNING \"worder_ac_op_id\"");
                }
                else
                {
                    sbSqlString.AppendFormat("UPDATE \"uyumsoft\".\"zz_worder_ac_op\" SET \"is_closed\" = 1,\"end_date\" = CURRENT_TIMESTAMP WHERE \"wstation_id\" = {0};", wstation.PrdGobalId);
                }

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
                            GetProducts();
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
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (worder_acop == null)
                {
                    Screens.Error("İstasyon başlatılmış üretim bulunamadı!");
                    return;
                }
                if (employee == null)
                {
                    Screens.Error("Personel seçilmelidir!");
                    btnpersonel_Click(btnpersonel, EventArgs.Empty);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                int lineNo = (listpersonel.Items.Count + 1) * 10;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.Append("INSERT INTO \"uyumsoft\".\"zz_worder_employee\" (\"create_user_id\",\"create_date\",\"worder_ac_op_id\",\"line_no\",\"prd_employee_id\",\"start_date\") VALUES (");
                sbSqlString.AppendFormat("'{0}',CURRENT_TIMESTAMP,'{1}','{2}','{3}',CURRENT_TIMESTAMP)", ClientApplication.Instance.ClientToken.UserId, worder_acop.worder_ac_op_id, lineNo, employee.PrdGobalId);
                sbSqlString.Append(" RETURNING \"worder_employee_id\"");

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
                            txtpersonel.Text = "";
                            employee = null;
                            GetEmployees();
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
        }

        private void btncikart_Click(object sender, EventArgs e)
        {
            try
            {
                if (listpersonel.SelectedIndices.Count == 0)
                {
                    Screens.Error("Personel listesinden çıkartmak istediğiniz personeli seçin ve tekrar deneyin!");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                int worder_employee_id = 0;
                DataRow rw = listpersonel.Items[listpersonel.SelectedIndices[0]].Tag as DataRow;
                worder_employee_id = StringUtil.ToInteger(rw[0]);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new StringBuilder().Append(@"UPDATE ""uyumsoft"".""zz_worder_employee"" SET ""status"" = 1,""update_user_id"" = '")
                    .Append(ClientApplication.Instance.ClientToken.UserId)
                    .Append(@"',""update_date"" = CURRENT_TIMESTAMP, ""end_date"" = CURRENT_TIMESTAMP, ")
                    .Append(@" ""op_duration"" = (EXTRACT(EPOCH FROM CURRENT_TIMESTAMP) - EXTRACT(EPOCH FROM ""start_date"")) / 60 ")
                    .Append(@" WHERE ""worder_employee_id"" = ")
                    .Append(worder_employee_id).ToString();
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
                        if (res.Value != null)
                        {
                            txtpersonel.Text = "";
                            employee = null;
                            GetEmployees();
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
        }
    }
}
