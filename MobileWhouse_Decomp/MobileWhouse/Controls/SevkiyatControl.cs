namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SevkiyatControl : BaseControl
    {
        private List<ItemPickingDetail> _Details;
        private SevkiyatInfo _Info;
        private List<PackageInfo> _Packages;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private Label adres1;
        private Label adres2;
        private Label adres3;
        private Button btnDeletePackage;
        private Button btnSil;
        private Button btnYeniPaket;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private IContainer components;
        private Label il;
        private Label ilce;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblMusteri;
        private Label lblSevkEmri;
        private ListView lvwItems;
        private ListView lvwOkutulanlar;
        private ListView lvwOnerilenler;
        private ListView lvwOther;
        private ListView lvwPackageDetail;
        private ListView lvwPackages;
        private Dictionary<int, ListViewItem> stokHash;
        private TabControl tabControlPalet;
        private TabControl tabMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPagePackkageIcerik;
        private TabPage tabPagePaket;
        private BarkodTextBox txtItemCode;
        private DecimalTextBox txtMiktar;
        private RafTextBox txtRaf;
        private Label ulke;

        public SevkiyatControl()
        {
            this.stokHash = new Dictionary<int, ListViewItem>();
            this.components = null;
            this.InitializeComponent();
            this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public SevkiyatControl(SevkiyatInfo info)
        {
            this.stokHash = new Dictionary<int, ListViewItem>();
            this.components = null;
            bool flag = true;
            this.InitializeComponent();
            try
            {
                if (!info.IsActive && (MessageBox.Show("Bu Cariye Sevkiyat Yapılamaz. Mal Hazırlamaya devam edilsin mi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes))
                {
                    flag = false;
                }
                if (flag)
                {
                    this.adres1.Text = info.Address1;
                    this.adres2.Text = info.Address2;
                    this.adres3.Text = info.Address3;
                    this.ilce.Text = info.Town;
                    this.il.Text = info.City;
                    this.ulke.Text = info.Country;
                    this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
                    this._Info = info;
                    this.lblMusteri.Text = info.Client;
                    this.lblSevkEmri.Text = info.SevkEmriNo;
                    this.txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledShipping;
                    this.txtMiktar.Text = "1";
                    ServiceRequestOfItemPickingSelectParam param = new ServiceRequestOfItemPickingSelectParam {
                        Token = ClientApplication.Instance.Token,
                        Value = new ItemPickingSelectParam()
                    };
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.MasterId = info.Id;
                    ServiceResultOfItemPickingDetailInfo info2 = ClientApplication.Instance.Service.GetItemPickingDetails(param);
                    if (!info2.Result)
                    {
                        throw new Exception(info2.Message);
                    }
                    this._Details = new List<ItemPickingDetail>();
                    this._Details.AddRange(info2.Value.Details);
                    this._Packages = new List<PackageInfo>();
                    if (info2.Value.Packages != null)
                    {
                        this._Packages.AddRange(info2.Value.Packages);
                    }
                    this._FillOnerilenler();
                    this._FillOkutulanlar();
                    this._FillMainList();
                    this._FillPackages();
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void _AddPackageDetailToListView(ItemPickingDetail item)
        {
            ListViewItem listViewItem = new ListViewItem {
                Tag = item,
                Text = item.StokKod
            };
            listViewItem.SubItems.Add(item.StokAd);
            listViewItem.SubItems.Add(item.QtyReadPrm.ToString("0.00"));
            this.lvwPackageDetail.Items.Insert(0, listViewItem);
        }

        private void _AddPackageToListView(PackageInfo p)
        {
            ListViewItem listViewItem = new ListViewItem {
                Tag = p,
                Text = p.PackageNo
            };
            listViewItem.SubItems.Add(p.PackageTraMId.ToString());
            this.lvwPackages.Items.Add(listViewItem);
        }

        private void _AddToList(ItemPickingDetail item)
        {
            ListViewItem listViewItem = null;
            if (this.stokHash.ContainsKey(item.StokId))
            {
                listViewItem = this.stokHash[item.StokId];
            }
            else
            {
                listViewItem = new ListViewItem();
                ShortItemInfo info = new ShortItemInfo(item.StokId);
                listViewItem.Tag = info;
                listViewItem.Text = item.StokKod;
                listViewItem.SubItems.Add(item.StokAd);
                listViewItem.SubItems.Add("0");
                listViewItem.SubItems.Add("0");
                listViewItem.SubItems.Add("0");
                listViewItem.SubItems.Add("0");
                this.lvwItems.Items.Add(listViewItem);
                this.stokHash.Add(item.StokId, listViewItem);
            }
            _SetListViewItemValues(item, listViewItem, true);
        }

        private void _AddToOkunanlar(ItemPickingDetail item)
        {
            if (item.IsReal)
            {
                ListViewItem item2 = new ListViewItem();
                this._SetOkutulanDetails(item, item2);
                this.lvwOkutulanlar.Items.Insert(0, item2);
            }
        }

        private static string _CombineValues(decimal val1, decimal val2, bool add)
        {
            if (add)
            {
                return Convert.ToString((decimal) (val1 + val2));
            }
            return Convert.ToString((decimal) (val1 - val2));
        }

        private void _FillMainList()
        {
            try
            {
                this.stokHash.Clear();
                this.lvwItems.BeginUpdate();
                this.lvwItems.Items.Clear();
                if (this._Details != null)
                {
                    for (int i = 0; i < this._Details.Count; i++)
                    {
                        this._AddToList(this._Details[i]);
                    }
                    this._SortListView();
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwItems.EndUpdate();
            }
        }

        private void _FillOkutulanlar()
        {
            try
            {
                this.lvwOkutulanlar.BeginUpdate();
                this.lvwOkutulanlar.Items.Clear();
                if (this._Details != null)
                {
                    for (int i = 0; i < this._Details.Count; i++)
                    {
                        this._AddToOkunanlar(this._Details[i]);
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwOkutulanlar.EndUpdate();
            }
        }

        private void _FillOnerilenler()
        {
            try
            {
                this.lvwOnerilenler.BeginUpdate();
                this.lvwOnerilenler.Items.Clear();
                if (this._Details != null)
                {
                    for (int i = 0; i < this._Details.Count; i++)
                    {
                        if (!this._Details[i].IsReal)
                        {
                            ListViewItem listViewItem = new ListViewItem {
                                Text = this._Details[i].StokKod
                            };
                            listViewItem.SubItems.Add(this._Details[i].StokAd);
                            listViewItem.SubItems.Add(this._Details[i].LocationCode);
                            listViewItem.SubItems.Add(this._Details[i].Qty.ToString("0.00"));
                            listViewItem.Tag = this._Details[i];
                            this.lvwOnerilenler.Items.Add(listViewItem);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwOnerilenler.EndUpdate();
            }
        }

        private void _FillPackages()
        {
            try
            {
                this.lvwPackages.BeginUpdate();
                this.lvwPackages.Items.Clear();
                for (int i = 0; i < this._Packages.Count; i++)
                {
                    this._AddPackageToListView(this._Packages[i]);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwPackages.EndUpdate();
            }
        }

        private void _RemoveDetailFromPackageDetail(ItemPickingDetail detail)
        {
            for (int i = 0; i < this.lvwPackageDetail.Items.Count; i++)
            {
                if (this.lvwPackageDetail.Items[i].Tag == detail)
                {
                    this.lvwPackageDetail.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private static void _SetListViewItemValues(ItemPickingDetail item, ListViewItem litem, bool add)
        {
            ShortItemInfo tag = litem.Tag as ShortItemInfo;
            if (!tag.SourceDetails.Contains(item.SourceDId))
            {
                tag.SourceDetails.Add(item.SourceDId);
                litem.SubItems[2].Text = _CombineValues(Convert.ToDecimal(litem.SubItems[2].Text), item.QtyShipping, add);
            }
            if (item.IsReal)
            {
                litem.SubItems[3].Text = _CombineValues(Convert.ToDecimal(litem.SubItems[3].Text), item.QtyReadPrm, add);
            }
            else
            {
                litem.SubItems[5].Text = _CombineValues(Convert.ToDecimal(litem.SubItems[5].Text), item.Qty, add);
            }
            if (item.PackageTraMId == 0)
            {
                litem.SubItems[4].Text = _CombineValues(Convert.ToDecimal(litem.SubItems[4].Text), item.QtyRead, add);
            }
        }

        private void _SetOkutulanDetails(ItemPickingDetail detail, ListViewItem item)
        {
            item.Text = detail.StokKod;
            item.SubItems.Add(detail.StokAd);
            item.SubItems.Add(detail.LocationCode);
            item.SubItems.Add(detail.QtyReadPrm.ToString("0.00"));
            item.SubItems.Add(detail.UnitCode);
            item.SubItems.Add(detail.Qty.ToString("0.00"));
            item.SubItems.Add(detail.ReadUnitCode);
            if (detail.PackageTraMId != 0)
            {
                item.SubItems.Add(detail.PackageTraMId.ToString());
            }
            else
            {
                item.SubItems.Add("");
            }
            item.Tag = detail;
        }

        private void _SortListView()
        {
            int num;
            List<int> list = new List<int>();
            List<ListViewItem> list2 = new List<ListViewItem>();
            for (num = 0; num < this.lvwItems.Items.Count; num++)
            {
                if (Convert.ToInt32(this.lvwItems.Items[num].SubItems[2].Text) != Convert.ToInt32(this.lvwItems.Items[num].SubItems[3].Text))
                {
                    list2.Add(this.lvwItems.Items[num]);
                    list.Add((this.lvwItems.Items[num].Tag as ShortItemInfo).StokId);
                }
            }
            foreach (ListViewItem item in this.lvwItems.Items)
            {
                if (!list.Contains((item.Tag as ShortItemInfo).StokId))
                {
                    list2.Add(item);
                }
            }
            this.lvwItems.Items.Clear();
            for (num = 0; num < list2.Count; num++)
            {
                this.lvwItems.Items.Add(list2[num]);
            }
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            try
            {
                PackageInfo tag = null;
                if (this.lvwPackages.SelectedIndices.Count > 0)
                {
                    tag = this.lvwPackages.Items[this.lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                }
                if (tag != null)
                {
                    for (int i = 0; i < this._Details.Count; i++)
                    {
                        if (this._Details[i].PackageTraMId == tag.PackageTraMId)
                        {
                            throw new Exception("Icinde urun bulunan paketi silemezsiniz");
                        }
                    }
                    ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                        Token = ClientApplication.Instance.Token,
                        Value = tag.PackageTraMId
                    };
                    ServiceResultOfBoolean flag = ClientApplication.Instance.Service.DeletePackage(param);
                    if (!flag.Result)
                    {
                        throw new Exception(flag.Message);
                    }
                    this.lvwPackages.Items.RemoveAt(this.lvwPackages.SelectedIndices[0]);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._SelectedItem == null)
                {
                    MessageBox.Show("Stokodu se\x00e7iniz.");
                }
                else if (this._SelectedRaf == null)
                {
                    MessageBox.Show("Raf se\x00e7iniz.");
                }
                else
                {
                    decimal num = this.txtMiktar.Value;
                    if (num != 0M)
                    {
                        if (!this.stokHash.ContainsKey(this._SelectedItem.Id))
                        {
                            throw new Exception("Bu mal hazirlamada bu stok yok");
                        }
                        decimal num2 = num * this._SelectedItem.StokMultiplier;
                        if ((num <= 0M) || (num2 <= 0M))
                        {
                            throw new Exception("Miktar 0 yada negatif olamaz");
                        }
                        ListViewItem item = this.stokHash[this._SelectedItem.Id];
                        decimal num3 = Convert.ToDecimal(item.SubItems[3].Text);
                        if (Convert.ToDecimal(item.SubItems[2].Text) < (num3 + num2))
                        {
                            throw new Exception("Sevk adedini asamazsiniz");
                        }
                        ServiceRequestOfItemPickingSaveContext param = new ServiceRequestOfItemPickingSaveContext {
                            Token = ClientApplication.Instance.Token,
                            Value = new ItemPickingSaveContext()
                        };
                        param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                        param.Value.MasterId = this._Info.Id;
                        param.Value.Detail = new ItemPickingDetail();
                        param.Value.Detail.IsReal = true;
                        param.Value.Detail.LocationId = this._SelectedRaf.Id;
                        param.Value.Detail.LocationCode = this._SelectedRaf.Name;
                        param.Value.Detail.StokId = this._SelectedItem.Id;
                        param.Value.Detail.StokKod = this._SelectedItem.Name;
                        param.Value.Detail.Qty = num;
                        param.Value.Detail.QtyRead = num;
                        param.Value.Detail.QtyReadPrm = num2;
                        param.Value.Detail.ReadUnitId = this._SelectedItem.ReadUnitId;
                        param.Value.Detail.UnitId = this._SelectedItem.UnitId;
                        param.Value.Detail.UnitCode = this._SelectedItem.UnitCode;
                        param.Value.Detail.ReadUnitCode = this._SelectedItem.ReadUnitCode;
                        param.Value.Detail.StokAd = this._SelectedItem.Description;
                        if ((this.tabControlPalet.SelectedIndex == 1) || (this.tabControlPalet.SelectedIndex == 2))
                        {
                            PackageInfo tag = null;
                            if (this.lvwPackages.SelectedIndices.Count > 0)
                            {
                                tag = this.lvwPackages.Items[this.lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                            }
                            if (tag == null)
                            {
                                throw new Exception("Herhangi bir paket yok");
                            }
                            param.Value.PackageMId = tag.PackageMId;
                            param.Value.PackageTraMId = tag.PackageTraMId;
                        }
                        ServiceResultOfItemPickingDetailResult result = ClientApplication.Instance.Service.SaveItemPickingDetail(param);
                        if (!result.Result)
                        {
                            throw new Exception(result.Message);
                        }
                        param.Value.Detail.Id = result.Value.PickingDetailId;
                        param.Value.Detail.PackageTraDId = result.Value.PacketTraDId;
                        param.Value.Detail.PackageTraMId = param.Value.PackageTraMId;
                        this._AddToList(param.Value.Detail);
                        this._SortListView();
                        this._Details.Add(param.Value.Detail);
                        if (param.Value.PackageTraMId > 0)
                        {
                            this._AddPackageDetailToListView(param.Value.Detail);
                        }
                        this._AddToOkunanlar(param.Value.Detail);
                        this._SelectedItem = null;
                        this.txtItemCode.Text = string.Empty;
                        this.txtItemCode.Focus();
                        this.txtMiktar.Text = "1";
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvwOkutulanlar.SelectedIndices.Count >= 1)
                {
                    ListViewItem listViewItem = this.lvwOkutulanlar.Items[this.lvwOkutulanlar.SelectedIndices[0]];
                    ItemPickingDetail tag = listViewItem.Tag as ItemPickingDetail;
                    if (tag != null)
                    {
                        ServiceRequestOfItemPickingDeleteInfo param = new ServiceRequestOfItemPickingDeleteInfo {
                            Token = ClientApplication.Instance.Token,
                            Value = new ItemPickingDeleteInfo()
                        };
                        param.Value.DetailId = tag.Id;
                        param.Value.PackageTraDId = tag.PackageTraDId;
                        ServiceResultOfBoolean flag = ClientApplication.Instance.Service.DeleteItemPickingDetail(param);
                        if (!flag.Result)
                        {
                            throw new Exception(flag.Message);
                        }
                        this._Details.Remove(tag);
                        this.lvwOkutulanlar.Items.Remove(listViewItem);
                        if (this.stokHash.ContainsKey(tag.StokId))
                        {
                            _SetListViewItemValues(tag, this.stokHash[tag.StokId], false);
                        }
                        if ((tag.PackageTraMId > 0) && (this.lvwPackages.SelectedIndices.Count > 0))
                        {
                            PackageInfo info2 = this.lvwPackages.Items[this.lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                            if ((info2 != null) && (info2.PackageTraMId == tag.PackageTraMId))
                            {
                                this._RemoveDetailFromPackageDetail(tag);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void btnYeniPaket_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new SelectParam()
                };
                param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.InfoId = this._Info.Id;
                ServiceResultOfPackageInfo info = ClientApplication.Instance.Service.CreateNewPackage(param);
                if (!info.Result)
                {
                    throw new Exception(info.Message);
                }
                this._Packages.Add(info.Value);
                this._AddPackageToListView(info.Value);
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SevkiyatControl));
            this.tabMain = new TabControl();
            this.tabPage1 = new TabPage();
            this.tabControlPalet = new TabControl();
            this.tabPage5 = new TabPage();
            this.lvwItems = new ListView();
            this.columnHeader4 = new ColumnHeader();
            this.columnHeader21 = new ColumnHeader();
            this.columnHeader5 = new ColumnHeader();
            this.columnHeader7 = new ColumnHeader();
            this.columnHeader25 = new ColumnHeader();
            this.columnHeader6 = new ColumnHeader();
            this.tabPagePaket = new TabPage();
            this.btnDeletePackage = new Button();
            this.btnYeniPaket = new Button();
            this.lvwPackages = new ListView();
            this.columnHeader13 = new ColumnHeader();
            this.columnHeader18 = new ColumnHeader();
            this.tabPagePackkageIcerik = new TabPage();
            this.lvwPackageDetail = new ListView();
            this.columnHeader11 = new ColumnHeader();
            this.columnHeader24 = new ColumnHeader();
            this.columnHeader12 = new ColumnHeader();
            this.tabPage7 = new TabPage();
            this.txtMiktar = new DecimalTextBox();
            this.label4 = new Label();
            this.txtItemCode = new BarkodTextBox();
            this.txtRaf = new RafTextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.lblSevkEmri = new Label();
            this.lblMusteri = new Label();
            this.tabPage4 = new TabPage();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label1 = new Label();
            this.ulke = new Label();
            this.il = new Label();
            this.ilce = new Label();
            this.adres3 = new Label();
            this.adres2 = new Label();
            this.adres1 = new Label();
            this.tabPage6 = new TabPage();
            this.lvwOther = new ListView();
            this.columnHeader19 = new ColumnHeader();
            this.columnHeader20 = new ColumnHeader();
            this.tabPage3 = new TabPage();
            this.btnSil = new Button();
            this.lvwOkutulanlar = new ListView();
            this.columnHeader8 = new ColumnHeader();
            this.columnHeader23 = new ColumnHeader();
            this.columnHeader9 = new ColumnHeader();
            this.columnHeader10 = new ColumnHeader();
            this.columnHeader14 = new ColumnHeader();
            this.columnHeader15 = new ColumnHeader();
            this.columnHeader16 = new ColumnHeader();
            this.columnHeader17 = new ColumnHeader();
            this.tabPage2 = new TabPage();
            this.lvwOnerilenler = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader22 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlPalet.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPagePaket.SuspendLayout();
            this.tabPagePackkageIcerik.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            base.SuspendLayout();
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage2);
            manager.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabPage1.Controls.Add(this.tabControlPalet);
            this.tabPage1.Controls.Add(this.txtMiktar);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtItemCode);
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblSevkEmri);
            this.tabPage1.Controls.Add(this.lblMusteri);
            manager.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            manager.ApplyResources(this.tabControlPalet, "tabControlPalet");
            this.tabControlPalet.Controls.Add(this.tabPage5);
            this.tabControlPalet.Controls.Add(this.tabPagePaket);
            this.tabControlPalet.Controls.Add(this.tabPagePackkageIcerik);
            this.tabControlPalet.Controls.Add(this.tabPage7);
            this.tabControlPalet.Name = "tabControlPalet";
            this.tabControlPalet.SelectedIndex = 0;
            this.tabControlPalet.SelectedIndexChanged += new EventHandler(this.tabControlPalet_SelectedIndexChanged);
            this.tabPage5.Controls.Add(this.lvwItems);
            manager.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.lvwItems.Columns.Add(this.columnHeader4);
            this.lvwItems.Columns.Add(this.columnHeader21);
            this.lvwItems.Columns.Add(this.columnHeader5);
            this.lvwItems.Columns.Add(this.columnHeader7);
            this.lvwItems.Columns.Add(this.columnHeader25);
            this.lvwItems.Columns.Add(this.columnHeader6);
            manager.ApplyResources(this.lvwItems, "lvwItems");
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.View = View.Details;
            this.lvwItems.SelectedIndexChanged += new EventHandler(this.lvwItems_SelectedIndexChanged);
            manager.ApplyResources(this.columnHeader4, "columnHeader4");
            manager.ApplyResources(this.columnHeader21, "columnHeader21");
            manager.ApplyResources(this.columnHeader5, "columnHeader5");
            manager.ApplyResources(this.columnHeader7, "columnHeader7");
            manager.ApplyResources(this.columnHeader25, "columnHeader25");
            manager.ApplyResources(this.columnHeader6, "columnHeader6");
            this.tabPagePaket.Controls.Add(this.btnDeletePackage);
            this.tabPagePaket.Controls.Add(this.btnYeniPaket);
            this.tabPagePaket.Controls.Add(this.lvwPackages);
            manager.ApplyResources(this.tabPagePaket, "tabPagePaket");
            this.tabPagePaket.Name = "tabPagePaket";
            manager.ApplyResources(this.btnDeletePackage, "btnDeletePackage");
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Click += new EventHandler(this.btnDeletePackage_Click);
            manager.ApplyResources(this.btnYeniPaket, "btnYeniPaket");
            this.btnYeniPaket.Name = "btnYeniPaket";
            this.btnYeniPaket.Click += new EventHandler(this.btnYeniPaket_Click);
            manager.ApplyResources(this.lvwPackages, "lvwPackages");
            this.lvwPackages.Columns.Add(this.columnHeader13);
            this.lvwPackages.Columns.Add(this.columnHeader18);
            this.lvwPackages.FullRowSelect = true;
            this.lvwPackages.Name = "lvwPackages";
            this.lvwPackages.View = View.Details;
            this.lvwPackages.SelectedIndexChanged += new EventHandler(this.lvwPackages_SelectedIndexChanged);
            manager.ApplyResources(this.columnHeader13, "columnHeader13");
            manager.ApplyResources(this.columnHeader18, "columnHeader18");
            this.tabPagePackkageIcerik.Controls.Add(this.lvwPackageDetail);
            manager.ApplyResources(this.tabPagePackkageIcerik, "tabPagePackkageIcerik");
            this.tabPagePackkageIcerik.Name = "tabPagePackkageIcerik";
            this.lvwPackageDetail.Columns.Add(this.columnHeader11);
            this.lvwPackageDetail.Columns.Add(this.columnHeader24);
            this.lvwPackageDetail.Columns.Add(this.columnHeader12);
            manager.ApplyResources(this.lvwPackageDetail, "lvwPackageDetail");
            this.lvwPackageDetail.Name = "lvwPackageDetail";
            this.lvwPackageDetail.View = View.Details;
            manager.ApplyResources(this.columnHeader11, "columnHeader11");
            manager.ApplyResources(this.columnHeader24, "columnHeader24");
            manager.ApplyResources(this.columnHeader12, "columnHeader12");
            manager.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            manager.ApplyResources(this.txtMiktar, "txtMiktar");
            this.txtMiktar.Name = "txtMiktar";
            int[] bits = new int[4];
            this.txtMiktar.Value = new decimal(bits);
            manager.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.IsTransfer = false;
            manager.ApplyResources(this.txtItemCode, "txtItemCode");
            this.txtItemCode.Name = "txtItemCode";
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.IsTransfer = false;
            manager.ApplyResources(this.txtRaf, "txtRaf");
            this.txtRaf.Name = "txtRaf";
            manager.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            manager.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            manager.ApplyResources(this.lblSevkEmri, "lblSevkEmri");
            this.lblSevkEmri.Name = "lblSevkEmri";
            manager.ApplyResources(this.lblMusteri, "lblMusteri");
            this.lblMusteri.Name = "lblMusteri";
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.ulke);
            this.tabPage4.Controls.Add(this.il);
            this.tabPage4.Controls.Add(this.ilce);
            this.tabPage4.Controls.Add(this.adres3);
            this.tabPage4.Controls.Add(this.adres2);
            this.tabPage4.Controls.Add(this.adres1);
            manager.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            manager.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            manager.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            manager.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            manager.ApplyResources(this.ulke, "ulke");
            this.ulke.Name = "ulke";
            manager.ApplyResources(this.il, "il");
            this.il.Name = "il";
            manager.ApplyResources(this.ilce, "ilce");
            this.ilce.Name = "ilce";
            manager.ApplyResources(this.adres3, "adres3");
            this.adres3.Name = "adres3";
            manager.ApplyResources(this.adres2, "adres2");
            this.adres2.Name = "adres2";
            manager.ApplyResources(this.adres1, "adres1");
            this.adres1.Name = "adres1";
            this.tabPage6.Controls.Add(this.lvwOther);
            manager.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.lvwOther.Columns.Add(this.columnHeader19);
            this.lvwOther.Columns.Add(this.columnHeader20);
            manager.ApplyResources(this.lvwOther, "lvwOther");
            this.lvwOther.Name = "lvwOther";
            this.lvwOther.View = View.Details;
            manager.ApplyResources(this.columnHeader19, "columnHeader19");
            manager.ApplyResources(this.columnHeader20, "columnHeader20");
            this.tabPage3.Controls.Add(this.btnSil);
            this.tabPage3.Controls.Add(this.lvwOkutulanlar);
            manager.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            manager.ApplyResources(this.btnSil, "btnSil");
            this.btnSil.Name = "btnSil";
            this.btnSil.Click += new EventHandler(this.btnSil_Click);
            manager.ApplyResources(this.lvwOkutulanlar, "lvwOkutulanlar");
            this.lvwOkutulanlar.Columns.Add(this.columnHeader8);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader23);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader9);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader10);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader14);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader15);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader16);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader17);
            this.lvwOkutulanlar.FullRowSelect = true;
            this.lvwOkutulanlar.Name = "lvwOkutulanlar";
            this.lvwOkutulanlar.View = View.Details;
            this.lvwOkutulanlar.SelectedIndexChanged += new EventHandler(this.lvwOkutulanlar_SelectedIndexChanged);
            manager.ApplyResources(this.columnHeader8, "columnHeader8");
            manager.ApplyResources(this.columnHeader23, "columnHeader23");
            manager.ApplyResources(this.columnHeader9, "columnHeader9");
            manager.ApplyResources(this.columnHeader10, "columnHeader10");
            manager.ApplyResources(this.columnHeader14, "columnHeader14");
            manager.ApplyResources(this.columnHeader15, "columnHeader15");
            manager.ApplyResources(this.columnHeader16, "columnHeader16");
            manager.ApplyResources(this.columnHeader17, "columnHeader17");
            this.tabPage2.Controls.Add(this.lvwOnerilenler);
            manager.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            manager.ApplyResources(this.lvwOnerilenler, "lvwOnerilenler");
            this.lvwOnerilenler.Columns.Add(this.columnHeader1);
            this.lvwOnerilenler.Columns.Add(this.columnHeader22);
            this.lvwOnerilenler.Columns.Add(this.columnHeader2);
            this.lvwOnerilenler.Columns.Add(this.columnHeader3);
            this.lvwOnerilenler.FullRowSelect = true;
            this.lvwOnerilenler.Name = "lvwOnerilenler";
            this.lvwOnerilenler.View = View.Details;
            manager.ApplyResources(this.columnHeader1, "columnHeader1");
            manager.ApplyResources(this.columnHeader22, "columnHeader22");
            manager.ApplyResources(this.columnHeader2, "columnHeader2");
            manager.ApplyResources(this.columnHeader3, "columnHeader3");
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.tabMain);
            base.Name = "SevkiyatControl";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControlPalet.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPagePaket.ResumeLayout(false);
            this.tabPagePackkageIcerik.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lvwItems.SelectedIndices.Count > 0)
                {
                    ShortItemInfo tag = this.lvwItems.Items[this.lvwItems.SelectedIndices[0]].Tag as ShortItemInfo;
                    ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                        Token = ClientApplication.Instance.Token,
                        Value = new SelectParam()
                    };
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.InfoId = tag.StokId;
                    ServiceResultOfListOfRafSayimDetay detay = ClientApplication.Instance.Service.GetItemQty(param);
                    if (!detay.Result)
                    {
                        throw new Exception(detay.Message);
                    }
                    this.lvwOther.BeginUpdate();
                    this.lvwOther.Items.Clear();
                    if (detay != null)
                    {
                        for (int i = 0; i < detay.Value.Length; i++)
                        {
                            ListViewItem listViewItem = new ListViewItem {
                                Text = detay.Value[i].LocationCode
                            };
                            listViewItem.SubItems.Add(detay.Value[i].QtyPrm.ToString("0.00"));
                            listViewItem.Tag = detay.Value;
                            this.lvwOther.Items.Insert(0, listViewItem);
                        }
                        this.lvwOther.EndUpdate();
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void lvwOkutulanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSil.Enabled = this.lvwOkutulanlar.SelectedIndices.Count > 0;
        }

        private void lvwPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lvwPackageDetail.BeginUpdate();
                this.lvwPackageDetail.Items.Clear();
                PackageInfo tag = null;
                if (this.lvwPackages.SelectedIndices.Count > 0)
                {
                    tag = this.lvwPackages.Items[this.lvwPackages.SelectedIndices[0]].Tag as PackageInfo;
                }
                if (tag == null)
                {
                    this.btnDeletePackage.Enabled = false;
                }
                else
                {
                    this.btnDeletePackage.Enabled = true;
                    for (int i = 0; i < this._Details.Count; i++)
                    {
                        if (this._Details[i].PackageTraMId == tag.PackageTraMId)
                        {
                            this._AddPackageDetailToListView(this._Details[i]);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwPackageDetail.EndUpdate();
            }
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            this._SelectedItem = item;
            this.txtItemCode.Text = item.Name;
            this.btnEkle_Click(this, EventArgs.Empty);
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            this._SelectedRaf = raf;
            this.txtRaf.Text = raf.Name;
            this.txtItemCode.Focus();
        }

        private void tabControlPalet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlPalet.SelectedIndex == 3)
            {
                using (FormSelectSevkiyat sevkiyat = new FormSelectSevkiyat(ClientApplication.Instance.SelectedDepot))
                {
                    if ((sevkiyat.ShowDialog() == DialogResult.OK) && (sevkiyat.Selected != null))
                    {
                        SevkiyatControl control = new SevkiyatControl(sevkiyat.Selected);
                        base.MainForm.ShowControl(control);
                    }
                    else
                    {
                        base.MainForm.ShowControl(null);
                    }
                }
            }
        }

        private class ShortItemInfo
        {
            public ShortItemInfo(int stokId)
            {
                this.StokId = stokId;
                this.SourceDetails = new List<int>();
            }

            public List<int> SourceDetails { get; set; }

            public int StokId { get; set; }
        }
    }
}

