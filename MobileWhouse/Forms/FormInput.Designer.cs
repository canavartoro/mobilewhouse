namespace MobileWhouse.Forms
{
    partial class FormInput
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnkaydet = new MobileWhouse.GUI.UButton();
            this.btnkapat = new MobileWhouse.GUI.UButton();
            this.t1 = new System.Windows.Forms.Button();
            this.textNum = new MobileWhouse.GUI.TextBoxNumeric();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 21);
            this.label1.Text = "Giriş Yapınız";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(5, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.Empty;
            this.btnkaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnkaydet.Location = new System.Drawing.Point(123, 124);
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
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.BackColor = System.Drawing.Color.Empty;
            this.btnkapat.ForeColor = System.Drawing.Color.Empty;
            this.btnkapat.Location = new System.Drawing.Point(5, 124);
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
            // t1
            // 
            this.t1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1.Location = new System.Drawing.Point(215, 35);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(25, 21);
            this.t1.TabIndex = 3;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // textNum
            // 
            this.textNum.AllowSpace = false;
            this.textNum.BackColor = System.Drawing.Color.LightCyan;
            this.textNum.Location = new System.Drawing.Point(5, 35);
            this.textNum.Name = "textNum";
            this.textNum.Size = new System.Drawing.Size(210, 21);
            this.textNum.TabIndex = 6;
            this.textNum.Text = "1";
            this.textNum.Visible = false;
            this.textNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNum_KeyPress);
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 160);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.textNum);
            this.Name = "FormInput";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.FormInput_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton btnkaydet;
        private MobileWhouse.GUI.UButton btnkapat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button t1;
        private MobileWhouse.GUI.TextBoxNumeric textNum;
    }
}