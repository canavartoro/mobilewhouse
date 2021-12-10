namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class RafHareketiControl : BaseControl
    {
        private Depot _Depot;
        private DocTra _SelectedDocTra;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf1;
        private NameIdItem _SelectedRaf2;
        private Button btnClose;
        private Button btnSave;
        private CheckBox chkSil;
        private IContainer components = null;
        private DecimalTextBox dcQty;
        private DateTimePicker dteDocDate;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListView lstDetails;
        private ColumnHeader Miktar;
        private ColumnHeader StokAd;
        private TextBox txtHareketKod;
        private RafTextBox txtRafCikis;
        private RafTextBox txtRafGiris;
        private BarkodTextBox txtStok;

        public RafHareketiControl()
        {
            this.InitializeComponent();
            this.FirstLoad = true;
            this.txtStok.DepoId = this.txtRafCikis.DepoId = this.txtRafGiris.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            this.dcQty.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledLocationTra;
            this.dcQty.Text = "1";
            ServiceRequestOfDepoHareketParam param = new ServiceRequestOfDepoHareketParam {
                Token = ClientApplication.Instance.Token,
                Value = new DepoHareketParam()
            };
            param.Value.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            ServiceResultOfRafHareketM tm = ClientApplication.Instance.Service.RafHareketIlkYukleme(param);
            if (tm.Result)
            {
                this.FirstLoad = false;
                this.RafHareketMId = tm.Value.Id;
                this._SelectedDocTra = new DocTra();
                this.txtHareketKod.Text = tm.Value.DocTra.DocTraCode;
                this.dteDocDate.Text = tm.Value.DocDate.Date.ToShortDateString();
                this.txtRafCikis.Enabled = true;
                this.txtRafGiris.Enabled = true;
                if (tm.Value.DocTra.Status == 1)
                {
                    this.txtRafCikis.Enabled = false;
                }
                if (tm.Value.DocTra.Status == 2)
                {
                    this.txtRafGiris.Enabled = false;
                }
                for (int i = 0; i < tm.Value.RafHareketDetayList.Length; i++)
                {
                    RafHareketD td = tm.Value.RafHareketDetayList[i];
                    ListViewItem listViewItem = new ListViewItem {
                        Text = td.ItemCode
                    };
                    listViewItem.SubItems.Add(td.QtyPrm.ToString());
                    listViewItem.Tag = td;
                    this.lstDetails.Items.Add(listViewItem);
                }
                this.txtHareketKod.Enabled = false;
            }
        }

        private static void _SetItemDetails(RafHareketD detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.ItemCode;
            item.SubItems.Add(detay.QtyPrm.ToString());
            item.Tag = detay;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.RafHareketMId == 0)
            {
                ClientApplication.ShowError("Raf Hareketi Bulunamadı...");
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                        Token = ClientApplication.Instance.Token,
                        Value = this.RafHareketMId
                    };
                    ServiceResultOfBoolean flag = ClientApplication.Instance.Service.RafHareketKaydet(param);
                    if (!flag.Result)
                    {
                        throw new Exception(flag.Message);
                    }
                    this.RafHareketMId = 0;
                    this.FirstLoad = true;
                    this._SelectedItem = null;
                    this._SelectedRaf1 = null;
                    this._SelectedRaf2 = null;
                    this._SelectedDocTra = null;
                    this.txtHareketKod.Text = string.Empty;
                    this.txtRafCikis.Text = string.Empty;
                    this.txtRafGiris.Text = string.Empty;
                    this.txtStok.Text = string.Empty;
                    this.dcQty.Text = "1";
                    this.lstDetails.Items.Clear();
                    this.txtHareketKod.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Kayıt Yapıldı");
                }
                catch (Exception exception)
                {
                    Cursor.Current = Cursors.Default;
                    ClientApplication.ShowError(exception);
                }
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
            this.lstDetails = new ListView();
            this.StokAd = new ColumnHeader();
            this.Miktar = new ColumnHeader();
            this.dteDocDate = new DateTimePicker();
            this.label5 = new Label();
            this.label4 = new Label();
            this.txtHareketKod = new TextBox();
            this.label1 = new Label();
            this.label6 = new Label();
            this.btnSave = new Button();
            this.txtStok = new BarkodTextBox();
            this.txtRafCikis = new RafTextBox();
            this.txtRafGiris = new RafTextBox();
            this.chkSil = new CheckBox();
            this.btnClose = new Button();
            this.dcQty = new DecimalTextBox();
            base.SuspendLayout();
            this.lstDetails.Columns.Add(this.StokAd);
            this.lstDetails.Columns.Add(this.Miktar);
            this.lstDetails.Location = new Point(2, 0x5c);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new Size(0xeb, 0x9d);
            this.lstDetails.TabIndex = 0x1a;
            this.lstDetails.View = View.Details;
            this.StokAd.Text = "Stok Adı";
            this.StokAd.Width = 0x9f;
            this.Miktar.Text = "Miktar";
            this.Miktar.Width = 70;
            this.dteDocDate.Format = DateTimePickerFormat.Short;
            this.dteDocDate.Location = new Point(0x4f, 0x2e);
            this.dteDocDate.Name = "dteDocDate";
            this.dteDocDate.Size = new Size(0x9e, 0x16);
            this.dteDocDate.TabIndex = 0x19;
            this.label5.Location = new Point(3, 0x2f);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x42, 20);
            this.label5.Text = "Belge Tarih";
            this.label4.Location = new Point(3, 0x17);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x44, 20);
            this.label4.Text = "Raf";
            this.txtHareketKod.Location = new Point(0x4f, 2);
            this.txtHareketKod.Name = "txtHareketKod";
            this.txtHareketKod.Size = new Size(0x9e, 0x15);
            this.txtHareketKod.TabIndex = 0x15;
            this.txtHareketKod.KeyDown += new KeyEventHandler(this.txtHareketKod_KeyDown);
            this.label1.Location = new Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x51, 20);
            this.label1.Text = "Hareket Kod";
            this.label6.Location = new Point(4, 0x44);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x2a, 20);
            this.label6.Text = "Barkod";
            this.btnSave.Location = new Point(0x9e, 0xfb);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x48, 20);
            this.btnSave.TabIndex = 0x23;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.IsTransfer = false;
            this.txtStok.Location = new Point(0x4f, 0x45);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new Size(110, 0x15);
            this.txtStok.TabIndex = 0x2c;
            this.txtRafCikis.DepoId = 0;
            this.txtRafCikis.Enabled = false;
            this.txtRafCikis.IsRaf = 1;
            this.txtRafCikis.IsTransfer = true;
            this.txtRafCikis.Location = new Point(0x4f, 0x18);
            this.txtRafCikis.Name = "txtRafCikis";
            this.txtRafCikis.Size = new Size(0x49, 0x15);
            this.txtRafCikis.TabIndex = 0x2d;
            this.txtRafGiris.DepoId = 0;
            this.txtRafGiris.Enabled = false;
            this.txtRafGiris.IsRaf = 1;
            this.txtRafGiris.IsTransfer = false;
            this.txtRafGiris.Location = new Point(0x9e, 0x18);
            this.txtRafGiris.Name = "txtRafGiris";
            this.txtRafGiris.Size = new Size(0x4f, 0x15);
            this.txtRafGiris.TabIndex = 0x2e;
            this.chkSil.Location = new Point(0x16, 0xfb);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new Size(0x2c, 20);
            this.chkSil.TabIndex = 0x30;
            this.chkSil.Text = "Sil";
            this.btnClose.Location = new Point(80, 0xfb);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.dcQty.Location = new Point(0xbf, 0x45);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new Size(0x2e, 0x15);
            this.dcQty.TabIndex = 0x42;
            int[] bits = new int[4];
            this.dcQty.Value = new decimal(bits);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.dcQty);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.chkSil);
            base.Controls.Add(this.txtRafGiris);
            base.Controls.Add(this.txtRafCikis);
            base.Controls.Add(this.txtStok);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.lstDetails);
            base.Controls.Add(this.dteDocDate);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.txtHareketKod);
            base.Controls.Add(this.label1);
            base.Name = "RafHareketiControl";
            base.ResumeLayout(false);
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                base.OnItemBarkod(item);
                this._SelectedItem = item;
                if (this._SelectedDocTra == null)
                {
                    MessageBox.Show("Hareket kodu se\x00e7iniz");
                }
                else if (this._SelectedItem == null)
                {
                    MessageBox.Show("Stok se\x00e7iniz");
                }
                else if ((this._SelectedRaf1 == null) && (this._SelectedRaf2 == null))
                {
                    MessageBox.Show("Raf Giriniz.");
                }
                else if ((this.txtRafCikis.Enabled && this.txtRafGiris.Enabled) && ((this._SelectedRaf1 == null) || (this._SelectedRaf2 == null)))
                {
                    MessageBox.Show("Raf Giriniz.");
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    decimal num = 0M;
                    num = this.dcQty.Value * this._SelectedItem.StokMultiplier;
                    if (num <= 0M)
                    {
                        throw new Exception("Miktar 0 yada negatif olamaz");
                    }
                    ListViewItem item2 = null;
                    RafHareketD detay = null;
                    string name = string.Empty;
                    string str2 = string.Empty;
                    int num2 = 0;
                    int num3 = 0;
                    if (this._SelectedRaf1 != null)
                    {
                        num2 = this._SelectedRaf1.Id;
                        name = this._SelectedRaf1.Name;
                    }
                    if (this._SelectedRaf2 != null)
                    {
                        num3 = this._SelectedRaf2.Id;
                        str2 = this._SelectedRaf2.Name;
                    }
                    if (num2 == 0)
                    {
                        num2 = num3;
                        name = str2;
                        num3 = 0;
                        str2 = string.Empty;
                    }
                    for (int i = 0; i < this.lstDetails.Items.Count; i++)
                    {
                        RafHareketD tag = this.lstDetails.Items[i].Tag as RafHareketD;
                        if (((tag.LocationId == num2) && (tag.LocationId2 == num3)) && (tag.ItemId == this._SelectedItem.Id))
                        {
                            item2 = this.lstDetails.Items[i];
                            detay = tag;
                            break;
                        }
                    }
                    if (detay != null)
                    {
                        if (this.chkSil.Checked)
                        {
                            if (num > detay.QtyPrm)
                            {
                                throw new Exception("Varolandan daha fazla urun siliyorsunuz");
                            }
                            detay.QtyPrm -= num;
                        }
                        else
                        {
                            detay.QtyPrm += num;
                        }
                    }
                    else
                    {
                        if (this.chkSil.Checked)
                        {
                            throw new Exception("Bu stok zaten bu sayimda yok");
                        }
                        detay = new RafHareketD {
                            QtyPrm = num,
                            ItemCode = this._SelectedItem.Description,
                            ItemId = this._SelectedItem.Id,
                            UnitId = item.UnitId
                        };
                        if (num2 != 0)
                        {
                            detay.LocationCode = name;
                            detay.LocationId = num2;
                        }
                        if (num3 != 0)
                        {
                            detay.LocationId2 = num3;
                        }
                    }
                    if (item2 == null)
                    {
                        item2 = new ListViewItem();
                        _SetItemDetails(detay, item2);
                        this.lstDetails.Items.Insert(0, item2);
                    }
                    else if (detay.QtyPrm == 0M)
                    {
                        this.lstDetails.Items.Remove(item2);
                    }
                    else
                    {
                        _SetItemDetails(detay, item2);
                    }
                    if (this.FirstLoad)
                    {
                        ServiceRequestOfRafHareketM param = new ServiceRequestOfRafHareketM {
                            Token = ClientApplication.Instance.Token,
                            Value = new RafHareketM()
                        };
                        param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                        param.Value.DocDate = this.dteDocDate.Value;
                        param.Value.RafHareketDetay = new RafHareketD();
                        param.Value.RafHareketDetay.ItemId = this._SelectedItem.Id;
                        param.Value.RafHareketDetay.UnitId = this._SelectedItem.UnitId;
                        param.Value.DocTra = this._SelectedDocTra;
                        param.Value.RafHareketDetay.LocationId = num2;
                        if ((this._SelectedRaf1 != null) && (this._SelectedRaf2 != null))
                        {
                            param.Value.RafHareketDetay.LocationId2 = this._SelectedRaf2.Id;
                        }
                        param.Value.RafHareketDetay.QtyPrm = ((RafHareketD) item2.Tag).QtyPrm;
                        ServiceResultOfListOfInt32 num5 = ClientApplication.Instance.Service.InsertRafHareketFisiFirst(param);
                        if (!num5.Result)
                        {
                            throw new Exception(num5.Message);
                        }
                        this.RafHareketMId = num5.Value[0];
                        RafHareketD td3 = item2.Tag as RafHareketD;
                        td3.Id = num5.Value[1];
                        this.FirstLoad = false;
                    }
                    else
                    {
                        RafHareketD td4 = (RafHareketD) item2.Tag;
                        ServiceRequestOfRafHareketInfo info = new ServiceRequestOfRafHareketInfo {
                            Token = ClientApplication.Instance.Token,
                            Value = new RafHareketInfo()
                        };
                        info.Value.RafHareketDetail = td4;
                        info.Value.RafHareketMId = this.RafHareketMId;
                        info.Value.RafHareketDetail.UnitId = td4.UnitId;
                        info.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                        ServiceResultOfInt32 num6 = ClientApplication.Instance.Service.InsertRafHareketFisiDevam(info);
                        if (!num6.Result)
                        {
                            throw new Exception(num6.Message);
                        }
                        td4.Id = num6.Value;
                    }
                    this._SelectedItem = null;
                    this.txtStok.Text = string.Empty;
                    this.txtStok.Focus();
                    this.dcQty.Text = "1";
                    if (this.lstDetails.Items.Count > 0)
                    {
                        this.txtHareketKod.Enabled = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Default;
                ClientApplication.ShowError(exception);
            }
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            if (this.txtRafGiris.Focused)
            {
                this._SelectedRaf2 = raf;
                this.txtRafGiris.Text = raf.Name;
            }
            else if (this.txtRafCikis.Focused)
            {
                this._SelectedRaf1 = raf;
                this.txtRafCikis.Text = raf.Name;
            }
            else if (this.txtRafGiris.Enabled)
            {
                this._SelectedRaf2 = raf;
                this.txtRafGiris.Text = raf.Name;
            }
            else if (this.txtRafCikis.Enabled)
            {
                this._SelectedRaf1 = raf;
                this.txtRafCikis.Text = raf.Name;
            }
            this.txtStok.Focus();
        }

        private void txtHareketKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtHareketKod.Enabled && (e.KeyCode == Keys.Enter))
            {
                FormSelectHareketKod kod = new FormSelectHareketKod();
                if ((kod.ShowDialog() == DialogResult.OK) && (kod.Selected != null))
                {
                    this.txtHareketKod.Text = kod.Selected.DocTraCode;
                    this._SelectedDocTra = kod.Selected;
                    if ((this._SelectedDocTra.Status == 1) || (this._SelectedDocTra.Status == 4))
                    {
                        this.txtRafGiris.Enabled = true;
                        this.txtRafCikis.Enabled = false;
                    }
                    else if (this._SelectedDocTra.Status == 2)
                    {
                        this.txtRafGiris.Enabled = false;
                        this.txtRafCikis.Enabled = true;
                    }
                    else if (this._SelectedDocTra.Status == 3)
                    {
                        this.txtRafGiris.Enabled = true;
                        this.txtRafCikis.Enabled = true;
                    }
                }
            }
        }

        private void txtWhouseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormSelectDepot depot = new FormSelectDepot();
                if ((depot.ShowDialog() == DialogResult.OK) && (depot.Selected != null))
                {
                    this._Depot = depot.Selected;
                }
            }
        }

        public bool FirstLoad { get; set; }

        public int RafHareketMId { get; set; }

        public enum InventoryStatus
        {
            Cikis = 2,
            Devir = 4,
            Giris = 1,
            Transfer = 3
        }
    }
}

