namespace MobileWhouse.Controls.PRD
{
    partial class EtiketOnayControl
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
            this.secistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtadet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnbarkod = new System.Windows.Forms.Button();
            this.textbarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textStok = new System.Windows.Forms.TextBox();
            this.btnkapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secistasyon
            // 
            this.secistasyon.DataFieldName = "";
            this.secistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.secistasyon.Description = "";
            this.secistasyon.FilterCondition = "";
            this.secistasyon.LabelText = "İstasyon";
            this.secistasyon.LabelWidth = 70;
            this.secistasyon.Location = new System.Drawing.Point(0, 1);
            this.secistasyon.Name = "secistasyon";
            this.secistasyon.RememberValue = false;
            this.secistasyon.ShowDescription = false;
            this.secistasyon.ShowLabelText = false;
            this.secistasyon.Size = new System.Drawing.Size(240, 27);
            this.secistasyon.SourceApplication = 0;
            this.secistasyon.TabIndex = 0;
            this.secistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.secistasyon_OnSelected);
            // 
            // txtisemri
            // 
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(70, 28);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(170, 21);
            this.txtisemri.TabIndex = 5;
            this.txtisemri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "İş Emri No";
            // 
            // txtadet
            // 
            this.txtadet.BackColor = System.Drawing.SystemColors.Control;
            this.txtadet.Location = new System.Drawing.Point(70, 52);
            this.txtadet.Name = "txtadet";
            this.txtadet.Size = new System.Drawing.Size(89, 21);
            this.txtadet.TabIndex = 8;
            this.txtadet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.Text = "Adet";
            // 
            // btnbarkod
            // 
            this.btnbarkod.Location = new System.Drawing.Point(208, 76);
            this.btnbarkod.Name = "btnbarkod";
            this.btnbarkod.Size = new System.Drawing.Size(32, 20);
            this.btnbarkod.TabIndex = 74;
            this.btnbarkod.Text = "...";
            // 
            // textbarkod
            // 
            this.textbarkod.BackColor = System.Drawing.Color.Linen;
            this.textbarkod.Location = new System.Drawing.Point(70, 76);
            this.textbarkod.Name = "textbarkod";
            this.textbarkod.Size = new System.Drawing.Size(139, 21);
            this.textbarkod.TabIndex = 73;
            this.textbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbarkod_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.Text = "Barkod";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.Text = "Stok Kodu";
            // 
            // textStok
            // 
            this.textStok.BackColor = System.Drawing.SystemColors.Control;
            this.textStok.Location = new System.Drawing.Point(70, 101);
            this.textStok.Name = "textStok";
            this.textStok.Size = new System.Drawing.Size(170, 21);
            this.textStok.TabIndex = 5;
            this.textStok.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkapat.Location = new System.Drawing.Point(3, 275);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(234, 42);
            this.btnkapat.TabIndex = 79;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // EtiketOnayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnbarkod);
            this.Controls.Add(this.textbarkod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtadet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textStok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secistasyon);
            this.Name = "EtiketOnayControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.ULookupEdit secistasyon;
        private System.Windows.Forms.TextBox txtisemri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtadet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnbarkod;
        private System.Windows.Forms.TextBox textbarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textStok;
        private System.Windows.Forms.Button btnkapat;
    }
}
