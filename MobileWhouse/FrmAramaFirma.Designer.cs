namespace MobileWhouse
{
    partial class FrmAramaFirma
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
            this.GridSearch = new System.Windows.Forms.DataGrid();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_FirmaAd = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridSearch
            // 
            this.GridSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GridSearch.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.GridSearch.Location = new System.Drawing.Point(0, 28);
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.PreferredRowHeight = 13;
            this.GridSearch.Size = new System.Drawing.Size(240, 246);
            this.GridSearch.TabIndex = 0;
            this.GridSearch.DoubleClick += new System.EventHandler(this.GridSearch_DoubleClick);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(3, 3);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(82, 33);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "Tamam";
            this.Btn_Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(160, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(77, 33);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Vazgeç";
            this.Btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCount);
            this.panel1.Controls.Add(this.Btn_Ok);
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 40);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Tx_FirmaAd);
            this.panel2.Controls.Add(this.GridSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 280);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 22);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ara";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.Text = "Adı";
            // 
            // Tx_FirmaAd
            // 
            this.Tx_FirmaAd.Location = new System.Drawing.Point(28, 1);
            this.Tx_FirmaAd.Name = "Tx_FirmaAd";
            this.Tx_FirmaAd.Size = new System.Drawing.Size(143, 25);
            this.Tx_FirmaAd.TabIndex = 1;
            // 
            // labelCount
            // 
            this.labelCount.Location = new System.Drawing.Point(91, 8);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(63, 20);
            // 
            // FrmAramaFirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "FrmAramaFirma";
            this.Text = "Firma Arama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmArama_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid GridSearch;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Tx_FirmaAd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCount;
    }
}