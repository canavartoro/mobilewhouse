namespace MobileWhouse.Controls.PRD
{
    partial class IsEmriControl
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
            this.txtisemri = new MobileWhouse.GUI.ULookupEdit();
            this.btnKapat = new MobileWhouse.GUI.UButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtisemri
            // 
            this.txtisemri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtisemri.Browsable = false;
            this.txtisemri.DataFieldName = "";
            this.txtisemri.DataType = MobileWhouse.Enums.DataSourceType.IsEmri;
            this.txtisemri.Description = "";
            this.txtisemri.FilterCondition = "";
            this.txtisemri.LabelText = "İş Emri";
            this.txtisemri.LabelWidth = 60;
            this.txtisemri.Location = new System.Drawing.Point(4, 4);
            this.txtisemri.Name = "txtisemri";
            this.txtisemri.PurchaseSales = -1;
            this.txtisemri.RememberValue = false;
            this.txtisemri.ShowDescription = false;
            this.txtisemri.ShowLabelText = false;
            this.txtisemri.Size = new System.Drawing.Size(233, 27);
            this.txtisemri.SourceApplication = 0;
            this.txtisemri.TabIndex = 24;
            this.txtisemri.OnSelected += new MobileWhouse.OnSelectedObject(this.txtisemri_OnSelected);
            // 
            // btnKapat
            // 
            this.btnKapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.Empty;
            this.btnKapat.ForeColor = System.Drawing.Color.Empty;
            this.btnKapat.Location = new System.Drawing.Point(3, 278);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKapat.Size = new System.Drawing.Size(234, 39);
            this.btnKapat.TabIndex = 25;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Location = new System.Drawing.Point(4, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 240);
            this.listBox1.TabIndex = 26;
            // 
            // IsEmriControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.txtisemri);
            this.Name = "IsEmriControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.ULookupEdit txtisemri;
        private MobileWhouse.GUI.UButton btnKapat;
        private System.Windows.Forms.ListBox listBox1;
    }
}
