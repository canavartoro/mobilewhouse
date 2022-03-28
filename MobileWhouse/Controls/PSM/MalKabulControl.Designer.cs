namespace MobileWhouse.Controls.PSM
{
    partial class MalKabulControl
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
            this.btnKapat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnetiketleme = new System.Windows.Forms.Button();
            this.btnsatinalma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(3, 280);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(234, 37);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "SATINALMA MAL KABUL";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnetiketleme
            // 
            this.btnetiketleme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnetiketleme.Location = new System.Drawing.Point(3, 47);
            this.btnetiketleme.Name = "btnetiketleme";
            this.btnetiketleme.Size = new System.Drawing.Size(234, 38);
            this.btnetiketleme.TabIndex = 2;
            this.btnetiketleme.Text = "S. MAL KABUL ETİKETLEME";
            this.btnetiketleme.Click += new System.EventHandler(this.btnetiketleme_Click);
            // 
            // btnsatinalma
            // 
            this.btnsatinalma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsatinalma.Location = new System.Drawing.Point(3, 91);
            this.btnsatinalma.Name = "btnsatinalma";
            this.btnsatinalma.Size = new System.Drawing.Size(234, 38);
            this.btnsatinalma.TabIndex = 2;
            this.btnsatinalma.Text = "SATINALMA";
            this.btnsatinalma.Click += new System.EventHandler(this.btnsatinalma_Click);
            // 
            // MalKabulControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnsatinalma);
            this.Controls.Add(this.btnetiketleme);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKapat);
            this.Name = "MalKabulControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnetiketleme;
        private System.Windows.Forms.Button btnsatinalma;
    }
}
