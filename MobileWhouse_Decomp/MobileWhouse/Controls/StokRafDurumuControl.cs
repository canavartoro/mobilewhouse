namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class StokRafDurumuControl : BaseControl
    {
        private Button btnListele;
        private Button btnShowItem;
        private Button btnShowRaf;
        private Button button1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private IContainer components = null;
        private Label label2;
        private Label label3;
        private ListView lvwInfos;
        private BarkodTextBox txtItemCode;
        private RafTextBox txtLocationCode;

        public StokRafDurumuControl()
        {
            this.InitializeComponent();
            this.txtItemCode.DepoId = this.txtLocationCode.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfStokRafSelectParam param = new ServiceRequestOfStokRafSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new StokRafSelectParam()
                };
                param.Value.LocationCode = this.txtLocationCode.Text.Trim();
                param.Value.ItemCode = this.txtItemCode.Text.Trim();
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfListOfStokRafInfo stokRafInfo = ClientApplication.Instance.Service.GetStokRafInfo(param);
                this.lvwInfos.BeginUpdate();
                this.lvwInfos.Items.Clear();
                for (int i = 0; i < stokRafInfo.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = stokRafInfo.Value[i].ItemCode
                    };
                    listViewItem.SubItems.Add(stokRafInfo.Value[i].ItemName);
                    listViewItem.SubItems.Add(stokRafInfo.Value[i].Qty.ToString());
                    listViewItem.SubItems.Add(stokRafInfo.Value[i].UnitCode);
                    listViewItem.SubItems.Add(stokRafInfo.Value[i].LocationCode);
                    listViewItem.Tag = stokRafInfo.Value[i];
                    this.lvwInfos.Items.Add(listViewItem);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwInfos.EndUpdate();
            }
        }

        private void btnShowItem_Click(object sender, EventArgs e)
        {
            using (FormSelectItem item = new FormSelectItem())
            {
                if ((item.ShowDialog() == DialogResult.OK) && (item.Selected != null))
                {
                    this.txtItemCode.Text = item.Selected.Name;
                }
            }
        }

        private void btnShowRaf_Click(object sender, EventArgs e)
        {
            using (FormSelectRaf raf = new FormSelectRaf(ClientApplication.Instance.SelectedDepot))
            {
                if ((raf.ShowDialog() == DialogResult.OK) && (raf.Selected != null))
                {
                    this.txtLocationCode.Text = raf.Selected.Name;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
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
            this.lvwInfos = new ListView();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader5 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.columnHeader1 = new ColumnHeader();
            this.btnListele = new Button();
            this.txtItemCode = new BarkodTextBox();
            this.txtLocationCode = new RafTextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.button1 = new Button();
            this.btnShowRaf = new Button();
            this.btnShowItem = new Button();
            base.SuspendLayout();
            this.lvwInfos.Columns.Add(this.columnHeader2);
            this.lvwInfos.Columns.Add(this.columnHeader5);
            this.lvwInfos.Columns.Add(this.columnHeader3);
            this.lvwInfos.Columns.Add(this.columnHeader4);
            this.lvwInfos.Columns.Add(this.columnHeader1);
            this.lvwInfos.FullRowSelect = true;
            this.lvwInfos.Location = new Point(4, 60);
            this.lvwInfos.Name = "lvwInfos";
            this.lvwInfos.Size = new Size(0xe9, 0xd6);
            this.lvwInfos.TabIndex = 6;
            this.lvwInfos.View = View.Details;
            this.columnHeader2.Text = "Stok Kodu";
            this.columnHeader2.Width = 60;
            this.columnHeader5.Text = "Stok Adı";
            this.columnHeader5.Width = 80;
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 50;
            this.columnHeader4.Text = "Br.";
            this.columnHeader4.Width = 40;
            this.columnHeader1.Text = "Raf";
            this.columnHeader1.Width = 60;
            this.btnListele.Location = new Point(0xc3, 0x21);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new Size(0x2a, 0x15);
            this.btnListele.TabIndex = 14;
            this.btnListele.Text = "Ara";
            this.btnListele.Click += new EventHandler(this.btnListele_Click);
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.Location = new Point(0x4c, 0x21);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new Size(0x5c, 0x15);
            this.txtItemCode.TabIndex = 0x18;
            this.txtLocationCode.DepoId = 0;
            this.txtLocationCode.IsRaf = 1;
            this.txtLocationCode.Location = new Point(0x4c, 9);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new Size(0x5c, 0x15);
            this.txtLocationCode.TabIndex = 0x17;
            this.label3.Location = new Point(9, 0x26);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x48, 0x10);
            this.label3.Text = "Stok Kodu";
            this.label2.Location = new Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x48, 0x10);
            this.label2.Text = "Raf";
            this.button1.Location = new Point(0xc3, 9);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x29, 0x15);
            this.button1.TabIndex = 0x1b;
            this.button1.Text = "X";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.btnShowRaf.Location = new Point(0xa6, 9);
            this.btnShowRaf.Name = "btnShowRaf";
            this.btnShowRaf.Size = new Size(0x1a, 0x15);
            this.btnShowRaf.TabIndex = 30;
            this.btnShowRaf.Text = "...";
            this.btnShowRaf.Click += new EventHandler(this.btnShowRaf_Click);
            this.btnShowItem.Location = new Point(0xa6, 0x21);
            this.btnShowItem.Name = "btnShowItem";
            this.btnShowItem.Size = new Size(0x1a, 0x15);
            this.btnShowItem.TabIndex = 0x1f;
            this.btnShowItem.Text = "...";
            this.btnShowItem.Click += new EventHandler(this.btnShowItem_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.btnShowItem);
            base.Controls.Add(this.btnShowRaf);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.txtItemCode);
            base.Controls.Add(this.txtLocationCode);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.btnListele);
            base.Controls.Add(this.lvwInfos);
            base.Name = "StokRafDurumuControl";
            base.ResumeLayout(false);
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            this.txtItemCode.Text = item.Name;
            this.btnListele_Click(this.btnListele, EventArgs.Empty);
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            this.txtLocationCode.Text = raf.Name;
            this.btnListele_Click(this.btnListele, EventArgs.Empty);
            this.txtItemCode.Focus();
        }
    }
}

