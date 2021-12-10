namespace MobileWhouse.Controls.PRD
{
    partial class IsEmriBaslatControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsEmriBaslatControl));
            this.btnKapat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listpersonel = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.img = new System.Windows.Forms.ImageList();
            this.txtistasyon = new System.Windows.Forms.TextBox();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpersonel = new System.Windows.Forms.TextBox();
            this.btnpersonel = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.btncikart = new System.Windows.Forms.Button();
            this.btnisemri = new System.Windows.Forms.Button();
            this.btnistasyon = new System.Windows.Forms.Button();
            this.txtstokkod = new System.Windows.Forms.TextBox();
            this.btnbaslat = new MobileWhouse.GUI.ColourButton();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(3, 287);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(234, 30);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.Text = "Istasyon";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.Text = "İş Emri";
            // 
            // listpersonel
            // 
            this.listpersonel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listpersonel.Columns.Add(this.columnHeader3);
            this.listpersonel.Columns.Add(this.columnHeader1);
            this.listpersonel.Columns.Add(this.columnHeader2);
            this.listpersonel.FullRowSelect = true;
            this.listpersonel.Location = new System.Drawing.Point(3, 133);
            this.listpersonel.Name = "listpersonel";
            this.listpersonel.Size = new System.Drawing.Size(237, 148);
            this.listpersonel.SmallImageList = this.img;
            this.listpersonel.TabIndex = 4;
            this.listpersonel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sira No";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Personel Kod";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Personel İsim";
            this.columnHeader2.Width = 160;
            this.img.Images.Clear();
            this.img.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.img.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // txtistasyon
            // 
            this.txtistasyon.Location = new System.Drawing.Point(57, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.Size = new System.Drawing.Size(158, 21);
            this.txtistasyon.TabIndex = 7;
            // 
            // txtisemri
            // 
            this.txtisemri.Location = new System.Drawing.Point(57, 27);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(158, 21);
            this.txtisemri.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.Text = "Personel";
            // 
            // txtpersonel
            // 
            this.txtpersonel.Location = new System.Drawing.Point(57, 108);
            this.txtpersonel.Name = "txtpersonel";
            this.txtpersonel.Size = new System.Drawing.Size(81, 21);
            this.txtpersonel.TabIndex = 7;
            // 
            // btnpersonel
            // 
            this.btnpersonel.Location = new System.Drawing.Point(140, 108);
            this.btnpersonel.Name = "btnpersonel";
            this.btnpersonel.Size = new System.Drawing.Size(24, 20);
            this.btnpersonel.TabIndex = 9;
            this.btnpersonel.Text = "...";
            this.btnpersonel.Click += new System.EventHandler(this.btnpersonel_Click);
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(168, 108);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(33, 20);
            this.btnekle.TabIndex = 9;
            this.btnekle.Text = "+";
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btncikart
            // 
            this.btncikart.Location = new System.Drawing.Point(203, 108);
            this.btncikart.Name = "btncikart";
            this.btncikart.Size = new System.Drawing.Size(33, 20);
            this.btncikart.TabIndex = 10;
            this.btncikart.Text = "-";
            this.btncikart.Click += new System.EventHandler(this.btncikart_Click);
            // 
            // btnisemri
            // 
            this.btnisemri.Location = new System.Drawing.Point(216, 27);
            this.btnisemri.Name = "btnisemri";
            this.btnisemri.Size = new System.Drawing.Size(24, 20);
            this.btnisemri.TabIndex = 9;
            this.btnisemri.Text = "...";
            this.btnisemri.Click += new System.EventHandler(this.btnisemri_Click);
            // 
            // btnistasyon
            // 
            this.btnistasyon.Location = new System.Drawing.Point(216, 4);
            this.btnistasyon.Name = "btnistasyon";
            this.btnistasyon.Size = new System.Drawing.Size(24, 20);
            this.btnistasyon.TabIndex = 9;
            this.btnistasyon.Text = "...";
            this.btnistasyon.Click += new System.EventHandler(this.btnistasyon_Click);
            // 
            // txtstokkod
            // 
            this.txtstokkod.Location = new System.Drawing.Point(3, 84);
            this.txtstokkod.Name = "txtstokkod";
            this.txtstokkod.Size = new System.Drawing.Size(233, 21);
            this.txtstokkod.TabIndex = 7;
            this.txtstokkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstokkod_KeyPress);
            // 
            // btnbaslat
            // 
            this.btnbaslat.BackColor = System.Drawing.Color.Empty;
            this.btnbaslat.Enabled = false;
            this.btnbaslat.ForeColor = System.Drawing.Color.Empty;
            this.btnbaslat.Location = new System.Drawing.Point(57, 54);
            this.btnbaslat.Name = "btnbaslat";
            this.btnbaslat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnbaslat.NormalTxtColour = System.Drawing.Color.Black;
            this.btnbaslat.PushedBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnbaslat.PushedTxtColour = System.Drawing.Color.White;
            this.btnbaslat.Size = new System.Drawing.Size(158, 24);
            this.btnbaslat.TabIndex = 20;
            this.btnbaslat.Text = "Başlat";
            this.btnbaslat.Click += new System.EventHandler(this.btnbaslat_Click);
            // 
            // IsEmriBaslatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnbaslat);
            this.Controls.Add(this.btncikart);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.btnistasyon);
            this.Controls.Add(this.btnisemri);
            this.Controls.Add(this.btnpersonel);
            this.Controls.Add(this.txtpersonel);
            this.Controls.Add(this.txtstokkod);
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.txtistasyon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listpersonel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKapat);
            this.Name = "IsEmriBaslatControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listpersonel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtistasyon;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpersonel;
        private System.Windows.Forms.Button btnpersonel;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Button btncikart;
        private System.Windows.Forms.Button btnisemri;
        private System.Windows.Forms.Button btnistasyon;
        private System.Windows.Forms.TextBox txtstokkod;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList img;
        private MobileWhouse.GUI.ColourButton btnbaslat;
    }
}
