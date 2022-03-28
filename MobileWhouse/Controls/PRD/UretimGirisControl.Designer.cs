namespace MobileWhouse.Controls.PRD
{
    partial class UretimGirisControl
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
            this.btnKapat = new MobileWhouse.GUI.UButton();
            this.btnkaydet = new MobileWhouse.GUI.UButton();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chksil = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblIsEmri = new System.Windows.Forms.Label();
            this.secistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uretimgirisprint = new MobileWhouse.GUI.UPrintControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKapat.BackColor = System.Drawing.Color.Empty;
            this.btnKapat.ForeColor = System.Drawing.Color.Empty;
            this.btnKapat.Location = new System.Drawing.Point(3, 98);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKapat.Size = new System.Drawing.Size(65, 22);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.Empty;
            this.btnkaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnkaydet.Location = new System.Drawing.Point(167, 97);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnkaydet.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnkaydet.Size = new System.Drawing.Size(70, 23);
            this.btnkaydet.TabIndex = 62;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnbarkod
            // 
            this.btnbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbarkod.Location = new System.Drawing.Point(167, 74);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(30, 20);
            this.btnbarkod.TabIndex = 71;
            this.btnbarkod.Text = "...";
            this.btnbarkod.Click += new System.EventHandler(this.btnbarkod_Click);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbarkod.BackColor = System.Drawing.Color.Linen;
            this.txtbarkod.Location = new System.Drawing.Point(54, 74);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(112, 21);
            this.txtbarkod.TabIndex = 1;
            this.txtbarkod.TextChanged += new System.EventHandler(this.txtbarkod_TextChanged);
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.Text = "Barkod";
            this.label4.ParentChanged += new System.EventHandler(this.label4_ParentChanged);
            // 
            // chksil
            // 
            this.chksil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksil.Location = new System.Drawing.Point(195, 75);
            this.chksil.Name = "chksil";
            this.chksil.Size = new System.Drawing.Size(42, 19);
            this.chksil.TabIndex = 73;
            this.chksil.Text = "Sil";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Location = new System.Drawing.Point(0, 122);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 173);
            this.listView1.TabIndex = 74;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Kod";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Ad";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Barkod";
            this.columnHeader4.Width = 70;
            // 
            // lblbilgi
            // 
            this.lblbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbilgi.Location = new System.Drawing.Point(67, 99);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(99, 20);
            this.lblbilgi.Text = "Satır sayısı 0";
            this.lblbilgi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 78;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnKapat);
            this.tabPage1.Controls.Add(this.lblIsEmri);
            this.tabPage1.Controls.Add(this.secistasyon);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.lblbilgi);
            this.tabPage1.Controls.Add(this.btnbarkod);
            this.tabPage1.Controls.Add(this.txtbarkod);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnkaydet);
            this.tabPage1.Controls.Add(this.chksil);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 295);
            this.tabPage1.Text = "Üretim";
            // 
            // lblIsEmri
            // 
            this.lblIsEmri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsEmri.BackColor = System.Drawing.Color.Honeydew;
            this.lblIsEmri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIsEmri.Location = new System.Drawing.Point(2, 32);
            this.lblIsEmri.Name = "lblIsEmri";
            this.lblIsEmri.Size = new System.Drawing.Size(235, 40);
            // 
            // secistasyon
            // 
            this.secistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.secistasyon.Browsable = false;
            this.secistasyon.DataFieldName = "";
            this.secistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.secistasyon.Description = "";
            this.secistasyon.FilterCondition = "";
            this.secistasyon.LabelText = "İstasyon";
            this.secistasyon.LabelWidth = 70;
            this.secistasyon.Location = new System.Drawing.Point(2, 2);
            this.secistasyon.Name = "secistasyon";
            this.secistasyon.PurchaseSales = -1;
            this.secistasyon.RememberValue = false;
            this.secistasyon.ShowDescription = false;
            this.secistasyon.ShowLabelText = false;
            this.secistasyon.Size = new System.Drawing.Size(235, 27);
            this.secistasyon.SourceApplication = 0;
            this.secistasyon.TabIndex = 77;
            this.secistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.secistasyon_OnSelected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uretimgirisprint);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 295);
            this.tabPage2.Text = "Ayarlar";
            // 
            // uretimgirisprint
            // 
            this.uretimgirisprint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uretimgirisprint.Location = new System.Drawing.Point(3, 3);
            this.uretimgirisprint.Name = "uretimgirisprint";
            this.uretimgirisprint.Size = new System.Drawing.Size(234, 74);
            this.uretimgirisprint.TabIndex = 0;
            // 
            // UretimGirisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "UretimGirisControl";
            this.OnLoad += new System.EventHandler(UretimGirisControl_OnLoad);
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      

        #endregion

        private GUI.UButton btnKapat;
        private GUI.UButton btnkaydet;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox txtbarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chksil;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblbilgi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MobileWhouse.GUI.UPrintControl uretimgirisprint;
        private MobileWhouse.GUI.ULookupEdit secistasyon;
        private System.Windows.Forms.Label lblIsEmri;
    }
}
