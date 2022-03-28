namespace MobileWhouse.Controls
{
    partial class SevkiyatControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SevkiyatControl));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlPalet = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tabPagePaket = new System.Windows.Forms.TabPage();
            this.btnDeletePackage = new System.Windows.Forms.Button();
            this.btnYeniPaket = new System.Windows.Forms.Button();
            this.lvwPackages = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.tabPagePackkageIcerik = new System.Windows.Forms.TabPage();
            this.lvwPackageDetail = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.txtMiktar = new MobileWhouse.Controls.DecimalTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRaf = new MobileWhouse.Controls.RafTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSevkEmri = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.textBarkod = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ulke = new System.Windows.Forms.Label();
            this.il = new System.Windows.Forms.Label();
            this.ilce = new System.Windows.Forms.Label();
            this.adres3 = new System.Windows.Forms.Label();
            this.adres2 = new System.Windows.Forms.Label();
            this.adres1 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lvwOther = new System.Windows.Forms.ListView();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSil = new System.Windows.Forms.Button();
            this.lvwOkutulanlar = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwOnerilenler = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlPalet.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPagePaket.SuspendLayout();
            this.tabPagePackkageIcerik.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControlPalet);
            this.tabPage1.Controls.Add(this.txtMiktar);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtRaf);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblSevkEmri);
            this.tabPage1.Controls.Add(this.lblMusteri);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBarkod);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabControlPalet
            // 
            resources.ApplyResources(this.tabControlPalet, "tabControlPalet");
            this.tabControlPalet.Controls.Add(this.tabPage5);
            this.tabControlPalet.Controls.Add(this.tabPagePaket);
            this.tabControlPalet.Controls.Add(this.tabPagePackkageIcerik);
            this.tabControlPalet.Controls.Add(this.tabPage7);
            this.tabControlPalet.Name = "tabControlPalet";
            this.tabControlPalet.SelectedIndex = 0;
            this.tabControlPalet.SelectedIndexChanged += new System.EventHandler(this.tabControlPalet_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lvwItems);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            // 
            // lvwItems
            // 
            this.lvwItems.Columns.Add(this.columnHeader4);
            this.lvwItems.Columns.Add(this.columnHeader21);
            this.lvwItems.Columns.Add(this.columnHeader5);
            this.lvwItems.Columns.Add(this.columnHeader7);
            this.lvwItems.Columns.Add(this.columnHeader25);
            this.lvwItems.Columns.Add(this.columnHeader6);
            resources.ApplyResources(this.lvwItems, "lvwItems");
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader21
            // 
            resources.ApplyResources(this.columnHeader21, "columnHeader21");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader25
            // 
            resources.ApplyResources(this.columnHeader25, "columnHeader25");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // tabPagePaket
            // 
            this.tabPagePaket.Controls.Add(this.btnDeletePackage);
            this.tabPagePaket.Controls.Add(this.btnYeniPaket);
            this.tabPagePaket.Controls.Add(this.lvwPackages);
            resources.ApplyResources(this.tabPagePaket, "tabPagePaket");
            this.tabPagePaket.Name = "tabPagePaket";
            // 
            // btnDeletePackage
            // 
            resources.ApplyResources(this.btnDeletePackage, "btnDeletePackage");
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Click += new System.EventHandler(this.btnDeletePackage_Click);
            // 
            // btnYeniPaket
            // 
            resources.ApplyResources(this.btnYeniPaket, "btnYeniPaket");
            this.btnYeniPaket.Name = "btnYeniPaket";
            this.btnYeniPaket.Click += new System.EventHandler(this.btnYeniPaket_Click);
            // 
            // lvwPackages
            // 
            resources.ApplyResources(this.lvwPackages, "lvwPackages");
            this.lvwPackages.Columns.Add(this.columnHeader13);
            this.lvwPackages.Columns.Add(this.columnHeader18);
            this.lvwPackages.FullRowSelect = true;
            this.lvwPackages.Name = "lvwPackages";
            this.lvwPackages.View = System.Windows.Forms.View.Details;
            this.lvwPackages.SelectedIndexChanged += new System.EventHandler(this.lvwPackages_SelectedIndexChanged);
            // 
            // columnHeader13
            // 
            resources.ApplyResources(this.columnHeader13, "columnHeader13");
            // 
            // columnHeader18
            // 
            resources.ApplyResources(this.columnHeader18, "columnHeader18");
            // 
            // tabPagePackkageIcerik
            // 
            this.tabPagePackkageIcerik.Controls.Add(this.lvwPackageDetail);
            resources.ApplyResources(this.tabPagePackkageIcerik, "tabPagePackkageIcerik");
            this.tabPagePackkageIcerik.Name = "tabPagePackkageIcerik";
            // 
            // lvwPackageDetail
            // 
            this.lvwPackageDetail.Columns.Add(this.columnHeader11);
            this.lvwPackageDetail.Columns.Add(this.columnHeader24);
            this.lvwPackageDetail.Columns.Add(this.columnHeader12);
            resources.ApplyResources(this.lvwPackageDetail, "lvwPackageDetail");
            this.lvwPackageDetail.Name = "lvwPackageDetail";
            this.lvwPackageDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            resources.ApplyResources(this.columnHeader11, "columnHeader11");
            // 
            // columnHeader24
            // 
            resources.ApplyResources(this.columnHeader24, "columnHeader24");
            // 
            // columnHeader12
            // 
            resources.ApplyResources(this.columnHeader12, "columnHeader12");
            // 
            // tabPage7
            // 
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            // 
            // txtMiktar
            // 
            resources.ApplyResources(this.txtMiktar, "txtMiktar");
            this.txtMiktar.BackColor = System.Drawing.Color.LightCyan;
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtItemCode
            // 
            // 
            // txtRaf
            // 
            resources.ApplyResources(this.txtRaf, "txtRaf");
            this.txtRaf.DepoId = 0;
            this.txtRaf.IsRaf = 1;
            this.txtRaf.IsTransfer = false;
            this.txtRaf.Name = "txtRaf";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblSevkEmri
            // 
            resources.ApplyResources(this.lblSevkEmri, "lblSevkEmri");
            this.lblSevkEmri.Name = "lblSevkEmri";
            // 
            // lblMusteri
            // 
            resources.ApplyResources(this.lblMusteri, "lblMusteri");
            this.lblMusteri.Name = "lblMusteri";
            // 
            // textBarkod
            // 
            resources.ApplyResources(this.textBarkod, "textBarkod");
            this.textBarkod.Name = "textBarkod";
            this.textBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBarkod_KeyPress);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.ulke);
            this.tabPage4.Controls.Add(this.il);
            this.tabPage4.Controls.Add(this.ilce);
            this.tabPage4.Controls.Add(this.adres3);
            this.tabPage4.Controls.Add(this.adres2);
            this.tabPage4.Controls.Add(this.adres1);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ulke
            // 
            resources.ApplyResources(this.ulke, "ulke");
            this.ulke.Name = "ulke";
            // 
            // il
            // 
            resources.ApplyResources(this.il, "il");
            this.il.Name = "il";
            // 
            // ilce
            // 
            resources.ApplyResources(this.ilce, "ilce");
            this.ilce.Name = "ilce";
            // 
            // adres3
            // 
            resources.ApplyResources(this.adres3, "adres3");
            this.adres3.Name = "adres3";
            // 
            // adres2
            // 
            resources.ApplyResources(this.adres2, "adres2");
            this.adres2.Name = "adres2";
            // 
            // adres1
            // 
            resources.ApplyResources(this.adres1, "adres1");
            this.adres1.Name = "adres1";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lvwOther);
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            // 
            // lvwOther
            // 
            this.lvwOther.Columns.Add(this.columnHeader19);
            this.lvwOther.Columns.Add(this.columnHeader20);
            resources.ApplyResources(this.lvwOther, "lvwOther");
            this.lvwOther.Name = "lvwOther";
            this.lvwOther.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader19
            // 
            resources.ApplyResources(this.columnHeader19, "columnHeader19");
            // 
            // columnHeader20
            // 
            resources.ApplyResources(this.columnHeader20, "columnHeader20");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSil);
            this.tabPage3.Controls.Add(this.lvwOkutulanlar);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            // 
            // btnSil
            // 
            resources.ApplyResources(this.btnSil, "btnSil");
            this.btnSil.Name = "btnSil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lvwOkutulanlar
            // 
            resources.ApplyResources(this.lvwOkutulanlar, "lvwOkutulanlar");
            this.lvwOkutulanlar.Columns.Add(this.columnHeader8);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader23);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader9);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader10);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader14);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader15);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader16);
            this.lvwOkutulanlar.Columns.Add(this.columnHeader17);
            this.lvwOkutulanlar.FullRowSelect = true;
            this.lvwOkutulanlar.Name = "lvwOkutulanlar";
            this.lvwOkutulanlar.View = System.Windows.Forms.View.Details;
            this.lvwOkutulanlar.SelectedIndexChanged += new System.EventHandler(this.lvwOkutulanlar_SelectedIndexChanged);
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // columnHeader23
            // 
            resources.ApplyResources(this.columnHeader23, "columnHeader23");
            // 
            // columnHeader9
            // 
            resources.ApplyResources(this.columnHeader9, "columnHeader9");
            // 
            // columnHeader10
            // 
            resources.ApplyResources(this.columnHeader10, "columnHeader10");
            // 
            // columnHeader14
            // 
            resources.ApplyResources(this.columnHeader14, "columnHeader14");
            // 
            // columnHeader15
            // 
            resources.ApplyResources(this.columnHeader15, "columnHeader15");
            // 
            // columnHeader16
            // 
            resources.ApplyResources(this.columnHeader16, "columnHeader16");
            // 
            // columnHeader17
            // 
            resources.ApplyResources(this.columnHeader17, "columnHeader17");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwOnerilenler);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // lvwOnerilenler
            // 
            resources.ApplyResources(this.lvwOnerilenler, "lvwOnerilenler");
            this.lvwOnerilenler.Columns.Add(this.columnHeader1);
            this.lvwOnerilenler.Columns.Add(this.columnHeader22);
            this.lvwOnerilenler.Columns.Add(this.columnHeader2);
            this.lvwOnerilenler.Columns.Add(this.columnHeader3);
            this.lvwOnerilenler.FullRowSelect = true;
            this.lvwOnerilenler.Name = "lvwOnerilenler";
            this.lvwOnerilenler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader22
            // 
            resources.ApplyResources(this.columnHeader22, "columnHeader22");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // SevkiyatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabMain);
            this.Name = "SevkiyatControl";
            resources.ApplyResources(this, "$this");
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControlPalet.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPagePaket.ResumeLayout(false);
            this.tabPagePackkageIcerik.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblSevkEmri;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ListView lvwOnerilenler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvwOkutulanlar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RafTextBox txtRaf;
        private DecimalTextBox txtMiktar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TabControl tabControlPalet;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPagePaket;
        private System.Windows.Forms.ListView lvwPackages;
        private System.Windows.Forms.Button btnYeniPaket;
        private System.Windows.Forms.TabPage tabPagePackkageIcerik;
        private System.Windows.Forms.ListView lvwPackageDetail;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListView lvwOther;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Button btnDeletePackage;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label adres2;
        private System.Windows.Forms.Label adres1;
        private System.Windows.Forms.Label ulke;
        private System.Windows.Forms.Label il;
        private System.Windows.Forms.Label ilce;
        private System.Windows.Forms.Label adres3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.TextBox textBarkod;
    }
}
