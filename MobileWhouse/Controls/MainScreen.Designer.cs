namespace MobileWhouse.Controls
{
    partial class MainScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btnSayim = new System.Windows.Forms.Button();
            this.btnStokHareketi = new System.Windows.Forms.Button();
            this.btnRafHareketi = new System.Windows.Forms.Button();
            this.btnSevkiyat = new System.Windows.Forms.Button();
            this.btnStokRafDurumu = new System.Windows.Forms.Button();
            this.btnPaletOlusturma = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelectDepot = new System.Windows.Forms.Button();
            this.btnIrsaliye = new System.Windows.Forms.Button();
            this.btnStokTransfer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUretim = new System.Windows.Forms.Button();
            this.lblversion = new System.Windows.Forms.Label();
            this.btnmalkabul = new System.Windows.Forms.Button();
            this.btnkalite = new System.Windows.Forms.Button();
            this.btnambalaj = new System.Windows.Forms.Button();
            this.btnayar = new MobileWhouse.GUI.ColourButton();
            this.SuspendLayout();
            // 
            // btnSayim
            // 
            this.btnSayim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSayim.Enabled = false;
            this.btnSayim.Location = new System.Drawing.Point(5, 4);
            this.btnSayim.Name = "btnSayim";
            this.btnSayim.Size = new System.Drawing.Size(110, 20);
            this.btnSayim.TabIndex = 0;
            this.btnSayim.Text = "Sayım";
            this.btnSayim.Click += new System.EventHandler(this.btnSayim_Click);
            // 
            // btnStokHareketi
            // 
            this.btnStokHareketi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokHareketi.Enabled = false;
            this.btnStokHareketi.Location = new System.Drawing.Point(6, 30);
            this.btnStokHareketi.Name = "btnStokHareketi";
            this.btnStokHareketi.Size = new System.Drawing.Size(231, 20);
            this.btnStokHareketi.TabIndex = 1;
            this.btnStokHareketi.Text = "Raflı Depo Transferi";
            this.btnStokHareketi.Click += new System.EventHandler(this.btnStokHareketi_Click);
            // 
            // btnRafHareketi
            // 
            this.btnRafHareketi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRafHareketi.Enabled = false;
            this.btnRafHareketi.Location = new System.Drawing.Point(6, 54);
            this.btnRafHareketi.Name = "btnRafHareketi";
            this.btnRafHareketi.Size = new System.Drawing.Size(231, 20);
            this.btnRafHareketi.TabIndex = 2;
            this.btnRafHareketi.Text = "Depo İçi Raf Hareketi";
            this.btnRafHareketi.Click += new System.EventHandler(this.btnRafHareketi_Click);
            // 
            // btnSevkiyat
            // 
            this.btnSevkiyat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSevkiyat.Enabled = false;
            this.btnSevkiyat.Location = new System.Drawing.Point(5, 106);
            this.btnSevkiyat.Name = "btnSevkiyat";
            this.btnSevkiyat.Size = new System.Drawing.Size(109, 20);
            this.btnSevkiyat.TabIndex = 3;
            this.btnSevkiyat.Text = "Mal Hazırlama";
            this.btnSevkiyat.Click += new System.EventHandler(this.btnSevkiyat_Click);
            // 
            // btnStokRafDurumu
            // 
            this.btnStokRafDurumu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokRafDurumu.Enabled = false;
            this.btnStokRafDurumu.Location = new System.Drawing.Point(121, 4);
            this.btnStokRafDurumu.Name = "btnStokRafDurumu";
            this.btnStokRafDurumu.Size = new System.Drawing.Size(116, 20);
            this.btnStokRafDurumu.TabIndex = 4;
            this.btnStokRafDurumu.Text = "Stok Raf Durumu";
            this.btnStokRafDurumu.Click += new System.EventHandler(this.btnStokRafDurumu_Click);
            // 
            // btnPaletOlusturma
            // 
            this.btnPaletOlusturma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaletOlusturma.Enabled = false;
            this.btnPaletOlusturma.Location = new System.Drawing.Point(121, 158);
            this.btnPaletOlusturma.Name = "btnPaletOlusturma";
            this.btnPaletOlusturma.Size = new System.Drawing.Size(116, 20);
            this.btnPaletOlusturma.TabIndex = 5;
            this.btnPaletOlusturma.Text = "Palet Olusturma";
            this.btnPaletOlusturma.Click += new System.EventHandler(this.btnPaletOlusturma_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(129, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelectDepot
            // 
            this.btnSelectDepot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDepot.Location = new System.Drawing.Point(5, 285);
            this.btnSelectDepot.Name = "btnSelectDepot";
            this.btnSelectDepot.Size = new System.Drawing.Size(118, 32);
            this.btnSelectDepot.TabIndex = 8;
            this.btnSelectDepot.Text = "Depo Seç";
            this.btnSelectDepot.Click += new System.EventHandler(this.btnSelectDepot_Click);
            // 
            // btnIrsaliye
            // 
            this.btnIrsaliye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrsaliye.Enabled = false;
            this.btnIrsaliye.Location = new System.Drawing.Point(121, 106);
            this.btnIrsaliye.Name = "btnIrsaliye";
            this.btnIrsaliye.Size = new System.Drawing.Size(116, 20);
            this.btnIrsaliye.TabIndex = 9;
            this.btnIrsaliye.Text = "İrsaliye";
            this.btnIrsaliye.Click += new System.EventHandler(this.btnIrsaliye_Click);
            // 
            // btnStokTransfer
            // 
            this.btnStokTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokTransfer.Enabled = false;
            this.btnStokTransfer.Location = new System.Drawing.Point(5, 80);
            this.btnStokTransfer.Name = "btnStokTransfer";
            this.btnStokTransfer.Size = new System.Drawing.Size(232, 20);
            this.btnStokTransfer.TabIndex = 10;
            this.btnStokTransfer.Text = "Stok Transfer";
            this.btnStokTransfer.Click += new System.EventHandler(this.btnStokTransfer_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(4, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "Geçici Dosya Sil";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUretim
            // 
            this.btnUretim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUretim.Enabled = false;
            this.btnUretim.Location = new System.Drawing.Point(5, 132);
            this.btnUretim.Name = "btnUretim";
            this.btnUretim.Size = new System.Drawing.Size(110, 20);
            this.btnUretim.TabIndex = 3;
            this.btnUretim.Text = "Üretim";
            this.btnUretim.Click += new System.EventHandler(this.btnUretim_Click);
            // 
            // lblversion
            // 
            this.lblversion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblversion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblversion.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblversion.Location = new System.Drawing.Point(5, 237);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(232, 45);
            this.lblversion.Text = "V:2.0.0";
            this.lblversion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnmalkabul
            // 
            this.btnmalkabul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmalkabul.Enabled = false;
            this.btnmalkabul.Location = new System.Drawing.Point(6, 184);
            this.btnmalkabul.Name = "btnmalkabul";
            this.btnmalkabul.Size = new System.Drawing.Size(231, 20);
            this.btnmalkabul.TabIndex = 9;
            this.btnmalkabul.Text = "Mal Kabul";
            this.btnmalkabul.Click += new System.EventHandler(this.btnmalkabul_Click);
            // 
            // btnkalite
            // 
            this.btnkalite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkalite.Enabled = false;
            this.btnkalite.Location = new System.Drawing.Point(121, 132);
            this.btnkalite.Name = "btnkalite";
            this.btnkalite.Size = new System.Drawing.Size(116, 20);
            this.btnkalite.TabIndex = 5;
            this.btnkalite.Text = "Kalite Kontrol";
            this.btnkalite.Click += new System.EventHandler(this.btnkalite_Click);
            // 
            // btnambalaj
            // 
            this.btnambalaj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnambalaj.Location = new System.Drawing.Point(6, 158);
            this.btnambalaj.Name = "btnambalaj";
            this.btnambalaj.Size = new System.Drawing.Size(107, 20);
            this.btnambalaj.TabIndex = 12;
            this.btnambalaj.Text = "Ambalaj ";
            this.btnambalaj.Click += new System.EventHandler(this.btnambalaj_Click);
            // 
            // btnayar
            // 
            this.btnayar.BackColor = System.Drawing.Color.Empty;
            this.btnayar.ForeColor = System.Drawing.Color.Empty;
            this.btnayar.Image = ((System.Drawing.Image)(resources.GetObject("btnayar.Image")));
            this.btnayar.Location = new System.Drawing.Point(6, 226);
            this.btnayar.Name = "btnayar";
            this.btnayar.NormalBtnColour = System.Drawing.SystemColors.Control;
            this.btnayar.NormalTxtColour = System.Drawing.SystemColors.Control;
            this.btnayar.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnayar.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnayar.Size = new System.Drawing.Size(28, 30);
            this.btnayar.TabIndex = 14;
            this.btnayar.Click += new System.EventHandler(this.btnayar_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnayar);
            this.Controls.Add(this.btnambalaj);
            this.Controls.Add(this.lblversion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStokTransfer);
            this.Controls.Add(this.btnmalkabul);
            this.Controls.Add(this.btnIrsaliye);
            this.Controls.Add(this.btnSelectDepot);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnkalite);
            this.Controls.Add(this.btnPaletOlusturma);
            this.Controls.Add(this.btnStokRafDurumu);
            this.Controls.Add(this.btnUretim);
            this.Controls.Add(this.btnSevkiyat);
            this.Controls.Add(this.btnRafHareketi);
            this.Controls.Add(this.btnStokHareketi);
            this.Controls.Add(this.btnSayim);
            this.Name = "MainScreen";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSayim;
        private System.Windows.Forms.Button btnStokHareketi;
        private System.Windows.Forms.Button btnRafHareketi;
        private System.Windows.Forms.Button btnSevkiyat;
        private System.Windows.Forms.Button btnStokRafDurumu;
        private System.Windows.Forms.Button btnPaletOlusturma;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelectDepot;
        private System.Windows.Forms.Button btnIrsaliye;
        private System.Windows.Forms.Button btnStokTransfer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUretim;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.Button btnmalkabul;
        private System.Windows.Forms.Button btnkalite;
        private System.Windows.Forms.Button btnambalaj;
        private MobileWhouse.GUI.ColourButton btnayar;
    }
}
