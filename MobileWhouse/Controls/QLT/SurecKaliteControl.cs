using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Models;
using MobileWhouse.Util;
using MobileWhouse.Enums;
using MobileWhouse.Log;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.QLT
{
    [UyumModule("QLT001", "MobileWhouse.Controls.QLT.SurecKaliteControl", "Kalite Onay")]
    public partial class SurecKaliteControl : BaseControl
    {
        public SurecKaliteControl()
        {
            InitializeComponent();
            cmbkontrol.SelectedIndex = -1;
        }

        private EmployeeLogin operatorLogin = new EmployeeLogin();
        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private worder_ac_op worder_acop = null;
        private worder_ac_op worder_acopBreak = null;

        private void GetProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_acop = worder_ac_op.GetProducts(wstation.PrdGobalId);
                if (worder_acop != null)
                {
                    txtisemri.Text = worder_acop.worder_no;
                    lblstokad.Text = string.Concat(worder_acop.item_code, " ", worder_acop.item_name);
                }
                else
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                GetBreakProducts();
            }
        }

        private void GetBreakProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_acopBreak = worder_ac_op.GetProductWithBreak(wstation.PrdGobalId);
                if (worder_acopBreak == null)
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetControlPoints()
        {
            try
            {
                if (cmbkontrol.SelectedValue == null) return;

                Cursor.Current = Cursors.WaitCursor;

                List<control_group_point> controlpoints = control_group_point.GetPoints(Convert.ToInt32(cmbkontrol.SelectedValue));
                if (worder_acop != null)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    for (int i = 0; i < controlpoints.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = 0;
                        item.Tag = controlpoints[i];
                        item.Text = controlpoints[i].control_point_code;
                        item.SubItems.Add(controlpoints[i].control_point_desc);
                        item.SubItems.Add("");
                        item.SubItems.Add(controlpoints[i].min_point_qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(controlpoints[i].max_point_qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    Screens.Error("Kalite ölçüm noktaları bulunamadı!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                listView1.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new QLT.QLTControl());
        }

        private void btnistasyon_Click(object sender, EventArgs e)
        {
            using (FormSelectWstation frm = new FormSelectWstation())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                {
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                    cmbkontrol.SelectedIndexChanged += new System.EventHandler(this.cmbkontrol_SelectedIndexChanged);
                    GetProducts();
                }
            }
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbkontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbkontrol.SelectedValue != null && cmbkontrol.SelectedValue is System.Int32)
            {
                GetControlPoints();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                control_group_point point = listView1.Items[listView1.SelectedIndices[0]].Tag as control_group_point;
                lblbilgi.Text = string.Concat(point.control_point_desc, " Min:", point.min_point_qty, ", Max:", point.max_point_qty);
                if (point.point_type == 1)
                {
                    rdred.Visible =
                    rdok.Visible = true;
                    rdred.Checked =
                    rdok.Checked = false;
                    txtDeger.Visible = false;
                    txtDeger.Text = "";
                }
                else
                {
                    rdred.Visible =
                    rdok.Visible = false;
                    rdred.Checked =
                    rdok.Checked = false;
                    txtDeger.Visible = true;
                    txtDeger.Text = "";
                    txtDeger.Focus();
                }

            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count > 0)
                {
                    int index = listView1.SelectedIndices[0];
                    int imgindex = 0;
                    control_group_point point = listView1.Items[listView1.SelectedIndices[0]].Tag as control_group_point;
                    point.control_qty = txtDeger.DecimalValue;
                    point.control_result = rdok.Checked;
                    string resp = "";
                    if (point.point_type == 1)
                    {
                        if (rdok.Checked == false && rdred.Checked == false)
                        {
                            Screens.Warning("Kabul/Red seçilmelidir!!!");
                            return;
                        }
                        if (rdok.Checked)
                        {
                            resp = "√";
                            imgindex = 1;
                        }
                        else
                        {
                            resp = "Χ";
                            imgindex = 2;
                        }
                    }
                    else
                    {
                        resp = point.control_qty.ToString(Statics.DECIMAL_STRING_FORMAT);
                        if (point.control_qty > point.max_point_qty || point.control_qty < point.min_point_qty)
                            imgindex = 2;
                        else
                            imgindex = 1;
                    }
                    listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text = resp;
                    listView1.Items[listView1.SelectedIndices[0]].ImageIndex = imgindex;
                    index++;
                    if (index > listView1.Items.Count - 1) index = 0;
                    listView1.Focus();
                    for (int l = 0; l < listView1.Items.Count; l++) if (l != index) listView1.Items[l].Selected = false;
                    listView1.Items[index].Selected = true;
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {

                if (!operatorLogin.Login()) return;
                if (!operatorLogin.Operator.qlt001)
                {
                    Screens.Error("Bu işlem için yetkiniz yok!");
                    return;
                }

                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmedi!");
                    return;
                }
                if (worder_acop == null)
                {
                    Screens.Error("Üretim bilgisi yok!");
                    return;
                }
                if (listView1.Items.Count == 0)
                {
                    Screens.Error("Ölçüm listesi boş olamaz!");
                    return;
                }
                if (cmbkontrol.SelectedItem == null)
                {
                    Screens.Error("Kontrol grubu seçikmedi!");
                    return;
                }

                Screens.ShowWait();

                PqcMaster pqc = new PqcMaster();
                pqc.CoId = ClientApplication.Instance.ClientToken.CoId;
                pqc.BranchId = ClientApplication.Instance.ClientToken.BranchId;
                pqc.MeasurementOk = true;
                pqc.ControlQty = txtmiktar.DecimalValue;
                pqc.ControlReason = ControlReason.ÜretimBaşlangıcı;
                pqc.ControlType = ControlType.SıkıKontrol;
                pqc.OpenClose = ActionState.Açık;
                pqc.ControlUserId = ClientApplication.Instance.ClientToken.UserId;
                pqc.AfterMinute = operatorLogin.Operator.prd_employee_id;
                pqc.Description4 = string.Concat(cmbkontrol.Text, ":", operatorLogin.Operator.emp_name, " ", operatorLogin.Operator.emp_surname, ":", textaciklama.Text);
                //pqc.CaliberCode = cmbkontrol.Text;
                pqc.Humidity = 0;
                pqc.ItemId = worder_acop.item_id;
                pqc.ItemCode = worder_acop.item_code;
                pqc.UnitId = worder_acop.unit_id;
                pqc.OperationId = worder_acop.operation_id;
                pqc.OperationNo = worder_acop.operation_no;
                pqc.WorderMId = worder_acop.worder_m_id;
                //pqc.BomMId = 1190;
                //pqc.AlternativeNo = "AL.0001";
                pqc.Name = operatorLogin.Operator.emp_name;
                pqc.Surname = operatorLogin.Operator.emp_surname;
                //pqc.UseMan2 = true;
                pqc.PqcDate = DateTime.Today;
                pqc.PqcNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                pqc.MeasurementTime = DateTime.Now.ToString("HH:mm");
                pqc.UyumDetailItem = new List<PqcDetail>();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    control_group_point point = listView1.Items[i].Tag as control_group_point;
                    PqcDetail detail = new PqcDetail();
                    detail.ControlPointCode = point.control_point_code;
                    detail.ControlPointId = point.control_point_id;
                    detail.MaxPointQty = point.max_point_qty;
                    detail.MinPointQty = point.min_point_qty;
                    detail.PointQty = point.control_qty;
                    detail.PointResult = point.control_result == true ? 1 : 2;
                    detail.SampleNo = (i + 1) * 10;
                    detail.LineNo = (i + 1) * 10;
                    detail.UtoleranceQty = point.utolerance_qty;
                    detail.DtoleranceQty = point.dtolerance_qty;
                    pqc.UyumDetailItem.Add(detail);
                }

                MobileWhouse.UyumWebService.UyumServiceResponseOfString res = ClientApplication.Instance.SaveWebService(pqc);
                if (res.Success == false)
                {
                    Screens.Error(res.Message);
                }
                else
                {
                    PqcMaster pqcmaster = (PqcMaster)BaseModel.FromXml(typeof(PqcMaster), res.Value);
                    Screens.Info(string.Concat("Belge kaydedildi! Id:", pqcmaster.Id, ", Belge No:", pqcmaster.PqcNo));
                    UpdateWorderAcOp(pqcmaster.Id);
                    cmbkontrol.SelectedIndex = -1;
                    listView1.Items.Clear();
                    wstation = null;
                    worder_acop = null;
                    txtistasyon.Text = "";
                    txtisemri.Text = "";
                    txtmiktar.Text = "1";
                    lblstokad.Text = "";
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

        private void UpdateWorderAcOp(int id)
        {
            try
            {
                if (worder_acop == null) return;



                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Format("UPDATE uyumsoft.zz_worder_ac_op SET update_date = CURRENT_TIMESTAMP,update_user_id = '{0}',quality_id='{1}',is_approved=1,is_break=0,worder_break_id = NULL WHERE worder_ac_op_id = {2}",
                    ClientApplication.Instance.ClientToken.UserId, id, worder_acop.worder_ac_op_id);
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
                        if (worder_acopBreak != null)
                        {
                            param.Value = string.Format("UPDATE uyumsoft.zz_worder_ac_op SET update_date = CURRENT_TIMESTAMP,update_user_id = '{0}',is_break=0 WHERE worder_ac_op_id = {1}",
                                ClientApplication.Instance.ClientToken.UserId, worder_acopBreak.worder_ac_op_id);
                            Logger.I(param.Value);
                            res = ClientApplication.Instance.Service.ExecuteSQL(param);
                            if (res.Result == false)
                            {
                                MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            }

                            param.Value = string.Concat("UPDATE prdd_free_break_worder SET update_date = CURRENT_TIMESTAMP,end_date = CURRENT_TIMESTAMP,net_time = (EXTRACT(EPOCH FROM NOW()::TIMESTAMP) - EXTRACT(EPOCH FROM start_date::TIMESTAMP)) / 60,description = '",
                                                        operatorLogin.Operator.citizenship_no, "' WHERE free_break_worder_id = ", worder_acopBreak.worder_break_id);
                            Logger.I(param.Value);
                            res = ClientApplication.Instance.Service.ExecuteSQL(param);
                            if (res.Result == false)
                            {
                                MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void txtistasyon_OnSelected(object sender, object obj)
        {
            wstation = obj as MobileWhouse.ProdConnector.PrdGobalInfo;
            if (wstation != null)
            {
                txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                cmbkontrol.SelectedIndexChanged += new System.EventHandler(this.cmbkontrol_SelectedIndexChanged);
                GetProducts();
            }
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textaciklama);
        }
    }
}
