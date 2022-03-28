namespace MobileWhouse.Controls.PRD
{
    partial class HurdaEtiketlemeControl
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
            this.btnyazdir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.cmbhurdaneden = new MobileWhouse.GUI.ComboControl();
            this.cmbisemribilesen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.txtstokkod = new MobileWhouse.GUI.ULookupEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.printhurdaetiket = new MobileWhouse.GUI.UPrintControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.Location = new System.Drawing.Point(0, 274);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(240, 46);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnyazdir
            // 
            this.btnyazdir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnyazdir.Location = new System.Drawing.Point(3, 412);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.Size = new System.Drawing.Size(323, 20);
            this.btnyazdir.TabIndex = 20;
            this.btnyazdir.Text = "Yazdır";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Hurda Nedeni";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 131);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 118);
            this.listView1.TabIndex = 30;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tarih";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hurda Miktar";
            this.columnHeader3.Width = 80;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Location = new System.Drawing.Point(171, 104);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(63, 22);
            this.btnkaydet.TabIndex = 31;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // cmbhurdaneden
            // 
            this.cmbhurdaneden.DataSourceType = MobileWhouse.Enums.DataSourceType.Hurda;
            this.cmbhurdaneden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbhurdaneden.HurdaTip = MobileWhouse.Enums.ScrapType.Malzeme;
            this.cmbhurdaneden.Location = new System.Drawing.Point(77, 80);
            this.cmbhurdaneden.Name = "cmbhurdaneden";
            this.cmbhurdaneden.Size = new System.Drawing.Size(157, 22);
            this.cmbhurdaneden.TabIndex = 43;
            // 
            // cmbisemribilesen
            // 
            this.cmbisemribilesen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbisemribilesen.Location = new System.Drawing.Point(77, 29);
            this.cmbisemribilesen.Name = "cmbisemribilesen";
            this.cmbisemribilesen.Size = new System.Drawing.Size(157, 22);
            this.cmbisemribilesen.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.Text = "Hurda Stok";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Browsable = false;
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 75;
            this.txtistasyon.Location = new System.Drawing.Point(3, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.PurchaseSales = -1;
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(231, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 59;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // txtstokkod
            // 
            this.txtstokkod.Browsable = true;
            this.txtstokkod.DataFieldName = "";
            this.txtstokkod.DataType = MobileWhouse.Enums.DataSourceType.ScrapItem;
            this.txtstokkod.Description = "";
            this.txtstokkod.FilterCondition = "";
            this.txtstokkod.LabelText = "Stok Kodu";
            this.txtstokkod.LabelWidth = 75;
            this.txtstokkod.Location = new System.Drawing.Point(3, 53);
            this.txtstokkod.Name = "txtstokkod";
            this.txtstokkod.PurchaseSales = -1;
            this.txtstokkod.RememberValue = false;
            this.txtstokkod.ShowDescription = false;
            this.txtstokkod.ShowLabelText = false;
            this.txtstokkod.Size = new System.Drawing.Size(231, 27);
            this.txtstokkod.SourceApplication = 0;
            this.txtstokkod.TabIndex = 63;
            this.txtstokkod.OnSelected += new MobileWhouse.OnSelectedObject(this.txtstokkod_OnSelected);
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
            this.tabControl1.Size = new System.Drawing.Size(240, 275);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtistasyon);
            this.tabPage1.Controls.Add(this.txtstokkod);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.cmbisemribilesen);
            this.tabPage1.Controls.Add(this.btnkaydet);
            this.tabPage1.Controls.Add(this.cmbhurdaneden);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 252);
            this.tabPage1.Text = "Bilgiler";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.printhurdaetiket);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 249);
            this.tabPage2.Text = "Yazıcı";
            // 
            // printhurdaetiket
            // 
            this.printhurdaetiket.Location = new System.Drawing.Point(0, 0);
            this.printhurdaetiket.Name = "printhurdaetiket";
            this.printhurdaetiket.Size = new System.Drawing.Size(240, 74);
            this.printhurdaetiket.TabIndex = 0;
            // 
            // HurdaEtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnyazdir);
            this.Name = "HurdaEtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnyazdir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnkaydet;
        private MobileWhouse.GUI.ComboControl cmbhurdaneden;
        private System.Windows.Forms.ComboBox cmbisemribilesen;
        private System.Windows.Forms.Label label5;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
        private MobileWhouse.GUI.ULookupEdit txtstokkod;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MobileWhouse.GUI.UPrintControl printhurdaetiket;
    }
}
