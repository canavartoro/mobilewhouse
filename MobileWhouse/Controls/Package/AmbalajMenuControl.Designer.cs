namespace MobileWhouse.Controls.Package
{
    partial class AmbalajMenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbalajMenuControl));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnambalajolustur = new System.Windows.Forms.Button();
            this.uButton2 = new System.Windows.Forms.Button();
            this.uButton3 = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Location = new System.Drawing.Point(3, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 40);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnambalajolustur
            // 
            this.btnambalajolustur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnambalajolustur.BackColor = System.Drawing.Color.Empty;
            this.btnambalajolustur.ForeColor = System.Drawing.Color.Empty;
            this.btnambalajolustur.Location = new System.Drawing.Point(3, 3);
            this.btnambalajolustur.Name = "btnambalajolustur";
            this.btnambalajolustur.Size = new System.Drawing.Size(233, 40);
            this.btnambalajolustur.TabIndex = 26;
            this.btnambalajolustur.Text = "Ambalaj Oluştur";
            this.btnambalajolustur.Click += new System.EventHandler(this.btnambalajolustur_Click);
            // 
            // uButton2
            // 
            this.uButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton2.BackColor = System.Drawing.Color.Empty;
            this.uButton2.ForeColor = System.Drawing.Color.Empty;
            this.uButton2.Location = new System.Drawing.Point(3, 49);
            this.uButton2.Name = "uButton2";
            this.uButton2.Size = new System.Drawing.Size(233, 40);
            this.uButton2.TabIndex = 26;
            this.uButton2.Text = "Palet Oluştur";
            this.uButton2.Click += new System.EventHandler(this.uButton2_Click);
            // 
            // uButton3
            // 
            this.uButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton3.BackColor = System.Drawing.Color.Empty;
            this.uButton3.ForeColor = System.Drawing.Color.Empty;
            this.uButton3.Location = new System.Drawing.Point(3, 95);
            this.uButton3.Name = "uButton3";
            this.uButton3.Size = new System.Drawing.Size(233, 40);
            this.uButton3.TabIndex = 26;
            this.uButton3.Text = "Ambalaj Transfer";
            this.uButton3.Click += new System.EventHandler(this.uButton3_Click);
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.Empty;
            this.btnprint.ForeColor = System.Drawing.Color.Empty;
            this.btnprint.Location = new System.Drawing.Point(3, 141);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(233, 40);
            this.btnprint.TabIndex = 26;
            this.btnprint.Text = "Etiketleme";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // AmbalajMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.uButton3);
            this.Controls.Add(this.uButton2);
            this.Controls.Add(this.btnambalajolustur);
            this.Controls.Add(this.btnCancel);
            this.Name = "AmbalajMenuControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnambalajolustur;
        private System.Windows.Forms.Button uButton2;
        private System.Windows.Forms.Button uButton3;
        private System.Windows.Forms.Button btnprint;
    }
}
