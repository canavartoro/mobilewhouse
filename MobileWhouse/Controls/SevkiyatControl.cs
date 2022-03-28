using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using MobileWhouse.Log;

namespace MobileWhouse.Controls
{
    public partial class SevkiyatControl : BaseControl
    {
        private class ShortItemInfo
        {
            public ShortItemInfo(int stokId)
            {
                StokId = stokId;
                SourceDetails = new List<int>();
            }

            public int StokId { get; set; }
            public List<int> SourceDetails { get; set; }
        }

        private SevkiyatInfo _Info;
        private List<ItemPickingDetail> _Details;
        private List<PackageInfo> _Packages;
        MobileWhouse.UTermConnector.PackageDetail package = null;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private Dictionary<int, ListViewItem> stokHash = new Dictionary<int, ListViewItem>();

        public SevkiyatControl()
        {
            InitializeComponent();
            //txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            //MainForm.Text = ClientApplication.Instance.SelectedDepot.Name;
        }

        public SevkiyatControl(SevkiyatInfo info)
        {
            bool answer = true;
            InitializeComponent();
            //MainForm.Text = ClientApplication.Instance.SelectedDepot.Name;
            try
            {
                if (!info.IsActive)
                {
                    DialogResult dialogResult = MessageBox.Show("Bu Cariye Sevkiyat Yapılamaz. Mal Hazırlamaya devam edilsin mi ?", "Uyarı"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes)
                    {
                        answer = false;
                    }
                }
                if (answer)
                {
                    //Adres
                    adres1.Text = info.Address1;
                    adres2.Text = info.Address2;
                    adres3.Text = info.Address3;
                    ilce.Text = info.Town;
                    il.Text = info.City;
                    ulke.Text = info.Country;
                    //Adres
                    txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
                    //txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
                    _Info = info;
                    lblMusteri.Text = info.Client;
                    //lblBNo.Text = info.DocNo;
                    lblSevkEmri.Text = info.SevkEmriNo;
                    txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledShipping;
                    txtMiktar.Text = "1";

                    ServiceRequestOfItemPickingSelectParam param = new ServiceRequestOfItemPickingSelectParam();
                    param.Token = ClientApplication.Instance.Token;
                    param.Value = new ItemPickingSelectParam();
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.MasterId = info.Id;

                    ServiceResultOfItemPickingDetailInfo details =
                        ClientApplication.Instance.Service.GetItemPickingDetails(param);
                    if (!details.Result)
                    {
                        throw new Exception(details.Message);
                    }

                    _Details = new List<ItemPickingDetail>();
                    _Details.AddRange(details.Value.Details);

                    _Packages = new List<PackageInfo>();
                    if (details.Value.Packages != null)
                        _Packages.AddRange(details.Value.Packages);

                    _FillOnerilenler();
                    _FillOkutulanlar();
                    _FillMainList();
                    _FillPackages();
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void _FillPackages()
        {
            try
            {
                lvwPackages.BeginUpdate();

                lvwPackages.Items.Clear();
                for (int i = 0; i < _Packages.Count; i++)
                {
                    _AddPackageToListView(_Packages[i]);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwPackages.EndUpdate();
            }
        }

        private void _AddPackageToListView(PackageInfo p)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = p;
            item.Text = p.PackageNo;
            item.SubItems.Add(p.PackageTraMId.ToString());
            lvwPackages.Items.Add(item);
        }

        private void _FillOnerilenler()
        {
            try
            {
                lvwOnerilenler.BeginUpdate();

                lvwOnerilenler.Items.Clear();
                if (_Details == null)
                {
                    return;
                }

                for (int i = 0; i < _Details.Count; i++)
                {
                    if (_Details[i].IsReal)
                        continue;
                    ListViewItem item = new ListViewItem();
                    item.Text = _Details[i].StokKod;
                    item.SubItems.Add(_Details[i].StokAd);
                    item.SubItems.Add(_Details[i].LocationCode);
                    item.SubItems.Add(_Details[i].Qty.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.00"));
                    item.Tag = _Details[i];

                    lvwOnerilenler.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwOnerilenler.EndUpdate();
            }
        }

        private void _FillOkutulanlar()
        {
            try
            {
                lvwOkutulanlar.BeginUpdate();

                lvwOkutulanlar.Items.Clear();
                if (_Details == null)
                {
                    return;
                }

                for (int i = 0; i < _Details.Count; i++)
                {
                    _AddToOkunanlar(_Details[i]);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwOkutulanlar.EndUpdate();
            }
        }

        private void _AddToOkunanlar(ItemPickingDetail item)
        {
            if (!item.IsReal)
                return;
            ListViewItem litem = new ListViewItem();
            _SetOkutulanDetails(item, litem);

            lvwOkutulanlar.Items.Insert(0, litem);
        }

        private void _SetOkutulanDetails(ItemPickingDetail detail, ListViewItem item)
        {
            item.Text = detail.StokKod;
            item.SubItems.Add(detail.StokAd);
            item.SubItems.Add(detail.LocationCode);
            item.SubItems.Add(detail.QtyReadPrm.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.00"));
            item.SubItems.Add(detail.UnitCode);
            item.SubItems.Add(detail.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.00"));
            item.SubItems.Add(detail.ReadUnitCode);
            if (detail.PackageTraMId != 0)
                item.SubItems.Add(detail.PackageTraMId.ToString());
            else
                item.SubItems.Add("");
            item.Tag = detail;
        }

        private void _FillMainList()
        {
            try
            {
                stokHash.Clear();
                lvwItems.BeginUpdate();
                lvwItems.Items.Clear();

                if (_Details == null)
                {
                    return;
                }

                for (int i = 0; i < _Details.Count; i++)
                {
                    _AddToList(_Details[i]);
                }
                _SortListView();
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwItems.EndUpdate();
            }
        }

        private void _AddToList(ItemPickingDetail item)
        {
            ListViewItem litem = null;
            if (stokHash.ContainsKey(item.StokId))
            {
                litem = stokHash[item.StokId];
            }
            else
            {
                litem = new ListViewItem();
                ShortItemInfo info = new ShortItemInfo(item.StokId);
                litem.Tag = info;
                litem.Text = item.StokKod;
                litem.SubItems.Add(item.StokAd);
                litem.SubItems.Add("0");
                litem.SubItems.Add("0");
                litem.SubItems.Add("0");
                litem.SubItems.Add("0");
                lvwItems.Items.Add(litem);
                stokHash.Add(item.StokId, litem);
            }

            _SetListViewItemValues(item, litem, true);
        }

        private static void _SetListViewItemValues(ItemPickingDetail item, ListViewItem litem, bool add)
        {
            ShortItemInfo tag = litem.Tag as ShortItemInfo;
            if (!tag.SourceDetails.Contains(item.SourceDId))
            {
                tag.SourceDetails.Add(item.SourceDId);
                litem.SubItems[2].Text = _CombineValues(StringUtil.ToDecimal(litem.SubItems[2].Text)
                    , item.QtyShipping, add);
            }

            if (item.IsReal)
            {
                litem.SubItems[3].Text = _CombineValues(StringUtil.ToDecimal(litem.SubItems[3].Text)
                    , item.QtyReadPrm, add);
            }
            else
            {
                litem.SubItems[5].Text = _CombineValues(StringUtil.ToDecimal(litem.SubItems[5].Text)
                    , item.Qty, add);
            }
            if (item.PackageTraMId == 0)
            {
                litem.SubItems[4].Text = _CombineValues(StringUtil.ToDecimal(litem.SubItems[4].Text)
                    , item.QtyRead, add);
            }

        }
        private void _SortListView()
        {
            List<int> litems = new List<int>();
            List<ListViewItem> items = new List<ListViewItem>();
            for (int i = 0; i < lvwItems.Items.Count; i++)
            {
                if (StringUtil.ToDecimal(lvwItems.Items[i].SubItems[2].Text) != StringUtil.ToDecimal(lvwItems.Items[i].SubItems[3].Text))
                {
                    items.Add(lvwItems.Items[i]);
                    litems.Add((lvwItems.Items[i].Tag as ShortItemInfo).StokId);
                }
            }
            foreach (ListViewItem item in lvwItems.Items)
            {
                if (!litems.Contains((item.Tag as ShortItemInfo).StokId))
                {
                    items.Add(item);
                }
            }
            lvwItems.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                lvwItems.Items.Add(items[i]);
            }
        }
        private static string _CombineValues(decimal val1, decimal val2, bool add)
        {
            if (add)
            {
                return (val1 + val2).ToString(Statics.DECIMAL_STRING_FORMAT);
            }
            else
            {
                return (val1 - val2).ToString(Statics.DECIMAL_STRING_FORMAT);
            }
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            _SelectedRaf = raf;
            txtRaf.Text = raf.Name;
            textBarkod.Focus();
            //txtItemCode.Focus();
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            _SelectedItem = item;
            textBarkod.Text = item.Name;
            //txtItemCode.Text = item.Name;
            btnEkle_Click(this, EventArgs.Empty);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null)
                {
                    MobileWhouse.Util.Screens.Error("Stokodu seçiniz.");
                    return;
                }

                if (_SelectedRaf == null)
                {
                    MobileWhouse.Util.Screens.Error("Raf seçiniz.");
                    return;
                }

                decimal miktar = txtMiktar.Value;
                if (miktar == 0)
                    return;
                if (!stokHash.ContainsKey(_SelectedItem.Id))
                {
                    throw new Exception("Bu mal hazirlamada bu stok yok");
                }

                decimal realmiktar = miktar * _SelectedItem.StokMultiplier;
                if (miktar <= 0 || realmiktar <= 0)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }

                ListViewItem lvwItem = stokHash[_SelectedItem.Id];
                decimal qty = StringUtil.ToDecimal(lvwItem.SubItems[3].Text);
                decimal qtyShipping = StringUtil.ToDecimal(lvwItem.SubItems[2].Text);
                if (qtyShipping < qty + realmiktar)
                {
                    throw new Exception("Sevk adedini asamazsiniz");
                }

                ServiceRequestOfItemPickingSaveContext req = new ServiceRequestOfItemPickingSaveContext();
                req.Token = ClientApplication.Instance.Token;
                req.Value = new ItemPickingSaveContext();
                req.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                req.Value.MasterId = _Info.Id;
                req.Value.Detail = new ItemPickingDetail();
                req.Value.Detail.IsReal = true;
                req.Value.Detail.IsFantom = false;
                req.Value.Detail.LocationId = _SelectedRaf.Id;
                req.Value.Detail.LocationCode = _SelectedRaf.Name;
                req.Value.Detail.StokId = _SelectedItem.Id;
                req.Value.Detail.StokKod = _SelectedItem.Name;
                req.Value.Detail.Qty = miktar;
                req.Value.Detail.QtyRead = miktar;
                req.Value.Detail.QtyReadPrm = realmiktar;
                req.Value.Detail.ReadUnitId = _SelectedItem.ReadUnitId;
                req.Value.Detail.UnitId = _SelectedItem.UnitId;
                req.Value.Detail.UnitCode = _SelectedItem.UnitCode;
                req.Value.Detail.ReadUnitCode = _SelectedItem.ReadUnitCode;
                req.Value.Detail.StokAd = _SelectedItem.Description;

                if (tabControlPalet.SelectedIndex == 1
                    || tabControlPalet.SelectedIndex == 2)
                {
                    PackageInfo pinfo = null;
                    if (lvwPackages.SelectedIndices.Count > 0)
                    {
                        pinfo = lvwPackages.Items[lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                    }

                    if (pinfo == null)
                    {
                        throw new Exception("Herhangi bir paket yok");
                    }

                    req.Value.PackageMId = pinfo.PackageMId;
                    req.Value.PackageTraMId = pinfo.PackageTraMId;
                }

                ServiceResultOfItemPickingDetailResult result = ClientApplication.Instance.Service.SaveItemPickingDetail(req);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }

                req.Value.Detail.Id = result.Value.PickingDetailId;
                req.Value.Detail.PackageTraDId = result.Value.PacketTraDId;
                req.Value.Detail.PackageTraMId = req.Value.PackageTraMId;

                _AddToList(req.Value.Detail);
                _SortListView();
                _Details.Add(req.Value.Detail);
                if (req.Value.PackageTraMId > 0)
                {
                    _AddPackageDetailToListView(req.Value.Detail);
                }
                if (result.Value.PickingDetailId > 0)
                    UpdatePackage(result.Value.PickingDetailId);
                _AddToOkunanlar(req.Value.Detail);

                _SelectedItem = null;
                //txtItemCode.Text = string.Empty;
                //txtItemCode.Focus();
                textBarkod.Text = "";
                textBarkod.Focus();
                txtMiktar.Text = "1";
                package = null;
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void lvwOkutulanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSil.Enabled = lvwOkutulanlar.SelectedIndices.Count > 0;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwOkutulanlar.SelectedIndices.Count < 1)
                    return;

                ListViewItem item = lvwOkutulanlar.Items[lvwOkutulanlar.SelectedIndices[0]];
                ItemPickingDetail detail = item.Tag as ItemPickingDetail;
                if (detail == null)
                    return;

                ServiceRequestOfItemPickingDeleteInfo param = new ServiceRequestOfItemPickingDeleteInfo();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new ItemPickingDeleteInfo();
                param.Value.DetailId = detail.Id;
                param.Value.PackageTraDId = detail.PackageTraDId;
                ServiceResultOfBoolean result = ClientApplication.Instance.Service.DeleteItemPickingDetail(param);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }
                _Details.Remove(detail);
                lvwOkutulanlar.Items.Remove(item);
                if (stokHash.ContainsKey(detail.StokId))
                {
                    _SetListViewItemValues(detail, stokHash[detail.StokId], false);
                }
                if (detail.PackageTraMId > 0)
                {
                    if (lvwPackages.SelectedIndices.Count > 0)
                    {
                        PackageInfo pinfo = lvwPackages.Items[lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                        if (pinfo != null && pinfo.PackageTraMId == detail.PackageTraMId)
                        {
                            _RemoveDetailFromPackageDetail(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnYeniPaket_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new SelectParam();
                param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.InfoId = _Info.Id;
                ServiceResultOfPackageInfo pinfo = ClientApplication.Instance.Service.CreateNewPackage(param);

                if (!pinfo.Result)
                    throw new Exception(pinfo.Message);

                _Packages.Add(pinfo.Value);
                _AddPackageToListView(pinfo.Value);
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void lvwPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lvwPackageDetail.BeginUpdate();

                lvwPackageDetail.Items.Clear();

                PackageInfo pinfo = null;
                if (lvwPackages.SelectedIndices.Count > 0)
                {
                    pinfo = lvwPackages.Items[lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                }

                if (pinfo == null)
                {
                    btnDeletePackage.Enabled = false;
                    return;
                }
                btnDeletePackage.Enabled = true;
                for (int i = 0; i < _Details.Count; i++)
                {
                    if (_Details[i].PackageTraMId == pinfo.PackageTraMId)
                    {
                        _AddPackageDetailToListView(_Details[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwPackageDetail.EndUpdate();
            }
        }

        private void _AddPackageDetailToListView(ItemPickingDetail item)
        {
            ListViewItem litem = new ListViewItem();
            litem.Tag = item;
            litem.Text = item.StokKod;
            litem.SubItems.Add(item.StokAd);
            litem.SubItems.Add(item.QtyReadPrm.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.00"));
            lvwPackageDetail.Items.Insert(0, litem);
        }

        private void _RemoveDetailFromPackageDetail(ItemPickingDetail detail)
        {
            for (int i = 0; i < lvwPackageDetail.Items.Count; i++)
            {
                if (lvwPackageDetail.Items[i].Tag == detail)
                {
                    lvwPackageDetail.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwItems.SelectedIndices.Count > 0)
                {
                    ShortItemInfo item = lvwItems.Items[lvwItems.SelectedIndices[0]].Tag as ShortItemInfo;
                    ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam();
                    param.Token = ClientApplication.Instance.Token;
                    param.Value = new SelectParam();
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.InfoId = item.StokId;

                    ServiceResultOfListOfRafSayimDetay details =
                        ClientApplication.Instance.Service.GetItemQty(param);
                    if (!details.Result)
                    {
                        throw new Exception(details.Message);
                    }

                    lvwOther.BeginUpdate();

                    lvwOther.Items.Clear();
                    if (details == null)
                    {
                        return;
                    }

                    for (int i = 0; i < details.Value.Length; i++)
                    {
                        ListViewItem litem = new ListViewItem();
                        litem.Text = details.Value[i].LocationCode;
                        litem.SubItems.Add(details.Value[i].QtyPrm.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.00"));
                        litem.Tag = details.Value;

                        lvwOther.Items.Insert(0, litem);
                    }
                    lvwOther.EndUpdate();

                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            try
            {
                PackageInfo pinfo = null;
                if (lvwPackages.SelectedIndices.Count > 0)
                {
                    pinfo = lvwPackages.Items[lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                }

                if (pinfo == null)
                {
                    return;
                }

                for (int i = 0; i < _Details.Count; i++)
                {
                    if (_Details[i].PackageTraMId == pinfo.PackageTraMId)
                    {
                        throw new Exception("Icinde urun bulunan paketi silemezsiniz");
                    }
                }

                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = pinfo.PackageTraMId;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.DeletePackage(param);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }

                lvwPackages.Items.RemoveAt(lvwPackages.SelectedIndices[0]);
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void tabControlPalet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPalet.SelectedIndex == 3)
            {
                //ServiceRequestOfItemPickingSelectParam param = new ServiceRequestOfItemPickingSelectParam();
                //param.Token = ClientApplication.Instance.Token;
                //param.Value = new ItemPickingSelectParam();
                //param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                //param.Value.MasterId = _Info.Id;
                //ClientApplication.Instance.Service.UnlockItemPicking(param);
                //MainForm.ShowControl(null);
                using (FormSelectSevkiyat form = new FormSelectSevkiyat(ClientApplication.Instance.SelectedDepot))
                {
                    if (form.ShowDialog() == DialogResult.OK
                        && form.Selected != null)
                    {
                        SevkiyatControl control = new SevkiyatControl(form.Selected);
                        MainForm.ShowControl(control);
                    }
                    else
                    {
                        MainForm.ShowControl(null);
                    }
                }
            }
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtMiktar);
        }

        private void textBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam();
                    _Ipp.Token = ClientApplication.Instance.UTermToken;
                    _Ipp.Value = new MobileWhouse.UTermConnector.ItemPickingParam();
                    _Ipp.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    _Ipp.Value.PackageNo = textBarkod.Text;
                    MobileWhouse.UTermConnector.ServiceResultOfPackageDetail result = ClientApplication.Instance.UTermService.GetPackageInfo(_Ipp);
                    if (result.Result == false)
                    {
                        ServiceRequestOfItemSelectParam req = new ServiceRequestOfItemSelectParam();
                        req.Token = ClientApplication.Instance.Token;
                        req.Value = new ItemSelectParam();
                        req.Value.Barkod = textBarkod.Text;
                        if (ClientApplication.Instance.SelectedDepot != null)
                            req.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                        ServiceResultOfItemInfo result2 = ClientApplication.Instance.Service.GetItemInfo(req);
                        if (!result2.Result)
                            throw new Exception(result2.Message);

                        if (result2.Value != null)
                        {
                            _SelectedItem = result2.Value;
                            //txtItemCode.Text = result2.Value.Name;
                            btnEkle_Click(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        package = result.Value;
                        if (package != null)
                        {
                            if (package.ItemInfo != null)
                            {
                                #region ItemInfo
                                _SelectedItem = new ItemInfo();
                                _SelectedItem.BwhQtyPrm = package.ItemInfo.BwhQtyPrm;
                                _SelectedItem.BwhUnitCode = package.ItemInfo.BwhUnitCode;
                                _SelectedItem.ColorCode = package.ItemInfo.ColorCode;
                                _SelectedItem.ColorId = package.ItemInfo.ColorId;
                                _SelectedItem.Description = package.ItemInfo.Description;
                                _SelectedItem.Description2 = package.ItemInfo.Description2;
                                _SelectedItem.DimCard2Used = package.ItemInfo.DimCard2Used;
                                _SelectedItem.Id = package.ItemInfo.Id;
                                _SelectedItem.InventoryStatus = package.ItemInfo.InventoryStatus;
                                _SelectedItem.IsIsLocNegative = package.ItemInfo.IsIsLocNegative;
                                _SelectedItem.ItemAttr1Id = package.ItemInfo.ItemAttr1Id;
                                _SelectedItem.ItemAttr2Id = package.ItemInfo.ItemAttr2Id;
                                _SelectedItem.ItemAttr3Id = package.ItemInfo.ItemAttr3Id;
                                _SelectedItem.ItemAttr4Id = package.ItemInfo.ItemAttr4Id;
                                _SelectedItem.ItemAttributeCode1 = package.ItemInfo.ItemAttributeCode1;
                                _SelectedItem.ItemAttributeCode2 = package.ItemInfo.ItemAttributeCode2;
                                _SelectedItem.ItemAttributeCode3 = package.ItemInfo.ItemAttributeCode3;
                                _SelectedItem.ItemAttributeCode4 = package.ItemInfo.ItemAttributeCode4;
                                _SelectedItem.LastWayyBillUnitPrice = package.ItemInfo.LastWayyBillUnitPrice;
                                _SelectedItem.LotCode = package.ItemInfo.LotCode;
                                _SelectedItem.LotId = package.ItemInfo.LotId;
                                _SelectedItem.Name = package.ItemInfo.Name;
                                _SelectedItem.PackageDetailType = package.ItemInfo.PackageDetailType == MobileWhouse.UTermConnector.PackageDetailType.A ? UyumConnector.PackageDetailType.A : PackageDetailType.S;
                                _SelectedItem.PackageTypeId = package.ItemInfo.PackageTypeId;
                                _SelectedItem.Qty = package.ItemInfo.Qty;
                                _SelectedItem.QtyMaxInv = package.ItemInfo.QtyMaxInv;
                                _SelectedItem.QtyMinSo = package.ItemInfo.QtyMinSo;
                                _SelectedItem.QualityCode = package.ItemInfo.QualityCode;
                                _SelectedItem.QualityId = package.ItemInfo.QualityId;
                                _SelectedItem.ReadUnitCode = package.ItemInfo.ReadUnitCode;
                                _SelectedItem.ReadUnitId = package.ItemInfo.ReadUnitId == 0 ? package.ItemInfo.UnitId : package.ItemInfo.ReadUnitId;
                                _SelectedItem.SerialMId = package.ItemInfo.SerialMId;
                                _SelectedItem.SerialNo = package.ItemInfo.SerialNo;
                                _SelectedItem.StokMultiplier = package.ItemInfo.StokMultiplier == 0 ? 1 : package.ItemInfo.StokMultiplier;
                                _SelectedItem.ToleranceMaxPo = package.ItemInfo.ToleranceMaxPo;
                                _SelectedItem.ToleranceMaxSo = package.ItemInfo.ToleranceMaxSo;
                                _SelectedItem.UnitCode = package.ItemInfo.UnitCode;
                                _SelectedItem.UnitId = package.ItemInfo.UnitId;
                                _SelectedItem.WhouseId = package.ItemInfo.WhouseId;
                                #endregion
                                //txtItemCode.Text = _SelectedItem.Name;
                                btnEkle_Click(this, EventArgs.Empty);
                            }

                            //txtmiktar.Text = package.Qty.ToString(Statics.DECIMAL_STRING_FORMAT);//"0.#####");
                            //txtmiktar.Focus();
                            //txtmiktar.SelectAll();
                            return;
                        }
                    }
                }
                catch (Exception exc)
                {
                    Screens.Error(exc);
                }
                finally
                {
                    Cursor.Current = Cursors.WaitCursor;
                    textBarkod.Focus();
                    textBarkod.SelectAll();
                }
            }
        }

        private void UpdatePackage(int masterId)
        {
            try
            {
                if (object.ReferenceEquals(package, null)) return;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Format("UPDATE invd_package_m SET update_date = CURRENT_TIMESTAMP,update_user_id = '{0}',source_d_id ='{1}' WHERE package_no = '{2}'",
                    ClientApplication.Instance.ClientToken.UserId, masterId, package.PackageNo);
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
