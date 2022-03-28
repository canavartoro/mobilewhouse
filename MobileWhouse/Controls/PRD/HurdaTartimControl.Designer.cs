namespace MobileWhouse.Controls.PRD
{
    partial class HurdaTartimControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.btnsec = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.btnara = new System.Windows.Forms.Button();
            this.textara = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(2, 272);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(238, 40);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
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
            this.tabControl1.Size = new System.Drawing.Size(240, 266);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnbarkod);
            this.tabPage1.Controls.Add(this.txtbarkod);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtmiktar);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtisemri);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 243);
            this.tabPage1.Text = "Tartim";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbarkod.Location = new System.Drawing.Point(200, 3);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(37, 20);
            this.btnbarkod.TabIndex = 74;
            this.btnbarkod.Text = "...";
            this.btnbarkod.Click += new System.EventHandler(this.btnbarkod_Click);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbarkod.BackColor = System.Drawing.Color.Linen;
            this.txtbarkod.Location = new System.Drawing.Point(66, 3);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(132, 21);
            this.txtbarkod.TabIndex = 73;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarkod_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.Text = "Barkod";
            // 
            // txtmiktar
            // 
            this.txtmiktar.AllowSpace = false;
            this.txtmiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.txtmiktar.Location = new System.Drawing.Point(81, 58);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(84, 21);
            this.txtmiktar.TabIndex = 45;
            this.txtmiktar.Text = "1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.Text = "Miktar";
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(81, 31);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(156, 21);
            this.txtisemri.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "İş Emri No";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnsec);
            this.tabPage2.Controls.Add(this.btnsil);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.btnara);
            this.tabPage2.Controls.Add(this.textara);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 243);
            this.tabPage2.Text = "Liste";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 20);
            this.progressBar1.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 18);
            this.label7.Text = "Satır sayısı 0";
            // 
            // btnsec
            // 
            this.btnsec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsec.Location = new System.Drawing.Point(160, 26);
            this.btnsec.Name = "btnsec";
            this.btnsec.Size = new System.Drawing.Size(36, 21);
            this.btnsec.TabIndex = 3;
            this.btnsec.Text = "Seç";
            this.btnsec.Click += new System.EventHandler(this.btnsec_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsil.Location = new System.Drawing.Point(197, 26);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(40, 21);
            this.btnsil.TabIndex = 3;
            this.btnsil.Text = "Sil";
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
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
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.Location = new System.Drawing.Point(3, 48);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 196);
            this.listView1.TabIndex = 2;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Türü";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cinsi";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "İş Emri No";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Barkod";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Stok Kodu";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stok Adı";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tarih";
            this.columnHeader7.Width = 60;
            // 
            // btnara
            // 
            this.btnara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnara.Location = new System.Drawing.Point(197, 3);
            this.btnara.Name = "btnara";
            this.btnara.Size = new System.Drawing.Size(40, 20);
            this.btnara.TabIndex = 1;
            this.btnara.Text = "Ara";
            this.btnara.Click += new System.EventHandler(this.btnara_Click);
            // 
            // textara
            // 
            this.textara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textara.Location = new System.Drawing.Point(3, 3);
            this.textara.Name = "textara";
            this.textara.Size = new System.Drawing.Size(193, 21);
            this.textara.TabIndex = 0;
            // 
            // HurdaTartimControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKapat);
            this.Name = "HurdaTartimControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label2;
        private MobileWhouse.GUI.TextBoxNumeric txtmiktar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnara;
        private System.Windows.Forms.TextBox textara;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnsec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox txtbarkod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
