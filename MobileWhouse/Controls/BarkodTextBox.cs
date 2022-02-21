using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public class BarkodTextBox : TextBox
    {
        private string _LastChecked = string.Empty;

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
                _LastChecked = value;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    ValidateBarkod();
                }
                base.OnKeyPress(e);
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
        }

        public virtual void ValidateBarkod()
        {
            if (Utility.IsDesignMode) return;

            if (string.IsNullOrEmpty(Text)) return;

            string text = Text;
            try
            {
                if (DepoId < 1)
                    throw new Exception("Lütfen rafın aranacağı depoyu seçiniz ");

                //if (_LastChecked == text)
                //    return;
                Text = string.Empty;
                ClientApplication.Instance.MainForm.ProcessBarkod(this, text);
                _LastChecked = text;
            }
            catch (Exception ex)
            {
                Text = "";
                Screens.Error(ex);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            //base.OnLostFocus(e);
            //if (this.IsRaf == 1 && !this.IsTransfer)
            //{
            //    ValidateBarkod();
            //}
            base.OnLostFocus(e);
            if (Utility.IsDesignMode) return;
            
            Screens.ShowKeyboard(false);

            if (this.IsRaf != 1 || this.IsTransfer)
                return;
            this.ValidateBarkod();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!Utility.IsDesignMode)
                Screens.ShowKeyboard(true);
        }
    }
}
