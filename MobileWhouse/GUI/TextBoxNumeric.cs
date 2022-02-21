using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MobileWhouse.GUI
{
    public class TextBoxNumeric : TextBox
    {
        public TextBoxNumeric()
        {
            this.BackColor = Color.SkyBlue;
        }

        private bool allowNegative = false;
        private bool allowSpace = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
            string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
            string negativeSign = numberFormat.NegativeSign;
            string str3 = e.KeyChar.ToString();
            if (((!char.IsDigit(e.KeyChar) && !str3.Equals(numberDecimalSeparator)) && ((!this.allowNegative || !str3.Equals(negativeSign)) && ((e.KeyChar != '\b') && (e.KeyChar != Convert.ToChar(Keys.Delete))))) && (!this.allowSpace || (e.KeyChar != ' ')))
            {
                e.Handled = true;
            }
        }

        public bool AllowSpace
        {
            get
            {
                return this.allowSpace;
            }
            set
            {
                this.allowSpace = value;
            }
        }

        public double DoubleValue
        {
            get
            {
                if (this.Text.Length == 0)
                {
                    return 0d;
                }
                try
                {
                    return double.Parse(this.Text);
                }
                catch (Exception)
                {
                    return 0d;
                }
            }
        }

        public decimal DecimalValue
        {
            get
            {
                if (this.Text.Length == 0)
                {
                    return 0M;
                }
                try
                {
                    return decimal.Parse(this.Text);
                }
                catch (Exception)
                {
                    return 0M;
                }
            }
        }

        public int IntValue
        {
            get
            {
                if (this.Text.Length == 0)
                {
                    return 0;
                }
                try
                {
                    return int.Parse(this.Text);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
