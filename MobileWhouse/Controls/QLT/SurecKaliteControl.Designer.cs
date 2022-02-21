namespace MobileWhouse.Controls.QLT
{
    partial class SurecKaliteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurecKaliteControl));
            this.btnkapat = new System.Windows.Forms.Button();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.cmbkontrol = new MobileWhouse.GUI.ComboControl();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.img = new System.Windows.Forms.ImageList();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeger = new MobileWhouse.GUI.TextBoxNumeric();
            this.btnUpd = new System.Windows.Forms.Button();
            this.rdok = new System.Windows.Forms.RadioButton();
            this.rdred = new System.Windows.Forms.RadioButton();
            this.txtmiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.t1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textaciklama = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkapat
            // 
            this.btnkapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnkapat.Location = new System.Drawing.Point(0, 268);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(240, 47);
            this.btnkapat.TabIndex = 0;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.BackColor = System.Drawing.Color.White;
            this.txtisemri.Location = new System.Drawing.Point(82, 33);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(89, 21);
            this.txtisemri.TabIndex = 8;
            this.txtisemri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "İş Emri No";
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(16, 213);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(205, 29);
            this.btnkaydet.TabIndex = 12;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // cmbkontrol
            // 
            this.cmbkontrol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbkontrol.DataSourceType = MobileWhouse.Enums.DataSourceType.KontrolGrubu;
            this.cmbkontrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbkontrol.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbkontrol.Location = new System.Drawing.Point(82, 57);
            this.cmbkontrol.Name = "cmbkontrol";
            this.cmbkontrol.Size = new System.Drawing.Size(154, 22);
            this.cmbkontrol.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Kontrol G.";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 133);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 110);
            this.listView1.SmallImageList = this.img;
            this.listView1.TabIndex = 15;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "K. N";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "K. Adı";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ö. Değer";
            this.columnHeader7.Width = 60;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Min";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Max";
            this.columnHeader2.Width = 60;
            this.img.Images.Clear();
            this.img.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.img.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.img.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // lblbilgi
            // 
            this.lblbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbilgi.BackColor = System.Drawing.Color.White;
            this.lblbilgi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblbilgi.ForeColor = System.Drawing.Color.Brown;
            this.lblbilgi.Location = new System.Drawing.Point(4, 82);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(232, 22);
            this.lblbilgi.Text = "...";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "Sonuç";
            // 
            // txtDeger
            // 
            this.txtDeger.AllowSpace = false;
            this.txtDeger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeger.BackColor = System.Drawing.Color.SkyBlue;
            this.txtDeger.Location = new System.Drawing.Point(80, 106);
            this.txtDeger.Name = "txtDeger";
            this.txtDeger.Size = new System.Drawing.Size(91, 21);
            this.txtDeger.TabIndex = 25;
            this.txtDeger.Visible = false;
            // 
            // btnUpd
            // 
            this.btnUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpd.Location = new System.Drawing.Point(173, 104);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(64, 23);
            this.btnUpd.TabIndex = 27;
            this.btnUpd.Text = "Kaydet";
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // rdok
            // 
            this.rdok.Location = new System.Drawing.Point(62, 106);
            this.rdok.Name = "rdok";
            this.rdok.Size = new System.Drawing.Size(63, 21);
            this.rdok.TabIndex = 33;
            this.rdok.Text = "Kabul";
            // 
            // rdred
            // 
            this.rdred.Location = new System.Drawing.Point(118, 106);
            this.rdred.Name = "rdred";
            this.rdred.Size = new System.Drawing.Size(53, 21);
            this.rdred.TabIndex = 34;
            this.rdred.Text = "Red";
            // 
            // txtmiktar
            // 
            this.txtmiktar.AllowSpace = false;
            this.txtmiktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.txtmiktar.Location = new System.Drawing.Point(172, 33);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(64, 21);
            this.txtmiktar.TabIndex = 40;
            this.txtmiktar.Text = "1";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 75;
            this.txtistasyon.Location = new System.Drawing.Point(2, 2);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.PurchaseSales = -1;
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(235, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 46;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtistasyon);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.rdred);
            this.tabPage1.Controls.Add(this.txtmiktar);
            this.tabPage1.Controls.Add(this.rdok);
            this.tabPage1.Controls.Add(this.txtisemri);
            this.tabPage1.Controls.Add(this.btnUpd);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbkontrol);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDeger);
            this.tabPage1.Controls.Add(this.lblbilgi);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 245);
            this.tabPage1.Text = "Detaylar";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.t1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textaciklama);
            this.tabPage2.Controls.Add(this.btnkaydet);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 245);
            this.tabPage2.Text = "Kaydet";
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(215, 0);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(22, 20);
            this.t1.TabIndex = 15;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Açıklama";
            // 
            // textaciklama
            // 
            this.textaciklama.Location = new System.Drawing.Point(3, 21);
            this.textaciklama.Multiline = true;
            this.textaciklama.Name = "textaciklama";
            this.textaciklama.Size = new System.Drawing.Size(234, 60);
            this.textaciklama.TabIndex = 13;
            // 
            // SurecKaliteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkapat);
            this.Name = "SurecKaliteControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnkaydet;
        private MobileWhouse.GUI.ComboControl cmbkontrol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label lblbilgi;
        private System.Windows.Forms.Label label5;
        private MobileWhouse.GUI.TextBoxNumeric txtDeger;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RadioButton rdok;
        private System.Windows.Forms.RadioButton rdred;
        private System.Windows.Forms.ImageList img;
        private MobileWhouse.GUI.TextBoxNumeric txtmiktar;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button t1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textaciklama;
    }
}
