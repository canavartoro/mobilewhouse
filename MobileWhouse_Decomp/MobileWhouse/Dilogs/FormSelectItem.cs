namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectItem : Form
    {
        private Button btnClose;
        private Button btnSearch;
        private Button btnSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private IContainer components = null;
        private ListView lvwStok;
        private TextBox txtName;

        public FormSelectItem()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new SelectParam()
                };
                param.Value.Filter = this.txtName.Text.Trim();
                if (ClientApplication.Instance.SelectedDepot != null)
                {
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                }
                ServiceResultOfListOfItemWithName stoklar = ClientApplication.Instance.Service.GetStoklar(param);
                this.lvwStok.BeginUpdate();
                this.lvwStok.Items.Clear();
                for (int i = 0; i < stoklar.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = stoklar.Value[i].Id.ToString()
                    };
                    listViewItem.SubItems.Add(stoklar.Value[i].Name);
                    listViewItem.SubItems.Add(stoklar.Value[i].Description);
                    listViewItem.Tag = stoklar.Value[i];
                    this.lvwStok.Items.Add(listViewItem);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwStok.EndUpdate();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
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
            this.txtName = new TextBox();
            this.btnSearch = new Button();
            this.lvwStok = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.btnSelect = new Button();
            this.btnClose = new Button();
            base.SuspendLayout();
            this.txtName.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtName.Location = new Point(4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(170, 0x15);
            this.txtName.TabIndex = 0;
            this.btnSearch.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnSearch.Location = new Point(0xb5, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(0x38, 20);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.lvwStok.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwStok.Columns.Add(this.columnHeader1);
            this.lvwStok.Columns.Add(this.columnHeader2);
            this.lvwStok.Columns.Add(this.columnHeader3);
            this.lvwStok.FullRowSelect = true;
            this.lvwStok.Location = new Point(4, 0x20);
            this.lvwStok.Name = "lvwStok";
            this.lvwStok.Size = new Size(0xe9, 0x106);
            this.lvwStok.TabIndex = 2;
            this.lvwStok.View = View.Details;
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 60;
            this.columnHeader2.Text = "Kod";
            this.columnHeader2.Width = 0x4d;
            this.columnHeader3.Text = "Ad";
            this.columnHeader3.Width = 0x49;
            this.btnSelect.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSelect.Location = new Point(0xa5, 0x129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x48, 20);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Sec";
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.btnClose.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(4, 0x129);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnSelect);
            base.Controls.Add(this.lvwStok);
            base.Controls.Add(this.btnSearch);
            base.Controls.Add(this.txtName);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectItem";
            this.Text = "Stok Sec";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        public ItemWithName Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lvwStok.SelectedIndices.Count > 0))
                {
                    return (this.lvwStok.Items[this.lvwStok.SelectedIndices[0]].Tag as ItemWithName);
                }
                return null;
            }
        }
    }
}

