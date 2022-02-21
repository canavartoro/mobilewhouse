namespace MobileWhouse.GUI
{
    partial class UPrintControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDesign = new System.Windows.Forms.ComboBox();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.Text = "Tasarım Adı";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.Text = "Yazıcı Adı";
            // 
            // cmbDesign
            // 
            this.cmbDesign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDesign.Location = new System.Drawing.Point(83, 4);
            this.cmbDesign.Name = "cmbDesign";
            this.cmbDesign.Size = new System.Drawing.Size(155, 22);
            this.cmbDesign.TabIndex = 3;
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrinter.Location = new System.Drawing.Point(83, 26);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(155, 22);
            this.cmbPrinter.TabIndex = 4;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(3, 50);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(79, 20);
            this.btnrefresh.TabIndex = 5;
            this.btnrefresh.Text = "Yenile";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // UPrintControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.cmbDesign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UPrintControl";
            this.Size = new System.Drawing.Size(240, 74);
            this.ParentChanged += new System.EventHandler(this.UPrintControl_ParentChanged);
            this.ResumeLayout(false);

        }

       


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDesign;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Button btnrefresh;

    }
}
