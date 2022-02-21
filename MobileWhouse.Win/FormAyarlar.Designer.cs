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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAyarlar));
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textAppServ = new System.Windows.Forms.TextBox();
            this.cmbLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtprintserv = new System.Windows.Forms.TextBox();
            this.textPort = new MobileWhouse.GUI.TextBoxNumeric();
            this.btngonder = new MobileWhouse.GUI.UButton();
            this.t4 = new MobileWhouse.GUI.UButton();
            this.t3 = new MobileWhouse.GUI.UButton();
            this.t2 = new MobileWhouse.GUI.UButton();
            this.t1 = new MobileWhouse.GUI.UButton();
            this.btnbilgi = new MobileWhouse.GUI.UButton();
            this.btnupdate = new MobileWhouse.GUI.UButton();
            this.btnKaydet = new MobileWhouse.GUI.UButton();
            this.btnCancel = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(3, 29);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(212, 21);
            this.txtURL.TabIndex = 8;
            this.txtURL.Text = "http://10.0.0.250:400/";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.Text = "Service URL";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.Text = "Uygulama Sunucusu";
            // 
            // textAppServ
            // 
            this.textAppServ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textAppServ.Location = new System.Drawing.Point(3, 76);
            this.textAppServ.Name = "textAppServ";
            this.textAppServ.Size = new System.Drawing.Size(212, 21);
            this.textAppServ.TabIndex = 8;
            this.textAppServ.Text = "http://10.0.0.250:2002/";
            // 
            // cmbLog
            // 
            this.cmbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLog.Items.Add("Kapalı");
            this.cmbLog.Items.Add("Hata Mesajları");
            this.cmbLog.Items.Add("Uyarı Mesajları");
            this.cmbLog.Items.Add("Bilgi Mesajları");
            this.cmbLog.Items.Add("Tüm Loglar");
            this.cmbLog.Location = new System.Drawing.Point(87, 151);
            this.cmbLog.Name = "cmbLog";
            this.cmbLog.Size = new System.Drawing.Size(97, 22);
            this.cmbLog.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.Text = "Program Log:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 20);
            this.label4.Text = "Print Server Host / Port";
            // 
            // txtprintserv
            // 
            this.txtprintserv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtprintserv.Location = new System.Drawing.Point(3, 124);
            this.txtprintserv.Name = "txtprintserv";
            this.txtprintserv.Size = new System.Drawing.Size(133, 21);
            this.txtprintserv.TabIndex = 8;
            this.txtprintserv.Text = "10.0.0.250";
            // 
            // textPort
            // 
            this.textPort.AllowSpace = false;
            this.textPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textPort.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular);
            this.textPort.Location = new System.Drawing.Point(161, 124);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(54, 20);
            this.textPort.TabIndex = 41;
            this.textPort.Text = "8888";
            // 
            // btngonder
            // 
            this.btngonder.Alignment = MobileWhouse.GUI.ImageAlignment.Right;
            this.btngonder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btngonder.BackColor = System.Drawing.Color.Empty;
            this.btngonder.ForeColor = System.Drawing.Color.Empty;
            this.btngonder.Image = ((System.Drawing.Image)(resources.GetObject("btngonder.Image")));
            this.btngonder.Location = new System.Drawing.Point(185, 151);
            this.btngonder.Name = "btngonder";
            this.btngonder.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btngonder.NormalTxtColour = System.Drawing.Color.Red;
            this.btngonder.PushedBtnColour = System.Drawing.Color.Blue;
            this.btngonder.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btngonder.Size = new System.Drawing.Size(55, 22);
            this.btngonder.TabIndex = 36;
            this.btngonder.Text = "Gönder";
            this.btngonder.Click += new System.EventHandler(this.btngonder_Click);
            // 
            // t4
            // 
            this.t4.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t4.BackColor = System.Drawing.Color.Empty;
            this.t4.ForeColor = System.Drawing.Color.Empty;
            this.t4.Location = new System.Drawing.Point(136, 124);
            this.t4.Name = "t4";
            this.t4.NormalBtnColour = System.Drawing.Color.Silver;
            this.t4.NormalTxtColour = System.Drawing.Color.Blue;
            this.t4.PushedBtnColour = System.Drawing.Color.Blue;
            this.t4.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t4.Size = new System.Drawing.Size(25, 21);
            this.t4.TabIndex = 31;
            this.t4.Text = "T";
            this.t4.Click += new System.EventHandler(this.t4_Click);
            // 
            // t3
            // 
            this.t3.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t3.BackColor = System.Drawing.Color.Empty;
            this.t3.ForeColor = System.Drawing.Color.Empty;
            this.t3.Location = new System.Drawing.Point(215, 124);
            this.t3.Name = "t3";
            this.t3.NormalBtnColour = System.Drawing.Color.Silver;
            this.t3.NormalTxtColour = System.Drawing.Color.Blue;
            this.t3.PushedBtnColour = System.Drawing.Color.Blue;
            this.t3.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t3.Size = new System.Drawing.Size(25, 21);
            this.t3.TabIndex = 31;
            this.t3.Text = "T";
            this.t3.Click += new System.EventHandler(this.t3_Click);
            // 
            // t2
            // 
            this.t2.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t2.BackColor = System.Drawing.Color.Empty;
            this.t2.ForeColor = System.Drawing.Color.Empty;
            this.t2.Location = new System.Drawing.Point(215, 76);
            this.t2.Name = "t2";
            this.t2.NormalBtnColour = System.Drawing.Color.Silver;
            this.t2.NormalTxtColour = System.Drawing.Color.Blue;
            this.t2.PushedBtnColour = System.Drawing.Color.Blue;
            this.t2.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t2.Size = new System.Drawing.Size(25, 21);
            this.t2.TabIndex = 31;
            this.t2.Text = "T";
            this.t2.Click += new System.EventHandler(this.t2_Click);
            // 
            // t1
            // 
            this.t1.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1.BackColor = System.Drawing.Color.Empty;
            this.t1.ForeColor = System.Drawing.Color.Empty;
            this.t1.Location = new System.Drawing.Point(215, 28);
            this.t1.Name = "t1";
            this.t1.NormalBtnColour = System.Drawing.Color.Silver;
            this.t1.NormalTxtColour = System.Drawing.Color.Blue;
            this.t1.PushedBtnColour = System.Drawing.Color.Blue;
            this.t1.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t1.Size = new System.Drawing.Size(25, 22);
            this.t1.TabIndex = 31;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // btnbilgi
            // 
            this.btnbilgi.Alignment = MobileWhouse.GUI.ImageAlignment.Center;
            this.btnbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbilgi.BackColor = System.Drawing.Color.Empty;
            this.btnbilgi.ForeColor = System.Drawing.Color.Empty;
            this.btnbilgi.Image = ((System.Drawing.Image)(resources.GetObject("btnbilgi.Image")));
            this.btnbilgi.Location = new System.Drawing.Point(96, 196);
            this.btnbilgi.Name = "btnbilgi";
            this.btnbilgi.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnbilgi.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnbilgi.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnbilgi.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnbilgi.Size = new System.Drawing.Size(40, 29);
            this.btnbilgi.TabIndex = 26;
            this.btnbilgi.Click += new System.EventHandler(this.btnbilgi_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupdate.BackColor = System.Drawing.Color.Empty;
            this.btnupdate.ForeColor = System.Drawing.Color.Empty;
            this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
            this.btnupdate.Location = new System.Drawing.Point(3, 233);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btnupdate.NormalTxtColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnupdate.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnupdate.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnupdate.Size = new System.Drawing.Size(237, 35);
            this.btnupdate.TabIndex = 21;
            this.btnupdate.Text = "Program Güncelle";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.BackColor = System.Drawing.Color.Empty;
            this.btnKaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(142, 196);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnKaydet.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnKaydet.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKaydet.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKaydet.Size = new System.Drawing.Size(98, 29);
            this.btnKaydet.TabIndex = 20;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnCancel.BackColor = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(3, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.NormalTxtColour = System.Drawing.Color.Black;
            this.btnCancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnCancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Iptal";
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.btngonder);
            this.Controls.Add(this.cmbLog);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.btnbilgi);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtprintserv);
            this.Controls.Add(this.textAppServ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAppServ;
        private System.Windows.Forms.ComboBox cmbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtprintserv;
        private MobileWhouse.GUI.UButton btnCancel;
        private MobileWhouse.GUI.UButton btnKaydet;
        private MobileWhouse.GUI.UButton btnupdate;
        private MobileWhouse.GUI.UButton btnbilgi;
        private GUI.UButton t1;
        private GUI.UButton t2;
        private GUI.UButton t3;
        private GUI.UButton btngonder;
        private MobileWhouse.GUI.TextBoxNumeric textPort;
        private MobileWhouse.GUI.UButton t4;

    }
}