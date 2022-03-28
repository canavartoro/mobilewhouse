using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;

namespace MobileWhouse.Dilogs
{
    public partial class FormPartiInput : Form
    {
        public FormPartiInput()
        {
            InitializeComponent();
        }

        private string captionText = "";
        public string CaptionText
        {
            get { return captionText; }
            set
            {
                captionText = value;
                label1.Text = captionText;
            }
        }

        private string lotcode = "";
        public string LotCode
        {
            get { return lotcode; }
            set { lotcode = value; }
        }

        private decimal miktar = 0;
        public decimal Miktar
        {
            get { return miktar; }
            set
            {
                miktar = value;
                textMiktar.Text = value.ToString(Statics.DECIMAL_STRING_FORMAT);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.lotcode = "";
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.lotcode = textBox1.Text;
            if (textMiktar.DecimalValue <= 0)
            {
                Screens.Warning("Parti miktarı boş geçilemez!");
                return;
            }
            if (textMiktar.DecimalValue > this.miktar)
            {
                Screens.Warning(string.Concat("Parti miktarı, İrsaliye miktarını geçemez! ",this.miktar));
                return;
            }
            else
                this.miktar = textMiktar.DecimalValue;
            if (string.IsNullOrEmpty(this.lotcode)) return;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FormPartiInput_Load(object sender, EventArgs e)
        {
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
            Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            Application.DoEvents();
        }

        public static PartiLotInf ShowInput(string caption)
        {
            return ShowInput(caption, 0);
        }

        public static PartiLotInf ShowInput(string caption, decimal qty)
        {
            FormPartiInput frm = new FormPartiInput();
            frm.CaptionText = caption;
            frm.Miktar = qty;
            if (frm.ShowDialog() == DialogResult.OK)
                return new PartiLotInf(frm.LotCode, frm.miktar);
            else
                return null;
        }

        private void t2_Click(object sender, EventArgs e)
        {

        }
    }

    public class PartiLotInf
    {
        public PartiLotInf() { }

        public PartiLotInf(string lot, decimal qty)
        {
            lotcode = lot;
            miktar = qty;
        }

        private string lotcode = "";
        public string LotCode
        {
            get { return lotcode; }
            set { lotcode = value; }
        }

        private decimal miktar = 0;
        public decimal Miktar
        {
            get { return miktar; }
            set { miktar = value; }
        }
    }
}