namespace MobileWhouse.Forms
{
    partial class FormMesaj
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
            this.btnok = new MobileWhouse.GUI.UButton();
            this.btncancel = new MobileWhouse.GUI.UButton();
            this.textdetail = new System.Windows.Forms.TextBox();
            this.textCaption = new System.Windows.Forms.Label();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.btnsend = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnok.BackColor = System.Drawing.Color.Empty;
            this.btnok.ForeColor = System.Drawing.Color.Empty;
            this.btnok.Location = new System.Drawing.Point(162, 244);
            this.btnok.Name = "btnok";
            this.btnok.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnok.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnok.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnok.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnok.Size = new System.Drawing.Size(61, 27);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "TAMAM";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancel
            // 
            this.btncancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncancel.BackColor = System.Drawing.Color.Empty;
            this.btncancel.ForeColor = System.Drawing.Color.Empty;
            this.btncancel.Location = new System.Drawing.Point(17, 244);
            this.btncancel.Name = "btncancel";
            this.btncancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btncancel.NormalTxtColour = System.Drawing.Color.Black;
            this.btncancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btncancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btncancel.Size = new System.Drawing.Size(69, 27);
            this.btncancel.TabIndex = 20;
            this.btncancel.Text = "VAZGEÇ";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // textdetail
            // 
            this.textdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textdetail.BackColor = System.Drawing.SystemColors.Info;
            this.textdetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textdetail.Location = new System.Drawing.Point(8, 59);
            this.textdetail.Multiline = true;
            this.textdetail.Name = "textdetail";
            this.textdetail.Size = new System.Drawing.Size(221, 179);
            this.textdetail.TabIndex = 2;
            // 
            // textCaption
            // 
            this.textCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textCaption.ForeColor = System.Drawing.Color.Black;
            this.textCaption.Location = new System.Drawing.Point(17, 11);
            this.textCaption.Name = "textCaption";
            this.textCaption.Size = new System.Drawing.Size(139, 45);
            this.textCaption.Text = "Lütfen dikkat";
            // 
            // pictureIcon
            // 
            this.pictureIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureIcon.Location = new System.Drawing.Point(162, 11);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(61, 45);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnsend
            // 
            this.btnsend.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnsend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsend.BackColor = System.Drawing.Color.Empty;
            this.btnsend.ForeColor = System.Drawing.Color.Empty;
            this.btnsend.Location = new System.Drawing.Point(88, 244);
            this.btnsend.Name = "btnsend";
            this.btnsend.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnsend.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnsend.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnsend.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnsend.Size = new System.Drawing.Size(72, 27);
            this.btnsend.TabIndex = 5;
            this.btnsend.Text = "BİLDİR";
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // FormMesaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.textCaption);
            this.Controls.Add(this.textdetail);
            this.Controls.Add(this.btnok);
            this.Name = "FormMesaj";
            this.Text = "Dikkat";
            this.Load += new System.EventHandler(this.FormMesaj_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton btnok;
        private System.Windows.Forms.TextBox textdetail;
        private System.Windows.Forms.Label textCaption;
        private System.Windows.Forms.PictureBox pictureIcon;
        private MobileWhouse.GUI.UButton btnsend;
        private MobileWhouse.GUI.UButton btncancel;

    }
}