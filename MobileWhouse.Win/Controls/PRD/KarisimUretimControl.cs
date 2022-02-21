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
using MobileWhouse.UyumSave;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    /// <summary>
    /// Silme durumunda tuketilen ambalaj icin geri alma yok. bir yontem bulunaacak
    /// Personel eklenecek
    /// </summary>
    [UyumModule("PRD010", "MobileWhouse.Controls.PRD.KarisimUretimControl", "Karışım Üretimi")]
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
                    #region Sil
                    {
                        for (int i = 0; i < listBarkod.Items.Count; i++)
                        {
                            if (listBarkod.Items[i].Text == package.PackageNo)
                            {
                                listBarkod.Items.RemoveAt(i);

                                for (int l = 0; l < listRecete.Items.Count; l++)
                                {
                                    prdt_worder_bom_d bom = listRecete.Items[l].Tag as prdt_worder_bom_d;
                                    if (bom.ITEM_ID == package.ItemInfo.Id || bom.ALTERNATIVES.IndexOf(package.ItemInfo.Id.ToString()) != -1)
                                    {
                                        int _index = bom.Packages.FindIndex(p => p.PackageNo == package.PackageNo);
                                        if (_index != -1)
                                        {
                                            MobileWhouse.UTermConnector.PackageDetail pkg = bom.Packages[_index];
                                            bom.Packages.RemoveAt(_index);
                                            bom.QTY_READ -= pkg.QtyFreeSec;

                                            for (int t = 0; t < listBarkod.Items.Count; t++)
                                            {
                                                if (listBarkod.Items[t].Text == package.PackageNo)
                                                {
                                                    listBarkod.Items.RemoveAt(t);
                                                }
                                            }
                                        }
                                    }
                                }
                                return;
                            }
                        }
                    }
                    #endregion
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
                            find = bom.ITEM_ID == package.ItemInfo.Id || bom.ALTERNATIVES.IndexOf(package.ItemInfo.Id.ToString()) != -1;
                            if (find)
                            {
                                if (bom.QTY_REMAIN == 0) throw new Exception("Reçete miktarı hatalı!");

                                decimal read = bom.QTY_REMAIN - bom.QTY_READ;
                                if (package.Qty < read) read = package.Qty;
                                package.QtyFreeSec = read;
                                bom.QTY_READ += read;

                                bom.Packages.Add(package);

                                listRecete.Items[i].SubItems[5].Text = bom.QTY_READ.ToString(Statics.DECIMAL_STRING_FORMAT);
                                ListViewItem item = new ListViewItem();
                                item.Text = package.PackageNo;
                                item.SubItems.Add(bom.ITEM_CODE);
                                item.SubItems.Add(bom.ITEM_NAME);
                                item.SubItems.Add(bom.UNIT_CODE);
                                item.SubItems.Add(package.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                                item.SubItems.Add(bom.QTY_REMAIN.ToString(Statics.DECIMAL_STRING_FORMAT));
                                item.SubItems.Add(package.ItemInfo.Name);
                                listBarkod.Items.Add(item);

                                find = true;
                            }
                        }

                        if (!find)
                        {
                            Screens.Warning(string.Concat("Okutulan ambalaj malzeme listesinde bulunamadı! ", package.PackageNo, " ", package.ItemInfo.Name));
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
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                if (tabControl1.SelectedIndex == 0)
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

                StringBuilder smsg = new StringBuilder();
                List<MobileWhouse.UTermConnector.PackageDetail> packages = new List<MobileWhouse.UTermConnector.PackageDetail>();
                List<WorderAcBomDDetailFields> materials = new List<WorderAcBomDDetailFields>();
                for (int i = 0; i < listRecete.Items.Count; i++)
                {
                    prdt_worder_bom_d bom = listRecete.Items[i].Tag as prdt_worder_bom_d;
                    if (bom.QTY_READ < bom.QTY_REMAIN)
                    {
                        smsg.AppendFormat("Eksik malzeme:{0}, Kalan:{1}", bom.ITEM_CODE, (bom.QTY_REMAIN - bom.QTY_READ).ToString(Statics.DECIMAL_STRING_FORMAT)).AppendLine();
                    }
                    for (int k = 0; k < bom.Packages.Count; k++)
                    {
                        MobileWhouse.UTermConnector.PackageDetail package = bom.Packages[k];
                        WorderAcBomDDetailFields material = new WorderAcBomDDetailFields();
                        material.LotId = package.LotId;
                        material.Qty = package.QtyFreeSec;
                        material.ItemId = package.ItemInfo.Id;
                        material.UnitId = package.ItemInfo.UnitId;
                        material.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                        material.QualityId = package.QualityId;
                        material.Note1 = package.PackageNo;
                        material.NoteLarge1 = package.PackageNo;
                        materials.Add(material);
                        packages.Add(package);
                    }
                }
                if (smsg.Length > 0)
                {
                    Screens.Error(smsg.ToString());
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
                context.Value.IsUseSendMaterialList = true;
                context.Value.ScrapQty = 0;
                context.Value.WstationId = wstation.PrdGobalId;
                context.Value.Qty = worder_acop.qty_net;
                context.Value.UnitId = worder_acop.unit_id;
                context.Value.WorderAcBomDMaterialList = materials.ToArray();
                context.Value.Note = DeviceUtil.GetDeviceId();

                MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                if (result.Result)
                {
                    PackageTraM ambhareket = new PackageTraM();
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

                    for (int loop = 0; loop < packages.Count; loop++)
                    {
                        UpdatePackage(packages[loop].PackageDId, packages[loop].QtyFreeSec);
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
                            PackageTraM hareket = BaseModel.FromXml(typeof(PackageTraM), resp.Value) as PackageTraM;
                            if (hareket != null)
                            {
                                printkarisim.Print(string.Concat(" \"doc_no\" = '", hareket.DocNo, "'  "));
                                //printkarisim.Print(221120315362129, "RPP_INV_9009", "pitemmid", hareket.Id);
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    if (txtkoliici.DoubleValue <= 0)
                    {
                        Screens.Error("Miktar girin!");
                        txtkoliici.Focus();
                        tabControl1.SelectedIndex = 0;
                        return;
                    }

                    btndegistir_Click(btndegistir, EventArgs.Empty);
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }

        private void txtistasyon_OnSelected(object sender, object obj)
        {
            wstation = obj as MobileWhouse.ProdConnector.PrdGobalInfo;
            if (wstation != null)
            {
                ClearForm();
                //txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                GetProducts();
            }
        }
    }
}
