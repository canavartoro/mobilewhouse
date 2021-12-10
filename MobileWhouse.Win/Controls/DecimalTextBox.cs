using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobileWhouse.Controls
{
    public class DecimalTextBox : TextBox
    {
        public decimal Value
        {
            get
            {
                if (ClientApplication.Instance == null)
                    return 0;
                string text = Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    return 0;
                }
                return Convert.ToDecimal(text, ClientApplication.Instance.Culture);
            }
            set
            {
                if (ClientApplication.Instance == null)
                    return;
                Text = value.ToString(ClientApplication.Instance.Culture);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar)
            //    || e.KeyChar == 8 || e.KeyChar == ',')
            //{
            //    base.OnKeyPress(e);
            //}
            //else
            //{
            //    e.Handled = true;
            //    base.OnKeyPress(e);
            //}
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',')
            {
                base.OnKeyPress(e);
            }
            else
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
    }
}
