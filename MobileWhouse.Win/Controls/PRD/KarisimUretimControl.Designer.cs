namespace MobileWhouse.Controls.PRD
{
    partial class KarisimUretimControl
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
            this.btnKapat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listRecete = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.btndegistir = new System.Windows.Forms.Button();
            this.txtkoliici = new MobileWhouse.GUI.TextBoxNumeric();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.printkarisim = new MobileWhouse.GUI.UPrintControl();
            this.btnyazdir = new System.Windows.Forms.Button();
            this.listBarkod = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.textBarkod = new System.Windows.Forms.TextBox();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chksil = new System.Windows.Forms.CheckBox();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.Location = new System.Drawing.Point(0, 292);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(240, 28);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 292);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtisemri);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listRecete);
            this.tabPage1.Controls.Add(this.btndegistir);
            this.tabPage1.Controls.Add(this.txtkoliici);
            this.tabPage1.Controls.Add(this.txtistasyon);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 269);
            this.tabPage1.Text = "Reçete";
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(81, 30);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(154, 21);
            this.txtisemri.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "İş Emri No";
            // 
            // listRecete
            // 
            this.listRecete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listRecete.Columns.Add(this.columnHeader1);
            this.listRecete.Columns.Add(this.columnHeader2);
            this.listRecete.Columns.Add(this.columnHeader9);
            this.listRecete.Columns.Add(this.columnHeader3);
            this.listRecete.Columns.Add(this.columnHeader4);
            this.listRecete.Columns.Add(this.columnHeader11);
            this.listRecete.FullRowSelect = true;
            this.listRecete.Location = new System.Drawing.Point(2, 78);
            this.listRecete.Name = "listRecete";
            this.listRecete.Size = new System.Drawing.Size(233, 189);
            this.listRecete.TabIndex = 16;
            this.listRecete.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Kodu";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Adı";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Birim";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Gereken";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Okunan";
            this.columnHeader11.Width = 60;
            // 
            // btndegistir
            // 
            this.btndegistir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndegistir.Location = new System.Drawing.Point(141, 54);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(94, 23);
            this.btndegistir.TabIndex = 15;
            this.btndegistir.Text = "Değiştir";
            this.btndegistir.Click += new System.EventHandler(this.btndegistir_Click);
            // 
            // txtkoliici
            // 
            this.txtkoliici.AllowSpace = false;
            this.txtkoliici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtkoliici.BackColor = System.Drawing.Color.SkyBlue;
            this.txtkoliici.Location = new System.Drawing.Point(81, 54);
            this.txtkoliici.Name = "txtkoliici";
            this.txtkoliici.Size = new System.Drawing.Size(57, 21);
            this.txtkoliici.TabIndex = 13;
            this.txtkoliici.Text = "0.00";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Browsable = false;
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 70;
            this.txtistasyon.Location = new System.Drawing.Point(2, 1);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.PurchaseSales = -1;
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(233, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 19;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Kazan Miktar";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.printkarisim);
            this.tabPage2.Controls.Add(this.btnyazdir);
            this.tabPage2.Controls.Add(this.listBarkod);
            this.tabPage2.Controls.Add(this.textBarkod);
            this.tabPage2.Controls.Add(this.btnbarkod);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.chksil);
            this.tabPage2.Controls.Add(this.lblbilgi);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 266);
            this.tabPage2.Text = "Üretim";
            // 
            // printkarisim
            // 
            this.printkarisim.Location = new System.Drawing.Point(3, 3);
            this.printkarisim.Name = "printkarisim";
            this.printkarisim.Size = new System.Drawing.Size(234, 74);
            this.printkarisim.TabIndex = 55;
            // 
            // btnyazdir
            // 
            this.btnyazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnyazdir.Location = new System.Drawing.Point(133, 105);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.Size = new System.Drawing.Size(96, 25);
            this.btnyazdir.TabIndex = 50;
            this.btnyazdir.Text = "Yazdir";
            this.btnyazdir.Click += new System.EventHandler(this.btnyazdir_Click);
            // 
            // listBarkod
            // 
            this.listBarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBarkod.Columns.Add(this.columnHeader5);
            this.listBarkod.Columns.Add(this.columnHeader6);
            this.listBarkod.Columns.Add(this.columnHeader7);
            this.listBarkod.Columns.Add(this.columnHeader8);
            this.listBarkod.Columns.Add(this.columnHeader10);
            this.listBarkod.Columns.Add(this.columnHeader12);
            this.listBarkod.Columns.Add(this.columnHeader15);
            this.listBarkod.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listBarkod.Location = new System.Drawing.Point(3, 133);
            this.listBarkod.Name = "listBarkod";
            this.listBarkod.Size = new System.Drawing.Size(226, 132);
            this.listBarkod.TabIndex = 49;
            this.listBarkod.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Barkod";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stok Kod";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Stok Adı";
            this.columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Birim";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Miktar";
            this.columnHeader10.Width = 60;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Cikilan";
            this.columnHeader12.Width = 60;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Alt. Stok Kodu";
            this.columnHeader15.Width = 100;
            // 
            // textBarkod
            // 
            this.textBarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBarkod.BackColor = System.Drawing.Color.Yellow;
            this.textBarkod.Location = new System.Drawing.Point(59, 81);
            this.textBarkod.Name = "textBarkod";
            this.textBarkod.Size = new System.Drawing.Size(129, 21);
            this.textBarkod.TabIndex = 43;
            this.textBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBarkod_KeyPress);
            // 
            // btnbarkod
            // 
            this.btnbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbarkod.Location = new System.Drawing.Point(189, 81);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(37, 21);
            this.btnbarkod.TabIndex = 44;
            this.btnbarkod.Text = "...";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(1, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.Text = "Barkod:";
            // 
            // chksil
            // 
            this.chksil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksil.Location = new System.Drawing.Point(85, 107);
            this.chksil.Name = "chksil";
            this.chksil.Size = new System.Drawing.Size(46, 20);
            this.chksil.TabIndex = 48;
            this.chksil.Text = "Sil";
            // 
            // lblbilgi
            // 
            this.lblbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbilgi.Location = new System.Drawing.Point(1, 105);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(94, 25);
            this.lblbilgi.Text = "Satır sayısı 0";
            // 
            // KarisimUretimControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKapat);
            this.Name = "KarisimUretimControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.OnLoad += new System.EventHandler(this.KarisimUretimControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label2;
        private MobileWhouse.GUI.TextBoxNumeric txtkoliici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btndegistir;
        private System.Windows.Forms.ListView listRecete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBarkod;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chksil;
        private System.Windows.Forms.ListView listBarkod;
        private System.Windows.Forms.Button btnyazdir;
        private System.Windows.Forms.Label lblbilgi;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
        private MobileWhouse.GUI.UPrintControl printkarisim;
        private System.Windows.Forms.ColumnHeader columnHeader15;
    }
}
