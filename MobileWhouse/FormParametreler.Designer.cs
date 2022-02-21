namespace MobileWhouse
{
    partial class FormParametreler
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.secblokehareket = new MobileWhouse.GUI.ULookupEdit();
            this.secblokedepo = new MobileWhouse.GUI.ULookupEdit();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 257);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 234);
            this.tabPage1.Text = "Genel";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.secblokehareket);
            this.tabPage2.Controls.Add(this.secblokedepo);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 234);
            this.tabPage2.Text = "Kalite";
            // 
            // secblokehareket
            // 
            this.secblokehareket.DataFieldName = "";
            this.secblokehareket.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.secblokehareket.Description = "";
            this.secblokehareket.FilterCondition = "";
            this.secblokehareket.LabelText = "Bloke Hareket";
            this.secblokehareket.LabelWidth = 80;
            this.secblokehareket.Location = new System.Drawing.Point(2, 35);
            this.secblokehareket.Name = "secblokehareket";
            this.secblokehareket.RememberValue = false;
            this.secblokehareket.ShowDescription = false;
            this.secblokehareket.ShowLabelText = false;
            this.secblokehareket.Size = new System.Drawing.Size(238, 27);
            this.secblokehareket.SourceApplication = 212;
            this.secblokehareket.TabIndex = 1;
            // 
            // secblokedepo
            // 
            this.secblokedepo.DataFieldName = "";
            this.secblokedepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.secblokedepo.Description = "";
            this.secblokedepo.FilterCondition = "";
            this.secblokedepo.LabelText = "Bloke Depo";
            this.secblokedepo.LabelWidth = 80;
            this.secblokedepo.Location = new System.Drawing.Point(2, 2);
            this.secblokedepo.Name = "secblokedepo";
            this.secblokedepo.RememberValue = false;
            this.secblokedepo.ShowDescription = false;
            this.secblokedepo.ShowLabelText = false;
            this.secblokedepo.Size = new System.Drawing.Size(238, 27);
            this.secblokedepo.SourceApplication = 0;
            this.secblokedepo.TabIndex = 0;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.Empty;
            this.btnkaydet.ForeColor = System.Drawing.Color.Empty;
            this.btnkaydet.Location = new System.Drawing.Point(121, 258);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(117, 33);
            this.btnkaydet.TabIndex = 21;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.BackColor = System.Drawing.Color.Empty;
            this.btnkapat.ForeColor = System.Drawing.Color.Empty;
            this.btnkapat.Location = new System.Drawing.Point(3, 258);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(112, 33);
            this.btnkapat.TabIndex = 20;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // FormParametreler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.btnkapat);
            this.Name = "FormParametreler";
            this.Text = "Parametreler";
            this.Load += new System.EventHandler(this.FormParametreler_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MobileWhouse.GUI.ULookupEdit secblokedepo;
        private MobileWhouse.GUI.ULookupEdit secblokehareket;

    }
}