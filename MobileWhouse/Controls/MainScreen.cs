using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using MobileWhouse.Controls.PRD;

namespace MobileWhouse.Controls
{
    public partial class MainScreen : BaseControl
    {
        public MainScreen()
        {
            InitializeComponent();
            ClientApplication.Instance.SelectedDepotChanged += new EventHandler(OnSelectedDepotChanged);
            lblversion.Text = string.Concat("V:", Program.Versiyon, " B:", Program.BuildNumber());
        }

        void OnSelectedDepotChanged(object sender, EventArgs e)
        {
            if (ClientApplication.Instance.SelectedDepot == null)
                btnSelectDepot.Text = "Depo Seç";
            else
                btnSelectDepot.Text = "Depo: " + ClientApplication.Instance.SelectedDepot.Name;
            bool enable = ClientApplication.Instance.SelectedDepot != null;
            btnSayim.Enabled = enable;
            btnSevkiyat.Enabled = enable;
            btnStokRafDurumu.Enabled = enable;
            btnRafHareketi.Enabled = enable;
            btnStokHareketi.Enabled = enable;
            btnPaletOlusturma.Enabled = enable;
            btnStokTransfer.Enabled = enable;
            btnmalkabul.Enabled = enable;
            btnUretim.Enabled = enable;
            btnIrsaliye.Enabled = enable;
            btnkalite.Enabled = enable;
            btnambalaj.Enabled = enable;
            this.Focus();
        }

        private void btnSayim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new SelectSayimType(ClientApplication.Instance.SelectedDepot));
        }

        private void btnStokHareketi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen Hedef Depo Seciniz !");

            using (FormSelectDepot form = new FormSelectDepot())
            {
                form._OnlyWithLocation = false;
                form.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null && form.Selected.Id != ClientApplication.Instance.SelectedDepot.Id)
                {
                    MainForm.ShowControl(new StokHareketiControl(form.Selected));
                }
            }
        }

        private void btnRafHareketi_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new RafHareketiControl());
        }

        private void btnSevkiyat_Click(object sender, EventArgs e)
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

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            using (FormSelectSevkiyat form = new FormSelectSevkiyat())
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    IrsaliyeOlusturControl control = new IrsaliyeOlusturControl(form.Selected);
                    MainForm.ShowControl(control);
                }
            }
        }

        private void btnStokRafDurumu_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new StokRafDurumuControl());
        }

        private void btnPaletOlusturma_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PaletOlusturmaControl());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm.Close();
        }

        private void btnSelectDepot_Click(object sender, EventArgs e)
        {


            using (FormSelectDepot form = new FormSelectDepot())
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    ClientApplication.Instance.SelectedDepot = form.Selected;
                    FileHelper.SaveFile("selectedDepot.xml", FileHelper.ToXml(ClientApplication.Instance.SelectedDepot));
                }
            }
        }

        private void btnStokTransfer_Click(object sender, EventArgs e)
        {
            //MobileWhouse.Util.Screens.Error("Lutfen Hedef Depo Seciniz !");

            using (FormSelectDepot form = new FormSelectDepot())
            {
                form._OnlyWithLocation = false;
                form.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null && form.Selected.Id != ClientApplication.Instance.SelectedDepot.Id)
                {

                    MainForm.ShowControl(new DepoTransferControl(form.Selected));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AcikBelgeSilControl());
        }

        private void btnUretim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void btnmalkabul_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PSM.MalKabulControl());
        }

        private void btnkalite_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new QLT.QLTControl());
        }

        private void btnambalaj_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajMenuControl());
        }

        private void btnayar_Click(object sender, EventArgs e)
        {
            using (FormAyarlar form = new FormAyarlar())
            {
                form.ShowDialog();
            }
        }
    }
}

