namespace MobileWhouse.Dilogs
{
    partial class FormSelectWstation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnsec = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.btnara = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.txtstokkod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnsec
            // 
            this.btnsec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsec.Location = new System.Drawing.Point(165, 297);
            this.btnsec.Name = "btnsec";
            this.btnsec.Size = new System.Drawing.Size(72, 20);
            this.btnsec.TabIndex = 0;
            this.btnsec.Text = "Seç";
            this.btnsec.Click += new System.EventHandler(this.btnsec_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(3, 297);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(72, 20);
            this.btnkapat.TabIndex = 0;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // txtisemri
            // 
            this.txtisemri.Location = new System.Drawing.Point(4, 5);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(84, 21);
            this.txtisemri.TabIndex = 1;
            this.txtisemri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // btnara
            // 
            this.btnara.Location = new System.Drawing.Point(181, 4);
            this.btnara.Name = "btnara";
            this.btnara.Size = new System.Drawing.Size(56, 20);
            this.btnara.TabIndex = 2;
            this.btnara.Text = "Ara";
            this.btnara.Click += new System.EventHandler(this.btnara_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.Columns.Add(this.columnHeader8);
            this.listView1.Columns.Add(this.columnHeader9);
            this.listView1.Columns.Add(this.columnHeader10);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(4, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(233, 259);
            this.listView1.TabIndex = 3;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "İstasyon Kod";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "İstasyon Adı";
            this.columnHeader7.Width = 190;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "İş Merkezi Kodu";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "İş Merkezi Adı";
            this.columnHeader9.Width = 190;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Malzeme Çıkış Deposu";
            this.columnHeader10.Width = 90;
            // 
            // txtstokkod
            // 
            this.txtstokkod.Location = new System.Drawing.Point(91, 5);
            this.txtstokkod.Name = "txtstokkod";
            this.txtstokkod.Size = new System.Drawing.Size(84, 21);
            this.txtstokkod.TabIndex = 1;
            this.txtstokkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // FormSelectWstation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnara);
            this.Controls.Add(this.txtstokkod);
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnsec);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSelectWstation";
            this.Text = "İstasyon Seçim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnsec;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Button btnara;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtstokkod;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}