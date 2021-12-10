namespace MobileWhouse.Controls
{
    partial class SelectSayimType
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
            this.btnYeniSayim = new System.Windows.Forms.Button();
            this.btnContinueSayim = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnambsayim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYeniSayim
            // 
            this.btnYeniSayim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniSayim.Location = new System.Drawing.Point(3, 3);
            this.btnYeniSayim.Name = "btnYeniSayim";
            this.btnYeniSayim.Size = new System.Drawing.Size(234, 52);
            this.btnYeniSayim.TabIndex = 0;
            this.btnYeniSayim.Text = "Yeni Sayım";
            this.btnYeniSayim.Click += new System.EventHandler(this.mnNewSayim_Click);
            // 
            // btnContinueSayim
            // 
            this.btnContinueSayim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinueSayim.Location = new System.Drawing.Point(3, 61);
            this.btnContinueSayim.Name = "btnContinueSayim";
            this.btnContinueSayim.Size = new System.Drawing.Size(234, 52);
            this.btnContinueSayim.TabIndex = 1;
            this.btnContinueSayim.Text = "Sayıma Devam Et";
            this.btnContinueSayim.Click += new System.EventHandler(this.mnContinueSayim_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(3, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(234, 49);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnambsayim
            // 
            this.btnambsayim.Location = new System.Drawing.Point(3, 119);
            this.btnambsayim.Name = "btnambsayim";
            this.btnambsayim.Size = new System.Drawing.Size(234, 52);
            this.btnambsayim.TabIndex = 3;
            this.btnambsayim.Text = "Ambalaj Sayım";
            this.btnambsayim.Click += new System.EventHandler(this.btnambsayim_Click);
            // 
            // SelectSayimType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnambsayim);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnContinueSayim);
            this.Controls.Add(this.btnYeniSayim);
            this.Name = "SelectSayimType";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYeniSayim;
        private System.Windows.Forms.Button btnContinueSayim;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnambsayim;
    }
}
