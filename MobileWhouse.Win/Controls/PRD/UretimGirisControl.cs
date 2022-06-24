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
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD006", "MobileWhouse.Controls.PRD.UretimGirisControl", "Palet Oluşturma")]
    public partial class UretimGirisControl : BaseControl
    {
        public UretimGirisControl()
        {
            InitializeComponent();
        }

        private int item_id = 0;
        private worder_ac_op worder_acop = null;
        private MobileParameter mobileParam = null;
        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;

        private void ClearForm()
        {
            //txtistasyon.Text = "";
            listView1.Items.Clear();
            //lblbilgi.Text = "";
            item_id = 0;
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
                    lblIsEmri.Text = string.Concat(worder_acop.worder_no, " ", worder_acop.item_code, " ", worder_acop.item_name, " ", worder_acop.density.ToString(Statics.DECIMAL_STRING_FORMAT));
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

        private void GetPackage()
        {
            try
            {
                if (string.IsNullOrEmpty(txtbarkod.Text))
                {
                    txtbarkod.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                package_m package = package_m.GetPackage(txtbarkod.Text);
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
                    if (item_id == 0) item_id = package.item_id;
                    if (item_id != package.item_id)
                    {
                        Screens.Error("Farklı stok okutuldu! Palet İÇİN okutulan barkodlar hep aynı iş stok olmalı");
                        return;
                    }

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
                }
                lblbilgi.Text = string.Concat(listView1.Items.Count);
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
            MainForm.ShowControl(new PRD.PrdControl());
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
                btnkaydet.Enabled = false;
                string worder_no = "";
                MobileWhouse.ProdConnector.PrdGobalInfo wstation = secistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmedi!");
                    return;
                }

                if (listView1.Items.Count == 0)
                {
                    Screens.Error("Koli barkodları okutulmalıdır!");
                    return;
                }

                if (mobileParam == null)
                {
                    Screens.Error("Mobil parametreler bulunamadı!");
                    return;
                }
                if (string.IsNullOrEmpty(mobileParam.palet_profix))
                {
                    Screens.Error("Mobil parametreler Palet Prefix tanımlı değil!");
                    return;
                }

                Screens.ShowWait();

                string[] ids = new string[listView1.Items.Count];
                MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new MobileWhouse.ProdConnector.PackageTraMInfo();
                param.Value.SourceApp = 80;
                param.Value.CreatePalet = true;
                param.Value.Whouse2Id = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.Details = new MobileWhouse.ProdConnector.PackageTraDInfo[listView1.Items.Count];
                decimal qty_net = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    package_m package = listView1.Items[i].Tag as package_m;
                    worder_no = package.worder_no;

                    #region Uretim Kaydi
                    if (!package.is_real)
                    {
                        //if (!Screens.Question(string.Concat(package.package_no, " nolu barkod üretilmemiş. Üretilsin mi?")))
                        //{
                        //    Screens.Error("Okutulan barkod üretilmemiş! " + package.package_no);
                        //    return;
                        //}

                        MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef context = new MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef();
                        context.Token = new MobileWhouse.UyumSave.UyumToken();
                        context.Token.Password = ClientApplication.Instance.Token.Password;
                        context.Token.UserName = ClientApplication.Instance.Token.UserName;
                        context.Value = new MobileWhouse.UyumSave.PrdWorderDef();
                        context.Value.StartDate = package.create_date.Date;
                        context.Value.EndDate = DateTime.Now.Date;
                        context.Value.WorderMId = package.worder_m_id;
                        context.Value.WorderOpDId = package.worder_op_d_id;
                        context.Value.IsUseSendMaterialList = false;
                        context.Value.ScrapQty = 0;
                        context.Value.WstationId = package.wstation_id > 0 ? package.wstation_id : wstation.PrdGobalId;
                        context.Value.Qty = package.qty;
                        context.Value.UnitId = package.unit_id;
                        context.Value.Note = package.package_no;
                        context.Value.PrdSourceApp = Statics.OPERASYONELURETIMGIRIS;
                        context.Value.PrdSourceApp2 = Statics.ELTERMINALIURETIMGIRISI;

                        MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                        if (!result.Result)
                        {
                            Screens.Error(result.Message);
                            return;
                        }
                        else
                        {
                            package.erp_worder_ac_op_id = StringUtil.ToInteger(result.Message);
                            package_m.UpdatePackage(package, package.erp_worder_ac_op_id);
                        }
                    }// üretim sonu 
                    #endregion

                    if (i == 0)
                    {
                        param.Value.SourceMId = package.erp_worder_ac_op_id;
                    }

                    qty_net += package.qty;
                    param.Value.DocDate = package.create_date.Date;

                    ids[i] = package.package_id.ToString();

                    param.Value.Details[i] = new MobileWhouse.ProdConnector.PackageTraDInfo();
                    param.Value.Details[i].ItemId = package.item_id;
                    param.Value.Details[i].PackageMNo = package.package_no;
                    param.Value.Details[i].Qty = package.qty;
                    param.Value.Details[i].UnitId = package.unit_id;
                    param.Value.Details[i].SourceMId = param.Value.SourceMId;
                }
                param.Value.PackageMQty = qty_net;

                MobileWhouse.ProdConnector.ServiceResultOfPackageTraDInfo res = ClientApplication.Instance.ProdService.SavePackageTraM(param);
                if (res.Result)
                {
                    //if (uretimgirisprint.IsSelectPrinter)
                    //    uretimgirisprint.Print(12000006, "rpp_prd_9010", "ItemMId", res.Value.PackageMId);

                    //StringBuilder sbSqlString = new StringBuilder();
                    //sbSqlString.AppendFormat(@"UPDATE zz_package_m SET package_tra_m_id = {0}, palette_no = '{1}', is_created = 1  ", res.Value.PackageMId, res.Value.PackageMNo);
                    //sbSqlString.AppendFormat("WHERE package_id IN ({0})", string.Join(",", ids));

                    MobileWhouse.UyumConnector.ServiceRequestOfString paramsql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                    paramsql.Token = ClientApplication.Instance.Token;
                    paramsql.Value = string.Format(@"UPDATE invd_package_m SET package_no = CONCAT('{3}', LPAD(((NEXTVAL('zz_package_m_package_pl_seq'::REGCLASS))::CHARACTER VARYING)::TEXT, 12, '0'::TEXT)) 
WHERE package_no = '{1}' AND source_m_id = {0};
UPDATE zz_package_m SET package_tra_m_id = {0}, 
palette_no = CONCAT('{3}', LPAD(((CURRVAL('zz_package_m_package_pl_seq'::REGCLASS))::CHARACTER VARYING)::TEXT, 12, '0'::TEXT)) , is_created = 1 
WHERE package_id IN ({2});
UPDATE invt_package_tra_m SET package_no = CONCAT('{3}', LPAD(((CURRVAL('zz_package_m_package_pl_seq'::REGCLASS))::CHARACTER VARYING)::TEXT, 12, '0'::TEXT)) 
WHERE package_tra_m_id = {0} RETURNING package_no;", res.Value.PackageMId, res.Value.PackageMNo, string.Join(",", ids), mobileParam.palet_profix);
                    Logger.I(paramsql.Value);
                    MobileWhouse.UyumConnector.ServiceResultOfDataTable resTbl = ClientApplication.Instance.Service.ExecuteSQL(paramsql);
                    if (resTbl != null && resTbl.Result && resTbl.Value != null && resTbl.Value.Rows.Count > 0)
                    {
                        lblbilgi.Text = resTbl.Value.Rows[0][0].ToString();
                        if (uretimgirisprint.IsSelectPrinter)
                            uretimgirisprint.Print(string.Concat(" \"barcode\" = '", lblbilgi.Text, "'  "));
                    }
                    else
                    {
                        lblbilgi.Text = res.Value.PackageMNo;
                        if (uretimgirisprint.IsSelectPrinter)
                            uretimgirisprint.Print(string.Concat(" \"barcode\" = '", lblbilgi.Text, "'  "));
                    }



                    //StringBuilder sbSqlString = new StringBuilder();
                    //sbSqlString.AppendFormat(@"UPDATE zz_package_m SET package_tra_m_id = {0}, palette_no = '{1}', is_created = 1  ", res.Value.PackageMId, res.Value.PackageMNo);
                    //sbSqlString.AppendFormat("WHERE package_id IN ({0})", string.Join(",", ids));

                    //MobileWhouse.UyumConnector.ServiceRequestOfString paramsql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                    //paramsql.Token = ClientApplication.Instance.Token;
                    //paramsql.Value = sbSqlString.ToString();
                    //Logger.I(paramsql.Value);
                    //ClientApplication.Instance.Service.ExecuteSQL(paramsql);
                    ClearForm();

                    if (Screens.Question(string.Concat("Palet oluşturuldu. ", lblbilgi.Text, " İş emri raporu açılsın mı?")))
                    {
                        txtisemri.SetText(worder_no);
                        tabControl1.SelectedIndex = 1;
                        //MainForm.ShowControl(new IsEmriControl());
                        return;
                    }
                }
                else
                {
                    Screens.Error(res.Message);
                }

            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                btnkaydet.Enabled = true;
                Screens.HideWait();
            }
        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtbarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void secistasyon_OnSelected(object sender, object obj)
        {
            wstation = obj as MobileWhouse.ProdConnector.PrdGobalInfo;
            if (wstation != null)
            {
                ClearForm();
                GetProducts();
            }
        }

        void UretimGirisControl_OnLoad(object sender, System.EventArgs e)
        {
            try
            {
                mobileParam = MobileParameter.GetMobileParameter();
                uretimgirisprint.ReleodDefaultValue();
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

        private void txtisemri_OnSelected(object sender, object obj)
        {
            MobileWhouse.ProdConnector.WorderMInfo worderM = obj as MobileWhouse.ProdConnector.WorderMInfo;
            if (worderM != null)
            {
                listBox1.Items.Clear();
                IsEmriRaporHelper help = new IsEmriRaporHelper(worderM);
                if (help.WorderInfos != null)
                {
                    for (int i = 0; i < help.WorderInfos.Count; i++)
                        listBox1.Items.Add(help.WorderInfos[i]);
                }
            }
        }
    }
}
