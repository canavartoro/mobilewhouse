namespace MobileWhouse.Controls.Package
{
    partial class PaletOlusturmaControl
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
            this.txtPaletNo = new System.Windows.Forms.TextBox();
            this.btnYeniPalet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstPackageDetail = new System.Windows.Forms.ListView();
            this.StokKod = new System.Windows.Forms.ColumnHeader();
            this.Birim = new System.Windows.Forms.ColumnHeader();
            this.Miktar = new System.Windows.Forms.ColumnHeader();
            this.txtStok = new MobileWhouse.Controls.BarkodTextBox();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dcQty = new MobileWhouse.Controls.DecimalTextBox();
            this.chkSil = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.printPaletctrl = new MobileWhouse.GUI.UPrintControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "Palet No";
            // 
            // txtPaletNo
            // 
            this.txtPaletNo.Location = new System.Drawing.Point(63, 3);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaletNo.TabIndex = 1;
            // 
            // btnYeniPalet
            // 
            this.btnYeniPalet.BackColor = System.Drawing.Color.Empty;
            this.btnYeniPalet.ForeColor = System.Drawing.Color.Empty;
            this.btnYeniPalet.Location = new System.Drawing.Point(169, 4);
            this.btnYeniPalet.Name = "btnYeniPalet";
            this.btnYeniPalet.Size = new System.Drawing.Size(51, 20);
            this.btnYeniPalet.TabIndex = 3;
            this.btnYeniPalet.Text = "Yeni";
            this.btnYeniPalet.Click += new System.EventHandler(this.btnYeniPalet_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.Text = "Stok";
            // 
            // lstPackageDetail
            // 
            this.lstPackageDetail.Columns.Add(this.StokKod);
            this.lstPackageDetail.Columns.Add(this.Birim);
            this.lstPackageDetail.Columns.Add(this.Miktar);
            this.lstPackageDetail.Location = new System.Drawing.Point(0, 141);
            this.lstPackageDetail.Name = "lstPackageDetail";
            this.lstPackageDetail.Size = new System.Drawing.Size(234, 135);
            this.lstPackageDetail.TabIndex = 6;
            this.lstPackageDetail.View = System.Windows.Forms.View.Details;
            // 
            // StokKod
            // 
            this.StokKod.Text = "Stok Kod";
            this.StokKod.Width = 110;
            // 
            // Birim
            // 
            this.Birim.Text = "Birim";
            this.Birim.Width = 60;
            // 
            // Miktar
            // 
            this.Miktar.Text = "Miktar";
            this.Miktar.Width = 60;
            // 
            // txtStok
            // 
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.Location = new System.Drawing.Point(34, 47);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(129, 21);
            this.txtStok.TabIndex = 7;
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(34, 25);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(129, 21);
            this.txtRaf.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.Text = "Raf";
            // 
            // dcQty
            // 
            this.dcQty.Location = new System.Drawing.Point(169, 47);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new System.Drawing.Size(65, 21);
            this.dcQty.TabIndex = 10;
            this.dcQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chkSil
            // 
            this.chkSil.Location = new System.Drawing.Point(169, 25);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new System.Drawing.Size(51, 20);
            this.chkSil.TabIndex = 11;
            this.chkSil.Text = "Sil";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.Color.Empty;
            this.btnClose.Location = new System.Drawing.Point(162, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(112, 276);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 20);
            this.checkBox1.TabIndex = 61;
            this.checkBox1.Text = "Sil";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Empty;
            this.btnprint.ForeColor = System.Drawing.Color.Empty;
            this.btnprint.Location = new System.Drawing.Point(0, 276);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(86, 32);
            this.btnprint.TabIndex = 67;
            this.btnprint.Text = "Yazdır";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // printPaletctrl
            // 
            this.printPaletctrl.Location = new System.Drawing.Point(0, 70);
            this.printPaletctrl.Name = "printPaletctrl";
            this.printPaletctrl.Size = new System.Drawing.Size(234, 74);
            this.printPaletctrl.TabIndex = 71;
            // 
            // PaletOlusturmaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtRaf);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkSil);
            this.Controls.Add(this.dcQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstPackageDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnYeniPalet);
            this.Controls.Add(this.txtPaletNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printPaletctrl);
            this.Name = "PaletOlusturmaControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Button btnYeniPalet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstPackageDetail;
        private System.Windows.Forms.ColumnHeader StokKod;
        private System.Windows.Forms.ColumnHeader Miktar;
        private BarkodTextBox txtStok;
        private RafTextBox txtRaf;
        private System.Windows.Forms.Label label3;
        private DecimalTextBox dcQty;
        private System.Windows.Forms.CheckBox chkSil;
        private System.Windows.Forms.ColumnHeader Birim;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnprint;
        private MobileWhouse.GUI.UPrintControl printPaletctrl;
    }
}
