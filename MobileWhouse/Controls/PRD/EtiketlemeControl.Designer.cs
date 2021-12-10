namespace MobileWhouse.Controls.PRD
{
    partial class EtiketlemeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EtiketlemeControl));
            this.label1 = new System.Windows.Forms.Label();
            this.txtistasyon = new System.Windows.Forms.TextBox();
            this.btnistasyon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.txtkoliici = new MobileWhouse.GUI.TextBoxNumeric();
            this.txtadet = new MobileWhouse.GUI.TextBoxNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.printetiketleme = new MobileWhouse.GUI.PrintControl();
            this.btnyazdir = new MobileWhouse.GUI.ColourButton();
            this.btnCancel = new MobileWhouse.GUI.ColourButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "İstasyon Kod";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Location = new System.Drawing.Point(82, 4);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.Size = new System.Drawing.Size(116, 21);
            this.txtistasyon.TabIndex = 3;
            // 
            // btnistasyon
            // 
            this.btnistasyon.Location = new System.Drawing.Point(199, 4);
            this.btnistasyon.Name = "btnistasyon";
            this.btnistasyon.Size = new System.Drawing.Size(37, 20);
            this.btnistasyon.TabIndex = 4;
            this.btnistasyon.Text = "...";
            this.btnistasyon.Click += new System.EventHandler(this.btnistasyon_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "İş Emri No";
            // 
            // txtisemri
            // 
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(82, 28);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(154, 21);
            this.txtisemri.TabIndex = 3;
            this.txtisemri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // txtkoliici
            // 
            this.txtkoliici.AllowSpace = false;
            this.txtkoliici.BackColor = System.Drawing.Color.SkyBlue;
            this.txtkoliici.Location = new System.Drawing.Point(82, 52);
            this.txtkoliici.Name = "txtkoliici";
            this.txtkoliici.Size = new System.Drawing.Size(63, 21);
            this.txtkoliici.TabIndex = 7;
            this.txtkoliici.Text = "1";
            // 
            // txtadet
            // 
            this.txtadet.AllowSpace = false;
            this.txtadet.BackColor = System.Drawing.Color.SkyBlue;
            this.txtadet.Location = new System.Drawing.Point(82, 78);
            this.txtadet.Name = "txtadet";
            this.txtadet.Size = new System.Drawing.Size(63, 21);
            this.txtadet.TabIndex = 7;
            this.txtadet.Text = "1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Koli İçi Adet";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.Text = "Adet";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.Text = "Adet";
            // 
            // txtbarkod
            // 
            this.txtbarkod.BackColor = System.Drawing.SystemColors.Control;
            this.txtbarkod.Location = new System.Drawing.Point(82, 101);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(154, 21);
            this.txtbarkod.TabIndex = 3;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // printetiketleme
            // 
            this.printetiketleme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printetiketleme.Location = new System.Drawing.Point(3, 128);
            this.printetiketleme.Name = "printetiketleme";
            this.printetiketleme.Size = new System.Drawing.Size(233, 41);
            this.printetiketleme.TabIndex = 16;
            // 
            // btnyazdir
            // 
            this.btnyazdir.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnyazdir.BackColor = System.Drawing.Color.Empty;
            this.btnyazdir.ForeColor = System.Drawing.Color.Empty;
            this.btnyazdir.Location = new System.Drawing.Point(151, 78);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnyazdir.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnyazdir.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnyazdir.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnyazdir.Size = new System.Drawing.Size(85, 20);
            this.btnyazdir.TabIndex = 22;
            this.btnyazdir.Text = "Yazdır";
            this.btnyazdir.Click += new System.EventHandler(this.btnyazdir_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnCancel.BackColor = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(3, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.NormalTxtColour = System.Drawing.Color.Black;
            this.btnCancel.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnCancel.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnCancel.Size = new System.Drawing.Size(233, 40);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // EtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.printetiketleme);
            this.Controls.Add(this.txtadet);
            this.Controls.Add(this.txtkoliici);
            this.Controls.Add(this.btnistasyon);
            this.Controls.Add(this.txtbarkod);
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtistasyon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnyazdir);
            this.Name = "EtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtistasyon;
        private System.Windows.Forms.Button btnistasyon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtisemri;
        private MobileWhouse.GUI.TextBoxNumeric txtkoliici;
        private MobileWhouse.GUI.TextBoxNumeric txtadet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbarkod;
        private MobileWhouse.GUI.PrintControl printetiketleme;
        private MobileWhouse.GUI.ColourButton btnyazdir;
        private MobileWhouse.GUI.ColourButton btnCancel;
    }
}
