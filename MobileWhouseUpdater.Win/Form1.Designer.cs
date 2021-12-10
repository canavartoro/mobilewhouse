namespace MobileWhouseUpdater
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblbaslik = new System.Windows.Forms.Label();
            this.lblbilgi = new System.Windows.Forms.Label();
            this.btnkapat = new System.Windows.Forms.Button();
            this.btnupd = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(3, 39);
            this.lblbaslik.Name = "lblbaslik";
            this.lblbaslik.Size = new System.Drawing.Size(234, 20);
            this.lblbaslik.Text = "Program güncelleniyor ..";
            // 
            // lblbilgi
            // 
            this.lblbilgi.Location = new System.Drawing.Point(3, 59);
            this.lblbilgi.Name = "lblbilgi";
            this.lblbilgi.Size = new System.Drawing.Size(234, 99);
            // 
            // btnkapat
            // 
            this.btnkapat.Location = new System.Drawing.Point(3, 217);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(118, 52);
            this.btnkapat.TabIndex = 2;
            this.btnkapat.Text = "KAPAT";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // btnupd
            // 
            this.btnupd.Location = new System.Drawing.Point(122, 217);
            this.btnupd.Name = "btnupd";
            this.btnupd.Size = new System.Drawing.Size(115, 52);
            this.btnupd.TabIndex = 2;
            this.btnupd.Text = "GÜNCELLE";
            this.btnupd.Click += new System.EventHandler(this.btnupd_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnupd);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.lblbilgi);
            this.Controls.Add(this.lblbaslik);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Program Güncelleme";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblbaslik;
        private System.Windows.Forms.Label lblbilgi;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.Button btnupd;
        private System.Windows.Forms.Timer timer1;
    }
}

