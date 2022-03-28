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
            this.label2 = new System.Windows.Forms.Label();
            this.txtisemri = new System.Windows.Forms.TextBox();
            this.txtkoliici = new MobileWhouse.GUI.TextBoxNumeric();
            this.txtadet = new MobileWhouse.GUI.TextBoxNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.btnyazdir = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.printKLetiketleme = new MobileWhouse.GUI.UPrintControl();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "İş Emri No";
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.BackColor = System.Drawing.SystemColors.Control;
            this.txtisemri.Location = new System.Drawing.Point(82, 30);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.Size = new System.Drawing.Size(154, 21);
            this.txtisemri.TabIndex = 3;
            this.txtisemri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // txtkoliici
            // 
            this.txtkoliici.AllowSpace = false;
            this.txtkoliici.BackColor = System.Drawing.Color.SkyBlue;
            this.txtkoliici.Location = new System.Drawing.Point(82, 54);
            this.txtkoliici.Name = "txtkoliici";
            this.txtkoliici.Size = new System.Drawing.Size(63, 21);
            this.txtkoliici.TabIndex = 7;
            this.txtkoliici.Text = "1";
            // 
            // txtadet
            // 
            this.txtadet.AllowSpace = false;
            this.txtadet.BackColor = System.Drawing.Color.SkyBlue;
            this.txtadet.Location = new System.Drawing.Point(82, 80);
            this.txtadet.Name = "txtadet";
            this.txtadet.Size = new System.Drawing.Size(63, 21);
            this.txtadet.TabIndex = 7;
            this.txtadet.Text = "1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Koli İçi Adet";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.Text = "Adet";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.Text = "Barkod";
            // 
            // txtbarkod
            // 
            this.txtbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbarkod.BackColor = System.Drawing.SystemColors.Control;
            this.txtbarkod.Location = new System.Drawing.Point(82, 103);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(154, 21);
            this.txtbarkod.TabIndex = 3;
            this.txtbarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtisemri_KeyPress);
            // 
            // btnyazdir
            // 
            this.btnyazdir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnyazdir.Location = new System.Drawing.Point(151, 80);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.Size = new System.Drawing.Size(85, 20);
            this.btnyazdir.TabIndex = 22;
            this.btnyazdir.Text = "Yazdır";
            this.btnyazdir.Click += new System.EventHandler(this.btnyazdir_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(3, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 40);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // printKLetiketleme
            // 
            this.printKLetiketleme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printKLetiketleme.Location = new System.Drawing.Point(3, 130);
            this.printKLetiketleme.Name = "printKLetiketleme";
            this.printKLetiketleme.Size = new System.Drawing.Size(233, 75);
            this.printKLetiketleme.TabIndex = 29;
            // 
            // txtistasyon
            // 
            this.txtistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtistasyon.Browsable = false;
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 77;
            this.txtistasyon.Location = new System.Drawing.Point(3, 0);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.PurchaseSales = -1;
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(233, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 34;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // EtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtisemri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.printKLetiketleme);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtadet);
            this.Controls.Add(this.txtkoliici);
            this.Controls.Add(this.txtbarkod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnyazdir);
            this.Controls.Add(this.txtistasyon);
            this.Name = "EtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.OnLoad += new System.EventHandler(this.EtiketlemeControl_OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtisemri;
        private MobileWhouse.GUI.TextBoxNumeric txtkoliici;
        private MobileWhouse.GUI.TextBoxNumeric txtadet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbarkod;
        private System.Windows.Forms.Button btnyazdir;
        private System.Windows.Forms.Button btnCancel;
        private MobileWhouse.GUI.UPrintControl printKLetiketleme;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
    }
}
