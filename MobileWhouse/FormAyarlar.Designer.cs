namespace MobileWhouse
{
    partial class FormAyarlar
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textAppServ = new System.Windows.Forms.TextBox();
            this.cmbLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtraporurl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(3, 29);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(233, 21);
            this.txtURL.TabIndex = 8;
            this.txtURL.Text = "http://10.0.0.250:400/";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Service URL";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(164, 205);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(72, 20);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Iptal";
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(3, 234);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(233, 33);
            this.btnupdate.TabIndex = 12;
            this.btnupdate.Text = "Program Güncelle";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 20);
            this.label2.Text = "Uygulama Sunucusu";
            // 
            // textAppServ
            // 
            this.textAppServ.Location = new System.Drawing.Point(3, 76);
            this.textAppServ.Name = "textAppServ";
            this.textAppServ.Size = new System.Drawing.Size(233, 21);
            this.textAppServ.TabIndex = 8;
            this.textAppServ.Text = "http://10.0.0.250:2002/";
            // 
            // cmbLog
            // 
            this.cmbLog.Items.Add("Kapalı");
            this.cmbLog.Items.Add("Hata Mesajları");
            this.cmbLog.Items.Add("Uyarı Mesajları");
            this.cmbLog.Items.Add("Bilgi Mesajları");
            this.cmbLog.Items.Add("Tüm Loglar");
            this.cmbLog.Location = new System.Drawing.Point(118, 151);
            this.cmbLog.Name = "cmbLog";
            this.cmbLog.Size = new System.Drawing.Size(118, 22);
            this.cmbLog.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.Text = "Program Log:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 20);
            this.label4.Text = "Rapor Sunucusu";
            // 
            // txtraporurl
            // 
            this.txtraporurl.Location = new System.Drawing.Point(3, 124);
            this.txtraporurl.Name = "txtraporurl";
            this.txtraporurl.Size = new System.Drawing.Size(233, 21);
            this.txtraporurl.TabIndex = 8;
            this.txtraporurl.Text = "http://localhost:62624/";
            // 
            // FormAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLog);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtraporurl);
            this.Controls.Add(this.textAppServ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormAyarlar";
            this.Text = "Ayarlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAyarlar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAppServ;
        private System.Windows.Forms.ComboBox cmbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtraporurl;

    }
}