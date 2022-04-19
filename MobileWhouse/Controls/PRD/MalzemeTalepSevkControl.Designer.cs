using MobileWhouse.GUI;
namespace MobileWhouse.Controls.PRD
{
    partial class MalzemeTalepSevkControl
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
            this.btnkapat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listtalep = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.txtarama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnarama = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.listbarkod = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnmiktar = new System.Windows.Forms.Button();
            this.chksil = new System.Windows.Forms.CheckBox();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.txtmiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.btnraf = new System.Windows.Forms.Button();
            this.txtraf = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.datebelge = new System.Windows.Forms.DateTimePicker();
            this.txtaciklama = new System.Windows.Forms.TextBox();
            this.txtbelgeno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkapat
            // 
            this.btnkapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnkapat.Location = new System.Drawing.Point(0, 295);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(240, 25);
            this.btnkapat.TabIndex = 0;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 295);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listtalep);
            this.tabPage1.Controls.Add(this.txtarama);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnarama);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 272);
            this.tabPage1.Text = "Talepleri";
            // 
            // listtalep
            // 
            this.listtalep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listtalep.Columns.Add(this.columnHeader1);
            this.listtalep.Columns.Add(this.columnHeader2);
            this.listtalep.Columns.Add(this.columnHeader3);
            this.listtalep.Columns.Add(this.columnHeader4);
            this.listtalep.Columns.Add(this.columnHeader10);
            this.listtalep.Columns.Add(this.columnHeader11);
            this.listtalep.Columns.Add(this.columnHeader12);
            this.listtalep.Columns.Add(this.columnHeader13);
            this.listtalep.FullRowSelect = true;
            this.listtalep.Location = new System.Drawing.Point(3, 25);
            this.listtalep.Name = "listtalep";
            this.listtalep.Size = new System.Drawing.Size(234, 225);
            this.listtalep.TabIndex = 3;
            this.listtalep.View = System.Windows.Forms.View.Details;
            this.listtalep.ItemActivate += new System.EventHandler(this.listtalep_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Belge Tarihi";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Belge No";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "İş Emri Tipi";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Talep Depo";
            this.columnHeader4.Width = 190;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Kaynak Depo";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Hareket Kodu";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Açıklama";
            this.columnHeader12.Width = 60;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Talep Tarihi";
            this.columnHeader13.Width = 60;
            // 
            // txtarama
            // 
            this.txtarama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtarama.Location = new System.Drawing.Point(46, 2);
            this.txtarama.Name = "txtarama";
            this.txtarama.Size = new System.Drawing.Size(135, 21);
            this.txtarama.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.Text = "Arama:";
            // 
            // btnarama
            // 
            this.btnarama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnarama.Location = new System.Drawing.Point(183, 3);
            this.btnarama.Name = "btnarama";
            this.btnarama.Size = new System.Drawing.Size(50, 20);
            this.btnarama.TabIndex = 0;
            this.btnarama.Text = "Ara";
            this.btnarama.Click += new System.EventHandler(this.btnarama_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblbilgi);
            this.tabPage2.Controls.Add(this.listbarkod);
            this.tabPage2.Controls.Add(this.btnmiktar);
            this.tabPage2.Controls.Add(this.chksil);
            this.tabPage2.Controls.Add(this.btnbarkod);
            this.tabPage2.Controls.Add(this.txtmiktar);
            this.tabPage2.Controls.Add(this.txtbarkod);
            this.tabPage2.Controls.Add(this.btnraf);
            this.tabPage2.Controls.Add(this.txtraf);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 272);
            this.tabPage2.Text = "Sevk";
            // 
            // lblbilgi
            // 
            this.lblbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblbilgi.Location = new System.Drawing.Point(3, 251);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(100, 20);
            this.lblbilgi.Text = "Okunan ...";
            // 
            // listbarkod
            // 
            this.listbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listbarkod.Columns.Add(this.columnHeader5);
            this.listbarkod.Columns.Add(this.columnHeader6);
            this.listbarkod.Columns.Add(this.columnHeader7);
            this.listbarkod.Columns.Add(this.columnHeader16);
            this.listbarkod.Columns.Add(this.columnHeader8);
            this.listbarkod.Columns.Add(this.columnHeader14);
            this.listbarkod.Columns.Add(this.columnHeader9);
            this.listbarkod.FullRowSelect = true;
            this.listbarkod.Location = new System.Drawing.Point(3, 98);
            this.listbarkod.Name = "listbarkod";
            this.listbarkod.Size = new System.Drawing.Size(235, 150);
            this.listbarkod.TabIndex = 14;
            this.listbarkod.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Raf";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stok Kodu";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Stok Adı";
            this.columnHeader7.Width = 180;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Birim";
            this.columnHeader16.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Miktar";
            this.columnHeader8.Width = 60;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Okunan";
            this.columnHeader14.Width = 60;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Barkod";
            this.columnHeader9.Width = 60;
            // 
            // btnmiktar
            // 
            this.btnmiktar.Location = new System.Drawing.Point(141, 48);
            this.btnmiktar.Name = "btnmiktar";
            this.btnmiktar.Size = new System.Drawing.Size(32, 20);
            this.btnmiktar.TabIndex = 13;
            this.btnmiktar.Text = "...";
            this.btnmiktar.Click += new System.EventHandler(this.btnmiktar_Click);
            // 
            // chksil
            // 
            this.chksil.Location = new System.Drawing.Point(198, 48);
            this.chksil.Name = "chksil";
            this.chksil.Size = new System.Drawing.Size(42, 20);
            this.chksil.TabIndex = 11;
            this.chksil.Text = "Sil";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbarkod.Location = new System.Drawing.Point(206, 26);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(32, 20);
            this.btnbarkod.TabIndex = 7;
            this.btnbarkod.Text = "...";
            this.btnbarkod.Click += new System.EventHandler(this.btnbarkod_Click);
            // 
            // txtmiktar
            // 
            this.txtmiktar.AllowSpace = false;
            this.txtmiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.txtmiktar.Location = new System.Drawing.Point(77, 48);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(63, 21);
            this.txtmiktar.TabIndex = 1;
            this.txtmiktar.Text = "1";
            this.txtmiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmiktar_KeyPress);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbarkod.BackColor = System.Drawing.SystemColors.Info;
            this.txtbarkod.Location = new System.Drawing.Point(77, 26);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(128, 21);
            this.txtbarkod.TabIndex = 0;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarkod_KeyPress);
            // 
            // btnraf
            // 
            this.btnraf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnraf.Location = new System.Drawing.Point(206, 3);
            this.btnraf.Name = "btnraf";
            this.btnraf.Size = new System.Drawing.Size(32, 20);
            this.btnraf.TabIndex = 2;
            this.btnraf.Text = "...";
            this.btnraf.Click += new System.EventHandler(this.btnraf_Click);
            // 
            // txtraf
            // 
            this.txtraf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtraf.IsRaf = 1;
            this.txtraf.Location = new System.Drawing.Point(77, 3);
            this.txtraf.Name = "txtraf";
            this.txtraf.Size = new System.Drawing.Size(128, 21);
            this.txtraf.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.Text = "Raf Kodu";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.Text = "Barkod";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.Text = "Miktar";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnkaydet);
            this.tabPage3.Controls.Add(this.datebelge);
            this.tabPage3.Controls.Add(this.txtaciklama);
            this.tabPage3.Controls.Add(this.txtbelgeno);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(240, 272);
            this.tabPage3.Text = "Belge";
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(3, 243);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(230, 26);
            this.btnkaydet.TabIndex = 5;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // datebelge
            // 
            this.datebelge.CustomFormat = "dd.MM.yyyy";
            this.datebelge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datebelge.Location = new System.Drawing.Point(75, 23);
            this.datebelge.Name = "datebelge";
            this.datebelge.Size = new System.Drawing.Size(100, 22);
            this.datebelge.TabIndex = 3;
            // 
            // txtaciklama
            // 
            this.txtaciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtaciklama.Location = new System.Drawing.Point(75, 49);
            this.txtaciklama.Name = "txtaciklama";
            this.txtaciklama.Size = new System.Drawing.Size(161, 21);
            this.txtaciklama.TabIndex = 1;
            // 
            // txtbelgeno
            // 
            this.txtbelgeno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbelgeno.Location = new System.Drawing.Point(75, 0);
            this.txtbelgeno.Name = "txtbelgeno";
            this.txtbelgeno.Size = new System.Drawing.Size(100, 21);
            this.txtbelgeno.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.Text = "Açıklama";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.Text = "Belge No";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.Text = "Belge No";
            // 
            // MalzemeTalepSevkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkapat);
            this.Name = "MalzemeTalepSevkControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtarama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnarama;
        private System.Windows.Forms.ListView listtalep;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnraf;
        private MobileWhouse.Controls.RafTextBox txtraf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbarkod;
        private TextBoxNumeric txtmiktar;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.CheckBox chksil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnmiktar;
        private System.Windows.Forms.ListView listbarkod;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DateTimePicker datebelge;
        private System.Windows.Forms.TextBox txtbelgeno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtaciklama;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Label lblbilgi;
    }
}
