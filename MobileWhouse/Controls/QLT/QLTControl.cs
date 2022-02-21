using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MobileWhouse.Controls.QLT
{
    public partial class QLTControl : BaseControl
    {
        public QLTControl()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new SurecKaliteControl());
        }

        private void btnbloke_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajBlokeControl());
        }

        private void btnuygunsuzluk_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new DiscordReportsControl());
        }
    }
}
