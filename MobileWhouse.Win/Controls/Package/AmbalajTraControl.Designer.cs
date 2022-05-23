namespace MobileWhouse.Controls.Package
{
    partial class AmbalajTraControl
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
            this.uButton1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblokunan = new System.Windows.Forms.Label();
            this.textDepo = new MobileWhouse.GUI.ULookupEdit();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.textHareket = new MobileWhouse.GUI.ULookupEdit();
            this.checksil = new System.Windows.Forms.CheckBox();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.textBarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uButton1
            // 
            this.uButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uButton1.Location = new System.Drawing.Point(0, 275);
            this.uButton1.Name = "uButton1";
            this.uButton1.Size = new System.Drawing.Size(125, 40);
            this.uButton1.TabIndex = 0;
            this.uButton1.Text = "Kapat";
            this.uButton1.Click += new System.EventHandler(this.uButton1_Click);
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
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblokunan);
            this.tabPage1.Controls.Add(this.textDepo);
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.textHareket);
            this.tabPage1.Controls.Add(this.checksil);
            this.tabPage1.Controls.Add(this.btnbarkod);
            this.tabPage1.Controls.Add(this.textBarkod);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 252);
            this.tabPage1.Text = "Belge";
            // 
            // lblokunan
            // 
            this.lblokunan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblokunan.ForeColor = System.Drawing.Color.Black;
            this.lblokunan.Location = new System.Drawing.Point(149, 59);
            this.lblokunan.Name = "lblokunan";
            this.lblokunan.Size = new System.Drawing.Size(88, 20);
            this.lblokunan.Text = "Okunan";
            // 
            // textDepo
            // 
            this.textDepo.Browsable = true;
            this.textDepo.DataFieldName = "";
            this.textDepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.textDepo.Description = "";
            this.textDepo.FilterCondition = "";
            this.textDepo.LabelText = "Depo";
            this.textDepo.LabelWidth = 50;
            this.textDepo.Location = new System.Drawing.Point(3, 29);
            this.textDepo.Name = "textDepo";
            this.textDepo.PurchaseSales = -1;
            this.textDepo.RememberValue = false;
            this.textDepo.ShowDescription = false;
            this.textDepo.ShowLabelText = false;
            this.textDepo.Size = new System.Drawing.Size(234, 27);
            this.textDepo.SourceApplication = 0;
            this.textDepo.TabIndex = 16;
            this.textDepo.OnSelected += new MobileWhouse.OnSelectedObject(this.textDepo_OnSelected);
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(55, 58);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(88, 21);
            this.txtRaf.TabIndex = 2;
            // 
            // textHareket
            // 
            this.textHareket.Browsable = true;
            this.textHareket.DataFieldName = "";
            this.textHareket.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.textHareket.Description = "";
            this.textHareket.FilterCondition = "";
            this.textHareket.LabelText = "Hareket";
            this.textHareket.LabelWidth = 50;
            this.textHareket.Location = new System.Drawing.Point(3, 3);
            this.textHareket.Name = "textHareket";
            this.textHareket.PurchaseSales = -1;
            this.textHareket.RememberValue = true;
            this.textHareket.ShowDescription = false;
            this.textHareket.ShowLabelText = false;
            this.textHareket.Size = new System.Drawing.Size(234, 27);
            this.textHareket.SourceApplication = 212;
            this.textHareket.TabIndex = 13;
            this.textHareket.OnSelected += new MobileWhouse.OnSelectedObject(this.textHareket_OnSelected);
            // 
            // checksil
            // 
            this.checksil.Location = new System.Drawing.Point(193, 84);
            this.checksil.Name = "checksil";
            this.checksil.Size = new System.Drawing.Size(45, 20);
            this.checksil.TabIndex = 7;
            this.checksil.Text = "Sil";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Location = new System.Drawing.Point(164, 85);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(25, 20);
            this.btnbarkod.TabIndex = 6;
            this.btnbarkod.Text = "...";
            // 
            // textBarkod
            // 
            this.textBarkod.BackColor = System.Drawing.Color.Yellow;
            this.textBarkod.Location = new System.Drawing.Point(55, 84);
            this.textBarkod.Name = "textBarkod";
            this.textBarkod.Size = new System.Drawing.Size(108, 21);
            this.textBarkod.TabIndex = 5;
            this.textBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.Text = "Barkod";
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
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 108);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 144);
            this.listView1.TabIndex = 7;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barkod";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stok Kodu";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Stok Adı";
            this.columnHeader4.Width = 160;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.Text = "Raf";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 249);
            this.tabPage2.Text = "Detaylar";
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(126, 275);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(114, 40);
            this.btnkaydet.TabIndex = 8;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // AmbalajTraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.uButton1);
            this.Name = "AmbalajTraControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.OnLoad += new System.EventHandler(this.AmbalajTraControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox textBarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checksil;
        private System.Windows.Forms.Button btnkaydet;
        private RafTextBox txtRaf;
        private MobileWhouse.GUI.ULookupEdit textHareket;
        private MobileWhouse.GUI.ULookupEdit textDepo;
        private System.Windows.Forms.Label lblokunan;
    }
}
