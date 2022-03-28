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
            this.btnKapat = new MobileWhouse.GUI.UButton();
            this.listpersonel = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.img = new System.Windows.Forms.ImageList();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpersonel = new System.Windows.Forms.TextBox();
            this.btnpersonel = new MobileWhouse.GUI.UButton();
            this.btnekle = new MobileWhouse.GUI.UButton();
            this.btncikart = new MobileWhouse.GUI.UButton();
            this.txtstokkod = new System.Windows.Forms.TextBox();
            this.btnbaslat = new MobileWhouse.GUI.UButton();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.txtisemri = new MobileWhouse.GUI.ULookupEdit();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.Empty;
            this.btnKapat.ForeColor = System.Drawing.Color.Empty;
            this.btnKapat.Location = new System.Drawing.Point(3, 287);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKapat.Size = new System.Drawing.Size(234, 30);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
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
            this.txtpersonel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpersonel.Location = new System.Drawing.Point(64, 108);
            this.txtpersonel.Name = "txtpersonel";
            this.txtpersonel.Size = new System.Drawing.Size(74, 21);
            this.txtpersonel.TabIndex = 7;
            // 
            // btnpersonel
            // 
            this.btnpersonel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnpersonel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnpersonel.BackColor = System.Drawing.Color.Empty;
            this.btnpersonel.ForeColor = System.Drawing.Color.Empty;
            this.btnpersonel.Location = new System.Drawing.Point(140, 108);
            this.btnpersonel.Name = "btnpersonel";
            this.btnpersonel.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnpersonel.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnpersonel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnpersonel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnpersonel.Size = new System.Drawing.Size(24, 20);
            this.btnpersonel.TabIndex = 9;
            this.btnpersonel.Text = "...";
            this.btnpersonel.Click += new System.EventHandler(this.btnpersonel_Click);
            // 
            // btnekle
            // 
            this.btnekle.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnekle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnekle.BackColor = System.Drawing.Color.Empty;
            this.btnekle.ForeColor = System.Drawing.Color.Empty;
            this.btnekle.Location = new System.Drawing.Point(168, 108);
            this.btnekle.Name = "btnekle";
            this.btnekle.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnekle.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnekle.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnekle.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnekle.Size = new System.Drawing.Size(33, 20);
            this.btnekle.TabIndex = 9;
            this.btnekle.Text = "+";
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btncikart
            // 
            this.btncikart.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btncikart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncikart.BackColor = System.Drawing.Color.Empty;
            this.btncikart.ForeColor = System.Drawing.Color.Empty;
            this.btncikart.Location = new System.Drawing.Point(203, 108);
            this.btncikart.Name = "btncikart";
            this.btncikart.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btncikart.NormalTxtColour = System.Drawing.Color.Blue;
            this.btncikart.PushedBtnColour = System.Drawing.Color.Blue;
            this.btncikart.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btncikart.Size = new System.Drawing.Size(33, 20);
            this.btncikart.TabIndex = 10;
            this.btncikart.Text = "-";
            this.btncikart.Click += new System.EventHandler(this.btncikart_Click);
            // 
            // txtstokkod
            // 
            this.txtstokkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtstokkod.Location = new System.Drawing.Point(3, 84);
            this.txtstokkod.Name = "txtstokkod";
            this.txtstokkod.Size = new System.Drawing.Size(233, 21);
            this.txtstokkod.TabIndex = 7;
            this.txtstokkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstokkod_KeyPress);
            // 
            // btnbaslat
            // 
            this.btnbaslat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnbaslat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbaslat.BackColor = System.Drawing.Color.Empty;
            this.btnbaslat.Enabled = false;
            this.btnbaslat.ForeColor = System.Drawing.Color.Empty;
            this.btnbaslat.Location = new System.Drawing.Point(64, 58);
            this.btnbaslat.Name = "btnbaslat";
            this.btnbaslat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnbaslat.NormalTxtColour = System.Drawing.Color.Black;
            this.btnbaslat.PushedBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnbaslat.PushedTxtColour = System.Drawing.Color.White;
            this.btnbaslat.Size = new System.Drawing.Size(143, 24);
            this.btnbaslat.TabIndex = 20;
            this.btnbaslat.Text = "Başlat";
            this.btnbaslat.Click += new System.EventHandler(this.btnbaslat_Click);
            // 
            // txtistasyon
            // 
            this.txtistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 60;
            this.txtistasyon.Location = new System.Drawing.Point(3, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(233, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 22;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.DataFieldName = "";
            this.txtisemri.DataType = MobileWhouse.Enums.DataSourceType.IsEmri;
            this.txtisemri.Description = "";
            this.txtisemri.FilterCondition = "";
            this.txtisemri.LabelText = "İş Emri";
            this.txtisemri.LabelWidth = 60;
            this.txtisemri.Location = new System.Drawing.Point(3, 29);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.RememberValue = false;
            this.txtisemri.ShowDescription = false;
            this.txtisemri.ShowLabelText = false;
            this.txtisemri.Size = new System.Drawing.Size(233, 27);
            this.txtisemri.SourceApplication = 0;
            this.txtisemri.TabIndex = 23;
            this.txtisemri.OnSelected += new MobileWhouse.OnSelectedObject(this.txtisemri_OnSelected);
            // 
            // IsEmriBaslatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.txtistasyon);
            this.Controls.Add(this.btnbaslat);
            this.Controls.Add(this.btncikart);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.btnpersonel);
            this.Controls.Add(this.txtpersonel);
            this.Controls.Add(this.txtstokkod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listpersonel);
            this.Controls.Add(this.btnKapat);
            this.Name = "IsEmriBaslatControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.UButton btnKapat;
        private System.Windows.Forms.ListView listpersonel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpersonel;
        private GUI.UButton btnpersonel;
        private GUI.UButton btnekle;
        private GUI.UButton btncikart;
        private System.Windows.Forms.TextBox txtstokkod;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList img;
        private MobileWhouse.GUI.UButton btnbaslat;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
        private MobileWhouse.GUI.ULookupEdit txtisemri;
    }
}
