namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class BarkodTextBox : TextBox
    {
        private string _LastChecked = string.Empty;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;
                    this.ValidateBarkod();
                }
                base.OnKeyPress(e);
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!((this.IsRaf != 1) || this.IsTransfer))
            {
                this.ValidateBarkod();
            }
        }

        public virtual void ValidateBarkod()
        {
            string text = this.Text;
            try
            {
                if (this.DepoId < 1)
                {
                    throw new Exception("L\x00fctfen rafın aranacağı depoyu se\x00e7iniz");
                }
                this.Text = string.Empty;
                ClientApplication.Instance.MainForm.ProcessBarkod(this, text);
                this._LastChecked = text;
            }
            catch (Exception exception)
            {
                this.Text = text;
                ClientApplication.ShowError(exception);
            }
        }

        public int DepoId { get; set; }

        public int IsRaf { get; set; }

        public bool IsTransfer { get; set; }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this._LastChecked = value;
            }
        }
    }
}

