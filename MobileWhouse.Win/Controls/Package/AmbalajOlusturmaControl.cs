using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;
using MobileWhouse.Models;
using MobileWhouse.Dilogs;
using MobileWhouse.UyumSave;
using System.Threading;
using MobileWhouse.Net;
using MobileWhouse.Attributes;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.Package
{
    [UyumModule("PKG001", "MobileWhouse.Controls.Package.AmbalajOlusturmaControl", "Ambalaj Oluştur")]
    public partial class AmbalajOlusturmaControl : BaseControl
    {
        PackageInfo _PackageInfo = null;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private CoEntityInfo entityInfo = null;
        private PackageTraM ambalajHareket = null;
        private DocTra selectedDocTra = null;
        private Depot selectedDepot = null;
        private EmployeeLogin operatorLogin = new EmployeeLogin();

        public AmbalajOlusturmaControl()
        {
            InitializeComponent();
            //dcQty.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledPackage;
            dcQty.Text = "1";
            dcQty.Value = 1;
            txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            txtStok.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            txthareket.SourceApplication = 212;

        }

        public string GetPackageNo()
        {
            try
            {
                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = "SELECT concat('PL', lpad(((nextval('zz_package_m_package_pl_seq'::regclass))::character varying)::text, 12, '0'::text)) ";
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
                            return res.Value.Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return null;
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            _SelectedRaf = raf;
            txtRaf.Text = raf.Name;

        }

        public override void OnItemBarkod(MobileWhouse.UyumConnector.ItemInfo item)
        {
            try
            {
                base.OnItemBarkod(item);
                _SelectedItem = item;
                txtStok.Text = _SelectedItem.Name;

                /* if (1 == 1) return;// kapatildi, mantik degisti

                 if (_SelectedRaf == null)
                     throw new Exception("Raf seçilmemiş");

                 if (_SelectedItem == null)
                     throw new Exception("Stok Seçilmemiş");

                 if (_PackageInfo == null)
                     throw new Exception("Önce yeni paket oluşturun.");

                 decimal miktar = 0;

                 miktar = dcQty.Value * _SelectedItem.StokMultiplier;
                 if (miktar <= 0)
                 {
                     throw new Exception("Miktar 0 yada negatif olamaz");
                 }

                 ListViewItem lstItem = null;
                 PackageDetail detay = null;

                 for (int i = 0; i < lstPackageDetail.Items.Count; i++)
                 {
                     PackageDetail detail = lstPackageDetail.Items[i].Tag as PackageDetail;

                     if (detail.LocationId == _SelectedRaf.Id && detail.ItemInfo.Id == _SelectedItem.Id)
                     {
                         lstItem = lstPackageDetail.Items[i];
                         detay = detail;
                         break;
                     }
                 }
                 if (detay != null)
                 {
                     if (chkSil.Checked)
                     {
                         if (miktar > detay.Qty)
                         {
                             throw new Exception("Varolandan daha fazla urun siliyorsunuz");
                         }

                         detay.Qty -= miktar;
                     }
                     else
                     {
                         detay.Qty += miktar;
                     }
                 }
                 else
                 {
                     if (chkSil.Checked)
                     {
                         throw new Exception("Bu stok zaten bu sayimda yok");
                     }
                     detay = new PackageDetail();
                     detay.Qty = miktar;
                     detay.ItemInfo = _SelectedItem;
                     if (_SelectedRaf != null)
                     {
                         detay.LocationId = _SelectedRaf.Id;
                     }
                 }
                 if (lstItem == null)
                 {
                     lstItem = new ListViewItem();
                     _SetItemDetails(detay, lstItem);
                     lstPackageDetail.Items.Insert(0, lstItem);
                 }
                 else
                 {
                     if (detay.Qty == 0)
                         lstPackageDetail.Items.Remove(lstItem);
                     else
                         _SetItemDetails(detay, lstItem);
                 }

                 ServiceRequestOfPackageDetail packageD = new ServiceRequestOfPackageDetail();
                 packageD.Value = new PackageDetail();
                 packageD.Token = ClientApplication.Instance.Token;
                 packageD.Value.ItemInfo = _SelectedItem;
                 packageD.Value.LocationId = _SelectedRaf.Id;
                 packageD.Value.PackageMId = _PackageInfo.PackageMId;
                 packageD.Value.PackageDId = detay.PackageDId;
                 packageD.Value.PackageTraDId = detay.PackageTraDId;
                 packageD.Value.PackageTraMId = _PackageInfo.PackageTraMId;
                 packageD.Value.Qty = detay.Qty;

                 ServiceResultOfPackageDetailResult detailResult = ClientApplication.Instance.Service.SavePackageDetail(packageD);
                 if (!detailResult.Result)
                 {
                     throw new Exception(detailResult.Message);
                 }
                 detay.PackageDId = detailResult.Value.PackageDId;
                 detay.PackageTraDId = detailResult.Value.PackageTraDId;*/
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }


        }
        private static void _SetItemDetails(PackageDetail detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.ItemInfo.Name;
            item.SubItems.Add(detay.ItemInfo.UnitCode.ToString());
            item.SubItems.Add(detay.Qty.ToString());
            item.Tag = detay;
        }

        private void btnYeniPalet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null)
                {
                    Screens.Error("Stok kodu seçilmedi!");
                    return;
                }
                if (selectedDocTra == null)
                {
                    Screens.Error("Hareket kodu seçilmedi!");
                    return;
                }

                if (!operatorLogin.Login()) return;
                if (!operatorLogin.Operator.pkg001)
                {
                    Screens.Error("Bu işlem için yetkiniz yok!");
                    return;
                }

                if (dcQty.Value <= 0)
                {
                    Screens.Error("Ambalaj miktarı girilmedi!");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                PackageTraM ambhareket = new PackageTraM();
                ambhareket.CoId = ClientApplication.Instance.Token.CoId;
                ambhareket.BranchId = ClientApplication.Instance.Token.BranchId;
                ambhareket.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                ambhareket.WhouseCode = ClientApplication.Instance.SelectedDepot.Code;
                if (selectedDepot != null)
                {
                    ambhareket.Whouse2Id = selectedDepot.Id;
                    ambhareket.Whouse2Code = selectedDepot.Code;
                }
                //ambhareket.DocNo =
                //ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                if (selectedDocTra.Status == 3)
                {
                    ambhareket.PackageOperationType = "Transfer";
                    ambhareket.InventoryStatus = "Transfer";
                }
                else if (selectedDocTra.Status == 2)
                {
                    ambhareket.PackageOperationType = "Sevk";
                    ambhareket.InventoryStatus = "Çıkış";
                }
                else
                {
                    ambhareket.PackageOperationType = "Giriş";
                    ambhareket.InventoryStatus = "Giriş";
                }

                ambhareket.SourceApp = "Ambalaj";
                ambhareket.PTypes = "Empty";
                ambhareket.Qty = dcQty.Value;
                ambhareket.DocDate = DateTime.Today;
                ambhareket.DocTraId = selectedDocTra.Id;
                ambhareket.DocTraCode = selectedDocTra.DocTraCode;
                if (entityInfo != null)
                {
                    ambhareket.EntityId = entityInfo.EntityId;
                    ambhareket.EntityCode = entityInfo.EntityCode;
                }
                AmbalajHareketDetail ambdetay = new AmbalajHareketDetail();
                ambdetay.AddString01 = textAciklama.Text;
                ambdetay.ItemId = _SelectedItem.Id;
                ambdetay.ItemCode = _SelectedItem.Name;
                ambdetay.LineNo = 10;
                ambdetay.Qty = dcQty.Value;
                ambdetay.UnitId = _SelectedItem.UnitId;
                ambdetay.UnitCode = _SelectedItem.UnitCode;
                ambdetay.PackageDetailType = "S";
                ambdetay.DcardId = _SelectedItem.Id;
                ambdetay.DcardCode = _SelectedItem.Name;
                if (_SelectedRaf != null)
                {
                    ambdetay.BwhLocationId = _SelectedRaf.Id;
                    //ambdetay.LocationCode = _SelectedRaf.Name;//sakın gönderme valla patlar
                }
                ambdetay.PackageOperationType = "Giriş";
                ambhareket.UyumDetailItem = new AmbalajHareketDetail[] { ambdetay };
                MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                Context.Token = new MobileWhouse.UyumSave.UyumToken();
                Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                Context.Token.Password = ClientApplication.Instance.Token.Password;

                int pltsay = Convert.ToInt32(numAmb.DoubleValue);
                if (pltsay <= 0) pltsay = 1;

                for (int l = 0; l < pltsay; l++)
                {
                    ambhareket.UyumDetailItem[0].PackageMNo = GetPackageNo();
                    ambhareket.DocNo = ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                    Context.Value = ambhareket.ToXml();

                    UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                    if (!resp.Success)
                    {
                        Screens.Error(resp.Message);
                        break;
                    }
                    else
                    {
                        txtStok.Text = "";
                        dcQty.Text = "";
                        textAciklama.Text = "";

                        _SelectedItem = null;

                        ambalajHareket = (PackageTraM)BaseModel.FromXml(typeof(PackageTraM), resp.Value);
                        txtPaletNo.Text = ambalajHareket.DocNo;

                        if (printPaletctrl.IsSelectPrinter)
                        {
                            //decimal raporcode = 221120315362129;

                            //if (cmbdizayn.SelectedValue != null && cmbdizayn.SelectedValue is System.Decimal)
                            //{
                            //    raporcode = Convert.ToDecimal(cmbdizayn.SelectedValue);
                            //}
                            printPaletctrl.Print(string.Concat(" \"doc_no\" = '", ambalajHareket.DocNo, "'  "));
                            Thread.Sleep(100);
                        }
                    }

                    //ServiceRequestOfSelectParam packageParam = new ServiceRequestOfSelectParam();
                    //packageParam.Value = new SelectParam();
                    //packageParam.Token = ClientApplication.Instance.Token;
                    //packageParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    //if (entityInfo != null)
                    //    packageParam.Value.SearchEntity = entityInfo.EntityId.ToString();

                    //ServiceResultOfPackageInfo packageInfo = ClientApplication.Instance.Service.CreateNewPackage(packageParam);

                    //if (!packageInfo.Result)
                    //{
                    //    throw new Exception(packageInfo.Message);
                    //}
                    //else
                    //{
                    //    _PackageInfo = packageInfo.Value;
                    //    txtPaletNo.Text = packageInfo.Value.PackageNo;
                    //}
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajMenuControl());
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (_PackageInfo == null)
            {
                Screens.Error("Ambalaj oluşturulmadan yazdırılamaz!");
                return;
            }

            if (!printPaletctrl.IsSelectPrinter)
            {
                Screens.Error("Ambalaj yazdırmak için printer seçin!");
                return;
            }

            printPaletctrl.Print(string.Concat(" \"barcode\" = '", _PackageInfo.PackageNo, "'  "));

            //Screens.Info(string.Concat("Bilgiler:221120315362129,",
            //    AppCache.ReadCache("BARCODE_PROC", "RPP_INV_9009"),
            //    AppCache.ReadCache("BARCODE_FIELD", "pitemmid"), _PackageInfo.PackageTraMId));

            //printPaletctrl.Print(221120315362129,
            //    AppCache.ReadCache("BARCODE_PROC", "RPP_INV_9009"),
            //    AppCache.ReadCache("BARCODE_FIELD", "pitemmid"), _PackageInfo.PackageTraMId);
        }

        private void AmbalajOlusturmaControl_OnLoad(object sender, EventArgs e)
        {
            try
            {
                //string selectedAmbDocTra = FileHelper.ReadFile("selectedAmbDocTra.xml");
                //if (!string.IsNullOrEmpty(selectedAmbDocTra))
                //{
                //    selectedDocTra = FileHelper.FromXml(selectedAmbDocTra, typeof(DocTra)) as DocTra;
                //    if (selectedDocTra == null)
                //    {
                //        FileHelper.DeleteFile("selectedAmbDocTra.xml");
                //    }
                //    else
                //    {
                //        txthareket.Text = string.Concat(selectedDocTra.DocTraCode, " ", selectedDocTra.DocTraDesc);
                //        txtdepo.Enabled = txtdepo.Enabled = selectedDocTra.Status == 3;
                //    }
                //}

                //string kod = AppCache.ReadCache("dizaynkod", "");
                //if (!string.IsNullOrEmpty(kod)) cmbdizayn.SelectedIndex = Convert.ToInt32(kod);
            }
            catch (Exception exc)
            {
                Log.Logger.E(exc);
            }
            //cmbdizayn.SelectedValueChanged += new EventHandler(cmbdizayn_SelectedValueChanged);
        }

        private void txtPaletNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            try
            {

                Screens.ShowWait();

                //Screens.Info(new StringBuilder().Append("Tasarım:").Append(Designs[cmbDesign.SelectedIndex].ID).Append(",Yazıcı:").Append(cmbPrinter.Text).ToString());

                //PrintParameter parameter = new PrintParameter();
                //parameter.Sirket = new Login();
                //parameter.PrinterName = cmbPrinter.Text;
                //parameter.DizaynName = cmbDesign.Text;
                //parameter.FilterCondition = criteria;

                //SirketResponseOfPrintResponse resp = WebClient.WebServ.Yazdir(parameter);
                //if (resp == null)
                //{
                //    Screens.Error("Yazdırma işleminde bilinmeyen hata!");
                //}
                //if (!resp.Result)
                //{
                //    Screens.Error(string.Concat("Yazdırma işleminde hata:", resp.Message));
                //}

                using (TcpPrinterClient tcpprinter = new TcpPrinterClient())
                {
                    PrintersDesigns print = tcpprinter.PrintServer("", printPaletctrl.PrinterName, "ambalaj", " package_no = 'P20211200153' ");
                    if (print == null)
                    {
                        Screens.Error("Yazdırma işleminde bilinmeyen hata!");
                    }
                    if (print.Result)
                    {
                        Screens.Error("Yazdırma işleminde başarılı");
                    }
                    else
                    {
                        Screens.Error(string.Concat("Yazdırma işleminde hata:", print.Massage));
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

        private void txthareket_OnSelected(object sender, object obj)
        {
            selectedDocTra = obj as DocTra;
            if (selectedDocTra != null)
            {
                //txthareket.Text = string.Concat(selectedDocTra.DocTraCode, " ", selectedDocTra.DocTraDesc);
                txtdepo.Enabled = txtdepo.Enabled = selectedDocTra.Status == 3;
            }
        }

        private void textCari_OnSelected(object sender, object obj)
        {
            entityInfo = obj as CoEntityInfo;
        }

        private void txtdepo_OnSelected(object sender, object obj)
        {
            selectedDepot = (Depot)obj;
        }

    }


}


/*
CREATE SEQUENCE "uyumsoft"."zz_package_m_package_pl_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

--SELECT setval('"uyumsoft"."zz_package_m_package_pl_seq"', 48958, true);

ALTER SEQUENCE "uyumsoft"."zz_package_m_package_pl_seq" OWNER TO "uyum";
 
SELECT concat('PL', lpad(((nextval('zz_package_m_package_pl_seq'::regclass))::character varying)::text, 12, '0'::text))
 */