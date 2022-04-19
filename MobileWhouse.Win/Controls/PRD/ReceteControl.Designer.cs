namespace MobileWhouse.Controls.PRD
{
    partial class ReceteControl
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
            this.txtisemri = new MobileWhouse.GUI.ULookupEdit();
            this.btnkapat = new System.Windows.Forms.Button();
            this.listisemri = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnklavye = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listbarkod = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.textDepo = new MobileWhouse.GUI.ULookupEdit();
            this.textHareket = new MobileWhouse.GUI.ULookupEdit();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.Browsable = false;
            this.txtisemri.DataFieldName = "";
            this.txtisemri.DataType = MobileWhouse.Enums.DataSourceType.IsEmri;
            this.txtisemri.Description = "";
            this.txtisemri.FilterCondition = "";
            this.txtisemri.LabelText = "İş Emri";
            this.txtisemri.LabelWidth = 50;
            this.txtisemri.Location = new System.Drawing.Point(2, 53);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.PurchaseSales = -1;
            this.txtisemri.RememberValue = false;
            this.txtisemri.ShowDescription = false;
            this.txtisemri.ShowLabelText = false;
            this.txtisemri.Size = new System.Drawing.Size(238, 27);
            this.txtisemri.SourceApplication = 0;
            this.txtisemri.TabIndex = 0;
            this.txtisemri.OnSelected += new MobileWhouse.OnSelectedObject(this.txtisemri_OnSelected);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(2, 284);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(112, 33);
            this.btnkapat.TabIndex = 1;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // listisemri
            // 
            this.listisemri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listisemri.Columns.Add(this.columnHeader1);
            this.listisemri.Columns.Add(this.columnHeader2);
            this.listisemri.Columns.Add(this.columnHeader3);
            this.listisemri.Columns.Add(this.columnHeader4);
            this.listisemri.FullRowSelect = true;
            this.listisemri.Location = new System.Drawing.Point(0, 0);
            this.listisemri.Name = "listisemri";
            this.listisemri.Size = new System.Drawing.Size(235, 153);
            this.listisemri.TabIndex = 2;
            this.listisemri.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Kodu";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Adı";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Birim";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Miktar";
            this.columnHeader4.Width = 60;
            // 
            // btnbarkod
            // 
            this.btnbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbarkod.Location = new System.Drawing.Point(188, 79);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(24, 21);
            this.btnbarkod.TabIndex = 10;
            this.btnbarkod.Text = "...";
            this.btnbarkod.Click += new System.EventHandler(this.btnbarkod_Click);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbarkod.BackColor = System.Drawing.SystemColors.Info;
            this.txtbarkod.Location = new System.Drawing.Point(53, 79);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(134, 21);
            this.txtbarkod.TabIndex = 9;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.Text = "Barkod";
            // 
            // btnklavye
            // 
            this.btnklavye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnklavye.Location = new System.Drawing.Point(213, 79);
            this.btnklavye.Name = "btnklavye";
            this.btnklavye.Size = new System.Drawing.Size(24, 21);
            this.btnklavye.TabIndex = 12;
            this.btnklavye.Text = "T";
            this.btnklavye.Click += new System.EventHandler(this.btnklavye_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(2, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 176);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listisemri);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(235, 153);
            this.tabPage1.Text = "Reçete";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listbarkod);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(227, 150);
            this.tabPage2.Text = "Barkod";
            // 
            // listbarkod
            // 
            this.listbarkod.Columns.Add(this.columnHeader5);
            this.listbarkod.Columns.Add(this.columnHeader6);
            this.listbarkod.Columns.Add(this.columnHeader9);
            this.listbarkod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbarkod.FullRowSelect = true;
            this.listbarkod.Location = new System.Drawing.Point(0, 0);
            this.listbarkod.Name = "listbarkod";
            this.listbarkod.Size = new System.Drawing.Size(227, 150);
            this.listbarkod.TabIndex = 0;
            this.listbarkod.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Barkod";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stok Kodu";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Miktar";
            this.columnHeader9.Width = 60;
            // 
            // textDepo
            // 
            this.textDepo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textDepo.Browsable = true;
            this.textDepo.DataFieldName = "";
            this.textDepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.textDepo.Description = "";
            this.textDepo.FilterCondition = "";
            this.textDepo.LabelText = "Depo";
            this.textDepo.LabelWidth = 50;
            this.textDepo.Location = new System.Drawing.Point(2, 26);
            this.textDepo.Name = "textDepo";
            this.textDepo.PurchaseSales = -1;
            this.textDepo.RememberValue = true;
            this.textDepo.ShowDescription = false;
            this.textDepo.ShowLabelText = false;
            this.textDepo.Size = new System.Drawing.Size(237, 27);
            this.textDepo.SourceApplication = 0;
            this.textDepo.TabIndex = 16;
            this.textDepo.OnSelected += new MobileWhouse.OnSelectedObject(this.textDepo_OnSelected);
            // 
            // textHareket
            // 
            this.textHareket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textHareket.Browsable = true;
            this.textHareket.DataFieldName = "";
            this.textHareket.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.textHareket.Description = "";
            this.textHareket.FilterCondition = "";
            this.textHareket.LabelText = "Hareket";
            this.textHareket.LabelWidth = 50;
            this.textHareket.Location = new System.Drawing.Point(2, 0);
            this.textHareket.Name = "textHareket";
            this.textHareket.PurchaseSales = -1;
            this.textHareket.RememberValue = true;
            this.textHareket.ShowDescription = false;
            this.textHareket.ShowLabelText = false;
            this.textHareket.Size = new System.Drawing.Size(238, 27);
            this.textHareket.SourceApplication = 212;
            this.textHareket.TabIndex = 17;
            this.textHareket.OnSelected += new MobileWhouse.OnSelectedObject(this.textHareket_OnSelected);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(120, 284);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(117, 33);
            this.btnkaydet.TabIndex = 19;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // ReceteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.textHareket);
            this.Controls.Add(this.textDepo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnklavye);
            this.Controls.Add(this.btnbarkod);
            this.Controls.Add(this.txtbarkod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.txtisemri);
            this.Name = "ReceteControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.ULookupEdit txtisemri;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.ListView listisemri;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox txtbarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnklavye;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listbarkod;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MobileWhouse.GUI.ULookupEdit textDepo;
        private MobileWhouse.GUI.ULookupEdit textHareket;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
