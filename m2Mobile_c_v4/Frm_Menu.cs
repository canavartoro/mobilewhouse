using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace m2Mobile_c_v4
{
    public partial class Frm_Menu : Form
    {
        private Button btn_Isemri_cikis;
        private Button btn_Stok_hareket;
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components = null;
        private MainMenu mainMenu1;

        public Frm_Menu()
        {
            this.InitializeComponent();
        }

        private void btn_Isemri_cikis_Click(object sender, EventArgs e)
        {
            new Frm_Isemri_Malz_Cikis().Show();
        }

        private void btn_Stok_hareket_Click(object sender, EventArgs e)
        {
            Frm_Depo_Stk_Sorgula sorgula = new Frm_Depo_Stk_Sorgula();
            base.Close();
            sorgula.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Frm_StnSiparisi().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Frm_Ith_Gum().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Stok_hareket = new System.Windows.Forms.Button();
            this.btn_Isemri_cikis = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(9, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 53);
            this.button1.TabIndex = 4;
            this.button1.Text = "Satın Alma Sip";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(123, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 53);
            this.button2.TabIndex = 3;
            this.button2.Text = "İth. Güm. çıkışı";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Stok_hareket
            // 
            this.btn_Stok_hareket.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Stok_hareket.Location = new System.Drawing.Point(9, 103);
            this.btn_Stok_hareket.Name = "btn_Stok_hareket";
            this.btn_Stok_hareket.Size = new System.Drawing.Size(108, 53);
            this.btn_Stok_hareket.TabIndex = 2;
            this.btn_Stok_hareket.Text = "Stok Hareketleri";
            this.btn_Stok_hareket.Click += new System.EventHandler(this.btn_Stok_hareket_Click);
            // 
            // btn_Isemri_cikis
            // 
            this.btn_Isemri_cikis.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Isemri_cikis.Location = new System.Drawing.Point(123, 103);
            this.btn_Isemri_cikis.Name = "btn_Isemri_cikis";
            this.btn_Isemri_cikis.Size = new System.Drawing.Size(108, 54);
            this.btn_Isemri_cikis.TabIndex = 1;
            this.btn_Isemri_cikis.Text = "İşEmirne Bağlı Har. ";
            this.btn_Isemri_cikis.Click += new System.EventHandler(this.btn_Isemri_cikis_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(123, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 45);
            this.button3.TabIndex = 0;
            this.button3.Text = "Çıkış";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_Isemri_cikis);
            this.Controls.Add(this.btn_Stok_hareket);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Frm_Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Frm_Menu_Load);
            this.ResumeLayout(false);

        }
    }
}

