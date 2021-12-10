namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class MainScreen : BaseControl
    {
        private Button btnExit;
        private Button btnIrsaliye;
        private Button btnPaletOlusturma;
        private Button btnRafHareketi;
        private Button btnSayim;
        private Button btnSelectDepot;
        private Button btnSevkiyat;
        private Button btnStokHareketi;
        private Button btnStokRafDurumu;
        private Button btnStokTransfer;
        private Button button1;
        private IContainer components = null;

        public MainScreen()
        {
            this.InitializeComponent();
            ClientApplication.Instance.SelectedDepotChanged += new EventHandler(this.OnSelectedDepotChanged);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.MainForm.Close();
        }

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            using (FormSelectSevkiyat sevkiyat = new FormSelectSevkiyat())
            {
                if ((sevkiyat.ShowDialog() == DialogResult.OK) && (sevkiyat.Selected != null))
                {
                    IrsaliyeOlusturControl control = new IrsaliyeOlusturControl(sevkiyat.Selected);
                    base.MainForm.ShowControl(control);
                }
            }
        }

        private void btnPaletOlusturma_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(new PaletOlusturmaControl());
        }

        private void btnRafHareketi_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(new RafHareketiControl());
        }

        private void btnSayim_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(new SelectSayimType(ClientApplication.Instance.SelectedDepot));
        }

        private void btnSelectDepot_Click(object sender, EventArgs e)
        {
            using (FormSelectDepot depot = new FormSelectDepot())
            {
                if ((depot.ShowDialog() == DialogResult.OK) && (depot.Selected != null))
                {
                    ClientApplication.Instance.SelectedDepot = depot.Selected;
                }
            }
        }

        private void btnSevkiyat_Click(object sender, EventArgs e)
        {
            using (FormSelectSevkiyat sevkiyat = new FormSelectSevkiyat(ClientApplication.Instance.SelectedDepot))
            {
                if ((sevkiyat.ShowDialog() == DialogResult.OK) && (sevkiyat.Selected != null))
                {
                    SevkiyatControl control = new SevkiyatControl(sevkiyat.Selected);
                    base.MainForm.ShowControl(control);
                }
            }
        }

        private void btnStokHareketi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen Hedef Depo Seciniz !");
            using (FormSelectDepot depot = new FormSelectDepot())
            {
                depot._OnlyWithLocation = false;
                depot.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (((depot.ShowDialog() == DialogResult.OK) && (depot.Selected != null)) && (depot.Selected.Id != ClientApplication.Instance.SelectedDepot.Id))
                {
                    base.MainForm.ShowControl(new StokHareketiControl(depot.Selected));
                }
            }
        }

        private void btnStokRafDurumu_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(new StokRafDurumuControl());
        }

        private void btnStokTransfer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen Hedef Depo Seciniz !");
            using (FormSelectDepot depot = new FormSelectDepot())
            {
                depot._OnlyWithLocation = false;
                depot.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (((depot.ShowDialog() == DialogResult.OK) && (depot.Selected != null)) && (depot.Selected.Id != ClientApplication.Instance.SelectedDepot.Id))
                {
                    base.MainForm.ShowControl(new DepoTransferControl(depot.Selected));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(new AcikBelgeSilControl());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSayim = new Button();
            this.btnStokHareketi = new Button();
            this.btnRafHareketi = new Button();
            this.btnSevkiyat = new Button();
            this.btnStokRafDurumu = new Button();
            this.btnPaletOlusturma = new Button();
            this.btnExit = new Button();
            this.btnSelectDepot = new Button();
            this.btnIrsaliye = new Button();
            this.btnStokTransfer = new Button();
            this.button1 = new Button();
            base.SuspendLayout();
            this.btnSayim.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnSayim.Enabled = false;
            this.btnSayim.Location = new Point(4, 4);
            this.btnSayim.Name = "btnSayim";
            this.btnSayim.Size = new Size(0xe9, 20);
            this.btnSayim.TabIndex = 0;
            this.btnSayim.Text = "Sayım";
            this.btnSayim.Click += new EventHandler(this.btnSayim_Click);
            this.btnStokHareketi.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnStokHareketi.Enabled = false;
            this.btnStokHareketi.Location = new Point(4, 0x31);
            this.btnStokHareketi.Name = "btnStokHareketi";
            this.btnStokHareketi.Size = new Size(0xe9, 20);
            this.btnStokHareketi.TabIndex = 1;
            this.btnStokHareketi.Text = "Raflı Depo Transferi";
            this.btnStokHareketi.Click += new EventHandler(this.btnStokHareketi_Click);
            this.btnRafHareketi.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnRafHareketi.Enabled = false;
            this.btnRafHareketi.Location = new Point(4, 0x47);
            this.btnRafHareketi.Name = "btnRafHareketi";
            this.btnRafHareketi.Size = new Size(0xe9, 20);
            this.btnRafHareketi.TabIndex = 2;
            this.btnRafHareketi.Text = "Depo İ\x00e7i Raf Hareketi";
            this.btnRafHareketi.Click += new EventHandler(this.btnRafHareketi_Click);
            this.btnSevkiyat.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnSevkiyat.Enabled = false;
            this.btnSevkiyat.Location = new Point(4, 120);
            this.btnSevkiyat.Name = "btnSevkiyat";
            this.btnSevkiyat.Size = new Size(0xe9, 20);
            this.btnSevkiyat.TabIndex = 3;
            this.btnSevkiyat.Text = "Mal Hazırlama";
            this.btnSevkiyat.Click += new EventHandler(this.btnSevkiyat_Click);
            this.btnStokRafDurumu.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnStokRafDurumu.Enabled = false;
            this.btnStokRafDurumu.Location = new Point(4, 0x1b);
            this.btnStokRafDurumu.Name = "btnStokRafDurumu";
            this.btnStokRafDurumu.Size = new Size(0xe9, 20);
            this.btnStokRafDurumu.TabIndex = 4;
            this.btnStokRafDurumu.Text = "Stok Raf Durumu";
            this.btnStokRafDurumu.Click += new EventHandler(this.btnStokRafDurumu_Click);
            this.btnPaletOlusturma.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnPaletOlusturma.Enabled = false;
            this.btnPaletOlusturma.Location = new Point(4, 0xac);
            this.btnPaletOlusturma.Name = "btnPaletOlusturma";
            this.btnPaletOlusturma.Size = new Size(0xe9, 20);
            this.btnPaletOlusturma.TabIndex = 5;
            this.btnPaletOlusturma.Text = "Palet Olusturma";
            this.btnPaletOlusturma.Click += new EventHandler(this.btnPaletOlusturma_Click);
            this.btnExit.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnExit.Location = new Point(3, 0xf7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0xe9, 20);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "\x00c7ıkış";
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnSelectDepot.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnSelectDepot.Location = new Point(4, 0xda);
            this.btnSelectDepot.Name = "btnSelectDepot";
            this.btnSelectDepot.Size = new Size(0xe9, 0x1a);
            this.btnSelectDepot.TabIndex = 8;
            this.btnSelectDepot.Text = "Depo Se\x00e7";
            this.btnSelectDepot.Click += new EventHandler(this.btnSelectDepot_Click);
            this.btnIrsaliye.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnIrsaliye.Location = new Point(4, 0x92);
            this.btnIrsaliye.Name = "btnIrsaliye";
            this.btnIrsaliye.Size = new Size(0xe9, 20);
            this.btnIrsaliye.TabIndex = 9;
            this.btnIrsaliye.Text = "İrsaliye";
            this.btnIrsaliye.Click += new EventHandler(this.btnIrsaliye_Click);
            this.btnStokTransfer.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnStokTransfer.Enabled = false;
            this.btnStokTransfer.Location = new Point(4, 0x5e);
            this.btnStokTransfer.Name = "btnStokTransfer";
            this.btnStokTransfer.Size = new Size(0xe9, 20);
            this.btnStokTransfer.TabIndex = 10;
            this.btnStokTransfer.Text = "Stok Transfer";
            this.btnStokTransfer.Click += new EventHandler(this.btnStokTransfer_Click);
            this.button1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.button1.Location = new Point(4, 0xc3);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0xe9, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ge\x00e7ici Dosya Sil";
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.button1);
            base.Controls.Add(this.btnStokTransfer);
            base.Controls.Add(this.btnIrsaliye);
            base.Controls.Add(this.btnSelectDepot);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnPaletOlusturma);
            base.Controls.Add(this.btnStokRafDurumu);
            base.Controls.Add(this.btnSevkiyat);
            base.Controls.Add(this.btnRafHareketi);
            base.Controls.Add(this.btnStokHareketi);
            base.Controls.Add(this.btnSayim);
            base.Name = "MainScreen";
            base.ResumeLayout(false);
        }

        private void OnSelectedDepotChanged(object sender, EventArgs e)
        {
            if (ClientApplication.Instance.SelectedDepot == null)
            {
                this.btnSelectDepot.Text = "Depo Se\x00e7";
            }
            else
            {
                this.btnSelectDepot.Text = "Depo: " + ClientApplication.Instance.SelectedDepot.Name;
            }
            bool flag = ClientApplication.Instance.SelectedDepot != null;
            this.btnSayim.Enabled = flag;
            this.btnSevkiyat.Enabled = flag;
            this.btnStokRafDurumu.Enabled = flag;
            this.btnRafHareketi.Enabled = flag;
            this.btnStokHareketi.Enabled = flag;
            this.btnPaletOlusturma.Enabled = flag;
            this.btnStokTransfer.Enabled = flag;
        }
    }
}

