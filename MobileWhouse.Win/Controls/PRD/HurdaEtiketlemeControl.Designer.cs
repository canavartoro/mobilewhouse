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
            this.btnistasyon = new System.Windows.Forms.Button();
            this.txtistasyon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtstokkod = new System.Windows.Forms.TextBox();
            this.btnstokkod = new System.Windows.Forms.Button();
            this.cmbhurdaneden = new MobileWhouse.GUI.ComboControl();
            this.textMiktar = new MobileWhouse.Controls.DecimalTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbisemribilesen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.Location = new System.Drawing.Point(0, 269);
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
            this.btnyazdir.Location = new System.Drawing.Point(3, 407);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.Size = new System.Drawing.Size(323, 20);
            this.btnyazdir.TabIndex = 20;
            this.btnyazdir.Text = "Yazdır";
            // 
            // btnistasyon
            // 
            this.btnistasyon.Location = new System.Drawing.Point(197, 3);
            this.btnistasyon.Name = "btnistasyon";
            this.btnistasyon.Size = new System.Drawing.Size(40, 20);
            this.btnistasyon.TabIndex = 17;
            this.btnistasyon.Text = "...";
            this.btnistasyon.Click += new System.EventHandler(this.btnistasyon_Click);
            // 
            // txtistasyon
            // 
            this.txtistasyon.Location = new System.Drawing.Point(80, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.Size = new System.Drawing.Size(116, 21);
            this.txtistasyon.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "İstasyon Kod";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Hurda Nedeni";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 126);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 137);
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
            this.btnkaydet.Location = new System.Drawing.Point(171, 98);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(66, 22);
            this.btnkaydet.TabIndex = 31;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.Text = "Stok Kodu";
            // 
            // txtstokkod
            // 
            this.txtstokkod.Location = new System.Drawing.Point(80, 50);
            this.txtstokkod.Name = "txtstokkod";
            this.txtstokkod.Size = new System.Drawing.Size(116, 21);
            this.txtstokkod.TabIndex = 37;
            // 
            // btnstokkod
            // 
            this.btnstokkod.Location = new System.Drawing.Point(197, 50);
            this.btnstokkod.Name = "btnstokkod";
            this.btnstokkod.Size = new System.Drawing.Size(40, 21);
            this.btnstokkod.TabIndex = 38;
            this.btnstokkod.Text = "...";
            this.btnstokkod.Click += new System.EventHandler(this.btnstokkod_Click);
            // 
            // cmbhurdaneden
            // 
            this.cmbhurdaneden.DataSourceType = MobileWhouse.Models.DataSourceType.Hurda;
            this.cmbhurdaneden.HurdaTip = MobileWhouse.Enums.ScrapType.Malzeme;
            this.cmbhurdaneden.Location = new System.Drawing.Point(80, 74);
            this.cmbhurdaneden.Name = "cmbhurdaneden";
            this.cmbhurdaneden.Size = new System.Drawing.Size(157, 22);
            this.cmbhurdaneden.TabIndex = 43;
            // 
            // textMiktar
            // 
            this.textMiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.textMiktar.Location = new System.Drawing.Point(80, 100);
            this.textMiktar.Name = "textMiktar";
            this.textMiktar.Size = new System.Drawing.Size(85, 20);
            this.textMiktar.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.Text = "Hurda Miktar";
            // 
            // cmbisemribilesen
            // 
            this.cmbisemribilesen.Location = new System.Drawing.Point(80, 26);
            this.cmbisemribilesen.Name = "cmbisemribilesen";
            this.cmbisemribilesen.Size = new System.Drawing.Size(157, 22);
            this.cmbisemribilesen.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.Text = "Hurda Stok";
            // 
            // HurdaEtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.cmbisemribilesen);
            this.Controls.Add(this.textMiktar);
            this.Controls.Add(this.cmbhurdaneden);
            this.Controls.Add(this.btnstokkod);
            this.Controls.Add(this.txtstokkod);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnyazdir);
            this.Controls.Add(this.btnistasyon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtistasyon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Name = "HurdaEtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnyazdir;
        private System.Windows.Forms.Button btnistasyon;
        private System.Windows.Forms.TextBox txtistasyon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtstokkod;
        private System.Windows.Forms.Button btnstokkod;
        private MobileWhouse.GUI.ComboControl cmbhurdaneden;
        private DecimalTextBox textMiktar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbisemribilesen;
        private System.Windows.Forms.Label label5;
    }
}
