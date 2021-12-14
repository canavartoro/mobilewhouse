using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MobileWhouse.Controls
{
    public partial class AmbalajMenuControl : BaseControl
    {
        public AmbalajMenuControl()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void uButton2_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PaletOlusturmaControl());
        }

        private void uButton3_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajTraControl());
        }

        private void btnambalajolustur_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajOlusturmaControl());
        }
    }
}
