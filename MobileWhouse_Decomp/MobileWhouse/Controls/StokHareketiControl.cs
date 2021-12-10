namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class StokHareketiControl : BaseControl
    {
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private Depot _TargetDepot;
        private Button btnClose;
        private Button btnKaydet;
        private Button btnRaf;
        private CheckBox chkSil;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private IContainer components;
        private DateTimePicker dtDocDate;
        private bool FirstLoad;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblDepo;
        private Label lblTargetDepo;
        private ListView lstDetails;
        private int RafHareketMId;
        private BarkodTextBox txtItemCode;
        private DecimalTextBox txtMiktar;
        private RafTextBox txtRaf;

        public StokHareketiControl()
        {
            this.components = null;
            this.InitializeComponent();
            this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public StokHareketiControl(Depot target)
        {
            this.components = null;
            try
            {
                this.InitializeComponent();
                this._TargetDepot = target;
                this.lblTargetDepo.Text = target.Name;
                this.lblDepo.Text = ClientApplication.Instance.SelectedDepot.Name;
                this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
                this._LoadItem();
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void _LoadItem()
        {
            this.FirstLoad = true;
            this.txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledLocationTra;
            this.txtMiktar.Text = "1";
            ServiceRequestOfDepoHareketParam param = new ServiceRequestOfDepoHareketParam {
                Token = ClientApplication.Instance.Token,
                Value = new DepoHareketParam()
            };
            param.Value.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            param.Value.HedefDepoId = this._TargetDepot.Id;
            ServiceResultOfRafHareketM tm = ClientApplication.Instance.Service.RafHareketIlkYukleme(param);
            if (tm.Result)
            {
                this.FirstLoad = false;
                this.RafHareketMId = tm.Value.Id;
                this.dtDocDate.Value = tm.Value.DocDate;
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

        private void btnRaf_Click(object sender, EventArgs e)
        {
            using (FormSelectRaf raf = new FormSelectRaf(ClientApplication.Instance.SelectedDepot))
            {
                if ((raf.ShowDialog() == DialogResult.OK) && (raf.Selected != null))
                {
                    this.txtRaf.Text = raf.Selected.Name;
                }
            }
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
                    Cursor.Current = Cursors.Default;
                    this.RafHareketMId = 0;
                    this.FirstLoad = true;
                    this._SelectedItem = null;
                    this._SelectedRaf = null;
                    this.txtRaf.Text = string.Empty;
                    this.txtItemCode.Text = string.Empty;
                    this.txtMiktar.Text = "1";
                    this.lstDetails.Items.Clear();
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.lblDepo = new Label();
            this.btnRaf = new Button();
            this.label4 = new Label();
            this.lstDetails = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.btnKaydet = new Button();
            this.btnClose = new Button();
            this.txtMiktar = new DecimalTextBox();
            this.lblTargetDepo = new Label();
            this.label5 = new Label();
            this.dtDocDate = new DateTimePicker();
            this.label6 = new Label();
            this.txtRaf = new RafTextBox();
            this.txtItemCode = new BarkodTextBox();
            this.chkSil = new CheckBox();
            base.SuspendLayout();
            this.label1.Location = new Point(4, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x36, 0x10);
            this.label1.Text = "Kyn.Depo";
            this.label2.Location = new Point(4, 0x30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x36, 0x10);
            this.label2.Text = "Kyn.Raf";
            this.lblDepo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.lblDepo.Location = new Point(0x51, 0x17);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new Size(0x9c, 0x10);
            this.btnRaf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnRaf.Location = new Point(0xd6, 0x2b);
            this.btnRaf.Name = "btnRaf";
            this.btnRaf.Size = new Size(0x17, 20);
            this.btnRaf.TabIndex = 7;
            this.btnRaf.Text = "...";
            this.btnRaf.Click += new EventHandler(this.btnRaf_Click);
            this.label4.Location = new Point(4, 0x48);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x36, 0x10);
            this.label4.Text = "Stok";
            this.lstDetails.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lstDetails.Columns.Add(this.columnHeader1);
            this.lstDetails.Columns.Add(this.columnHeader2);
            this.lstDetails.Location = new Point(4, 0x6f);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new Size(0xe9, 0x87);
            this.lstDetails.TabIndex = 13;
            this.lstDetails.View = View.Details;
            this.columnHeader1.Text = "Stok Adı";
            this.columnHeader1.Width = 0x88;
            this.columnHeader2.Text = "Miktar";
            this.columnHeader2.Width = 60;
            this.btnKaydet.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnKaydet.Location = new Point(0xa5, 0xf8);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(0x48, 20);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new EventHandler(this.btnSave_Click);
            this.btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(0x57, 0xf8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.txtMiktar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtMiktar.Location = new Point(0xc0, 0x41);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new Size(0x2d, 0x15);
            this.txtMiktar.TabIndex = 0x10;
            int[] bits = new int[4];
            this.txtMiktar.Value = new decimal(bits);
            this.lblTargetDepo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.lblTargetDepo.Location = new Point(0x51, 5);
            this.lblTargetDepo.Name = "lblTargetDepo";
            this.lblTargetDepo.Size = new Size(0x9c, 0x10);
            this.label5.Location = new Point(4, 5);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x36, 0x10);
            this.label5.Text = "Hdf.Depo";
            this.dtDocDate.Format = DateTimePickerFormat.Short;
            this.dtDocDate.Location = new Point(0x51, 0x57);
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.Size = new Size(0x9c, 0x16);
            this.dtDocDate.TabIndex = 0x1b;
            this.label6.Location = new Point(3, 0x5d);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x42, 0x10);
            this.label6.Text = "Belge Tarih";
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new Point(0x51, 0x2b);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new Size(0x83, 0x15);
            this.txtRaf.TabIndex = 0x1d;
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.Location = new Point(0x51, 0x41);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new Size(0x6d, 0x15);
            this.txtItemCode.TabIndex = 30;
            this.chkSil.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.chkSil.Location = new Point(3, 0xf9);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new Size(0x37, 20);
            this.chkSil.TabIndex = 0x26;
            this.chkSil.Text = "Sil";
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.chkSil);
            base.Controls.Add(this.txtItemCode);
            base.Controls.Add(this.txtRaf);
            base.Controls.Add(this.dtDocDate);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.lblTargetDepo);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.txtMiktar);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnKaydet);
            base.Controls.Add(this.lstDetails);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.btnRaf);
            base.Controls.Add(this.lblDepo);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "StokHareketiControl";
            base.ResumeLayout(false);
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                base.OnItemBarkod(item);
                this._SelectedItem = item;
                if (this._SelectedItem == null)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Stok se\x00e7iniz");
                }
                else if (this._SelectedRaf == null)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Raf Giriniz.");
                }
                else
                {
                    decimal num = 0M;
                    num = this.txtMiktar.Value * this._SelectedItem.StokMultiplier;
                    if (num <= 0M)
                    {
                        throw new Exception("Miktar 0 yada negatif olamaz");
                    }
                    ListViewItem item2 = null;
                    RafHareketD detay = null;
                    for (int i = 0; i < this.lstDetails.Items.Count; i++)
                    {
                        RafHareketD tag = this.lstDetails.Items[i].Tag as RafHareketD;
                        if ((tag.LocationId == this._SelectedRaf.Id) && (tag.ItemId == this._SelectedItem.Id))
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
                            UnitId = item.UnitId,
                            LocationCode = this._SelectedRaf.Name,
                            LocationId = this._SelectedRaf.Id
                        };
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
                        param.Value.Whouse2Id = this._TargetDepot.Id;
                        param.Value.DocDate = this.dtDocDate.Value;
                        param.Value.RafHareketDetay = new RafHareketD();
                        param.Value.RafHareketDetay.ItemId = this._SelectedItem.Id;
                        param.Value.RafHareketDetay.UnitId = this._SelectedItem.UnitId;
                        param.Value.RafHareketDetay.LocationId = (this._SelectedRaf == null) ? 0 : this._SelectedRaf.Id;
                        param.Value.RafHareketDetay.QtyPrm = ((RafHareketD) item2.Tag).QtyPrm;
                        ServiceResultOfListOfInt32 num3 = ClientApplication.Instance.Service.InsertRafHareketFisiFirst(param);
                        if (!num3.Result)
                        {
                            throw new Exception(num3.Message);
                        }
                        this.RafHareketMId = num3.Value[0];
                        RafHareketD td3 = item2.Tag as RafHareketD;
                        td3.Id = num3.Value[1];
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
                        info.Value.Whouse2Id = this._TargetDepot.Id;
                        ServiceResultOfInt32 num4 = ClientApplication.Instance.Service.InsertRafHareketFisiDevam(info);
                        if (!num4.Result)
                        {
                            throw new Exception(num4.Message);
                        }
                        td4.Id = num4.Value;
                    }
                    Cursor.Current = Cursors.Default;
                    this._SelectedItem = null;
                    this.txtItemCode.Text = string.Empty;
                    this.txtItemCode.Focus();
                    this.txtMiktar.Text = "1";
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
            try
            {
                base.OnRafBarkod(raf);
                this._SelectedRaf = raf;
                this.txtRaf.Text = raf.Name;
                this.txtItemCode.Focus();
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }
    }
}

