namespace MobileWhouse.Controls
{
    partial class AmbalajOlusturmaControl
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
            this.txtPaletNo = new System.Windows.Forms.TextBox();
            this.btnYeniPalet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStok = new MobileWhouse.Controls.BarkodTextBox();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dcQty = new MobileWhouse.Controls.DecimalTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.printPaletctrl = new MobileWhouse.GUI.PrintControl();
            this.label4 = new System.Windows.Forms.Label();
            this.textCari = new System.Windows.Forms.TextBox();
            this.btncari = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textAciklama = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numAmb = new MobileWhouse.GUI.TextBoxNumeric();
            this.btnhareket = new System.Windows.Forms.Button();
            this.btndepo = new System.Windows.Forms.Button();
            this.txthareket = new System.Windows.Forms.TextBox();
            this.txtdepo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.Text = "Plt";
            // 
            // txtPaletNo
            // 
            this.txtPaletNo.Location = new System.Drawing.Point(35, 164);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(129, 21);
            this.txtPaletNo.TabIndex = 1;
            this.txtPaletNo.TabStop = false;
            this.txtPaletNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaletNo_KeyPress);
            // 
            // btnYeniPalet
            // 
            this.btnYeniPalet.Location = new System.Drawing.Point(35, 191);
            this.btnYeniPalet.Name = "btnYeniPalet";
            this.btnYeniPalet.Size = new System.Drawing.Size(158, 26);
            this.btnYeniPalet.TabIndex = 8;
            this.btnYeniPalet.Text = "Kaydet";
            this.btnYeniPalet.Click += new System.EventHandler(this.btnYeniPalet_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.Text = "Stok";
            // 
            // txtStok
            // 
            this.txtStok.DepoId = 0;
            this.txtStok.IsRaf = 0;
            this.txtStok.Location = new System.Drawing.Point(35, 57);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(129, 21);
            this.txtStok.TabIndex = 2;
            // 
            // txtRaf
            // 
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.Location = new System.Drawing.Point(35, 31);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(158, 21);
            this.txtRaf.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.Text = "Raf";
            // 
            // dcQty
            // 
            this.dcQty.Location = new System.Drawing.Point(170, 57);
            this.dcQty.Name = "dcQty";
            this.dcQty.Size = new System.Drawing.Size(65, 21);
            this.dcQty.TabIndex = 3;
            this.dcQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(0, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 36);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // printPaletctrl
            // 
            this.printPaletctrl.Location = new System.Drawing.Point(7, 7);
            this.printPaletctrl.Name = "printPaletctrl";
            this.printPaletctrl.Size = new System.Drawing.Size(234, 29);
            this.printPaletctrl.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.Text = "Cari";
            // 
            // textCari
            // 
            this.textCari.Location = new System.Drawing.Point(35, 84);
            this.textCari.Name = "textCari";
            this.textCari.Size = new System.Drawing.Size(158, 21);
            this.textCari.TabIndex = 4;
            this.textCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCari_KeyPress);
            // 
            // btncari
            // 
            this.btncari.Location = new System.Drawing.Point(195, 84);
            this.btncari.Name = "btncari";
            this.btncari.Size = new System.Drawing.Size(40, 20);
            this.btncari.TabIndex = 5;
            this.btncari.Text = "...";
            this.btncari.Click += new System.EventHandler(this.btncari_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.Text = "Not";
            // 
            // textAciklama
            // 
            this.textAciklama.Location = new System.Drawing.Point(35, 111);
            this.textAciklama.Name = "textAciklama";
            this.textAciklama.Size = new System.Drawing.Size(200, 21);
            this.textAciklama.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 284);
            this.tabControl1.TabIndex = 81;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numAmb);
            this.tabPage1.Controls.Add(this.txtPaletNo);
            this.tabPage1.Controls.Add(this.textAciklama);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnhareket);
            this.tabPage1.Controls.Add(this.btndepo);
            this.tabPage1.Controls.Add(this.btncari);
            this.tabPage1.Controls.Add(this.btnYeniPalet);
            this.tabPage1.Controls.Add(this.txthareket);
            this.tabPage1.Controls.Add(this.txtdepo);
            this.tabPage1.Controls.Add(this.textCari);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.txtStok);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dcQty);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 261);
            this.tabPage1.Text = "Ambalaj";
            // 
            // numAmb
            // 
            this.numAmb.AllowSpace = false;
            this.numAmb.BackColor = System.Drawing.Color.LightCyan;
            this.numAmb.Location = new System.Drawing.Point(195, 164);
            this.numAmb.Name = "numAmb";
            this.numAmb.Size = new System.Drawing.Size(38, 21);
            this.numAmb.TabIndex = 79;
            this.numAmb.Text = "1";
            // 
            // btnhareket
            // 
            this.btnhareket.Location = new System.Drawing.Point(195, 7);
            this.btnhareket.Name = "btnhareket";
            this.btnhareket.Size = new System.Drawing.Size(40, 20);
            this.btnhareket.TabIndex = 0;
            this.btnhareket.Text = "...";
            this.btnhareket.Click += new System.EventHandler(this.btnhareket_Click);
            // 
            // btndepo
            // 
            this.btndepo.Location = new System.Drawing.Point(195, 138);
            this.btndepo.Name = "btndepo";
            this.btndepo.Size = new System.Drawing.Size(40, 20);
            this.btndepo.TabIndex = 7;
            this.btndepo.Text = "...";
            this.btndepo.Click += new System.EventHandler(this.btndepo_Click);
            // 
            // txthareket
            // 
            this.txthareket.Location = new System.Drawing.Point(35, 7);
            this.txthareket.Name = "txthareket";
            this.txthareket.Size = new System.Drawing.Size(158, 21);
            this.txthareket.TabIndex = 0;
            this.txthareket.TabStop = false;
            this.txthareket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCari_KeyPress);
            // 
            // txtdepo
            // 
            this.txtdepo.Location = new System.Drawing.Point(35, 138);
            this.txtdepo.Name = "txtdepo";
            this.txtdepo.Size = new System.Drawing.Size(158, 21);
            this.txtdepo.TabIndex = 72;
            this.txtdepo.TabStop = false;
            this.txtdepo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCari_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.Text = "Tür";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.Text = "Depo";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(161, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 20);
            this.label8.Text = "X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.printPaletctrl);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 258);
            this.tabPage2.Text = "Ayarlar";
            // 
            // AmbalajOlusturmaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "AmbalajOlusturmaControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.OnLoad += new System.EventHandler(this.AmbalajOlusturmaControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Button btnYeniPalet;
        private System.Windows.Forms.Label label2;
        private BarkodTextBox txtStok;
        private RafTextBox txtRaf;
        private System.Windows.Forms.Label label3;
        private DecimalTextBox dcQty;
        private System.Windows.Forms.Button btnClose;
        private MobileWhouse.GUI.PrintControl printPaletctrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCari;
        private System.Windows.Forms.Button btncari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAciklama;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnhareket;
        private System.Windows.Forms.TextBox txthareket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btndepo;
        private System.Windows.Forms.TextBox txtdepo;
        private System.Windows.Forms.Label label7;
        private MobileWhouse.GUI.TextBoxNumeric numAmb;
        private System.Windows.Forms.Label label8;
    }
}
