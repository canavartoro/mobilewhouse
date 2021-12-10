namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class BaseControl : UserControl
    {
        private FormMain _MainForm;
        private IContainer components = null;

        public BaseControl()
        {
            this.InitializeComponent();
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Name = "BaseControl";
            base.Size = new Size(240, 0x126);
            base.ResumeLayout(false);
        }

        public virtual void OnItemBarkod(ItemInfo item)
        {
        }

        public virtual void OnRafBarkod(NameIdItem raf)
        {
        }

        public FormMain MainForm
        {
            get
            {
                return this._MainForm;
            }
            set
            {
                this._MainForm = value;
            }
        }
    }
}

