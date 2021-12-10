namespace MobileWhouse
{
    using MobileWhouse.Controls;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using UyumConnector;

    public class FormMain : Form
    {
        private MainScreen _ButtonPanel;
        private BaseControl _SelectedPage;
        private IContainer components = null;
        private Panel pnlContainer;

        public FormMain()
        {
            this.InitializeComponent();
            this._ButtonPanel = new MainScreen();
            this._ButtonPanel.MainForm = this;
            this._ButtonPanel.Dock = DockStyle.Fill;
            this._ButtonPanel.Parent = this.pnlContainer;
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
            this.pnlContainer = new Panel();
            base.SuspendLayout();
            this.pnlContainer.Dock = DockStyle.Fill;
            this.pnlContainer.Location = new Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new Size(240, 320);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.ControlBox = false;
            base.Controls.Add(this.pnlContainer);
            base.Location = new Point(0, 0);
            base.MinimizeBox = false;
            base.Name = "FormMain";
            this.Text = "Mobile Whouse";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }

        public void ProcessBarkod(BarkodTextBox textBox, string barkod)
        {
            if (!string.IsNullOrEmpty(barkod) && (this.SelectedPage != null))
            {
                ServiceRequestOfItemSelectParam param;
                if (barkod.StartsWith(ClientApplication.Instance.ClientToken.RafPrefix) || (textBox.IsRaf == 1))
                {
                    param = new ServiceRequestOfItemSelectParam {
                        Token = ClientApplication.Instance.Token
                    };
                    if (barkod.StartsWith(ClientApplication.Instance.ClientToken.RafPrefix))
                    {
                        barkod = barkod.Substring(ClientApplication.Instance.ClientToken.RafPrefix.Length);
                    }
                    param.Value = new ItemSelectParam();
                    param.Value.DepotId = textBox.DepoId;
                    param.Value.Barkod = barkod;
                    ServiceResultOfNameIdItem rafInfo = ClientApplication.Instance.Service.GetRafInfo(param);
                    if (!rafInfo.Result)
                    {
                        throw new Exception(rafInfo.Message);
                    }
                    this.SelectedPage.OnRafBarkod(rafInfo.Value);
                }
                else
                {
                    param = new ServiceRequestOfItemSelectParam {
                        Token = ClientApplication.Instance.Token,
                        Value = new ItemSelectParam()
                    };
                    param.Value.Barkod = barkod;
                    if (ClientApplication.Instance.SelectedDepot != null)
                    {
                        param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    }
                    ServiceResultOfItemInfo info = ClientApplication.Instance.Service.GetItemInfo(param);
                    if (!info.Result)
                    {
                        throw new Exception(info.Message);
                    }
                    this.SelectedPage.OnItemBarkod(info.Value);
                }
            }
        }

        public void ShowControl(BaseControl control)
        {
            this.SelectedPage = control;
        }

        public BaseControl SelectedPage
        {
            get
            {
                return this._SelectedPage;
            }
            set
            {
                if (this._SelectedPage != null)
                {
                    this._SelectedPage.Parent = null;
                    this._SelectedPage.Dispose();
                }
                this._SelectedPage = value;
                if (this._SelectedPage != null)
                {
                    this._ButtonPanel.Visible = false;
                    this._SelectedPage.Dock = DockStyle.Fill;
                    this._SelectedPage.MainForm = this;
                    this._SelectedPage.Parent = this.pnlContainer;
                }
                else
                {
                    this._ButtonPanel.Visible = true;
                }
            }
        }
    }
}

