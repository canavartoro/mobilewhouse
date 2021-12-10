namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectIrsaliyeTur : Form
    {
        private Button btnClose;
        private Button btnSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private IContainer components = null;
        private ListView lvwDepots;

        public FormSelectIrsaliyeTur()
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
                ServiceRequestOfBoolean param = new ServiceRequestOfBoolean {
                    Token = ClientApplication.Instance.Token
                };
                ServiceResultOfListOfItemWithName name = ClientApplication.Instance.Service.GetIrsaliyeTurleri(param);
                if (!name.Result)
                {
                    throw new Exception(name.Message);
                }
                this.lvwDepots.BeginUpdate();
                this.lvwDepots.Items.Clear();
                for (int i = 0; i < name.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = name.Value[i].Id.ToString()
                    };
                    listViewItem.SubItems.Add(name.Value[i].Name);
                    listViewItem.SubItems.Add(name.Value[i].Description);
                    listViewItem.Tag = name.Value[i];
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
            this.lvwDepots = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.btnSelect = new Button();
            this.btnClose = new Button();
            base.SuspendLayout();
            this.lvwDepots.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lvwDepots.Columns.Add(this.columnHeader1);
            this.lvwDepots.Columns.Add(this.columnHeader2);
            this.lvwDepots.Columns.Add(this.columnHeader3);
            this.lvwDepots.FullRowSelect = true;
            this.lvwDepots.Location = new Point(4, 3);
            this.lvwDepots.Name = "lvwDepots";
            this.lvwDepots.Size = new Size(0xe9, 0x120);
            this.lvwDepots.TabIndex = 2;
            this.lvwDepots.View = View.Details;
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 60;
            this.columnHeader2.Text = "Kod";
            this.columnHeader2.Width = 0x4b;
            this.columnHeader3.Text = "A\x00e7ıklama";
            this.columnHeader3.Width = 60;
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
            base.Location = new Point(0, 0);
            base.Name = "FormSelectIrsaliyeTur";
            this.Text = "Irsaliye Turu Se\x00e7";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.btnSearch_Click(this, e);
        }

        public ItemWithName Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lvwDepots.SelectedIndices.Count > 0))
                {
                    return (this.lvwDepots.Items[this.lvwDepots.SelectedIndices[0]].Tag as ItemWithName);
                }
                return null;
            }
        }
    }
}

