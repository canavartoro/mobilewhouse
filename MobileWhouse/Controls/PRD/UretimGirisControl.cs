using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Models;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using System.Diagnostics;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PRD
{
    public partial class UretimGirisControl : BaseControl
    {
        public UretimGirisControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
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
                    txtisemri.Text = string.Concat(worder_acop.worder_no, " ", worder_acop.item_code);
                    btnkaydet.Enabled = true;
                    txtbarkod.Focus();
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

        private void ClearForm()
        {
            wstation = null;
            worder_acop = null;
            txtistasyon.Text = "";
            txtisemri.Text = "";
            listView1.Items.Clear();
            lblbilgi.Text = "";
        }

        private void GetPackage()
        {
            try
            {
                if (wstation == null)
                {
                    Screens.Error("İş istasyonu seçilmelidir!");
                    return;
                }

                if (worder_acop == null)
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }
                if (string.IsNullOrEmpty(txtbarkod.Text))
                {
                    txtbarkod.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT pkg.package_id,pkg.palette_no,pkg.worder_ac_op_id,pkg.operation_id,pkg.operation_no,pkg.package_no,pkg.item_id,it.item_code,it.item_name,
pkg.unit_id,un.unit_code,pkg.qty,pkg.worder_m_id,pkg.worder_op_d_id,wm.worder_no,pkg.whouse_id,wh.whouse_code,wh.description whouse_desc,pkg.create_date,pkg.is_closed,pkg.is_created  
FROM uyumsoft.zz_package_m pkg LEFT JOIN invd_item it ON pkg.item_id = it.item_id LEFT JOIN 
invd_unit un ON pkg.unit_id = un.unit_id LEFT JOIN prdt_worder_m wm ON pkg.worder_m_id = wm.worder_m_id LEFT JOIN 
invd_whouse wh ON pkg.whouse_id = wh.whouse_id
WHERE pkg.package_no = '{0}' ", txtbarkod.Text.Replace("'", "`"));

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
                            package_m package = new package_m(res.Value.Rows[0]);
                            if (chksil.Checked)
                            {
                                bool finded = false;
                                if (listView1.Items.Count > 0)
                                {
                                    for (int i = 0; i < listView1.Items.Count; i++)
                                    {
                                        if (listView1.Items[i].SubItems[3].Text == package.package_no)
                                        {
                                            finded = true;
                                            listView1.Items.RemoveAt(i);
                                            worder_acop.qty_net -= package.qty;
                                        }
                                    }
                                }
                                if (!finded)
                                {
                                    Screens.Error("Okutulan barkod listede bulunamadı!");
                                    return;
                                }
                            }
                            else
                            {
                                if (package.is_created)
                                {
                                    Screens.Error("Okutulan barkod paletlenmiş! " + package.palette_no);
                                    return;
                                }
                                for (int i = 0; i < listView1.Items.Count; i++)
                                {
                                    if (listView1.Items[i].SubItems[3].Text == package.package_no)
                                    {
                                        Screens.Error(string.Concat(package.package_no, " daha önce okutulmuş!"));
                                        return;
                                    }
                                }

                                listView1.BeginUpdate();
                                ListViewItem item = new ListViewItem();
                                item.Text = package.item_code;
                                item.SubItems.Add(package.item_name);
                                item.SubItems.Add(package.qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                                item.SubItems.Add(package.package_no);
                                item.ImageIndex = 0;
                                item.Tag = package;
                                listView1.Items.Add(item);
                                worder_acop.qty_net += package.qty;
                            }
                            lblbilgi.Text = string.Concat(listView1.Items.Count, " x ", worder_acop.qty_net.ToString(Statics.DECIMAL_STRING_FORMAT));
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
                listView1.EndUpdate();
                Cursor.Current = Cursors.Default;
                txtbarkod.Text = "";
                txtbarkod.Focus();
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
                    listView1.Items.Clear();
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                    GetProducts();
                }
            }
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) GetPackage();
        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            GetPackage();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (worder_acop == null)
                {
                    Screens.Error("Üretim bilgisi bulunamadı!");
                    return;
                }
                if (listView1.Items.Count == 0)
                {
                    Screens.Error("Koli barkodları okutulmalıdır!");
                    return;
                }

                Screens.ShowWait();

                List<worder_ac_op> worderacops = new List<worder_ac_op>();

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    package_m package = listView1.Items[i].Tag as package_m;
                    if (package != null)
                    {
                        worder_ac_op acop = null;
                        int acopindex = worderacops.FindIndex(x => x.worder_m_id == package.worder_m_id);
                        if (acopindex == -1)
                        {
                            acop = new worder_ac_op(package);
                            acop.GetEmployee();
                        }
                        else
                        {
                            acop = worderacops[acopindex];
                        }
                        acop.create_date = package.create_date;
                        acop.qty_net += package.qty;
                        acop.Packages.Add(package);
                        if (acopindex == -1) worderacops.Add(acop);
                    }
                }

                for (int i = 0; i < worderacops.Count; i++)
                {
                    MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef context = new MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef();
                    context.Token = new MobileWhouse.UyumSave.UyumToken();
                    context.Token.Password = ClientApplication.Instance.Token.Password;
                    context.Token.UserName = ClientApplication.Instance.Token.UserName;
                    context.Value = new MobileWhouse.UyumSave.PrdWorderDef();
                    context.Value.StartDate = worderacops[i].start_date.Date;
                    context.Value.EndDate = worderacops[i].create_date.Date;
                    context.Value.WorderMId = worderacops[i].worder_m_id;
                    context.Value.WorderOpDId = worderacops[i].worder_op_d_id;
                    context.Value.IsUseSendMaterialList = false;
                    context.Value.ScrapQty = 0;
                    context.Value.WstationId = wstation.PrdGobalId;
                    context.Value.Qty = worderacops[i].qty_net;
                    context.Value.UnitId = worderacops[i].unit_id;
                    if (worderacops[i].Employee != null && worderacops[i].Employee.Count > 0)
                    {
                        context.Value.WorderEmployeeList = new MobileWhouse.UyumSave.WorderEmployeeFields[worderacops[i].Employee.Count];
                        for (int l = 0; l < worderacops[i].Employee.Count; l++)
                        {
                            context.Value.WorderEmployeeList[l] = new MobileWhouse.UyumSave.WorderEmployeeFields();
                            context.Value.WorderEmployeeList[l].PrdEmployeeId = worderacops[i].Employee[l].prd_employee_id;
                            context.Value.WorderEmployeeList[l].StartDate = worderacops[i].start_date.Date;
                            context.Value.WorderEmployeeList[l].EndDate = worderacops[i].create_date.Date;
                        }
                    }

                    MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                    if (result.Result)
                    {
                        MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo();
                        param.Token = ClientApplication.Instance.ProdToken;
                        param.Value = new MobileWhouse.ProdConnector.PackageTraMInfo();
                        param.Value.Whouse2Id = ClientApplication.Instance.SelectedDepot.Id;
                        param.Value.WhouseId = wstation.PrdGobalId4;
                        param.Value.DocDate = worderacops[i].start_date.Date;

                        param.Value.SourceMId = StringUtil.ToInteger(result.Message);

                        param.Value.Details = new MobileWhouse.ProdConnector.PackageTraDInfo[worderacops[i].Packages.Count];
                        string[] ids = new string[worderacops[i].Packages.Count];
                        for (int loop = 0; loop < worderacops[i].Packages.Count; loop++)
                        {
                            ids[loop] = worderacops[i].Packages[loop].package_id.ToString();
                            param.Value.Details[loop] = new MobileWhouse.ProdConnector.PackageTraDInfo();
                            param.Value.Details[loop].ItemId = worderacops[i].Packages[loop].item_id;
                            param.Value.Details[loop].PackageMNo = worderacops[i].Packages[loop].package_no;
                            param.Value.Details[loop].Qty = worderacops[i].Packages[loop].qty;
                            param.Value.Details[loop].UnitId = worderacops[i].Packages[loop].unit_id;
                            param.Value.Details[loop].SourceMId = param.Value.SourceMId;
                            //param.Value.Details[loop].SourceDId = worderacops[i].Packages[loop].worder_m_id;
                        }

                        MobileWhouse.ProdConnector.ServiceResultOfPackageTraDInfo res = ClientApplication.Instance.ProdService.SavePackageTraM(param);
                        if (res.Result)
                        {
                            if (uretimgirisprint.IsSelectPrinter)
                                uretimgirisprint.Print(12000006, "rpp_prd_9010", "ItemMId", res.Value.PackageMId);

                            StringBuilder sbSqlString = new StringBuilder();
                            sbSqlString.AppendFormat(@"UPDATE zz_package_m SET package_tra_m_id = {0}, palette_no = '{1}', is_created = 1  ", res.Value.PackageMId, res.Value.PackageMNo);
                            sbSqlString.AppendFormat("WHERE package_id IN ({0})", string.Join(",", ids));

                            MobileWhouse.UyumConnector.ServiceRequestOfString paramsql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                            paramsql.Token = ClientApplication.Instance.Token;
                            paramsql.Value = sbSqlString.ToString();
                            Logger.I(paramsql.Value);
                            ClientApplication.Instance.Service.ExecuteSQL(paramsql);
                            ClearForm();
                        }
                        else
                        {
                            Screens.Error(res.Message);
                        }
                    }
                    else
                    {
                        Screens.Error(result.Message);
                    }
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
    }
}
