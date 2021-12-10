namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PaletOlusturmaControl : BaseControl
    {
        private PackageInfo _PackageInfo = null;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private ColumnHeader Birim;
        private Button btnClose;
        private Button btnYeniPalet;
        private CheckBox checkBox1;
        private CheckBox chkSil;
        private IContainer components = null;
        private DecimalTextBox dcQty;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView lstPackageDetail;
        private ColumnHeader Miktar;
        private ColumnHeader StokKod;
        private TextBox txtPaletNo;
        private RafTextBox txtRaf;
        private BarkodTextBox txtStok;

        public PaletOlusturmaControl()
        {
            this.InitializeComponent();
            this.dcQty.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledPackage;
            this.dcQty.Text = "1";
            this.dcQty.Value = 1M;
            this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            this.txtStok.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        private static void _SetItemDetails(PackageDetail detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.ItemInfo.Name;
            item.SubItems.Add(detay.ItemInfo.UnitCode.ToString());
            item.SubItems.Add(detay.Qty.ToString());
            item.Tag = detay;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
        }

        private void btnYeniPalet_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                    Value = new SelectParam(),
                    Token = ClientApplication.Instance.Token
                };
                param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfPackageInfo info = ClientApplication.Instance.Service.CreateNewPackage(param);
                if (!info.Result)
                {
                    throw new Exception(info.Message);
                }
                this._PackageInfo = info.Value;
                this.txtPaletNo.Text = info.Value.PackageNo;
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
            this.label1 = new Label();
            this.txtPaletNo = new TextBox();
            this.btnYeniPalet = new Button();
            this.label2 = new Label();
            this.lstPackageDetail = new ListView();
            this.StokKod = new ColumnHeader();
            this.Birim = new ColumnHeader();
            this.Miktar = new ColumnHeader();
            this.txtStok = new BarkodTextBox();
            this.txtRaf = new RafTextBox();
            this.label3 = new Label();
            this.dcQty = new DecimalTextBox();
            this.chkSil = new CheckBox();
            this.btnClose = new Button();
            this.checkBox1 = new CheckBox();
            base.SuspendLayout();
            this.label1.Location = new Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x36, 20);
            this.label1.Text = "Palet No";
            this.txtPaletNo.Location = new Point(0x3f, 3);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new Size(100, 0x15);
            this.txtPaletNo.TabIndex = 1;
            this.btnYeniPalet.Location = new Point(0xa9, 4);
            this.btnYeniPalet.Name = "btnYeniPalet";
            this.btnYeniPalet.Size = new Size(0x33, 20);
            this.btnYeniPalet.TabIndex = 3;
            this.btnYeniPalet.Text = "Yeni";
            this.btnYeniPalet.Click += new EventHandler(this.btnYeniPalet_Click);
            this.label2.Location = new Point(3, 0x2f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x36, 20);
            this.label2.Text = "Stok";
            this.lstPackageDetail.Columns.Add(this.StokKod);
            this.lstPackageDetail.Columns.Add(this.Birim);
            this.lstPackageDetail.Columns.Add(this.Miktar);
            this.lstPackageDetail.Location = new Point(3, 0x4a);
            this.lstPackageDetail.Name = "lstPackageDetail";
            this.lstPackageDetail.Size = new Size(0xea, 0xa8);
            this.lstPackageDetail.TabIndex = 6;
            this.lstPackageDetail.View = View.Details;
            this.StokKod.Text = "Stok Kod";
            this.StokKod.Width = 110;
            this.Birim.Text = "Birim";
            this.Birim.Width = 60;
            this.Miktar.Text = "Miktar";
            this.Miktar.Width = 60;
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.Location = new Point(0x3f, 0x2f);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new Size(100, 0x15);
            this.txtStok.TabIndex = 7;
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new Point(0x3f, 0x19);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new Size(100, 0x15);
            this.txtRaf.TabIndex = 8;
            this.label3.Location = new Point(3, 0x19);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x36, 20);
            this.label3.Text = "Raf";
            this.dcQty.Location = new Point(0xa9, 0x2f);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new Size(0x27, 0x15);
            this.dcQty.TabIndex = 10;
            int[] bits = new int[4];
            this.dcQty.Value = new decimal(bits);
            this.chkSil.Location = new Point(0xa9, 0x19);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new Size(0x33, 20);
            this.chkSil.TabIndex = 11;
            this.chkSil.Text = "Sil";
            this.btnClose.Location = new Point(0xa5, 0xf4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 0x3e;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.checkBox1.Location = new Point(0x73, 0xf5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x2c, 20);
            this.checkBox1.TabIndex = 0x3d;
            this.checkBox1.Text = "Sil";
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.chkSil);
            base.Controls.Add(this.dcQty);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.txtRaf);
            base.Controls.Add(this.txtStok);
            base.Controls.Add(this.lstPackageDetail);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.btnYeniPalet);
            base.Controls.Add(this.txtPaletNo);
            base.Controls.Add(this.label1);
            base.Name = "PaletOlusturmaControl";
            base.ResumeLayout(false);
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            try
            {
                base.OnItemBarkod(item);
                this._SelectedItem = item;
                if (this._SelectedRaf == null)
                {
                    throw new Exception("Raf se\x00e7ilmemiş");
                }
                if (this._SelectedItem == null)
                {
                    throw new Exception("Stok Se\x00e7ilmemiş");
                }
                if (this._PackageInfo == null)
                {
                    throw new Exception("\x00d6nce yeni paket oluşturun.");
                }
                decimal num = 0M;
                num = this.dcQty.Value * this._SelectedItem.StokMultiplier;
                if (num <= 0M)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }
                ListViewItem item2 = null;
                PackageDetail detay = null;
                for (int i = 0; i < this.lstPackageDetail.Items.Count; i++)
                {
                    PackageDetail tag = this.lstPackageDetail.Items[i].Tag as PackageDetail;
                    if ((tag.LocationId == this._SelectedRaf.Id) && (tag.ItemInfo.Id == this._SelectedItem.Id))
                    {
                        item2 = this.lstPackageDetail.Items[i];
                        detay = tag;
                        break;
                    }
                }
                if (detay != null)
                {
                    if (this.chkSil.Checked)
                    {
                        if (num > detay.Qty)
                        {
                            throw new Exception("Varolandan daha fazla urun siliyorsunuz");
                        }
                        detay.Qty -= num;
                    }
                    else
                    {
                        detay.Qty += num;
                    }
                }
                else
                {
                    if (this.chkSil.Checked)
                    {
                        throw new Exception("Bu stok zaten bu sayimda yok");
                    }
                    detay = new PackageDetail {
                        Qty = num,
                        ItemInfo = this._SelectedItem
                    };
                    if (this._SelectedRaf != null)
                    {
                        detay.LocationId = this._SelectedRaf.Id;
                    }
                }
                if (item2 == null)
                {
                    item2 = new ListViewItem();
                    _SetItemDetails(detay, item2);
                    this.lstPackageDetail.Items.Insert(0, item2);
                }
                else if (detay.Qty == 0M)
                {
                    this.lstPackageDetail.Items.Remove(item2);
                }
                else
                {
                    _SetItemDetails(detay, item2);
                }
                ServiceRequestOfPackageDetail param = new ServiceRequestOfPackageDetail {
                    Value = new PackageDetail(),
                    Token = ClientApplication.Instance.Token
                };
                param.Value.ItemInfo = this._SelectedItem;
                param.Value.LocationId = this._SelectedRaf.Id;
                param.Value.PackageMId = this._PackageInfo.PackageMId;
                param.Value.PackageDId = detay.PackageDId;
                param.Value.PackageTraDId = detay.PackageTraDId;
                param.Value.PackageTraMId = this._PackageInfo.PackageTraMId;
                param.Value.Qty = detay.Qty;
                ServiceResultOfPackageDetailResult result = ClientApplication.Instance.Service.SavePackageDetail(param);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }
                detay.PackageDId = result.Value.PackageDId;
                detay.PackageTraDId = result.Value.PackageTraDId;
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            this._SelectedRaf = raf;
            this.txtRaf.Text = raf.Name;
        }
    }
}

