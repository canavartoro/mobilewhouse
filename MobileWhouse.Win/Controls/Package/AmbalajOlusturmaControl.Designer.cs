namespace MobileWhouse.Controls.Package
{
    partial class AmbalajOlusturmaControl
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
            this.txtStok = new MobileWhouse.Controls.BarkodTextBox();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dcQty = new MobileWhouse.Controls.DecimalTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textAciklama = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbparti = new MobileWhouse.GUI.ComboControl();
            this.txtdepo = new MobileWhouse.GUI.ULookupEdit();
            this.textCari = new MobileWhouse.GUI.ULookupEdit();
            this.txthareket = new MobileWhouse.GUI.ULookupEdit();
            this.btntest = new System.Windows.Forms.Button();
            this.numAmb = new MobileWhouse.GUI.TextBoxNumeric();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.printAmbPaletctrl = new MobileWhouse.GUI.UPrintControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.Text = "Plt";
            // 
            // txtPaletNo
            // 
            this.txtPaletNo.Location = new System.Drawing.Point(35, 191);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(129, 21);
            this.txtPaletNo.TabIndex = 1;
            this.txtPaletNo.TabStop = false;
            this.txtPaletNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaletNo_KeyPress);
            // 
            // btnYeniPalet
            // 
            this.btnYeniPalet.Location = new System.Drawing.Point(35, 216);
            this.btnYeniPalet.Name = "btnYeniPalet";
            this.btnYeniPalet.Size = new System.Drawing.Size(158, 26);
            this.btnYeniPalet.TabIndex = 8;
            this.btnYeniPalet.Text = "Kaydet";
            this.btnYeniPalet.Click += new System.EventHandler(this.btnYeniPalet_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.Text = "Stok";
            // 
            // txtStok
            // 
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.Location = new System.Drawing.Point(40, 56);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(128, 21);
            this.txtStok.TabIndex = 2;
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(40, 32);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(153, 21);
            this.txtRaf.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.Text = "Raf";
            // 
            // dcQty
            // 
            this.dcQty.Location = new System.Drawing.Point(170, 56);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new System.Drawing.Size(65, 21);
            this.dcQty.TabIndex = 3;
            this.dcQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(0, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 36);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.Text = "Not";
            // 
            // textAciklama
            // 
            this.textAciklama.Location = new System.Drawing.Point(40, 137);
            this.textAciklama.Name = "textAciklama";
            this.textAciklama.Size = new System.Drawing.Size(193, 21);
            this.textAciklama.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 284);
            this.tabControl1.TabIndex = 81;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbparti);
            this.tabPage1.Controls.Add(this.txtdepo);
            this.tabPage1.Controls.Add(this.textCari);
            this.tabPage1.Controls.Add(this.txthareket);
            this.tabPage1.Controls.Add(this.btntest);
            this.tabPage1.Controls.Add(this.numAmb);
            this.tabPage1.Controls.Add(this.txtPaletNo);
            this.tabPage1.Controls.Add(this.textAciklama);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnYeniPalet);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.txtStok);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dcQty);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 261);
            this.tabPage1.Text = "Ambalaj";
            // 
            // cmbparti
            // 
            this.cmbparti.DataSourceType = MobileWhouse.Enums.DataSourceType.PartiLot;
            this.cmbparti.FilterCondition = "";
            this.cmbparti.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbparti.Location = new System.Drawing.Point(40, 82);
            this.cmbparti.Name = "cmbparti";
            this.cmbparti.Size = new System.Drawing.Size(195, 22);
            this.cmbparti.TabIndex = 118;
            // 
            // txtdepo
            // 
            this.txtdepo.Browsable = true;
            this.txtdepo.DataFieldName = "";
            this.txtdepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.txtdepo.Description = "";
            this.txtdepo.FilterCondition = "";
            this.txtdepo.LabelText = "Depo";
            this.txtdepo.LabelWidth = 35;
            this.txtdepo.Location = new System.Drawing.Point(4, 162);
            this.txtdepo.Name = "txtdepo";
            this.txtdepo.PurchaseSales = -1;
            this.txtdepo.RememberValue = false;
            this.txtdepo.ShowDescription = false;
            this.txtdepo.ShowLabelText = false;
            this.txtdepo.Size = new System.Drawing.Size(233, 27);
            this.txtdepo.SourceApplication = 0;
            this.txtdepo.TabIndex = 112;
            this.txtdepo.OnSelected += new MobileWhouse.OnSelectedObject(this.txtdepo_OnSelected);
            // 
            // textCari
            // 
            this.textCari.Browsable = true;
            this.textCari.DataFieldName = "";
            this.textCari.DataType = MobileWhouse.Enums.DataSourceType.Cari;
            this.textCari.Description = "";
            this.textCari.FilterCondition = "";
            this.textCari.LabelText = "Cari";
            this.textCari.LabelWidth = 35;
            this.textCari.Location = new System.Drawing.Point(4, 107);
            this.textCari.Name = "textCari";
            this.textCari.PurchaseSales = -1;
            this.textCari.RememberValue = false;
            this.textCari.ShowDescription = false;
            this.textCari.ShowLabelText = false;
            this.textCari.Size = new System.Drawing.Size(233, 27);
            this.textCari.SourceApplication = 0;
            this.textCari.TabIndex = 105;
            this.textCari.OnSelected += new MobileWhouse.OnSelectedObject(this.textCari_OnSelected);
            // 
            // txthareket
            // 
            this.txthareket.Browsable = true;
            this.txthareket.DataFieldName = "";
            this.txthareket.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.txthareket.Description = "";
            this.txthareket.FilterCondition = "";
            this.txthareket.LabelText = "Tür";
            this.txthareket.LabelWidth = 35;
            this.txthareket.Location = new System.Drawing.Point(4, 2);
            this.txthareket.Name = "txthareket";
            this.txthareket.PurchaseSales = -1;
            this.txthareket.RememberValue = true;
            this.txthareket.ShowDescription = false;
            this.txthareket.ShowLabelText = false;
            this.txthareket.Size = new System.Drawing.Size(233, 27);
            this.txthareket.SourceApplication = 0;
            this.txthareket.TabIndex = 97;
            this.txthareket.OnSelected += new MobileWhouse.OnSelectedObject(this.txthareket_OnSelected);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(199, 216);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(38, 26);
            this.btntest.TabIndex = 88;
            this.btntest.Text = "Test";
            this.btntest.Visible = false;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // numAmb
            // 
            this.numAmb.AllowSpace = false;
            this.numAmb.BackColor = System.Drawing.Color.LightCyan;
            this.numAmb.Location = new System.Drawing.Point(195, 191);
            this.numAmb.Name = "numAmb";
            this.numAmb.Size = new System.Drawing.Size(38, 21);
            this.numAmb.TabIndex = 79;
            this.numAmb.Text = "1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(161, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 20);
            this.label8.Text = "X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.Text = "Parti";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.printAmbPaletctrl);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 261);
            this.tabPage2.Text = "Ayarlar";
            // 
            // printAmbPaletctrl
            // 
            this.printAmbPaletctrl.Location = new System.Drawing.Point(3, 3);
            this.printAmbPaletctrl.Name = "printAmbPaletctrl";
            this.printAmbPaletctrl.Size = new System.Drawing.Size(234, 74);
            this.printAmbPaletctrl.TabIndex = 0;
            // 
            // AmbalajOlusturmaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "AmbalajOlusturmaControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.OnLoad += new System.EventHandler(this.AmbalajOlusturmaControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Button btnYeniPalet;
        private System.Windows.Forms.Label label2;
        private BarkodTextBox txtStok;
        private RafTextBox txtRaf;
        private System.Windows.Forms.Label label3;
        private DecimalTextBox dcQty;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAciklama;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MobileWhouse.GUI.TextBoxNumeric numAmb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btntest;
        private MobileWhouse.GUI.UPrintControl printAmbPaletctrl;
        private MobileWhouse.GUI.ULookupEdit txthareket;
        private MobileWhouse.GUI.ULookupEdit textCari;
        private MobileWhouse.GUI.ULookupEdit txtdepo;
        private MobileWhouse.GUI.ComboControl cmbparti;
        private System.Windows.Forms.Label label4;
    }
}
