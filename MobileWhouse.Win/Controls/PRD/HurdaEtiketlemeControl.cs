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
using System.Diagnostics;
using MobileWhouse.Data;
using MobileWhouse.ProdConnector;
using MobileWhouse.Log;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD008", "MobileWhouse.Controls.PRD.HurdaEtiketlemeControl", "Hurda Etiketi Basma")]
    public partial class HurdaEtiketlemeControl : BaseControl
    {
        public HurdaEtiketlemeControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private invd_item item = null;
        private worder_ac_op selectedWorderAcop = null;

        private void GetProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_ac_op worder_acop = worder_ac_op.GetProducts(wstation.PrdGobalId);
                if (worder_acop != null)
                {
                    StringBuilder sbSqlString = new StringBuilder();
                    sbSqlString.AppendFormat(@"SELECT acop.worder_ac_op_id,acop.worder_m_id,wo.worder_no,wo.item_id,it.item_code,acop.unit_id,un.unit_code,
acop.worder_op_d_id,acop.operation_id,op.operation_code,acop.wstation_id,ws.wstation_code,acop.qty,acop.qty_total_scrap,acop.start_date,acop.end_date 
FROM prdt_worder_ac_op acop INNER JOIN 
prdt_worder_m wo ON acop.worder_m_id = wo.worder_m_id INNER JOIN 
invd_item it ON wo.item_id = it.item_id LEFT JOIN 
invd_unit un ON acop.unit_id = un.unit_id LEFT JOIN
prdd_wstation ws ON acop.wstation_id = ws.wstation_id LEFT JOIN
prdd_operation op ON acop.operation_id = op.operation_id
WHERE acop.co_id = '{0}' AND acop.branch_id = '{1}' AND acop.worder_m_id = '{2}' ",
                                                                                    ClientApplication.Instance.ClientToken.CoId,
                                                                                    ClientApplication.Instance.ClientToken.BranchId,
                                                                                    worder_acop.worder_m_id);

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
                            List<worder_ac_op> woacops = DataProvider.TableToList(res.Value, typeof(worder_ac_op)) as List<worder_ac_op>;
                            if (woacops != null && woacops.Count > 0)
                            {
                                for (int i = 0; i < woacops.Count; i++)
                                {
                                    ListViewItem item = new ListViewItem();
                                    item.Tag = woacops[i];
                                    item.Text = woacops[i].start_date.ToString("dd.MM.yyyy");
                                    item.SubItems.Add(woacops[i].qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                                    listView1.Items.Add(item);
                                }
                            }
                        }
                    }

                }
                else
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
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

        private void GetMaterials()
        {
            try
            {
                if (wstation == null) return;

                if (selectedWorderAcop == null) return;

                Cursor.Current = Cursors.WaitCursor;

                List<prdt_worder_bom_d> boms = prdt_worder_bom_d.GetWorderAcMaterials(selectedWorderAcop.worder_ac_op_id);
                if (boms != null && boms.Count > 0)
                {
                    cmbisemribilesen.DataSource = boms;
                    cmbisemribilesen.DisplayMember = "Aciklama";
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
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnistasyon_Click(object sender, EventArgs e)
        {
            using (FormSelectWstation frm = new FormSelectWstation())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                {
                    listView1.Items.Clear();
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                    GetProducts();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (i == listView1.SelectedIndices[0])
                    {
                        selectedWorderAcop = listView1.Items[listView1.SelectedIndices[0]].Tag as worder_ac_op;
                        listView1.Items[i].Checked = true;
                        GetMaterials();
                    }
                    else
                    {
                        listView1.Items[i].Checked = false;
                    }
                }
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                wstation = txtistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmedi!");
                    //btnistasyon_Click(btnistasyon, EventArgs.Empty);
                    return;
                }
                if (selectedWorderAcop == null)
                {
                    Screens.Error("Üretim seçilmedi! Listeden üretim kaydı seçin.");
                    return;
                }
                if (cmbhurdaneden.SelectedItem == null)
                {
                    Screens.Error("Hurda nedeni seçilmedi! Hurda nedeni seçin.");
                    cmbhurdaneden.Focus();
                    return;
                }
                if (cmbisemribilesen.SelectedItem == null)
                {
                    Screens.Error("İş emri bileşeni seçilmedi! İş emri bileşeni seçin.");
                    cmbisemribilesen.Focus();
                    return;
                }

                prdt_worder_bom_d bom = cmbisemribilesen.SelectedItem as prdt_worder_bom_d;
                DataRowView dr = cmbhurdaneden.SelectedItem as DataRowView;

                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;

                StringBuilder sb = new StringBuilder();
                sb.Append(@"INSERT INTO ""uyumsoft"".""zz_package_m"" (""create_user_id"",""create_date"",""worder_ac_op_id"",""worder_m_id"",""worder_op_d_id"",""operation_id"",")
                    .Append(@"""operation_no"",""item_id"",""unit_id"",""qty"",""whouse_id"",""is_scrapt"",""worder_ac_bom_m_id"",""worder_ac_bom_d_id"",""scrap_result_type"",""scrap_reason_id"",""diff_item_id"",""diff_unit_id"",""worder_ac_bom_d_line_no"") VALUES (");
                sb.AppendFormat("{0},CURRENT_TIMESTAMP,", ClientApplication.Instance.ClientToken.UserId)//"create_user_id","create_date"
                    .AppendFormat("{0},{1},", selectedWorderAcop.worder_ac_op_id, selectedWorderAcop.worder_m_id)//"worder_ac_op_id","worder_m_id"
                    .AppendFormat("{0},{1},{2},", selectedWorderAcop.worder_op_d_id, selectedWorderAcop.operation_id, selectedWorderAcop.operation_no)//"worder_op_d_id","operation_id","operation_no"
                    .AppendFormat("{0},{1},0,", bom.ITEM_ID, bom.UNIT_ID);//"item_id","unit_id","qty"

                if (dr != null && DBNull.Value != dr["SCRAP_IN_WHOUSE_ID"])
                    sb.AppendFormat("'{0}',", StringUtil.ToInteger(dr["SCRAP_IN_WHOUSE_ID"])); //"whouse_id"
                else
                    sb.AppendFormat("'{0}',", bom.WHOUSE_ID); //"whouse_id"

                sb.AppendFormat("1,{0},{1},2,{2},", bom.ITEM_BOM_M_ID, bom.WORDER_BOM_D_ID, StringUtil.ToInteger(cmbhurdaneden.SelectedValue)); //"is_scrapt","worder_ac_bom_d_id","scrap_result_type","scrap_reason_id"
                if (item != null)
                {
                    sb.AppendFormat(@"{0},{1},", item.item_id, item.unit_id);
                }
                else
                {
                    sb.Append(@"NULL,NULL,");
                }
                sb.Append(bom.LINE_NO).Append(")");

                sb.Append(@" RETURNING ""package_no"",""package_id"" ").ToString();

                Logger.I(param.Value);
                param.Value = sb.ToString();

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        //StringBuilder str = new StringBuilder();
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            if (printhurdaetiket.IsSelectPrinter)
                                printhurdaetiket.Print(string.Concat(" package_no = '", res.Value.Rows[0][0], "' "));
                            //str.AppendFormat("package_no:{0}{1}", res.Value.Rows[0][0], Environment.NewLine);
                            //str.AppendFormat("package_id:{0}{1}", res.Value.Rows[0][1], Environment.NewLine);
                        }
                        //Screens.Info(str.ToString());

                        cmbhurdaneden.SelectedIndex = -1;
                        cmbhurdaneden.Text = "";
                        cmbisemribilesen.SelectedIndex = -1;
                        cmbisemribilesen.Text = "";
                        txtstokkod.SetText("");
                        txtistasyon.SetText("");
                        listView1.Items.Clear();
                        //MainForm.ShowControl(new PRD.PrdControl());
                    }
                }

                /*ServiceRequestOfWorderAcOpInfo param = new ServiceRequestOfWorderAcOpInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new WorderAcOpInfo();
                param.Value.Id = selectedWorderAcop.worder_ac_op_id;
                param.Value.WorderOpDId = selectedWorderAcop.worder_op_d_id;
                param.Value.WorderMId = selectedWorderAcop.worder_m_id;
                param.Value.WorderScrapMaterialList = new WorderScrapMaterialInfo[1];
                param.Value.WorderScrapMaterialList[0] = new WorderScrapMaterialInfo();
                param.Value.WorderScrapMaterialList[0].ScrapReasonId = StringUtil.ToInteger(cmbhurdaneden.SelectedValue);
                param.Value.WorderScrapMaterialList[0].QtyScrap = Convert.ToDecimal(textMiktar.Text);
                param.Value.WorderScrapMaterialList[0].SourceBomMId = bom.ITEM_BOM_M_ID;
                param.Value.WorderScrapMaterialList[0].SourceItemId = bom.ITEM_ID;
                param.Value.WorderScrapMaterialList[0].UnitId = bom.UNIT_ID;
                param.Value.WorderScrapMaterialList[0].ScrapResultType = 2; //Mamul = 1,Malzeme = 2,FarkliKod = 3,YanUrun = 4,DemonteUrun = 5,TersUrun = 6
                param.Value.WorderScrapMaterialList[0].WorderBomDId = bom.WORDER_BOM_D_ID;
                param.Value.WorderScrapMaterialList[0].NoteLarge = "El terminalinden oluşturuldu";
                if (item != null)
                {
                    param.Value.WorderScrapMaterialList[0].DiffItemId = item.item_id;
                    param.Value.WorderScrapMaterialList[0].DiffUnitId = item.unit_id;
                }
                if (dr != null && DBNull.Value != dr["SCRAP_IN_WHOUSE_ID"])
                    param.Value.WorderScrapMaterialList[0].WhouseId = StringUtil.ToInteger(dr["SCRAP_IN_WHOUSE_ID"]);
                else
                    param.Value.WorderScrapMaterialList[0].WhouseId = bom.WHOUSE_ID;

                ServiceResultOfInt32 res = ClientApplication.Instance.ProdService.SaveWorderScrap(param);
                if (res.Result)
                {
                    MainForm.ShowControl(null);
                }
                else
                {
                    Screens.Error(res.Message);
                }*/
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtstokkod_OnSelected(object sender, object obj)
        {
            item = obj as invd_item;
        }

        private void txtistasyon_OnSelected(object sender, object obj)
        {
            wstation = txtistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
            listView1.Items.Clear();
            if (wstation != null) GetProducts();
        }
    }
}
