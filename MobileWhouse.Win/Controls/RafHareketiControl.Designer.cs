namespace MobileWhouse.Controls
{
    partial class RafHareketiControl
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
            this.lstDetails = new System.Windows.Forms.ListView();
            this.StokAd = new System.Windows.Forms.ColumnHeader();
            this.Miktar = new System.Windows.Forms.ColumnHeader();
            this.dteDocDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHareketKod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStok = new MobileWhouse.Controls.BarkodTextBox();
            this.txtRafCikis = new MobileWhouse.Controls.RafTextBox();
            this.txtRafGiris = new MobileWhouse.Controls.RafTextBox();
            this.chkSil = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dcQty = new MobileWhouse.Controls.DecimalTextBox();
            this.btnhareket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.Columns.Add(this.StokAd);
            this.lstDetails.Columns.Add(this.Miktar);
            this.lstDetails.Location = new System.Drawing.Point(2, 92);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(235, 157);
            this.lstDetails.TabIndex = 26;
            this.lstDetails.View = System.Windows.Forms.View.Details;
            // 
            // StokAd
            // 
            this.StokAd.Text = "Stok Adı";
            this.StokAd.Width = 159;
            // 
            // Miktar
            // 
            this.Miktar.Text = "Miktar";
            this.Miktar.Width = 70;
            // 
            // dteDocDate
            // 
            this.dteDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDocDate.Location = new System.Drawing.Point(79, 46);
            this.dteDocDate.Name = "dteDocDate";
            this.dteDocDate.Size = new System.Drawing.Size(158, 22);
            this.dteDocDate.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.Text = "Belge Tarih";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "Raf";
            // 
            // txtHareketKod
            // 
            this.txtHareketKod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHareketKod.Location = new System.Drawing.Point(79, 2);
            this.txtHareketKod.Name = "txtHareketKod";
            this.txtHareketKod.Size = new System.Drawing.Size(118, 21);
            this.txtHareketKod.TabIndex = 21;
            this.txtHareketKod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHareketKod_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.Text = "Hareket Kod";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.Text = "Barkod";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(158, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 20);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStok
            // 
            this.txtStok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.IsTransfer = false;
            this.txtStok.Location = new System.Drawing.Point(79, 69);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(110, 21);
            this.txtStok.TabIndex = 44;
            // 
            // txtRafCikis
            // 
            this.txtRafCikis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRafCikis.DepoId = 0;
            this.txtRafCikis.Enabled = false;
            this.txtRafCikis.IsRaf = 1;
            this.txtRafCikis.IsTransfer = true;
            this.txtRafCikis.Location = new System.Drawing.Point(79, 24);
            this.txtRafCikis.Name = "txtRafCikis";
            this.txtRafCikis.Size = new System.Drawing.Size(73, 21);
            this.txtRafCikis.TabIndex = 45;
            // 
            // txtRafGiris
            // 
            this.txtRafGiris.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRafGiris.DepoId = 0;
            this.txtRafGiris.Enabled = false;
            this.txtRafGiris.IsRaf = 1;
            this.txtRafGiris.IsTransfer = false;
            this.txtRafGiris.Location = new System.Drawing.Point(158, 24);
            this.txtRafGiris.Name = "txtRafGiris";
            this.txtRafGiris.Size = new System.Drawing.Size(79, 21);
            this.txtRafGiris.TabIndex = 46;
            // 
            // chkSil
            // 
            this.chkSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSil.Location = new System.Drawing.Point(22, 251);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new System.Drawing.Size(44, 20);
            this.chkSil.TabIndex = 48;
            this.chkSil.Text = "Sil";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(80, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dcQty
            // 
            this.dcQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dcQty.Location = new System.Drawing.Point(191, 69);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new System.Drawing.Size(46, 21);
            this.dcQty.TabIndex = 66;
            this.dcQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnhareket
            // 
            this.btnhareket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhareket.Location = new System.Drawing.Point(199, 2);
            this.btnhareket.Name = "btnhareket";
            this.btnhareket.Size = new System.Drawing.Size(38, 20);
            this.btnhareket.TabIndex = 71;
            this.btnhareket.Text = "...";
            this.btnhareket.Click += new System.EventHandler(this.btnhareket_Click);
            // 
            // RafHareketiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnhareket);
            this.Controls.Add(this.dcQty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkSil);
            this.Controls.Add(this.txtRafGiris);
            this.Controls.Add(this.txtRafCikis);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.dteDocDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHareketKod);
            this.Controls.Add(this.label1);
            this.Name = "RafHareketiControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstDetails;
        private System.Windows.Forms.DateTimePicker dteDocDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHareketKod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private BarkodTextBox txtStok;
        private RafTextBox txtRafCikis;
        private RafTextBox txtRafGiris;
        private System.Windows.Forms.ColumnHeader StokAd;
        private System.Windows.Forms.ColumnHeader Miktar;
        private System.Windows.Forms.CheckBox chkSil;
        private System.Windows.Forms.Button btnClose;
        private DecimalTextBox dcQty;
        private System.Windows.Forms.Button btnhareket;

    }
}
