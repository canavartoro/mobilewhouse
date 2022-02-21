namespace MobileWhouse.Dilogs
{
    partial class FormEmployeeLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboperator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPassw = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnkaydet = new MobileWhouse.GUI.UButton();
            this.btnkapat = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.Text = "Operatör";
            // 
            // cmboperator
            // 
            this.cmboperator.Location = new System.Drawing.Point(89, 7);
            this.cmboperator.Name = "cmboperator";
            this.cmboperator.Size = new System.Drawing.Size(148, 22);
            this.cmboperator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "Parola";
            // 
            // textPassw
            // 
            this.textPassw.Location = new System.Drawing.Point(89, 40);
            this.textPassw.Name = "textPassw";
            this.textPassw.PasswordChar = '*';
            this.textPassw.Size = new System.Drawing.Size(124, 21);
            this.textPassw.TabIndex = 0;
            this.textPassw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassw_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "T";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.Empty;
            this.btnkaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnkaydet.Location = new System.Drawing.Point(123, 115);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnkaydet.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnkaydet.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnkaydet.Size = new System.Drawing.Size(117, 33);
            this.btnkaydet.TabIndex = 1;
            this.btnkaydet.Text = "Tamam";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnkapat.BackColor = System.Drawing.Color.Empty;
            this.btnkapat.ForeColor = System.Drawing.Color.Empty;
            this.btnkapat.Location = new System.Drawing.Point(2, 115);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnkapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnkapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnkapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnkapat.Size = new System.Drawing.Size(112, 33);
            this.btnkapat.TabIndex = 2;
            this.btnkapat.Text = "İptal";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // FormEmployeeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 160);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPassw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboperator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.btnkapat);
            this.MinimizeBox = false;
            this.Name = "FormEmployeeLogin";
            this.Text = "Operatör Girişi";
            this.Load += new System.EventHandler(this.FormEmployeeLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton btnkaydet;
        private MobileWhouse.GUI.UButton btnkapat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboperator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPassw;
        private System.Windows.Forms.Button button1;
    }
}