using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;

namespace MobileWhouse.Controls.PSM
{
    public partial class MalKabulControl : BaseControl
    {
        public MalKabulControl()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FormSelectStnSiparisi form = new FormSelectStnSiparisi())
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    SatinalmaMalKabulControl control = new SatinalmaMalKabulControl(form.Selected);
                    MainForm.ShowControl(control);
                }
            }
        }

        private void btnetiketleme_Click(object sender, EventArgs e)
        {
            using (FormSelectAlisIrsaliye form = new FormSelectAlisIrsaliye())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SatinalmaMalKabulEtiketlemeControl control = new SatinalmaMalKabulEtiketlemeControl(form.Selected);
                    MainForm.ShowControl(control);
                }
            }
        }
    }
}
