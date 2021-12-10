namespace MobileWhouse.Controls
{
    partial class StokHareketiControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDepo = new System.Windows.Forms.Label();
            this.btnRaf = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMiktar = new MobileWhouse.Controls.DecimalTextBox();
            this.lblTargetDepo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtDocDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.txtItemCode = new MobileWhouse.Controls.BarkodTextBox();
            this.chkSil = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.Text = "Kyn.Depo";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.Text = "Kyn.Raf";
            // 
            // lblDepo
            // 
            this.lblDepo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepo.Location = new System.Drawing.Point(81, 23);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new System.Drawing.Size(156, 16);
            // 
            // btnRaf
            // 
            this.btnRaf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRaf.Location = new System.Drawing.Point(214, 43);
            this.btnRaf.Name = "btnRaf";
            this.btnRaf.Size = new System.Drawing.Size(23, 20);
            this.btnRaf.TabIndex = 7;
            this.btnRaf.Text = "...";
            this.btnRaf.Click += new System.EventHandler(this.btnRaf_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.Text = "Stok";
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.Columns.Add(this.columnHeader1);
            this.lstDetails.Columns.Add(this.columnHeader2);
            this.lstDetails.Location = new System.Drawing.Point(4, 111);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(233, 135);
            this.lstDetails.TabIndex = 13;
            this.lstDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Adı";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar";
            this.columnHeader2.Width = 60;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKaydet.Location = new System.Drawing.Point(165, 248);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(72, 20);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(87, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMiktar
            // 
            this.txtMiktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiktar.Location = new System.Drawing.Point(192, 65);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(45, 21);
            this.txtMiktar.TabIndex = 16;
            this.txtMiktar.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblTargetDepo
            // 
            this.lblTargetDepo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetDepo.Location = new System.Drawing.Point(81, 5);
            this.lblTargetDepo.Name = "lblTargetDepo";
            this.lblTargetDepo.Size = new System.Drawing.Size(156, 16);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.Text = "Hdf.Depo";
            // 
            // dtDocDate
            // 
            this.dtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDocDate.Location = new System.Drawing.Point(81, 87);
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.Size = new System.Drawing.Size(156, 22);
            this.dtDocDate.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.Text = "Belge Tarih";
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(81, 43);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(131, 21);
            this.txtRaf.TabIndex = 29;
            // 
            // txtItemCode
            // 
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.Location = new System.Drawing.Point(81, 65);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(109, 21);
            this.txtItemCode.TabIndex = 30;
            // 
            // chkSil
            // 
            this.chkSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSil.Location = new System.Drawing.Point(3, 249);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new System.Drawing.Size(55, 20);
            this.chkSil.TabIndex = 38;
            this.chkSil.Text = "Sil";
            // 
            // StokHareketiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chkSil);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.txtRaf);
            this.Controls.Add(this.dtDocDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTargetDepo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRaf);
            this.Controls.Add(this.lblDepo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StokHareketiControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDepo;
        private System.Windows.Forms.Button btnRaf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstDetails;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DecimalTextBox txtMiktar;
        private System.Windows.Forms.Label lblTargetDepo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDocDate;
        private System.Windows.Forms.Label label6;
        private RafTextBox txtRaf;
        private BarkodTextBox txtItemCode;
        private System.Windows.Forms.CheckBox chkSil;
    }
}
