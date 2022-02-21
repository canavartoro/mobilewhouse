namespace MobileWhouse.GUI
{
    partial class ULookupEdit
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
            this.labelkod = new System.Windows.Forms.Label();
            this.textkod = new System.Windows.Forms.TextBox();
            this.labeldesc = new System.Windows.Forms.Label();
            this.textdesc = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.btnk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelkod
            // 
            this.labelkod.Location = new System.Drawing.Point(0, 1);
            this.labelkod.Name = "labelkod";
            this.labelkod.Size = new System.Drawing.Size(70, 25);
            this.labelkod.Text = "Kod";
            // 
            // textkod
            // 
            this.textkod.BackColor = System.Drawing.Color.Yellow;
            this.textkod.Location = new System.Drawing.Point(70, 2);
            this.textkod.Name = "textkod";
            this.textkod.Size = new System.Drawing.Size(120, 21);
            this.textkod.TabIndex = 2;
            this.textkod.GotFocus += new System.EventHandler(this.textkod_GotFocus);
            this.textkod.ParentChanged += new System.EventHandler(this.textkod_ParentChanged);
            this.textkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textkod_KeyPress);
            this.textkod.LostFocus += new System.EventHandler(this.textkod_LostFocus);
            // 
            // labeldesc
            // 
            this.labeldesc.Location = new System.Drawing.Point(0, 26);
            this.labeldesc.Name = "labeldesc";
            this.labeldesc.Size = new System.Drawing.Size(70, 20);
            this.labeldesc.Text = "Ad";
            this.labeldesc.Visible = false;
            // 
            // textdesc
            // 
            this.textdesc.Location = new System.Drawing.Point(70, 26);
            this.textdesc.Name = "textdesc";
            this.textdesc.Size = new System.Drawing.Size(167, 21);
            this.textdesc.TabIndex = 5;
            this.textdesc.Visible = false;
            this.textdesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textdesc_KeyPress);
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.Location = new System.Drawing.Point(185, 1);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(25, 22);
            this.btn.TabIndex = 8;
            this.btn.Text = "...";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnk
            // 
            this.btnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnk.Location = new System.Drawing.Point(211, 1);
            this.btnk.Name = "btnk";
            this.btnk.Size = new System.Drawing.Size(24, 22);
            this.btnk.TabIndex = 11;
            this.btnk.Text = "T";
            this.btnk.Click += new System.EventHandler(this.btnk_Click);
            // 
            // ULookupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn);
            this.Controls.Add(this.textdesc);
            this.Controls.Add(this.labeldesc);
            this.Controls.Add(this.textkod);
            this.Controls.Add(this.labelkod);
            this.Controls.Add(this.btnk);
            this.Name = "ULookupEdit";
            this.Size = new System.Drawing.Size(235, 49);
            this.Click += new System.EventHandler(this.MTALookupEdit_Click);
            this.ParentChanged += new System.EventHandler(this.ULookupEdit_ParentChanged);
            this.Resize += new System.EventHandler(this.MTALookupEdit_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelkod;
        private System.Windows.Forms.TextBox textkod;
        private System.Windows.Forms.Label labeldesc;
        private System.Windows.Forms.TextBox textdesc;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnk;

    }
}
