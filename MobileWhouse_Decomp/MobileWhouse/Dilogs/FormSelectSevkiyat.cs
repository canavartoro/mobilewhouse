namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectSevkiyat : Form
    {
        private Depot _Depot;
        private Button btnClose;
        private Button btnIrsaliye;
        private Button btnSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private IContainer components;
        private TextBox eName;
        private Label label1;
        private ListView lvwItems;

        public FormSelectSevkiyat()
        {
            this.components = null;
            this.InitializeComponent();
            this.btnIrsaliye.Visible = true;
            this.btnSelect.Visible = false;
        }

        public FormSelectSevkiyat(Depot depot)
        {
            this.components = null;
            this.InitializeComponent();
            this._Depot = depot;
            if (this._Depot == null)
            {
                this.btnSelect.Visible = false;
                this.btnIrsaliye.Visible = true;
            }
            else
            {
                this.btnSelect.Visible = true;
                this.btnIrsaliye.Visible = false;
            }
        }

        private void _LoadSevkEmirleri()
        {
            try
            {
                this.lvwItems.BeginUpdate();
                this.lvwItems.Items.Clear();
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new SelectParam()
                };
                if (this._Depot != null)
                {
                    param.Value.DepotId = this._Depot.Id;
                    param.Value.SearchEntity = this.eName.Text;
                }
                else
                {
                    param.Value.SearchEntity = this.eName.Text;
                }
                ServiceResultOfListOfSevkiyatInfo sevkiyatlar = ClientApplication.Instance.Service.GetSevkiyatlar(param);
                if (!sevkiyatlar.Result)
                {
                    throw new Exception(sevkiyatlar.Message);
                }
                for (int i = 0; i < sevkiyatlar.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Tag = sevkiyatlar.Value[i],
                        Text = sevkiyatlar.Value[i].SevkEmriNo
                    };
                    listViewItem.SubItems.Add(sevkiyatlar.Value[i].Client);
                    listViewItem.SubItems.Add(sevkiyatlar.Value[i].IsProcess.ToString());
                    this.lvwItems.Items.Add(listViewItem);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void dateP_ValueChanged(object sender, EventArgs e)
        {
            this._LoadSevkEmirleri();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void eName_TextChanged(object sender, EventArgs e)
        {
            this._LoadSevkEmirleri();
        }

        private void InitializeComponent()
        {
            this.lvwItems = new ListView();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.btnSelect = new Button();
            this.btnIrsaliye = new Button();
            this.btnClose = new Button();
            this.label1 = new Label();
            this.eName = new TextBox();
            this.columnHeader1 = new ColumnHeader();
            base.SuspendLayout();
            this.lvwItems.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwItems.Columns.Add(this.columnHeader2);
            this.lvwItems.Columns.Add(this.columnHeader3);
            this.lvwItems.Columns.Add(this.columnHeader1);
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Location = new Point(4, 0x1a);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new Size(0xe9, 0x10d);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.View = View.Details;
            this.columnHeader2.Text = "SevkE.No";
            this.columnHeader2.Width = 0x4a;
            this.columnHeader3.Text = "M\x00fcşteri";
            this.columnHeader3.Width = 0x59;
            this.btnSelect.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSelect.Location = new Point(0xa5, 0x129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x48, 20);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Se\x00e7";
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.btnIrsaliye.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnIrsaliye.Location = new Point(0xa5, 0x129);
            this.btnIrsaliye.Name = "btnIrsaliye";
            this.btnIrsaliye.Size = new Size(0x48, 20);
            this.btnIrsaliye.TabIndex = 2;
            this.btnIrsaliye.Text = "İrsaliye";
            this.btnIrsaliye.Visible = false;
            this.btnIrsaliye.Click += new EventHandler(this.btnIrsaliye_Click);
            this.btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(4, 0x129);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.label1.Location = new Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3a, 0x10);
            this.label1.Text = "Cari Ad";
            this.eName.Location = new Point(0x36, 3);
            this.eName.Name = "eName";
            this.eName.Size = new Size(0xb7, 0x15);
            this.eName.TabIndex = 5;
            this.eName.TextChanged += new EventHandler(this.eName_TextChanged);
            this.columnHeader1.Text = "İş. G\x00f6r.";
            this.columnHeader1.Width = 60;
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.eName);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnIrsaliye);
            base.Controls.Add(this.btnSelect);
            base.Controls.Add(this.lvwItems);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectSevkiyat";
            this.Text = "Sevkiyat Se\x00e7";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._LoadSevkEmirleri();
        }

        public SevkiyatInfo Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lvwItems.SelectedIndices.Count > 0))
                {
                    return (this.lvwItems.Items[this.lvwItems.SelectedIndices[0]].Tag as SevkiyatInfo);
                }
                return null;
            }
        }
    }
}

