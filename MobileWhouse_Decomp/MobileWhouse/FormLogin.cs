namespace MobileWhouse
{
    using MobileWhouse.Properties;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormLogin : Form
    {
        private Button btnCancel;
        private Button btnKapat;
        private Button btnOkey;
        private Button btnSettings;
        private CheckBox chkRememberMe;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBranch;
        private TextBox txtPassword;
        private TextBox txtUsername;

        public FormLogin()
        {
            this.InitializeComponent();
            this.chkRememberMe.Checked = Settings.Default.RememberMe;
            if (Settings.Default.RememberMe)
            {
                this.txtUsername.Text = Settings.Default.LastUsername;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.txtUsername.Text.Trim();
                string str2 = this.txtPassword.Text.Trim();
                string str3 = this.txtBranch.Text.Trim();
                if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str3))
                {
                    throw new Exception("Kullanıcı Adı ve İş Yeri Girmek Mecburidir!...");
                }
                ServiceRequestOfToken token = new ServiceRequestOfToken {
                    Value = new Token()
                };
                token.Value.BranchCode = str3;
                token.Value.Password = str2;
                token.Value.UserName = str;
                ServiceResultOfLoginResult result = ClientApplication.Instance.Service.Login(token);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }
                ClientApplication.Instance.ClientToken = result.Value;
                token.Value.BranchId = result.Value.BranchId;
                token.Value.CoId = result.Value.CoId;
                token.Value.BranchDesc = result.Value.BranchDesc;
                ClientApplication.Instance.Token = token.Value;
                base.DialogResult = DialogResult.OK;
                base.Close();
                Settings.Default.RememberMe = this.chkRememberMe.Checked;
                if (Settings.Default.RememberMe)
                {
                    Settings.Default.BranchCode = str3;
                    Settings.Default.LastUsername = str;
                }
                Settings.Default.Save();
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormAyarlar ayarlar = new FormAyarlar())
            {
                ayarlar.ShowDialog();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtBranch = new TextBox();
            this.btnOkey = new Button();
            this.chkRememberMe = new CheckBox();
            this.btnCancel = new Button();
            this.btnSettings = new Button();
            this.btnKapat = new Button();
            base.SuspendLayout();
            this.label1.Location = new Point(14, 0x2b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x51, 15);
            this.label1.Text = "Kullanıcı Adı";
            this.label2.Location = new Point(14, 70);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x51, 15);
            this.label2.Text = "Şifre";
            this.label3.Location = new Point(14, 0x60);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x51, 15);
            this.label3.Text = "İş Yeri";
            this.txtUsername.Location = new Point(0x65, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(0x7c, 0x15);
            this.txtUsername.TabIndex = 5;
            this.txtPassword.Location = new Point(0x65, 0x43);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(0x7c, 0x15);
            this.txtPassword.TabIndex = 6;
            this.txtBranch.Location = new Point(0x65, 0x5e);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new Size(0x7c, 0x15);
            this.txtBranch.TabIndex = 7;
            this.btnOkey.Location = new Point(0x65, 0x94);
            this.btnOkey.Name = "btnOkey";
            this.btnOkey.Size = new Size(0x3b, 20);
            this.btnOkey.TabIndex = 8;
            this.btnOkey.Text = "Giriş";
            this.btnOkey.Click += new EventHandler(this.btnOkey_Click);
            this.chkRememberMe.Location = new Point(0x65, 0x79);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new Size(100, 0x15);
            this.chkRememberMe.TabIndex = 9;
            this.chkRememberMe.Text = "Beni Hatırla";
            this.btnCancel.Location = new Point(0xa6, 0x94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x3b, 20);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnSettings.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnSettings.Location = new Point(14, 0xfe);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new Size(0x3b, 20);
            this.btnSettings.TabIndex = 14;
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
            this.btnKapat.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnKapat.Location = new Point(0x58, 0xfe);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(0x3b, 20);
            this.btnKapat.TabIndex = 0x12;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.Controls.Add(this.btnKapat);
            base.Controls.Add(this.btnSettings);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.chkRememberMe);
            base.Controls.Add(this.btnOkey);
            base.Controls.Add(this.txtBranch);
            base.Controls.Add(this.txtPassword);
            base.Controls.Add(this.txtUsername);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "FormLogin";
            this.Text = "Login To MW";
            base.ResumeLayout(false);
        }
    }
}

