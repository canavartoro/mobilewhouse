namespace MobileWhouse
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.lblbuild = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new MobileWhouse.GUI.UButton();
            this.btnOkey = new MobileWhouse.GUI.UButton();
            this.btnCancel = new MobileWhouse.GUI.UButton();
            this.t1 = new MobileWhouse.GUI.UButton();
            this.t2 = new MobileWhouse.GUI.UButton();
            this.t3 = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.Text = "Şifre";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.Text = "İş Yeri";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(101, 82);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(99, 21);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(101, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(99, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtBranch
            // 
            this.txtBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch.Location = new System.Drawing.Point(101, 136);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(99, 21);
            this.txtBranch.TabIndex = 7;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.Location = new System.Drawing.Point(101, 163);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(100, 21);
            this.chkRememberMe.TabIndex = 9;
            this.chkRememberMe.Text = "Beni Hatırla";
            // 
            // lblbuild
            // 
            this.lblbuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbuild.ForeColor = System.Drawing.Color.Maroon;
            this.lblbuild.Location = new System.Drawing.Point(14, 241);
            this.lblbuild.Name = "lblbuild";
            this.lblbuild.Size = new System.Drawing.Size(211, 25);
            this.lblbuild.Text = "Build:000001";
            this.lblbuild.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = MobileWhouse.GUI.ImageAlignment.Center;
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Empty;
            this.btnSettings.ForeColor = System.Drawing.Color.Empty;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(101, 190);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnSettings.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnSettings.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnSettings.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnSettings.Size = new System.Drawing.Size(37, 27);
            this.btnSettings.TabIndex = 24;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnOkey
            // 
            this.btnOkey.Alignment = MobileWhouse.GUI.ImageAlignment.Right;
            this.btnOkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkey.BackColor = System.Drawing.Color.Empty;
            this.btnOkey.ForeColor = System.Drawing.Color.Empty;
            this.btnOkey.Image = ((System.Drawing.Image)(resources.GetObject("btnOkey.Image")));
            this.btnOkey.Location = new System.Drawing.Point(144, 190);
            this.btnOkey.Name = "btnOkey";
            this.btnOkey.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnOkey.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnOkey.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnOkey.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnOkey.Size = new System.Drawing.Size(81, 27);
            this.btnOkey.TabIndex = 23;
            this.btnOkey.Text = "Giriş";
            this.btnOkey.Click += new System.EventHandler(this.btnOkey_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnCancel.BackColor = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(14, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.NormalTxtColour = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnCancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnCancel.Size = new System.Drawing.Size(81, 27);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // t1
            // 
            this.t1.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1.BackColor = System.Drawing.Color.Empty;
            this.t1.ForeColor = System.Drawing.Color.Empty;
            this.t1.Location = new System.Drawing.Point(200, 81);
            this.t1.Name = "t1";
            this.t1.NormalBtnColour = System.Drawing.Color.Silver;
            this.t1.NormalTxtColour = System.Drawing.Color.Black;
            this.t1.PushedBtnColour = System.Drawing.Color.Blue;
            this.t1.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t1.Size = new System.Drawing.Size(25, 22);
            this.t1.TabIndex = 30;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // t2
            // 
            this.t2.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t2.BackColor = System.Drawing.Color.Empty;
            this.t2.ForeColor = System.Drawing.Color.Empty;
            this.t2.Location = new System.Drawing.Point(200, 109);
            this.t2.Name = "t2";
            this.t2.NormalBtnColour = System.Drawing.Color.Silver;
            this.t2.NormalTxtColour = System.Drawing.Color.Black;
            this.t2.PushedBtnColour = System.Drawing.Color.Blue;
            this.t2.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t2.Size = new System.Drawing.Size(25, 21);
            this.t2.TabIndex = 30;
            this.t2.Text = "T";
            this.t2.Click += new System.EventHandler(this.t2_Click);
            // 
            // t3
            // 
            this.t3.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t3.BackColor = System.Drawing.Color.Empty;
            this.t3.ForeColor = System.Drawing.Color.Empty;
            this.t3.Location = new System.Drawing.Point(200, 136);
            this.t3.Name = "t3";
            this.t3.NormalBtnColour = System.Drawing.Color.Silver;
            this.t3.NormalTxtColour = System.Drawing.Color.Black;
            this.t3.PushedBtnColour = System.Drawing.Color.Blue;
            this.t3.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t3.Size = new System.Drawing.Size(25, 21);
            this.t3.TabIndex = 30;
            this.t3.Text = "T";
            this.t3.Click += new System.EventHandler(this.t3_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnOkey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblbuild);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.Text = "Login To MW";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Label lblbuild;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MobileWhouse.GUI.UButton btnCancel;
        private MobileWhouse.GUI.UButton btnOkey;
        private MobileWhouse.GUI.UButton btnSettings;
        private MobileWhouse.GUI.UButton t1;
        private MobileWhouse.GUI.UButton t2;
        private MobileWhouse.GUI.UButton t3;
    }
}