using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;

namespace MobileWhouse.Controls
{
    public partial class SevkControl : BaseControl
    {
        public SevkControl()
        {
            InitializeComponent();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FormSelectSevkiyat form = new FormSelectSevkiyat(ClientApplication.Instance.SelectedDepot))
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    SevkiyatControl control = new SevkiyatControl(form.Selected);
                    MainForm.ShowControl(control);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new Frm_PaletSevk());
        }
    }
}
