﻿namespace MobileWhouse.Controls.PRD
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
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.btnistasyon = new System.Windows.Forms.Button();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtistasyon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uretimgirisprint = new MobileWhouse.GUI.PrintControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.Location = new System.Drawing.Point(0, 288);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(240, 32);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(170, 77);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(67, 20);
            this.btnkaydet.TabIndex = 62;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnistasyon
            // 
            this.btnistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnistasyon.Location = new System.Drawing.Point(203, 3);
            this.btnistasyon.Name = "btnistasyon";
            this.btnistasyon.Size = new System.Drawing.Size(34, 20);
            this.btnistasyon.TabIndex = 0;
            this.btnistasyon.Text = "...";
            this.btnistasyon.Click += new System.EventHandler(this.btnistasyon_Click);
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(74, 27);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(163, 21);
            this.txtisemri.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.Text = "İş Emri No";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtistasyon.Location = new System.Drawing.Point(74, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.Size = new System.Drawing.Size(128, 21);
            this.txtistasyon.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.Text = "İstasyon";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Location = new System.Drawing.Point(207, 51);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(30, 20);
            this.btnbarkod.TabIndex = 71;
            this.btnbarkod.Text = "...";
            this.btnbarkod.Click += new System.EventHandler(this.btnbarkod_Click);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Location = new System.Drawing.Point(74, 51);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(132, 21);
            this.txtbarkod.TabIndex = 1;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.Text = "Barkod";
            // 
            // chksil
            // 
            this.chksil.Location = new System.Drawing.Point(121, 78);
            this.chksil.Name = "chksil";
            this.chksil.Size = new System.Drawing.Size(45, 19);
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
            this.listView1.Location = new System.Drawing.Point(0, 103);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 162);
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
            this.lblbilgi.Location = new System.Drawing.Point(3, 78);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(119, 20);
            this.lblbilgi.Text = "Satır sayısı 0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 288);
            this.tabControl1.TabIndex = 78;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.lblbilgi);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnbarkod);
            this.tabPage1.Controls.Add(this.txtbarkod);
            this.tabPage1.Controls.Add(this.txtistasyon);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnkaydet);
            this.tabPage1.Controls.Add(this.txtisemri);
            this.tabPage1.Controls.Add(this.btnistasyon);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chksil);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 265);
            this.tabPage1.Text = "Üretim";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uretimgirisprint);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 265);
            this.tabPage2.Text = "Ayarlar";
            // 
            // uretimgirisprint
            // 
            this.uretimgirisprint.Dock = System.Windows.Forms.DockStyle.Top;
            this.uretimgirisprint.Location = new System.Drawing.Point(0, 0);
            this.uretimgirisprint.Name = "uretimgirisprint";
            this.uretimgirisprint.Size = new System.Drawing.Size(240, 30);
            this.uretimgirisprint.TabIndex = 0;
            // 
            // UretimGirisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKapat);
            this.Name = "UretimGirisControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnistasyon;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtistasyon;
        private System.Windows.Forms.Label label1;
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
        private MobileWhouse.GUI.PrintControl uretimgirisprint;
    }
}
