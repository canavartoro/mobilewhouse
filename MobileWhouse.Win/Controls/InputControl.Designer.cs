namespace MobileWhouse.Controls
{
    partial class InputControl
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
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncancel.Location = new System.Drawing.Point(3, 265);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(69, 47);
            this.btncancel.TabIndex = 22;
            this.btncancel.Text = "KAPAT";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsend
            // 
            this.btnsend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsend.Location = new System.Drawing.Point(165, 265);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(72, 47);
            this.btnsend.TabIndex = 21;
            this.btnsend.Text = "GÖNDER";
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(3, 23);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.text.Size = new System.Drawing.Size(234, 226);
            this.text.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Not Defteri";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnac
            // 
            this.btnac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnac.Location = new System.Drawing.Point(89, 265);
            this.btnac.Name = "btnac";
            this.btnac.Size = new System.Drawing.Size(56, 47);
            this.btnac.TabIndex = 24;
            this.btnac.Text = "...";
            this.btnac.Click += new System.EventHandler(this.btnac_Click);
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.btnac);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnac;
    }
}
