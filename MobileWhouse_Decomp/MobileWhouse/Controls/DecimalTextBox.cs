namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using System;
    using System.Windows.Forms;

    public class DecimalTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || (e.KeyChar == '\b')) || (e.KeyChar == ','))
            {
                base.OnKeyPress(e);
            }
            else
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        public decimal Value
        {
            get
            {
                if (ClientApplication.Instance == null)
                {
                    return 0M;
                }
                string str = this.Text.Trim();
                if (string.IsNullOrEmpty(str))
                {
                    return 0M;
                }
                return Convert.ToDecimal(str, ClientApplication.Instance.Culture);
            }
            set
            {
                if (ClientApplication.Instance != null)
                {
                    this.Text = value.ToString(ClientApplication.Instance.Culture);
                }
            }
        }
    }
}

