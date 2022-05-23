namespace MobileWhouse
{
    partial class FrmArama
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
            this.Lbl_Current = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.Tx_Entity = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridSearch
            // 
            this.GridSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GridSearch.Location = new System.Drawing.Point(0, 22);
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.PreferredRowHeight = 13;
            this.GridSearch.Size = new System.Drawing.Size(240, 258);
            this.GridSearch.TabIndex = 0;
            this.GridSearch.DoubleClick += new System.EventHandler(this.GridSearch_DoubleClick);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(3, 3);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(102, 33);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "Tamam";
            this.Btn_Ok.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(135, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(102, 33);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Vazgeç";
            this.Btn_Cancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Ok);
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 40);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lbl_Current);
            this.panel2.Controls.Add(this.btnAra);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.Tx_Entity);
            this.panel2.Controls.Add(this.GridSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 280);
            // 
            // Lbl_Current
            // 
            this.Lbl_Current.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_Current.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Current.Location = new System.Drawing.Point(2, 2);
            this.Lbl_Current.Name = "Lbl_Current";
            this.Lbl_Current.Size = new System.Drawing.Size(34, 17);
            this.Lbl_Current.Text = "Cari Ad";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(188, 2);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(49, 18);
            this.btnAra.TabIndex = 35;
            this.btnAra.Text = "Ara";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click_1);
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.btnCari.Location = new System.Drawing.Point(161, 2);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(20, 17);
            this.btnCari.TabIndex = 34;
            this.btnCari.Text = "...";
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click_1);
            // 
            // Tx_Entity
            // 
            this.Tx_Entity.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Entity.Location = new System.Drawing.Point(42, 2);
            this.Tx_Entity.Name = "Tx_Entity";
            this.Tx_Entity.Size = new System.Drawing.Size(118, 21);
            this.Tx_Entity.TabIndex = 33;
            // 
            // FrmArama
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
            this.Name = "FrmArama";
            this.Text = "FrmArama";
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
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox Tx_Entity;
        private System.Windows.Forms.Label Lbl_Current;
    }
}