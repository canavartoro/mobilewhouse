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

namespace MobileWhouse.Controls
{
    public partial class PaletOlusturmaControl : BaseControl
    {
        PackageInfo _PackageInfo = null;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        public PaletOlusturmaControl()
        {
            InitializeComponent();
            //dcQty.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledPackage;
            dcQty.Text = "1";
            dcQty.Value = 1;
            txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            txtStok.DepoId = ClientApplication.Instance.SelectedDepot.Id;
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
                detay.PackageTraDId = detailResult.Value.PackageTraDId;
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
                ServiceRequestOfSelectParam packageParam = new ServiceRequestOfSelectParam();
                packageParam.Value = new SelectParam();
                packageParam.Token = ClientApplication.Instance.Token;
                packageParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;

                ServiceResultOfPackageInfo packageInfo = ClientApplication.Instance.Service.CreateNewPackage(packageParam);

                if (!packageInfo.Result)
                {
                    throw new Exception(packageInfo.Message);
                }
                else
                {
                    _PackageInfo = packageInfo.Value;
                    txtPaletNo.Text = packageInfo.Value.PackageNo;
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
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

            //Screens.Info(string.Concat("Bilgiler:221120315362129,",
            //    AppCache.ReadCache("BARCODE_PROC", "RPP_INV_9009"),
            //    AppCache.ReadCache("BARCODE_FIELD", "pitemmid"), _PackageInfo.PackageTraMId));

            printPaletctrl.Print(221120315362129,
                AppCache.ReadCache("BARCODE_PROC", "RPP_INV_9009"),
                AppCache.ReadCache("BARCODE_FIELD", "pitemmid"), _PackageInfo.PackageTraMId);
        }
    }


}
