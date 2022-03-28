namespace MobileWhouse.Dilogs
{
    partial class FormPartiInput
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
            this.btncancel = new MobileWhouse.GUI.UButton();
            this.btnok = new MobileWhouse.GUI.UButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.t2 = new System.Windows.Forms.Button();
            this.textMiktar = new MobileWhouse.GUI.TextBoxNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancel
            // 
            this.btncancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncancel.BackColor = System.Drawing.Color.Empty;
            this.btncancel.ForeColor = System.Drawing.Color.Empty;
            this.btncancel.Location = new System.Drawing.Point(4, 83);
            this.btncancel.Name = "btncancel";
            this.btncancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btncancel.NormalTxtColour = System.Drawing.Color.Black;
            this.btncancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btncancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btncancel.Size = new System.Drawing.Size(69, 27);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "VAZGEÇ";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnok
            // 
            this.btnok.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnok.BackColor = System.Drawing.Color.Empty;
            this.btnok.ForeColor = System.Drawing.Color.Empty;
            this.btnok.Location = new System.Drawing.Point(168, 83);
            this.btnok.Name = "btnok";
            this.btnok.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnok.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnok.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnok.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnok.Size = new System.Drawing.Size(69, 27);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "TAMAM";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.Text = "Parti kodu girin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 21);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(215, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "T";
            // 
            // t2
            // 
            this.t2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t2.Location = new System.Drawing.Point(215, 56);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(22, 21);
            this.t2.TabIndex = 17;
            this.t2.Text = "T";
            // 
            // textMiktar
            // 
            this.textMiktar.AllowSpace = false;
            this.textMiktar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textMiktar.BackColor = System.Drawing.Color.LightCyan;
            this.textMiktar.Location = new System.Drawing.Point(129, 56);
            this.textMiktar.Name = "textMiktar";
            this.textMiktar.Size = new System.Drawing.Size(85, 21);
            this.textMiktar.TabIndex = 16;
            this.textMiktar.Text = "1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.Text = "Parti Miktar";
            // 
            // FormPartiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 135);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.textMiktar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Name = "FormPartiInput";
            this.Text = "Parti Kodu Girişi";
            this.Load += new System.EventHandler(this.FormPartiInput_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton btncancel;
        private MobileWhouse.GUI.UButton btnok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button t2;
        private MobileWhouse.GUI.TextBoxNumeric textMiktar;
        private System.Windows.Forms.Label label5;
    }
}