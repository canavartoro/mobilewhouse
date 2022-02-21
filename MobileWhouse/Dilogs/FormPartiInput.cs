using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.lotcode = "";
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.lotcode = textBox1.Text;
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

        public static string ShowInput(string caption)
        {
            FormPartiInput frm = new FormPartiInput();
            frm.CaptionText = caption;
            if (frm.ShowDialog() == DialogResult.OK)
                return frm.LotCode;
            else
                return null;
        }
    }
}