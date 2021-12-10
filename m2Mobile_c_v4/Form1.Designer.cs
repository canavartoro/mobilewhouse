namespace m2Mobile_c_v4
{
    partial class Frm_Giris
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
            this.Tx_UserCode = new System.Windows.Forms.TextBox();
            this.Lbl_UserCode = new System.Windows.Forms.Label();
            this.Lbl_PassWord = new System.Windows.Forms.Label();
            this.Tx_PassWord = new System.Windows.Forms.TextBox();
            this.Lbl_WorkPlace = new System.Windows.Forms.Label();
            this.Cbo_IsYeri = new System.Windows.Forms.ComboBox();
            this.Cbo_Depo = new System.Windows.Forms.ComboBox();
            this.Lbl_Warehouse = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.img_header = new System.Windows.Forms.PictureBox();
            this.Btn_Settings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tx_UserCode
            // 
            this.Tx_UserCode.Location = new System.Drawing.Point(92, 62);
            this.Tx_UserCode.Name = "Tx_UserCode";
            this.Tx_UserCode.Size = new System.Drawing.Size(131, 21);
            this.Tx_UserCode.TabIndex = 1;
            this.Tx_UserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_UserCode_KeyDown);
            this.Tx_UserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_UserCode_KeyPress);
            // 
            // Lbl_UserCode
            // 
            this.Lbl_UserCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_UserCode.Location = new System.Drawing.Point(13, 62);
            this.Lbl_UserCode.Name = "Lbl_UserCode";
            this.Lbl_UserCode.Size = new System.Drawing.Size(76, 20);
            this.Lbl_UserCode.Text = "Kullanıcı Kodu";
            this.Lbl_UserCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_PassWord
            // 
            this.Lbl_PassWord.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_PassWord.Location = new System.Drawing.Point(13, 90);
            this.Lbl_PassWord.Name = "Lbl_PassWord";
            this.Lbl_PassWord.Size = new System.Drawing.Size(73, 20);
            this.Lbl_PassWord.Text = "Şifre";
            this.Lbl_PassWord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_PassWord.ParentChanged += new System.EventHandler(this.Lbl_PassWord_ParentChanged);
            // 
            // Tx_PassWord
            // 
            this.Tx_PassWord.Location = new System.Drawing.Point(92, 89);
            this.Tx_PassWord.Name = "Tx_PassWord";
            this.Tx_PassWord.PasswordChar = '*';
            this.Tx_PassWord.Size = new System.Drawing.Size(131, 21);
            this.Tx_PassWord.TabIndex = 2;
            this.Tx_PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_PassWord_KeyDown);
            this.Tx_PassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_PassWord_KeyPress);
            this.Tx_PassWord.LostFocus += new System.EventHandler(this.Tx_PassWord_LostFocus);
            // 
            // Lbl_WorkPlace
            // 
            this.Lbl_WorkPlace.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_WorkPlace.Location = new System.Drawing.Point(13, 152);
            this.Lbl_WorkPlace.Name = "Lbl_WorkPlace";
            this.Lbl_WorkPlace.Size = new System.Drawing.Size(74, 20);
            this.Lbl_WorkPlace.Text = "İşyeri Kodu";
            this.Lbl_WorkPlace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Cbo_IsYeri
            // 
            this.Cbo_IsYeri.Enabled = false;
            this.Cbo_IsYeri.Location = new System.Drawing.Point(92, 150);
            this.Cbo_IsYeri.Name = "Cbo_IsYeri";
            this.Cbo_IsYeri.Size = new System.Drawing.Size(131, 22);
            this.Cbo_IsYeri.TabIndex = 4;
            this.Cbo_IsYeri.SelectedIndexChanged += new System.EventHandler(this.Cbo_IsYeri_SelectedIndexChanged);
            // 
            // Cbo_Depo
            // 
            this.Cbo_Depo.Enabled = false;
            this.Cbo_Depo.Location = new System.Drawing.Point(92, 178);
            this.Cbo_Depo.Name = "Cbo_Depo";
            this.Cbo_Depo.Size = new System.Drawing.Size(131, 22);
            this.Cbo_Depo.TabIndex = 5;
            this.Cbo_Depo.SelectedIndexChanged += new System.EventHandler(this.Cbo_Depo_SelectedIndexChanged);
            // 
            // Lbl_Warehouse
            // 
            this.Lbl_Warehouse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_Warehouse.Location = new System.Drawing.Point(13, 180);
            this.Lbl_Warehouse.Name = "Lbl_Warehouse";
            this.Lbl_Warehouse.Size = new System.Drawing.Size(74, 20);
            this.Lbl_Warehouse.Text = "Depo Kodu";
            this.Lbl_Warehouse.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Enabled = false;
            this.Btn_Ok.Location = new System.Drawing.Point(13, 252);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(96, 30);
            this.Btn_Ok.TabIndex = 6;
            this.Btn_Ok.Text = "Tamam";
            this.Btn_Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(127, 252);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(96, 30);
            this.Btn_Cancel.TabIndex = 7;
            this.Btn_Cancel.Text = "İptal";
            this.Btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // img_header
            // 
            this.img_header.Location = new System.Drawing.Point(13, 3);
            this.img_header.Name = "img_header";
            this.img_header.Size = new System.Drawing.Size(210, 53);
            // 
            // Btn_Settings
            // 
            this.Btn_Settings.Location = new System.Drawing.Point(127, 209);
            this.Btn_Settings.Name = "Btn_Settings";
            this.Btn_Settings.Size = new System.Drawing.Size(96, 31);
            this.Btn_Settings.TabIndex = 8;
            this.Btn_Settings.Text = "Ayarlar";
            this.Btn_Settings.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tamam";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Frm_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Settings);
            this.Controls.Add(this.img_header);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Cbo_Depo);
            this.Controls.Add(this.Lbl_Warehouse);
            this.Controls.Add(this.Cbo_IsYeri);
            this.Controls.Add(this.Lbl_WorkPlace);
            this.Controls.Add(this.Lbl_PassWord);
            this.Controls.Add(this.Tx_PassWord);
            this.Controls.Add(this.Lbl_UserCode);
            this.Controls.Add(this.Tx_UserCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Giris";
            this.Text = "Kullanıcı Giriş";
            this.Load += new System.EventHandler(this.Frm_Giris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Tx_UserCode;
        private System.Windows.Forms.Label Lbl_UserCode;
        private System.Windows.Forms.Label Lbl_PassWord;
        private System.Windows.Forms.TextBox Tx_PassWord;
        private System.Windows.Forms.Label Lbl_WorkPlace;
        private System.Windows.Forms.ComboBox Cbo_IsYeri;
        private System.Windows.Forms.ComboBox Cbo_Depo;
        private System.Windows.Forms.Label Lbl_Warehouse;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.PictureBox img_header;
        private System.Windows.Forms.Button Btn_Settings;
        private System.Windows.Forms.Button button1;
    }
}

