namespace MobileWhouse.Controls.QLT
{
    partial class DiscordReportsControl
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
            this.btnkayit = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbDiscordReportState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDiscordReportSource = new System.Windows.Forms.ComboBox();
            this.cmbDiscordReportOptions = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStok = new MobileWhouse.Controls.BarkodTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texthurda = new MobileWhouse.GUI.TextBoxNumeric();
            this.textmiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.seccari = new MobileWhouse.GUI.ULookupEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboperator = new MobileWhouse.GUI.ComboControl();
            this.label7 = new System.Windows.Forms.Label();
            this.cmboperasyon = new MobileWhouse.GUI.ComboControl();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbistasyon = new MobileWhouse.GUI.ComboControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textTanim = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Button();
            this.t1 = new System.Windows.Forms.Button();
            this.textKonu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbkonu = new MobileWhouse.GUI.ComboControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkayit
            // 
            this.btnkayit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkayit.Location = new System.Drawing.Point(131, 286);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(106, 31);
            this.btnkayit.TabIndex = 3;
            this.btnkayit.Text = "Kaydet";
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(3, 286);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(107, 31);
            this.btnkapat.TabIndex = 2;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.date.CustomFormat = "dd.MM.yyyy";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(76, 7);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(81, 22);
            this.date.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "Tarih";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 280);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbDiscordReportState);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbDiscordReportSource);
            this.tabPage1.Controls.Add(this.cmbDiscordReportOptions);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtStok);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.texthurda);
            this.tabPage1.Controls.Add(this.textmiktar);
            this.tabPage1.Controls.Add(this.seccari);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cmboperator);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cmboperasyon);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cmbistasyon);
            this.tabPage1.Controls.Add(this.date);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 257);
            this.tabPage1.Text = "Bilgiler";
            // 
            // cmbDiscordReportState
            // 
            this.cmbDiscordReportState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDiscordReportState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbDiscordReportState.Items.Add("Açık");
            this.cmbDiscordReportState.Items.Add("Kapalı");
            this.cmbDiscordReportState.Location = new System.Drawing.Point(159, 7);
            this.cmbDiscordReportState.Name = "cmbDiscordReportState";
            this.cmbDiscordReportState.Size = new System.Drawing.Size(74, 22);
            this.cmbDiscordReportState.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Kay/Seç";
            // 
            // cmbDiscordReportSource
            // 
            this.cmbDiscordReportSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbDiscordReportSource.Items.Add("Fatura");
            this.cmbDiscordReportSource.Items.Add("İrsaliye");
            this.cmbDiscordReportSource.Items.Add("Üretim");
            this.cmbDiscordReportSource.Items.Add("MüşteriŞikayeti");
            this.cmbDiscordReportSource.Items.Add("İçDenetim");
            this.cmbDiscordReportSource.Items.Add("Tedarikçi");
            this.cmbDiscordReportSource.Items.Add("MüşteriÖnerisi");
            this.cmbDiscordReportSource.Items.Add("PersonelÖnerisi");
            this.cmbDiscordReportSource.Location = new System.Drawing.Point(76, 140);
            this.cmbDiscordReportSource.Name = "cmbDiscordReportSource";
            this.cmbDiscordReportSource.Size = new System.Drawing.Size(72, 22);
            this.cmbDiscordReportSource.TabIndex = 49;
            // 
            // cmbDiscordReportOptions
            // 
            this.cmbDiscordReportOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbDiscordReportOptions.Items.Add("MüşteriİçinRapor");
            this.cmbDiscordReportOptions.Items.Add("TedarikçiİçinRapor");
            this.cmbDiscordReportOptions.Items.Add("FirmaİçiRapor");
            this.cmbDiscordReportOptions.Location = new System.Drawing.Point(154, 140);
            this.cmbDiscordReportOptions.Name = "cmbDiscordReportOptions";
            this.cmbDiscordReportOptions.Size = new System.Drawing.Size(79, 22);
            this.cmbDiscordReportOptions.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.Text = "Stok";
            // 
            // txtStok
            // 
            this.txtStok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.Location = new System.Drawing.Point(76, 113);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(157, 21);
            this.txtStok.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.Text = "Miktar/Hurda";
            // 
            // texthurda
            // 
            this.texthurda.AllowSpace = false;
            this.texthurda.BackColor = System.Drawing.Color.SkyBlue;
            this.texthurda.Location = new System.Drawing.Point(169, 201);
            this.texthurda.Name = "texthurda";
            this.texthurda.Size = new System.Drawing.Size(64, 21);
            this.texthurda.TabIndex = 29;
            // 
            // textmiktar
            // 
            this.textmiktar.AllowSpace = false;
            this.textmiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.textmiktar.Location = new System.Drawing.Point(104, 201);
            this.textmiktar.Name = "textmiktar";
            this.textmiktar.Size = new System.Drawing.Size(64, 21);
            this.textmiktar.TabIndex = 29;
            // 
            // seccari
            // 
            this.seccari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.seccari.DataFieldName = "";
            this.seccari.DataType = MobileWhouse.Enums.DataSourceType.Cari;
            this.seccari.Description = "";
            this.seccari.FilterCondition = "";
            this.seccari.LabelText = "Cari";
            this.seccari.LabelWidth = 70;
            this.seccari.Location = new System.Drawing.Point(6, 168);
            this.seccari.Name = "seccari";
            this.seccari.PurchaseSales = -1;
            this.seccari.RememberValue = false;
            this.seccari.ShowDescription = false;
            this.seccari.ShowLabelText = false;
            this.seccari.Size = new System.Drawing.Size(227, 27);
            this.seccari.SourceApplication = 0;
            this.seccari.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.Text = "Operatör";
            // 
            // cmboperator
            // 
            this.cmboperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboperator.DataSourceType = MobileWhouse.Enums.DataSourceType.Personel;
            this.cmboperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmboperator.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmboperator.Location = new System.Drawing.Point(76, 85);
            this.cmboperator.Name = "cmboperator";
            this.cmboperator.Size = new System.Drawing.Size(157, 22);
            this.cmboperator.TabIndex = 18;
            this.cmboperator.Tag = "Operatör kodu seçilmelidir!";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.Text = "Operasyon";
            // 
            // cmboperasyon
            // 
            this.cmboperasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboperasyon.DataSourceType = MobileWhouse.Enums.DataSourceType.Operasyon;
            this.cmboperasyon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmboperasyon.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmboperasyon.Location = new System.Drawing.Point(76, 59);
            this.cmboperasyon.Name = "cmboperasyon";
            this.cmboperasyon.Size = new System.Drawing.Size(157, 22);
            this.cmboperasyon.TabIndex = 16;
            this.cmboperasyon.Tag = "Operasyon Kodu seçilmelidir!";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.Text = "İstasyon";
            // 
            // cmbistasyon
            // 
            this.cmbistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbistasyon.DataSourceType = MobileWhouse.Enums.DataSourceType.Istasyon;
            this.cmbistasyon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbistasyon.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbistasyon.Location = new System.Drawing.Point(76, 33);
            this.cmbistasyon.Name = "cmbistasyon";
            this.cmbistasyon.Size = new System.Drawing.Size(157, 22);
            this.cmbistasyon.TabIndex = 14;
            this.cmbistasyon.Tag = "İstasyon Kodu seçilmelidir!";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textTanim);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.t2);
            this.tabPage2.Controls.Add(this.t1);
            this.tabPage2.Controls.Add(this.textKonu);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cmbkonu);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 257);
            this.tabPage2.Text = "Uygunsuzluk";
            // 
            // textTanim
            // 
            this.textTanim.Location = new System.Drawing.Point(3, 122);
            this.textTanim.Multiline = true;
            this.textTanim.Name = "textTanim";
            this.textTanim.Size = new System.Drawing.Size(234, 72);
            this.textTanim.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(208, 20);
            this.label12.Text = "Uygunsuzluk Tanımı";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(211, 98);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(26, 21);
            this.t2.TabIndex = 4;
            this.t2.Text = "T";
            this.t2.Click += new System.EventHandler(this.t2_Click);
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(211, 75);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(26, 21);
            this.t1.TabIndex = 4;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // textKonu
            // 
            this.textKonu.Location = new System.Drawing.Point(3, 75);
            this.textKonu.Name = "textKonu";
            this.textKonu.Size = new System.Drawing.Size(208, 21);
            this.textKonu.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(230, 20);
            this.label11.Text = "Uygunsuzluk Konusu";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 20);
            this.label10.Text = "Uygunsuzluk Kodu";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbkonu
            // 
            this.cmbkonu.DataSourceType = MobileWhouse.Enums.DataSourceType.KaliteUygunsuzlukKonu;
            this.cmbkonu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbkonu.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbkonu.Location = new System.Drawing.Point(3, 27);
            this.cmbkonu.Name = "cmbkonu";
            this.cmbkonu.Size = new System.Drawing.Size(234, 22);
            this.cmbkonu.TabIndex = 0;
            this.cmbkonu.Tag = "Konu Kodu seçilmelidir!";
            // 
            // DiscordReportsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkayit);
            this.Controls.Add(this.btnkapat);
            this.Name = "DiscordReportsControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkayit;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private MobileWhouse.GUI.ComboControl cmboperator;
        private System.Windows.Forms.Label label7;
        private MobileWhouse.GUI.ComboControl cmboperasyon;
        private System.Windows.Forms.Label label6;
        private MobileWhouse.GUI.ComboControl cmbistasyon;
        private System.Windows.Forms.TextBox textKonu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private MobileWhouse.GUI.ComboControl cmbkonu;
        private System.Windows.Forms.Button t1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textTanim;
        private System.Windows.Forms.Button t2;
        private MobileWhouse.GUI.ULookupEdit seccari;
        private MobileWhouse.GUI.TextBoxNumeric textmiktar;
        private System.Windows.Forms.Label label3;
        private MobileWhouse.GUI.TextBoxNumeric texthurda;
        private System.Windows.Forms.Label label4;
        private BarkodTextBox txtStok;
        private System.Windows.Forms.ComboBox cmbDiscordReportOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDiscordReportSource;
        private System.Windows.Forms.ComboBox cmbDiscordReportState;
    }
}
