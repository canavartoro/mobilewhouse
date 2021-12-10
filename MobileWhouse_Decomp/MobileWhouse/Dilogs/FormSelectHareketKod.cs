namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectHareketKod : Form
    {
        private Button btnChoose;
        private Button btnClose;
        private Button btnSearch;
        private IContainer components = null;
        private ColumnHeader DocTraCode;
        private ColumnHeader DocTraDesc;
        private ColumnHeader Id;
        private ListView lswDocTra;
        private TextBox txtDocTraCode;

        public FormSelectHareketKod()
        {
            this.InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
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
                ServiceRequestOfDocTraSelectParam param = new ServiceRequestOfDocTraSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new DocTraSelectParam()
                };
                param.Value.DocTraCodeFilter = this.txtDocTraCode.Text;
                param.Value.BranchId = ClientApplication.Instance.Token.BranchId;
                param.Value.CoId = ClientApplication.Instance.Token.CoId;
                ServiceResultOfListOfDocTra docTras = ClientApplication.Instance.Service.GetDocTras(param);
                this.lswDocTra.BeginUpdate();
                this.lswDocTra.Items.Clear();
                for (int i = 0; i < docTras.Value.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem {
                        Text = docTras.Value[i].Id.ToString()
                    };
                    listViewItem.SubItems.Add(docTras.Value[i].DocTraCode);
                    listViewItem.SubItems.Add(docTras.Value[i].DocTraDesc);
                    listViewItem.Tag = docTras.Value[i];
                    this.lswDocTra.Items.Add(listViewItem);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.lswDocTra.EndUpdate();
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
            this.txtDocTraCode = new TextBox();
            this.btnSearch = new Button();
            this.lswDocTra = new ListView();
            this.Id = new ColumnHeader();
            this.DocTraCode = new ColumnHeader();
            this.DocTraDesc = new ColumnHeader();
            this.btnChoose = new Button();
            this.btnClose = new Button();
            base.SuspendLayout();
            this.txtDocTraCode.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtDocTraCode.Location = new Point(0, 3);
            this.txtDocTraCode.Name = "txtDocTraCode";
            this.txtDocTraCode.Size = new Size(0xa2, 0x15);
            this.txtDocTraCode.TabIndex = 0;
            this.btnSearch.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnSearch.Location = new Point(0xa8, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(0x48, 20);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.lswDocTra.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lswDocTra.Columns.Add(this.Id);
            this.lswDocTra.Columns.Add(this.DocTraCode);
            this.lswDocTra.Columns.Add(this.DocTraDesc);
            this.lswDocTra.FullRowSelect = true;
            this.lswDocTra.Location = new Point(3, 30);
            this.lswDocTra.Name = "lswDocTra";
            this.lswDocTra.Size = new Size(0xeb, 0x108);
            this.lswDocTra.TabIndex = 2;
            this.lswDocTra.View = View.Details;
            this.Id.Text = "Id";
            this.Id.Width = 0x1b;
            this.DocTraCode.Text = "Hareket Kod";
            this.DocTraCode.Width = 90;
            this.DocTraDesc.Text = "Hareket Ad";
            this.DocTraDesc.Width = 0x69;
            this.btnChoose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnChoose.Location = new Point(0xa6, 0x129);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new Size(0x48, 20);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "Se\x00e7";
            this.btnChoose.Click += new EventHandler(this.btnChoose_Click);
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
            base.Controls.Add(this.btnChoose);
            base.Controls.Add(this.lswDocTra);
            base.Controls.Add(this.btnSearch);
            base.Controls.Add(this.txtDocTraCode);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectHareketKod";
            this.Text = "Hareket Kodu";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.btnSearch_Click(this, e);
        }

        public DocTra Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.lswDocTra.SelectedIndices.Count > 0))
                {
                    return (this.lswDocTra.Items[this.lswDocTra.SelectedIndices[0]].Tag as DocTra);
                }
                return null;
            }
        }
    }
}

