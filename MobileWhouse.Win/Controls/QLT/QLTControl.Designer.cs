namespace MobileWhouse.Controls.QLT
{
    partial class QLTControl
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btnkaliteonay = new System.Windows.Forms.Button();
            this.btnbloke = new System.Windows.Forms.Button();
            this.btnuygunsuzluk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(3, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 40);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.Location = new System.Drawing.Point(3, 3);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(233, 41);
            this.btn.TabIndex = 25;
            this.btn.Text = "Kalite Onay";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnkaliteonay
            // 
            this.btnkaliteonay.Location = new System.Drawing.Point(0, 3);
            this.btnkaliteonay.Name = "btnkaliteonay";
            this.btnkaliteonay.Size = new System.Drawing.Size(240, 47);
            this.btnkaliteonay.TabIndex = 25;
            this.btnkaliteonay.Text = "colourButton1";
            // 
            // btnbloke
            // 
            this.btnbloke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbloke.Location = new System.Drawing.Point(3, 50);
            this.btnbloke.Name = "btnbloke";
            this.btnbloke.Size = new System.Drawing.Size(233, 41);
            this.btnbloke.TabIndex = 26;
            this.btnbloke.Text = "Kalite Bloke";
            this.btnbloke.Click += new System.EventHandler(this.btnbloke_Click);
            // 
            // btnuygunsuzluk
            // 
            this.btnuygunsuzluk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnuygunsuzluk.Location = new System.Drawing.Point(3, 97);
            this.btnuygunsuzluk.Name = "btnuygunsuzluk";
            this.btnuygunsuzluk.Size = new System.Drawing.Size(233, 41);
            this.btnuygunsuzluk.TabIndex = 26;
            this.btnuygunsuzluk.Text = "Kalite Uygunsuzluk";
            this.btnuygunsuzluk.Click += new System.EventHandler(this.btnuygunsuzluk_Click);
            // 
            // QLTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnuygunsuzluk);
            this.Controls.Add(this.btnbloke);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnCancel);
            this.Name = "QLTControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnkaliteonay;
        private System.Windows.Forms.Button btnbloke;
        private System.Windows.Forms.Button btnuygunsuzluk;
    }
}
