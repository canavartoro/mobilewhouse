namespace MobileWhouse.Dilogs
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSelectRaf : Form
    {
        private Depot _Depot;
        private Button btnClose;
        private Button btnSearch;
        private Button btnSelect;
        private Button btnTre;
        private IContainer components;
        private TreeView trvRaflar;
        private TextBox txtName;

        public FormSelectRaf()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public FormSelectRaf(Depot depot)
        {
            this.components = null;
            this.InitializeComponent();
            this._Depot = depot;
        }

        private void _AddToNodes(TreeNodeCollection nodes, string text, NameIdItem raf)
        {
            TreeNode node;
            int index = text.IndexOf("-");
            if (index < 0)
            {
                node = new TreeNode(text) {
                    Tag = raf
                };
                nodes.Add(node);
            }
            else
            {
                string str = text.Substring(0, index);
                node = this._SearchNode(nodes, str);
                string str2 = text.Substring(index + 1, (text.Length - index) - 1);
                if (node == null)
                {
                    node = new TreeNode(str);
                    this._AddToNodes(node.Nodes, str2, raf);
                    nodes.Add(node);
                }
                else
                {
                    this._AddToNodes(node.Nodes, str2, raf);
                }
            }
        }

        private TreeNode _SearchNode(TreeNodeCollection nodes, string part1)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Text.Equals(part1))
                {
                    return nodes[i];
                }
            }
            return null;
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
                if (this._Depot == null)
                {
                    throw new Exception("Depo secmediniz");
                }
                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam {
                    Token = ClientApplication.Instance.Token,
                    Value = new SelectParam()
                };
                param.Value.Filter = this.txtName.Text;
                param.Value.DepotId = this._Depot.Id;
                ServiceResultOfListOfNameIdItem raflar = ClientApplication.Instance.Service.GetRaflar(param);
                if (!raflar.Result)
                {
                    throw new Exception(raflar.Message);
                }
                this.trvRaflar.BeginUpdate();
                this.trvRaflar.Nodes.Clear();
                TreeNodeCollection nodes = this.trvRaflar.Nodes;
                for (int i = 0; i < raflar.Value.Length; i++)
                {
                    this._AddToNodes(nodes, raflar.Value[i].Name, raflar.Value[i]);
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
            finally
            {
                this.trvRaflar.EndUpdate();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btnTre_Click(object sender, EventArgs e)
        {
            this.txtName.Text = this.txtName.Text + "-";
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
            this.btnSelect = new Button();
            this.trvRaflar = new TreeView();
            this.btnTre = new Button();
            this.btnClose = new Button();
            base.SuspendLayout();
            this.txtName.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtName.Location = new Point(4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(0xa9, 0x15);
            this.txtName.TabIndex = 0;
            this.btnSearch.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnSearch.Location = new Point(0xbf, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(0x2e, 20);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.btnSelect.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSelect.Location = new Point(0xa5, 0x129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x48, 20);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Sec";
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.trvRaflar.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.trvRaflar.Location = new Point(4, 0x20);
            this.trvRaflar.Name = "trvRaflar";
            this.trvRaflar.Size = new Size(0xe9, 0x103);
            this.trvRaflar.TabIndex = 4;
            this.btnTre.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnTre.Location = new Point(0xaf, 4);
            this.btnTre.Name = "btnTre";
            this.btnTre.Size = new Size(14, 20);
            this.btnTre.TabIndex = 5;
            this.btnTre.Text = "-";
            this.btnTre.Click += new EventHandler(this.btnTre_Click);
            this.btnClose.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(3, 0x129);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x48, 20);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnTre);
            base.Controls.Add(this.trvRaflar);
            base.Controls.Add(this.btnSelect);
            base.Controls.Add(this.btnSearch);
            base.Controls.Add(this.txtName);
            base.Location = new Point(0, 0);
            base.Name = "FormSelectRaf";
            this.Text = "Raf Se\x00e7";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        public NameIdItem Selected
        {
            get
            {
                if ((base.DialogResult == DialogResult.OK) && (this.trvRaflar.SelectedNode != null))
                {
                    return (this.trvRaflar.SelectedNode.Tag as NameIdItem);
                }
                return null;
            }
        }
    }
}

