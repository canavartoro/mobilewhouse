namespace MobileWhouse.Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbalajTraControl));
            this.uButton1 = new MobileWhouse.GUI.UButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.btnkaydet = new MobileWhouse.GUI.UButton();
            this.checksil = new System.Windows.Forms.CheckBox();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.textBarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnhareket = new System.Windows.Forms.Button();
            this.btndepo = new System.Windows.Forms.Button();
            this.textHareket = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDepo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uButton1
            // 
            this.uButton1.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.uButton1.BackColor = System.Drawing.Color.Empty;
            this.uButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uButton1.ForeColor = System.Drawing.Color.Empty;
            this.uButton1.Image = ((System.Drawing.Image)(resources.GetObject("uButton1.Image")));
            this.uButton1.Location = new System.Drawing.Point(0, 275);
            this.uButton1.Name = "uButton1";
            this.uButton1.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.uButton1.NormalTxtColour = System.Drawing.Color.Blue;
            this.uButton1.PushedBtnColour = System.Drawing.Color.Blue;
            this.uButton1.PushedTxtColour = System.Drawing.Color.Yellow;
            this.uButton1.Size = new System.Drawing.Size(240, 40);
            this.uButton1.TabIndex = 0;
            this.uButton1.Text = "Kapat";
            this.uButton1.Click += new System.EventHandler(this.uButton1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 275);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.btnkaydet);
            this.tabPage1.Controls.Add(this.checksil);
            this.tabPage1.Controls.Add(this.btnbarkod);
            this.tabPage1.Controls.Add(this.textBarkod);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.btnhareket);
            this.tabPage1.Controls.Add(this.btndepo);
            this.tabPage1.Controls.Add(this.textHareket);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textDepo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 252);
            this.tabPage1.Text = "Belge";
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(55, 31);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(152, 21);
            this.txtRaf.TabIndex = 2;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Alignment = MobileWhouse.GUI.ImageAlignment.Center;
            this.btnkaydet.BackColor = System.Drawing.Color.Empty;
            this.btnkaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnkaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnkaydet.Image")));
            this.btnkaydet.Location = new System.Drawing.Point(193, 7);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnkaydet.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnkaydet.Size = new System.Drawing.Size(44, 21);
            this.btnkaydet.TabIndex = 8;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // checksil
            // 
            this.checksil.Location = new System.Drawing.Point(193, 78);
            this.checksil.Name = "checksil";
            this.checksil.Size = new System.Drawing.Size(45, 20);
            this.checksil.TabIndex = 7;
            this.checksil.Text = "Sil";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Location = new System.Drawing.Point(164, 79);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(25, 20);
            this.btnbarkod.TabIndex = 6;
            this.btnbarkod.Text = "...";
            // 
            // textBarkod
            // 
            this.textBarkod.BackColor = System.Drawing.Color.Yellow;
            this.textBarkod.Location = new System.Drawing.Point(55, 78);
            this.textBarkod.Name = "textBarkod";
            this.textBarkod.Size = new System.Drawing.Size(108, 21);
            this.textBarkod.TabIndex = 5;
            this.textBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 79);
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
            this.listView1.Location = new System.Drawing.Point(3, 104);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 148);
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
            // btnhareket
            // 
            this.btnhareket.Location = new System.Drawing.Point(164, 7);
            this.btnhareket.Name = "btnhareket";
            this.btnhareket.Size = new System.Drawing.Size(25, 20);
            this.btnhareket.TabIndex = 1;
            this.btnhareket.Text = "...";
            this.btnhareket.Click += new System.EventHandler(this.btnhareket_Click);
            // 
            // btndepo
            // 
            this.btndepo.Location = new System.Drawing.Point(208, 55);
            this.btndepo.Name = "btndepo";
            this.btndepo.Size = new System.Drawing.Size(25, 20);
            this.btndepo.TabIndex = 4;
            this.btndepo.Text = "...";
            this.btndepo.Click += new System.EventHandler(this.btndepo_Click);
            // 
            // textHareket
            // 
            this.textHareket.Location = new System.Drawing.Point(55, 7);
            this.textHareket.Name = "textHareket";
            this.textHareket.Size = new System.Drawing.Size(108, 21);
            this.textHareket.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.Text = "Hareket";
            // 
            // textDepo
            // 
            this.textDepo.Location = new System.Drawing.Point(55, 55);
            this.textDepo.Name = "textDepo";
            this.textDepo.Size = new System.Drawing.Size(152, 21);
            this.textDepo.TabIndex = 3;
            this.textDepo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDepo_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.Text = "Raf";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "Depo";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 249);
            this.tabPage2.Text = "Detaylar";
            // 
            // AmbalajTraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.uButton1);
            this.Name = "AmbalajTraControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.OnLoad += new System.EventHandler(this.AmbalajTraControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton uButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textDepo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndepo;
        private System.Windows.Forms.Button btnhareket;
        private System.Windows.Forms.TextBox textHareket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox textBarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checksil;
        private MobileWhouse.GUI.UButton btnkaydet;
        private RafTextBox txtRaf;
    }
}
