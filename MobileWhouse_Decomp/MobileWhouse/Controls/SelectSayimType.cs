namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SelectSayimType : BaseControl
    {
        private Depot _Depot;
        private Button btnClose;
        private Button btnContinueSayim;
        private Button btnYeniSayim;
        private IContainer components;

        public SelectSayimType()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public SelectSayimType(Depot depot)
        {
            this.components = null;
            this.InitializeComponent();
            this._Depot = depot;
        }

        private void btnClose_Click(object sender, EventArgs e)
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
            this.btnYeniSayim = new Button();
            this.btnContinueSayim = new Button();
            this.btnClose = new Button();
            base.SuspendLayout();
            this.btnYeniSayim.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnYeniSayim.Location = new Point(3, 3);
            this.btnYeniSayim.Name = "btnYeniSayim";
            this.btnYeniSayim.Size = new Size(0xea, 0x34);
            this.btnYeniSayim.TabIndex = 0;
            this.btnYeniSayim.Text = "Yeni Sayım";
            this.btnYeniSayim.Click += new EventHandler(this.mnNewSayim_Click);
            this.btnContinueSayim.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnContinueSayim.Location = new Point(3, 0x3d);
            this.btnContinueSayim.Name = "btnContinueSayim";
            this.btnContinueSayim.Size = new Size(0xea, 0x34);
            this.btnContinueSayim.TabIndex = 1;
            this.btnContinueSayim.Text = "Sayıma Devam Et";
            this.btnContinueSayim.Click += new EventHandler(this.mnContinueSayim_Click);
            this.btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnClose.Location = new Point(3, 0x10c);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0xea, 0x17);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnContinueSayim);
            base.Controls.Add(this.btnYeniSayim);
            base.Name = "SelectSayimType";
            base.ResumeLayout(false);
        }

        private void mnContinueSayim_Click(object sender, EventArgs e)
        {
            using (FormSelectSayim sayim = new FormSelectSayim(this._Depot))
            {
                if ((sayim.ShowDialog() == DialogResult.OK) && (sayim.Selected != null))
                {
                    base.MainForm.ShowControl(new SayimControl(sayim.Selected, true));
                }
            }
        }

        private void mnNewSayim_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                    Token = ClientApplication.Instance.Token,
                    Value = this._Depot.Id
                };
                ServiceResultOfRafSayimFisi fisi = ClientApplication.Instance.Service.InsertRafSayimFisi(param);
                if (!fisi.Result)
                {
                    throw new Exception(fisi.Message);
                }
                base.MainForm.ShowControl(new SayimControl(fisi.Value, false));
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }
    }
}

