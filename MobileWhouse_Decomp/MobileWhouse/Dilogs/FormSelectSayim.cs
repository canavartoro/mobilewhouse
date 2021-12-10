namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectSayim : Form
    {
        private Depot _Depot;
        private Button btnCancel;
        private Button btnSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private IContainer components;
        private ListView lvwItems;

        public FormSelectSayim()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public FormSelectSayim(Depot depot)
        {
            this.components = null;
            this.InitializeComponent();
            this._Depot = depot;
        }

        private void _LoadSayimFisleri()
        {
            try
            {
                this.lvwItems.BeginUpdate();
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                    Token = ClientApplication.Instance.Token,
                    Value = this._Depot.Id
                };
                ServiceResultOfListOfRafSayimFisi rafSayimlari = ClientApplication.Instance.Service.GetRafSayimlari(param);
                if (!rafSayimlari.Result)
                {
                    throw new Exception(rafSayimlari.Message);
                }
                this.lvwItems.Items.Clear();
                for (int i = 0; i < rafSayimlari.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = rafSayimlari.Value[i].DocNo
                    };
                    listViewItem.SubItems.Add(rafSayimlari.Value[i].DepoCode);
                    listViewItem.SubItems.Add(rafSayimlari.Value[i].Date.ToString("dd/MM/yyyy"));
                    listViewItem.SubItems.Add(rafSayimlari.Value[i].User);
                    listViewItem.Tag = rafSayimlari.Value[i];
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
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
            this.lvwItems = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.btnSelect = new Button();
            this.btnCancel = new Button();
            base.SuspendLayout();
            this.lvwItems.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwItems.Columns.Add(this.columnHeader1);
            this.lvwItems.Columns.Add(this.columnHeader2);
            this.lvwItems.Columns.Add(this.columnHeader3);
            this.lvwItems.Columns.Add(this.columnHeader4);
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Location = new Point(4, 4);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new Size(0xe9, 0x11f);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.View = View.Details;
            this.columnHeader1.Text = "Belge No";
            this.columnHeader1.Width = 60;
            this.columnHeader2.Text = "Depo";
            this.columnHeader2.Width = 60;
            this.columnHeader3.Text = "Tarih";
            this.columnHeader3.Width = 60;
            this.columnHeader4.Text = "Kullanici";
            this.columnHeader4.Width = 60;
            this.btnSelect.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSelect.Location = new Point(0xa5, 0x129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x48, 20);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Sec";
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.btnCancel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnCancel.Location = new Point(4, 0x129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x48, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnSelect);
            base.Controls.Add(this.lvwItems);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectSayim";
            this.Text = "Sayim Sec";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._LoadSayimFisleri();
        }

        public RafSayimFisi Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lvwItems.SelectedIndices.Count > 0))
                {
                    return (this.lvwItems.Items[this.lvwItems.SelectedIndices[0]].Tag as RafSayimFisi);
                }
                return null;
            }
        }
    }
}

