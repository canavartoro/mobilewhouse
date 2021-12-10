namespace MobileWhouse.Controls
{
    partial class AcikBelgeSilControl
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
            this.btnAcikDepo = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAcikDepo
            // 
            this.btnAcikDepo.Location = new System.Drawing.Point(23, 28);
            this.btnAcikDepo.Name = "btnAcikDepo";
            this.btnAcikDepo.Size = new System.Drawing.Size(200, 25);
            this.btnAcikDepo.TabIndex = 0;
            this.btnAcikDepo.Text = "Açık Depoiçi Raf Hareketi Sil";
            this.btnAcikDepo.Click += new System.EventHandler(this.btnAcikDepo_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(23, 209);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(200, 37);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // AcikBelgeSilControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnAcikDepo);
            this.Name = "AcikBelgeSilControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAcikDepo;
        private System.Windows.Forms.Button btnKapat;
    }
}
