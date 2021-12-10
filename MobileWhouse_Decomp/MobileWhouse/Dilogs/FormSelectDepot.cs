namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FormSelectDepot : Form
    {
        public bool _OnlyWithLocation = true;
        private Button btnClose;
        private Button btnSearch;
        private Button btnSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private IContainer components = null;
        private ListView lvwDepots;
        private TextBox txtName;

        public FormSelectDepot()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfDepotSelectParam param = new ServiceRequestOfDepotSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new DepotSelectParam()
                };
                param.Value.DescriptionFilter = this.txtName.Text.Trim();
                param.Value.OnlyWithLocation = this._OnlyWithLocation;
                param.Value.NotEqualDepotId = this.DepotId;
                ServiceResultOfListOfDepot depots = ClientApplication.Instance.Service.GetDepots(param);
                this.lvwDepots.BeginUpdate();
                this.lvwDepots.Items.Clear();
                for (int i = 0; i < depots.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = depots.Value[i].Id.ToString()
                    };
                    listViewItem.SubItems.Add(depots.Value[i].Name);
                    listViewItem.Tag = depots.Value[i];
                    this.lvwDepots.Items.Add(listViewItem);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lvwDepots.EndUpdate();
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
            this.lvwDepots = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
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
            this.lvwDepots.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwDepots.Columns.Add(this.columnHeader1);
            this.lvwDepots.Columns.Add(this.columnHeader2);
            this.lvwDepots.FullRowSelect = true;
            this.lvwDepots.Location = new Point(4, 0x20);
            this.lvwDepots.Name = "lvwDepots";
            this.lvwDepots.Size = new Size(0xe9, 0x103);
            this.lvwDepots.TabIndex = 2;
            this.lvwDepots.View = View.Details;
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 60;
            this.columnHeader2.Text = "Aciklama";
            this.columnHeader2.Width = 0x93;
            this.btnSelect.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSelect.Location = new Point(0xa5, 0x129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x48, 20);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Sec";
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.btnClose.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(3, 0x129);
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
            base.Controls.Add(this.lvwDepots);
            base.Controls.Add(this.btnSearch);
            base.Controls.Add(this.txtName);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectDepot";
            this.Text = "Depo Sec";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.btnSearch_Click(this, e);
        }

        public int DepotId { get; set; }

        public Depot Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lvwDepots.SelectedIndices.Count > 0))
                {
                    return (this.lvwDepots.Items[this.lvwDepots.SelectedIndices[0]].Tag as Depot);
                }
                return null;
            }
        }
    }
}

