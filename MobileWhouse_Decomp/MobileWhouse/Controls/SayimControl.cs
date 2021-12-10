namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SayimControl : BaseControl
    {
        private List<RafSayimDetay> _Details;
        private RafSayimFisi _Fis;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private Button btnClose;
        private Button btnSave;
        private CheckBox chkSil;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private IContainer components;
        private DateTimePicker dtDocDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView lvwItems;
        private TextBox txtBelgeNo;
        private BarkodTextBox txtItemCode;
        private DecimalTextBox txtMiktar;
        private RafTextBox txtRaf;

        public SayimControl()
        {
            this.components = null;
            this.InitializeComponent();
            this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public SayimControl(RafSayimFisi fis, bool loadDetails)
        {
            this.components = null;
            this.InitializeComponent();
            this.txtItemCode.DepoId = this.txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            this._Fis = fis;
            this.txtBelgeNo.Text = fis.DocNo;
            this.dtDocDate.Value = fis.Date;
            this.txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledCycleCount;
            this.txtMiktar.Text = "1";
            if (loadDetails)
            {
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                    Token = ClientApplication.Instance.Token,
                    Value = fis.Id
                };
                ServiceResultOfListOfRafSayimDetay rafSayimDetaylari = ClientApplication.Instance.Service.GetRafSayimDetaylari(param);
                if (!rafSayimDetaylari.Result)
                {
                    throw new Exception(rafSayimDetaylari.Message);
                }
                try
                {
                    this.lvwItems.BeginUpdate();
                    this._Details = new List<RafSayimDetay>();
                    this._Details.AddRange(rafSayimDetaylari.Value);
                    for (int i = 0; i < rafSayimDetaylari.Value.Length; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        _SetItemDetails(rafSayimDetaylari.Value[i], item);
                        this.lvwItems.Items.Add(item);
                    }
                }
                finally
                {
                    this.lvwItems.EndUpdate();
                }
            }
            else
            {
                this._Details = new List<RafSayimDetay>();
            }
        }

        private static void _SetItemDetails(RafSayimDetay detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.LocationCode;
            item.SubItems.Add(detay.ItemCode);
            item.SubItems.Add(detay.QtyPrm.ToString());
            item.Tag = detay;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._SelectedItem == null)
                {
                    MessageBox.Show("Stokkodu se\x00e7iniz...");
                }
                else if (this._SelectedRaf == null)
                {
                    MessageBox.Show("Raf se\x00e7iniz...");
                }
                else
                {
                    decimal num = this.txtMiktar.Value;
                    if (num != 0M)
                    {
                        num *= this._SelectedItem.StokMultiplier;
                        if (num <= 0M)
                        {
                            throw new Exception("Miktar 0 yada negatif olamaz");
                        }
                        ListViewItem item = null;
                        RafSayimDetay detay = null;
                        for (int i = 0; i < this.lvwItems.Items.Count; i++)
                        {
                            RafSayimDetay tag = this.lvwItems.Items[i].Tag as RafSayimDetay;
                            if ((tag.LocationId == this._SelectedRaf.Id) && (tag.ItemId == this._SelectedItem.Id))
                            {
                                item = this.lvwItems.Items[i];
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
                            detay = new RafSayimDetay {
                                QtyPrm = num,
                                ItemCode = this._SelectedItem.Name,
                                ItemId = this._SelectedItem.Id,
                                LocationCode = this._SelectedRaf.Name,
                                LocationId = this._SelectedRaf.Id
                            };
                        }
                        ServiceRequestOfRafSayimKayitInfo param = new ServiceRequestOfRafSayimKayitInfo {
                            Token = ClientApplication.Instance.Token,
                            Value = new RafSayimKayitInfo()
                        };
                        param.Value.DepotId = this._Fis.DepoId;
                        param.Value.Detay = detay;
                        param.Value.MasterId = this._Fis.Id;
                        ServiceResultOfBoolean flag = ClientApplication.Instance.Service.SaveRafSayimDetay(param);
                        if (!flag.Result)
                        {
                            throw new Exception(flag.Message);
                        }
                        if (item == null)
                        {
                            item = new ListViewItem();
                            _SetItemDetails(detay, item);
                            this.lvwItems.Items.Insert(0, item);
                        }
                        else
                        {
                            _SetItemDetails(detay, item);
                        }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this._Fis.Date = this.dtDocDate.Value;
                this._Fis.DocNo = this.txtBelgeNo.Text;
                ServiceRequestOfRafSayimFisi fis = new ServiceRequestOfRafSayimFisi {
                    Token = ClientApplication.Instance.Token,
                    Value = this._Fis
                };
                ServiceResultOfBoolean flag = ClientApplication.Instance.Service.SaveRafSayimFisi(fis);
                if (!flag.Result)
                {
                    throw new Exception(flag.Message);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void chkSil_CheckStateChanged(object sender, EventArgs e)
        {
            this.txtItemCode.Focus();
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
            this.txtBelgeNo = new TextBox();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.lvwItems = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.dtDocDate = new DateTimePicker();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.txtRaf = new RafTextBox();
            this.txtItemCode = new BarkodTextBox();
            this.chkSil = new CheckBox();
            this.txtMiktar = new DecimalTextBox();
            base.SuspendLayout();
            this.label1.Location = new Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x52, 0x10);
            this.label1.Text = "BelgeN/Tarih";
            this.txtBelgeNo.Location = new Point(80, 2);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new Size(0x3f, 0x15);
            this.txtBelgeNo.TabIndex = 1;
            this.btnSave.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnSave.Location = new Point(4, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x8d, 20);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Belge No Kaydet";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(0xa5, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.lvwItems.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwItems.Columns.Add(this.columnHeader1);
            this.lvwItems.Columns.Add(this.columnHeader2);
            this.lvwItems.Columns.Add(this.columnHeader3);
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Location = new Point(4, 0x5e);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new Size(0xe9, 0x9a);
            this.lvwItems.TabIndex = 5;
            this.lvwItems.View = View.Details;
            this.columnHeader1.Text = "Raf";
            this.columnHeader1.Width = 60;
            this.columnHeader2.Text = "Stok Kodu";
            this.columnHeader2.Width = 0x4e;
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 70;
            this.dtDocDate.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.dtDocDate.Format = DateTimePickerFormat.Short;
            this.dtDocDate.Location = new Point(0x92, 1);
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.Size = new Size(0x5c, 0x16);
            this.dtDocDate.TabIndex = 7;
            this.label2.Location = new Point(1, 0x1c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x48, 0x10);
            this.label2.Text = "Raf";
            this.label3.Location = new Point(1, 0x34);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x48, 0x10);
            this.label3.Text = "Kod";
            this.label4.Location = new Point(1, 0x4a);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x48, 0x10);
            this.label4.Text = "Miktar";
            this.txtRaf.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new Point(80, 0x19);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new Size(100, 0x15);
            this.txtRaf.TabIndex = 0x13;
            this.txtItemCode.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.Location = new Point(80, 0x30);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new Size(100, 0x15);
            this.txtItemCode.TabIndex = 20;
            this.chkSil.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.chkSil.Location = new Point(0xb5, 0x49);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new Size(0x36, 20);
            this.chkSil.TabIndex = 0x19;
            this.chkSil.Text = "Sil";
            this.chkSil.CheckStateChanged += new EventHandler(this.chkSil_CheckStateChanged);
            this.txtMiktar.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtMiktar.Location = new Point(80, 0x47);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new Size(100, 0x15);
            this.txtMiktar.TabIndex = 30;
            int[] bits = new int[4];
            this.txtMiktar.Value = new decimal(bits);
            base.AutoScaleMode = AutoScaleMode.Inherit;
            base.Controls.Add(this.txtMiktar);
            base.Controls.Add(this.chkSil);
            base.Controls.Add(this.txtItemCode);
            base.Controls.Add(this.txtRaf);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.dtDocDate);
            base.Controls.Add(this.lvwItems);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.txtBelgeNo);
            base.Controls.Add(this.label1);
            base.Name = "SayimControl";
            base.ResumeLayout(false);
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
    }
}

