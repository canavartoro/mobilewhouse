namespace MobileWhouse.Controls.QLT
{
    partial class QLTControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLTControl));
            this.btnCancel = new MobileWhouse.GUI.UButton();
            this.btn = new MobileWhouse.GUI.UButton();
            this.btnkaliteonay = new MobileWhouse.GUI.UButton();
            this.btnbloke = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(3, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.NormalTxtColour = System.Drawing.Color.Black;
            this.btnCancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnCancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnCancel.Size = new System.Drawing.Size(233, 40);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btn
            // 
            this.btn.Alignment = MobileWhouse.GUI.ImageAlignment.Right;
            this.btn.BackColor = System.Drawing.Color.Empty;
            this.btn.ForeColor = System.Drawing.Color.Empty;
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.Location = new System.Drawing.Point(3, 3);
            this.btn.Name = "btn";
            this.btn.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn.NormalTxtColour = System.Drawing.Color.Blue;
            this.btn.PushedBtnColour = System.Drawing.Color.Blue;
            this.btn.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btn.Size = new System.Drawing.Size(233, 41);
            this.btn.TabIndex = 25;
            this.btn.Text = "Kalite Onay";
            // 
            // btnkaliteonay
            // 
            this.btnkaliteonay.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnkaliteonay.BackColor = System.Drawing.Color.Empty;
            this.btnkaliteonay.ForeColor = System.Drawing.Color.Empty;
            this.btnkaliteonay.Location = new System.Drawing.Point(0, 3);
            this.btnkaliteonay.Name = "btnkaliteonay";
            this.btnkaliteonay.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnkaliteonay.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnkaliteonay.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnkaliteonay.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnkaliteonay.Size = new System.Drawing.Size(240, 47);
            this.btnkaliteonay.TabIndex = 25;
            this.btnkaliteonay.Text = "colourButton1";
            // 
            // btnbloke
            // 
            this.btnbloke.Alignment = MobileWhouse.GUI.ImageAlignment.Right;
            this.btnbloke.BackColor = System.Drawing.Color.Empty;
            this.btnbloke.ForeColor = System.Drawing.Color.Empty;
            this.btnbloke.Image = ((System.Drawing.Image)(resources.GetObject("btnbloke.Image")));
            this.btnbloke.Location = new System.Drawing.Point(3, 50);
            this.btnbloke.Name = "btnbloke";
            this.btnbloke.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnbloke.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnbloke.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnbloke.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnbloke.Size = new System.Drawing.Size(233, 41);
            this.btnbloke.TabIndex = 26;
            this.btnbloke.Text = "Kalite Bloke";
            // 
            // QLTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnbloke);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnCancel);
            this.Name = "QLTControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UButton btnCancel;
        private MobileWhouse.GUI.UButton btn;
        private MobileWhouse.GUI.UButton btnkaliteonay;
        private MobileWhouse.GUI.UButton btnbloke;
    }
}
