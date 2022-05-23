namespace MobileWhouse.Controls
{
    partial class SevkControl
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
            this.btnpaletsevk = new System.Windows.Forms.Button();
            this.btnmalhazirlama = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnpaletsevk
            // 
            this.btnpaletsevk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnpaletsevk.Location = new System.Drawing.Point(3, 3);
            this.btnpaletsevk.Name = "btnpaletsevk";
            this.btnpaletsevk.Size = new System.Drawing.Size(234, 60);
            this.btnpaletsevk.TabIndex = 0;
            this.btnpaletsevk.Text = "Palet Sevk";
            this.btnpaletsevk.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnmalhazirlama
            // 
            this.btnmalhazirlama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmalhazirlama.Location = new System.Drawing.Point(3, 69);
            this.btnmalhazirlama.Name = "btnmalhazirlama";
            this.btnmalhazirlama.Size = new System.Drawing.Size(234, 60);
            this.btnmalhazirlama.TabIndex = 0;
            this.btnmalhazirlama.Text = "Mal Hazırlama";
            this.btnmalhazirlama.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkapat.Location = new System.Drawing.Point(3, 239);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(234, 63);
            this.btnkapat.TabIndex = 0;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // SevkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnmalhazirlama);
            this.Controls.Add(this.btnpaletsevk);
            this.Name = "SevkControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnpaletsevk;
        private System.Windows.Forms.Button btnmalhazirlama;
        private System.Windows.Forms.Button btnkapat;
    }
}
