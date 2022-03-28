namespace MobileWhouse.Controls
{
    partial class StokRafDurumuControl
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
            this.lvwInfos = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnListele = new System.Windows.Forms.Button();
            this.txtItemCode = new MobileWhouse.Controls.BarkodTextBox();
            this.txtLocationCode = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowRaf = new System.Windows.Forms.Button();
            this.btnShowItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwInfos
            // 
            this.lvwInfos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInfos.Columns.Add(this.columnHeader2);
            this.lvwInfos.Columns.Add(this.columnHeader5);
            this.lvwInfos.Columns.Add(this.columnHeader3);
            this.lvwInfos.Columns.Add(this.columnHeader4);
            this.lvwInfos.Columns.Add(this.columnHeader1);
            this.lvwInfos.FullRowSelect = true;
            this.lvwInfos.Location = new System.Drawing.Point(4, 60);
            this.lvwInfos.Name = "lvwInfos";
            this.lvwInfos.Size = new System.Drawing.Size(233, 214);
            this.lvwInfos.TabIndex = 6;
            this.lvwInfos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Kodu";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Stok Adı";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Br.";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Raf";
            this.columnHeader1.Width = 60;
            // 
            // btnListele
            // 
            this.btnListele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListele.Location = new System.Drawing.Point(195, 33);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(42, 21);
            this.btnListele.TabIndex = 14;
            this.btnListele.Text = "Ara";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.DepoId = 0;
            this.txtItemCode.IsRaf = 0;
            this.txtItemCode.Location = new System.Drawing.Point(76, 33);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(92, 21);
            this.txtItemCode.TabIndex = 24;
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocationCode.DepoId = 0;
            this.txtLocationCode.IsRaf = 1;
            this.txtLocationCode.Location = new System.Drawing.Point(76, 9);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(92, 21);
            this.txtLocationCode.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.Text = "Stok Kodu";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.Text = "Raf";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(195, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 21);
            this.button1.TabIndex = 27;
            this.button1.Text = "X";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowRaf
            // 
            this.btnShowRaf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRaf.Location = new System.Drawing.Point(166, 9);
            this.btnShowRaf.Name = "btnShowRaf";
            this.btnShowRaf.Size = new System.Drawing.Size(26, 21);
            this.btnShowRaf.TabIndex = 30;
            this.btnShowRaf.Text = "...";
            this.btnShowRaf.Click += new System.EventHandler(this.btnShowRaf_Click);
            // 
            // btnShowItem
            // 
            this.btnShowItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowItem.Location = new System.Drawing.Point(166, 33);
            this.btnShowItem.Name = "btnShowItem";
            this.btnShowItem.Size = new System.Drawing.Size(26, 21);
            this.btnShowItem.TabIndex = 31;
            this.btnShowItem.Text = "...";
            this.btnShowItem.Click += new System.EventHandler(this.btnShowItem_Click);
            // 
            // StokRafDurumuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnShowItem);
            this.Controls.Add(this.btnShowRaf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.lvwInfos);
            this.Name = "StokRafDurumuControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwInfos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnListele;
        private BarkodTextBox txtItemCode;
        private RafTextBox txtLocationCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowRaf;
        private System.Windows.Forms.Button btnShowItem;
    }
}
