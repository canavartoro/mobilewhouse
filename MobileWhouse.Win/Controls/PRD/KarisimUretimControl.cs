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
using System.Diagnostics;
using MobileWhouse.Data;
using MobileWhouse.Util;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PRD
{
    /// <summary>
    /// Silme durumunda tuketilen ambalaj icin geri alma yok. bir yontem bulunaacak
    /// Personel eklenecek
    /// </summary>
    public partial class KarisimUretimControl : BaseControl
    {
        private const string CACHENAME = "kmiktar";

        public KarisimUretimControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private worder_ac_op worder_acop = null;
        DateTime startprod;

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
                    GetMaterials();
                }
                else
                {
                    txtisemri.Text = "";
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

                if (worder_acop == null) return;

                Cursor.Current = Cursors.WaitCursor;

                List<prdt_worder_bom_d> boms = prdt_worder_bom_d.GetMaterials(worder_acop.worder_m_id, worder_acop.operation_id, true);
                if (boms != null && boms.Count > 0)
                {
                    listRecete.BeginUpdate();
                    for (int i = 0; i < boms.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = boms[i];
                        item.Text = boms[i].ITEM_CODE;
                        item.SubItems.Add(boms[i].ITEM_NAME);
                        item.SubItems.Add(boms[i].UNIT_CODE);
                        item.SubItems.Add(boms[i].QTY_BASE_BOM.ToString(ClientApplication.Instance.Culture));
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        listRecete.Items.Add(item);
                    }
                    listRecete.EndUpdate();
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
                if (string.IsNullOrEmpty(textBarkod.Text))
                {
                    textBarkod.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam();
                _Ipp.Token = ClientApplication.Instance.UTermToken;
                _Ipp.Value = new MobileWhouse.UTermConnector.ItemPickingParam();
                _Ipp.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                _Ipp.Value.PackageNo = textBarkod.Text;

                MobileWhouse.UTermConnector.ServiceResultOfPackageDetail result = ClientApplication.Instance.UTermService.GetPackageInfo(_Ipp);
                if (result.Result == false)
                {
                    Screens.Error(result.Message.ToString());
                    return;
                }
                else
                {
                    //((MobileWhouse.UTermConnector.NameIdItem)(package.ItemInfo)).Id
                    MobileWhouse.UTermConnector.PackageDetail package = result.Value;
                    if (package == null || package.ItemInfo == null)
                    {
                        textBarkod.Text = "";
                        return;
                    }
                    bool find = false;
                    if (chksil.Checked)
                    {
                    }
                    else
                    {
                        for (int i = 0; i < listBarkod.Items.Count; i++)
                        {
                            if (listBarkod.Items[i].Text == package.PackageNo)
                            {
                                Screens.Error(string.Concat("Barkod daha önce okutulmuştur! ", package.PackageNo));
                                return;
                            }
                        }

                        for (int i = 0; i < listRecete.Items.Count; i++)
                        {
                            prdt_worder_bom_d bom = listRecete.Items[i].Tag as prdt_worder_bom_d;
                            if (bom.ITEM_ID == package.ItemInfo.Id)
                            {
                                decimal read = bom.QTY_REMAIN - bom.QTY_READ;
                                bom.QTY_READ += read;
                                listRecete.Items[i].SubItems[5].Text = bom.QTY_READ.ToString(Statics.DECIMAL_STRING_FORMAT);
                                ListViewItem item = new ListViewItem();
                                item.Text = package.PackageNo;
                                item.Tag = package;
                                item.SubItems.Add(bom.ITEM_CODE);
                                item.SubItems.Add(bom.ITEM_NAME);
                                item.SubItems.Add(bom.UNIT_CODE);
                                item.SubItems.Add(package.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                                item.SubItems.Add(read.ToString(Statics.DECIMAL_STRING_FORMAT));
                                listBarkod.Items.Add(item);
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
                listRecete.EndUpdate();
                Cursor.Current = Cursors.Default;
                textBarkod.Text = "";
                textBarkod.Focus();
            }
        }

        private void ClearForm()
        {
            listBarkod.Items.Clear();
            listRecete.Items.Clear();
            txtisemri.Text = "";
            lblbilgi.Text = "Satır sayısı 0";
            worder_acop = null;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnistasyon_Click(object sender, EventArgs e)
        {
            using (FormSelectWstation frm = new FormSelectWstation())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                {
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                    GetProducts();
                }
            }
        }

        private void btndegistir_Click(object sender, EventArgs e)
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

                worder_acop.qty_net = StringUtil.ToDecimal(txtkoliici.Text);
                if (worder_acop.qty_net <= 0)
                {
                    Screens.Error("Miktar giriniz.");
                    return;
                }
                if (listRecete.Items.Count == 0)
                {
                    Screens.Error("İş emri başlatılmamış.");
                    return;
                }

                AppCache.WriteCache(CACHENAME, worder_acop.qty_net.ToString(Statics.DECIMAL_STRING_FORMAT));

                for (int i = 0; i < listRecete.Items.Count; i++)
                {
                    prdt_worder_bom_d bom = listRecete.Items[i].Tag as prdt_worder_bom_d;
                    bom.QTY_REMAIN = bom.QTY_BASE_BOM * worder_acop.qty_net;
                    listRecete.Items[i].SubItems[4].Text = bom.QTY_REMAIN.ToString(Statics.DECIMAL_STRING_FORMAT);
                }
                startprod = DateTime.Now;
                tabControl1.SelectedIndex = 1;
                textBarkod.Focus();
                return;

            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }

        private void KarisimUretimControl_OnLoad(object sender, EventArgs e)
        {
            txtkoliici.Text = AppCache.ReadCache(CACHENAME, "300");
        }

        private void textBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetPackage();
            }
        }

        private void btnyazdir_Click(object sender, EventArgs e)
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

                if (worder_acop.qty_net <= 0)
                {
                    Screens.Error("Miktar giriniz.");
                    return;
                }
                if (listRecete.Items.Count == 0)
                {
                    Screens.Error("İş emri başlatılmamış.");
                    return;
                }

                Screens.ShowWait();

                MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef context = new MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef();
                context.Token = new MobileWhouse.UyumSave.UyumToken();
                context.Token.Password = ClientApplication.Instance.Token.Password;
                context.Token.UserName = ClientApplication.Instance.Token.UserName;
                context.Value = new MobileWhouse.UyumSave.PrdWorderDef();
                context.Value.StartDate = startprod.Date;
                context.Value.EndDate = startprod.Date;
                context.Value.WorderMId = worder_acop.worder_m_id;
                context.Value.WorderOpDId = worder_acop.worder_op_d_id;
                context.Value.IsUseSendMaterialList = false;
                context.Value.ScrapQty = 0;
                context.Value.WstationId = wstation.PrdGobalId;
                context.Value.Qty = worder_acop.qty_net;
                context.Value.UnitId = worder_acop.unit_id;
                StringBuilder snode = new StringBuilder();
                for (int loop = 0; loop < listBarkod.Items.Count; loop++)
                {
                    MobileWhouse.UTermConnector.PackageDetail package = listBarkod.Items[loop].Tag as MobileWhouse.UTermConnector.PackageDetail;
                    snode.AppendFormat("{0}{1}", loop > 0 ? "," : "", package.PackageNo);
                }
                context.Value.Note = snode.ToString();

                MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                if (result.Result)
                {
                    AmbalajHareket ambhareket = new AmbalajHareket();
                    ambhareket.CoId = ClientApplication.Instance.Token.CoId;
                    ambhareket.BranchId = ClientApplication.Instance.Token.BranchId;
                    ambhareket.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    ambhareket.WhouseCode = ClientApplication.Instance.SelectedDepot.Code;

                    ambhareket.DocNo =
                    ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                    ambhareket.PackageOperationType = "Giriş";
                    ambhareket.InventoryStatus = "Giriş";
                    ambhareket.SourceApp = "Ambalaj";
                    ambhareket.PTypes = "Empty";
                    ambhareket.Qty = worder_acop.qty_net;
                    ambhareket.DocDate = DateTime.Today;
                    ambhareket.DocTraId = AppCache.ReadCacheInt("DocTraId", 2866);
                    ambhareket.SourceMId = StringUtil.ToInteger(result.Message);
                    ambhareket.UyumDetailItem = new AmbalajHareketDetail[1];
                    ambhareket.UyumDetailItem[0] = new AmbalajHareketDetail();
                    ambhareket.UyumDetailItem[0].AddString01 = worder_acop.worder_no;
                    ambhareket.UyumDetailItem[0].ItemId = worder_acop.item_id;
                    ambhareket.UyumDetailItem[0].ItemCode = worder_acop.item_code;
                    ambhareket.UyumDetailItem[0].LineNo = 10;
                    ambhareket.UyumDetailItem[0].Qty = worder_acop.qty_net;
                    ambhareket.UyumDetailItem[0].UnitId = worder_acop.unit_id;
                    ambhareket.UyumDetailItem[0].PackageDetailType = "S";
                    ambhareket.UyumDetailItem[0].DcardId = worder_acop.item_id;
                    ambhareket.UyumDetailItem[0].DcardCode = worder_acop.item_code;
                    ambhareket.UyumDetailItem[0].PackageOperationType = "Giriş";

                    for (int loop = 0; loop < listBarkod.Items.Count; loop++)
                    {
                        decimal qty = StringUtil.ToDecimal(listBarkod.Items[loop].SubItems[5].Text);
                        MobileWhouse.UTermConnector.PackageDetail package = listBarkod.Items[loop].Tag as MobileWhouse.UTermConnector.PackageDetail;
                        UpdatePackage(package.PackageDId, qty);
                    }

                    MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                    Context.Token = new MobileWhouse.UyumSave.UyumToken();
                    Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                    Context.Token.Password = ClientApplication.Instance.Token.Password;
                    Context.Value = ambhareket.ToXml();

                    MobileWhouse.UyumSave.UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                    if (!resp.Success)
                    {
                        Screens.Error(resp.Message);
                    }
                    else
                    {
                        if (printkarisim.IsSelectPrinter)
                        {
                            AmbalajHareket hareket = BaseModel.FromXml(typeof(AmbalajHareket), resp.Value) as AmbalajHareket;
                            if (hareket != null)
                            {
                                printkarisim.Print(221120315362129, "RPP_INV_9009", "pitemmid", hareket.Id);
                            }
                        }
                        ClearForm();
                    }

                    /*MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo();
                    param.Token = ClientApplication.Instance.ProdToken;
                    param.Value = new MobileWhouse.ProdConnector.PackageTraMInfo();
                    param.Value.Whouse2Id = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.WhouseId = wstation.PrdGobalId4;
                    param.Value.DocDate = startprod.Date;

                    param.Value.SourceMId = StringUtil.ToInteger(result.Message);

                    param.Value.Details = new MobileWhouse.ProdConnector.PackageTraDInfo[listBarkod.Items.Count];

                    for (int loop = 0; loop < listBarkod.Items.Count; loop++)
                    {
                        decimal qty = StringUtil.ToDecimal(listBarkod.Items[loop].SubItems[5].Text);

                        MobileWhouse.UTermConnector.PackageDetail package = listBarkod.Items[loop].Tag as MobileWhouse.UTermConnector.PackageDetail;

                        UpdatePackage(package.PackageDId, qty);

                        param.Value.Details[loop] = new MobileWhouse.ProdConnector.PackageTraDInfo();
                        param.Value.Details[loop].ItemId = package.ItemInfo.Id;
                        //param.Value.Details[loop].PackageMNo = package.PackageNo;
                        param.Value.Details[loop].Qty = qty;
                        param.Value.Details[loop].UnitId = package.ItemInfo.UnitId;
                        param.Value.Details[loop].SourceMId = param.Value.SourceMId;
                        //param.Value.Details[loop].SourceDId = worderacops[i].Packages[loop].worder_m_id;
                    }
                    MobileWhouse.ProdConnector.ServiceResultOfPackageTraDInfo res = ClientApplication.Instance.ProdService.SavePackageTraM(param);
                    if (res.Result)
                    {
                        ClearForm();
                    }
                    else
                    {
                        Screens.Error(res.Message);
                    }*/
                }
                else
                {
                    Screens.Error(result.Message);
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

        private void UpdatePackage(int packageId, decimal qty)
        {
            try
            {
                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat("UPDATE uyumsoft.invd_package_m SET qty = qty - ", qty.ToString(Statics.DECIMAL_STRING_FORMAT), ", revort = CASE WHEN qty - ", qty.ToString(Statics.DECIMAL_STRING_FORMAT), " <= 0 THEN 1 ELSE revort END WHERE package_id = '", packageId, "'");
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }
    }
}
