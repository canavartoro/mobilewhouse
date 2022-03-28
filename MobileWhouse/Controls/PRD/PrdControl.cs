using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MobileWhouse.Controls.PRD
{
    public partial class PrdControl : BaseControl
    {
        public PrdControl()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnisemritalep_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new IsEmrineMalzemeTalepControl());
        }

        private void btntalepsevk_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new MalzemeTalepSevkControl());
        }

        private void btnisemribaslat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new IsEmriBaslatControl());
        }

        private void btnkolietiket_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new EtiketlemeControl());
        }

        private void btnhurdaetiket_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new HurdaEtiketlemeControl());
        }

        private void btndurus_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new DurusControl());
        }

        private void btnhurdatartim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new HurdaTartimControl());
        }

        private void btnuretimgiris_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new UretimGirisControl());
        }

        private void btnkarisim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new KarisimUretimControl());
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnrecete_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new ReceteControl());
        }

        private void btnonay_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new EtiketOnayControl());
        }

        private void btnisemri_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new IsEmriControl());
        }
    }
}
