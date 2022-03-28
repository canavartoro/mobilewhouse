namespace MobileWhouse.Controls.PSM
{
    partial class SatinalmaMalKabulEtiketlemeControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.btnekle = new System.Windows.Forms.Button();
            this.txtmiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.numAmb = new MobileWhouse.GUI.TextBoxNumeric();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.secmalkabuldoktra = new MobileWhouse.GUI.ULookupEdit();
            this.listbarkod = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.printmalkabul = new MobileWhouse.GUI.UPrintControl();
            this.btnkapat = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(240, 274);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblbilgi);
            this.tabPage1.Controls.Add(this.btnekle);
            this.tabPage1.Controls.Add(this.txtmiktar);
            this.tabPage1.Controls.Add(this.numAmb);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 251);
            this.tabPage1.Text = "Detaylar";
            // 
            // lblbilgi
            // 
            this.lblbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbilgi.Location = new System.Drawing.Point(2, 0);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(235, 31);
            this.lblbilgi.Text = "..";
            // 
            // btnekle
            // 
            this.btnekle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnekle.Location = new System.Drawing.Point(195, 34);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(41, 21);
            this.btnekle.TabIndex = 83;
            this.btnekle.Text = "Ekle";
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // txtmiktar
            // 
            this.txtmiktar.AllowSpace = false;
            this.txtmiktar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmiktar.BackColor = System.Drawing.Color.LightCyan;
            this.txtmiktar.Location = new System.Drawing.Point(58, 34);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(79, 21);
            this.txtmiktar.TabIndex = 80;
            // 
            // numAmb
            // 
            this.numAmb.AllowSpace = false;
            this.numAmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAmb.BackColor = System.Drawing.Color.LightCyan;
            this.numAmb.Location = new System.Drawing.Point(156, 34);
            this.numAmb.Name = "numAmb";
            this.numAmb.Size = new System.Drawing.Size(38, 21);
            this.numAmb.TabIndex = 80;
            this.numAmb.Text = "1";
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
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 59);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 189);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Kodu";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Adı";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Birim";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Miktar";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Parti Kod";
            this.columnHeader5.Width = 60;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(135, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 21);
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "Miktar";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.secmalkabuldoktra);
            this.tabPage2.Controls.Add(this.listbarkod);
            this.tabPage2.Controls.Add(this.printmalkabul);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 251);
            this.tabPage2.Text = "Ambalaj";
            // 
            // secmalkabuldoktra
            // 
            this.secmalkabuldoktra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.secmalkabuldoktra.Browsable = true;
            this.secmalkabuldoktra.DataFieldName = "";
            this.secmalkabuldoktra.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.secmalkabuldoktra.Description = "";
            this.secmalkabuldoktra.FilterCondition = "";
            this.secmalkabuldoktra.LabelText = "Kod";
            this.secmalkabuldoktra.LabelWidth = 70;
            this.secmalkabuldoktra.Location = new System.Drawing.Point(3, 76);
            this.secmalkabuldoktra.Name = "secmalkabuldoktra";
            this.secmalkabuldoktra.PurchaseSales = -1;
            this.secmalkabuldoktra.RememberValue = true;
            this.secmalkabuldoktra.ShowDescription = false;
            this.secmalkabuldoktra.ShowLabelText = false;
            this.secmalkabuldoktra.Size = new System.Drawing.Size(234, 27);
            this.secmalkabuldoktra.SourceApplication = 212;
            this.secmalkabuldoktra.TabIndex = 2;
            // 
            // listbarkod
            // 
            this.listbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listbarkod.Columns.Add(this.columnHeader6);
            this.listbarkod.Columns.Add(this.columnHeader7);
            this.listbarkod.Columns.Add(this.columnHeader8);
            this.listbarkod.FullRowSelect = true;
            this.listbarkod.Location = new System.Drawing.Point(3, 105);
            this.listbarkod.Name = "listbarkod";
            this.listbarkod.Size = new System.Drawing.Size(234, 145);
            this.listbarkod.TabIndex = 1;
            this.listbarkod.View = System.Windows.Forms.View.Details;
            this.listbarkod.ItemActivate += new System.EventHandler(this.listbarkod_ItemActivate);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stok Kod";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Stok Ad";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Miktar";
            this.columnHeader8.Width = 60;
            // 
            // printmalkabul
            // 
            this.printmalkabul.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printmalkabul.Location = new System.Drawing.Point(3, 3);
            this.printmalkabul.Name = "printmalkabul";
            this.printmalkabul.Size = new System.Drawing.Size(234, 74);
            this.printmalkabul.TabIndex = 0;
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(0, 276);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(117, 44);
            this.btnkapat.TabIndex = 1;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(118, 276);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(122, 44);
            this.btnkaydet.TabIndex = 2;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // SatinalmaMalKabulEtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.tabControl1);
            this.OnLoad += new System.EventHandler(SatinalmaMalKabulEtiketlemeControl_OnLoad);
            this.Name = "SatinalmaMalKabulEtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnkapat;
        private MobileWhouse.GUI.UPrintControl printmalkabul;
        private System.Windows.Forms.Button btnekle;
        private MobileWhouse.GUI.TextBoxNumeric txtmiktar;
        private MobileWhouse.GUI.TextBoxNumeric numAmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listbarkod;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblbilgi;
        private MobileWhouse.GUI.ULookupEdit secmalkabuldoktra;

    }
}
