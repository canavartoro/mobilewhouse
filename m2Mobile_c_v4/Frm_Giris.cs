namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;
    using WebReference;

    public class Frm_Giris : Form, IDisposable
    {
        private IResourceReader _reader;
        private Button Btn_Cancel;
        private Button Btn_Ok;
        private Button Btn_Settings;
        private Button button1;
        private ComboBox Cbo_Depo;
        private ComboBox Cbo_IsYeri;
        private IContainer components = null;
        private IDictionaryEnumerator en;
        private PictureBox img_header;
        private Label Lbl_PassWord;
        private Label Lbl_UserCode;
        private Label Lbl_Warehouse;
        private Label Lbl_WorkPlace;
        private TextBox Tx_PassWord;
        private Label lblbuild;
        private TextBox Tx_UserCode;

        public Frm_Giris()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SysDefinitions.SetXmlData("MainParam", "LastWorkPlace", this.Cbo_IsYeri.Text.ToString());
            SysDefinitions.SetXmlData("MainParam", "LastWareHouse", this.Cbo_Depo.Text.ToString());
            Data._SelectedWareHouse = int.Parse(((ComboboxItem)this.Cbo_Depo.SelectedItem).Value.ToString());
            SysDefinitions._SysUserId = 1;
            new Frm_Menu().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((this.Tx_PassWord.Text != "") || (this.Tx_PassWord.Text != null))
                {
                    SysDefinitions._SysUserId = 0;
                    SysDefinitions.CursorState("Wait");
                    Data._Token.Value = new Token();
                    Data._Token.Value.UserName = this.Tx_UserCode.Text.ToString();
                    Data._Token.Value.Password = this.Tx_PassWord.Text.ToString();
                    ServiceResultOfLoginResult res = Data._UService.Login(Data._Token);
                    if (!res.Result)
                    {
                        SysDefinitions.CursorState("Default");
                        MessageBox.Show(string.Concat("Hatalı giriş! ", res.Message));
                    }
                    else
                    {
                        Data._Token.Token = new Token();
                        Data._Token.Token.UserName = Data._Token.Value.UserName;
                        Data._Token.Token.Password = Data._Token.Value.Password;
                        this.Cbo_IsYeri.Enabled = true;
                        ServiceRequestOfWorkPlaceSelectParam param = new ServiceRequestOfWorkPlaceSelectParam
                        {
                            Token = Data._Token.Token,
                            Value = new WorkPlaceSelectParam()
                        };
                        ServiceResultOfListOfWorkPlace workPlaces = Data._UService.GetWorkPlaces(param);
                        foreach (WorkPlace place2 in workPlaces.Value)
                        {
                            ComboboxItem item = new ComboboxItem
                            {
                                Text = place2.Code,
                                Value = place2.Id,
                                Id = place2.CoId
                            };
                            this.Cbo_IsYeri.Items.Add(item);
                        }
                        SysDefinitions.CursorState("Default");
                        this.Cbo_IsYeri.Focus();
                        if (SysDefinitions.GetXmlData("MainParam", "LastWorkPlace").ToString() != "")
                        {
                            this.Cbo_IsYeri.Text = SysDefinitions.GetXmlData("MainParam", "LastWorkPlace").ToString();
                            this.Cbo_IsYeri_SelectedIndexChanged(null, null);
                        }
                        if (SysDefinitions.GetXmlData("MainParam", "LastWareHouse").ToString() != "")
                        {
                            this.Cbo_Depo.Text = SysDefinitions.GetXmlData("MainParam", "LastWareHouse").ToString();
                            this.Cbo_Depo_SelectedIndexChanged(null, null);
                        }
                    }
                }
            }
            catch (ObjectDisposedException exception)
            {
                SysDefinitions.CursorState("Default");
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Ayarlar ayarlar = new Frm_Ayarlar();
            ayarlar.ShowDialog();
            SysDefinitions.FirstLoad();
            ayarlar.Dispose();
            GC.Collect();
            GC.SuppressFinalize(ayarlar);
            this.Frm_Giris_Load(null, null);
        }

        private void Cbo_Depo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Btn_Ok.Enabled = true;
        }

        private void Cbo_IsYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Cbo_IsYeri.Text != "" && this.Cbo_IsYeri.SelectedItem != null)
            {
                this.Cbo_Depo.Enabled = true;
                this.Cbo_Depo.Items.Clear();
                Data._Token.Token.BranchId = int.Parse(((ComboboxItem)this.Cbo_IsYeri.SelectedItem).Value.ToString());
                Data._Token.Token.CoId = int.Parse(((ComboboxItem)this.Cbo_IsYeri.SelectedItem).Id.ToString());
                ServiceRequestOfDepotSelectParam param = new ServiceRequestOfDepotSelectParam
                {
                    Token = Data._Token.Token,
                    Value = new DepotSelectParam()
                };
                ServiceResultOfListOfDepot wareHouses = Data._UService.GetWareHouses(param);
                foreach (Depot depot2 in wareHouses.Value)
                {
                    ComboboxItem item = new ComboboxItem
                    {
                        Text = depot2.Code,
                        Value = depot2.Id
                    };
                    this.Cbo_Depo.Items.Add(item);
                }
                wareHouses = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Frm_Giris_Load(object sender, EventArgs e)
        {
            Data._UService.Url = SysDefinitions.GetXmlData("MainParam", "WebServiceUrl");

            lblbuild.Text = string.Concat("V:", Program.Versiyon, "  B:", Program.BuildNumber());
            this.Cbo_IsYeri.Items.Clear();
            this.Cbo_Depo.Items.Clear();
            try
            {
                if (Data.CheckWebService(Data._UService.Url.ToString()) == HttpStatusCode.OK)
                {
                    Data._UService.Timeout = 0xc350;
                    this.Btn_Ok.Enabled = false;
                    this.Btn_Cancel.Enabled = true;
                    this.Cbo_Depo.Text = SysDefinitions.GetXmlData("MainParam", "LastWareHouse");
                    this.Cbo_IsYeri.Text = SysDefinitions.GetXmlData("MainParam", "LastWorkPlace");
                }
                else
                {
                    this.Btn_Ok.Enabled = false;
                    this.Btn_Cancel.Enabled = true;
                    this.Btn_Settings.Enabled = true;
                }
            }
            catch (SystemException)
            {
                this.Btn_Ok.Enabled = false;
                this.Btn_Cancel.Enabled = false;
                this.Btn_Settings.Enabled = true;
            }
            Assembly assembly = typeof(Frm_Giris).Assembly;
            string[] manifestResourceNames = assembly.GetManifestResourceNames();
            Stream manifestResourceStream = assembly.GetManifestResourceStream("m2Mobile_c_v4.Resources.Languages.Tr_TR.resources");
            this._reader = new ResourceReader(manifestResourceStream);
            this.en = this._reader.GetEnumerator();
            this._reader.Close();
        }

        private void InitializeComponent()
        {
            this.Tx_UserCode = new System.Windows.Forms.TextBox();
            this.Lbl_UserCode = new System.Windows.Forms.Label();
            this.Lbl_PassWord = new System.Windows.Forms.Label();
            this.Tx_PassWord = new System.Windows.Forms.TextBox();
            this.Lbl_WorkPlace = new System.Windows.Forms.Label();
            this.Cbo_IsYeri = new System.Windows.Forms.ComboBox();
            this.Cbo_Depo = new System.Windows.Forms.ComboBox();
            this.Lbl_Warehouse = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.img_header = new System.Windows.Forms.PictureBox();
            this.Btn_Settings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblbuild = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tx_UserCode
            // 
            this.Tx_UserCode.Location = new System.Drawing.Point(92, 62);
            this.Tx_UserCode.Name = "Tx_UserCode";
            this.Tx_UserCode.Size = new System.Drawing.Size(131, 21);
            this.Tx_UserCode.TabIndex = 1;
            this.Tx_UserCode.Text = "terminal";
            this.Tx_UserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_UserCode_KeyDown);
            this.Tx_UserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_UserCode_KeyPress);
            // 
            // Lbl_UserCode
            // 
            this.Lbl_UserCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_UserCode.Location = new System.Drawing.Point(13, 62);
            this.Lbl_UserCode.Name = "Lbl_UserCode";
            this.Lbl_UserCode.Size = new System.Drawing.Size(76, 20);
            this.Lbl_UserCode.Text = "Kullanıcı Kodu";
            this.Lbl_UserCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_PassWord
            // 
            this.Lbl_PassWord.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_PassWord.Location = new System.Drawing.Point(13, 90);
            this.Lbl_PassWord.Name = "Lbl_PassWord";
            this.Lbl_PassWord.Size = new System.Drawing.Size(73, 20);
            this.Lbl_PassWord.Text = "Şifre";
            this.Lbl_PassWord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_PassWord.ParentChanged += new System.EventHandler(this.Lbl_PassWord_ParentChanged);
            // 
            // Tx_PassWord
            // 
            this.Tx_PassWord.Location = new System.Drawing.Point(92, 89);
            this.Tx_PassWord.Name = "Tx_PassWord";
            this.Tx_PassWord.PasswordChar = '*';
            this.Tx_PassWord.Size = new System.Drawing.Size(131, 21);
            this.Tx_PassWord.TabIndex = 2;
            this.Tx_PassWord.Text = "te.123456";
            this.Tx_PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_PassWord_KeyDown);
            this.Tx_PassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_PassWord_KeyPress);
            this.Tx_PassWord.LostFocus += new System.EventHandler(this.Tx_PassWord_LostFocus);
            // 
            // Lbl_WorkPlace
            // 
            this.Lbl_WorkPlace.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_WorkPlace.Location = new System.Drawing.Point(13, 152);
            this.Lbl_WorkPlace.Name = "Lbl_WorkPlace";
            this.Lbl_WorkPlace.Size = new System.Drawing.Size(74, 20);
            this.Lbl_WorkPlace.Text = "İşyeri Kodu";
            this.Lbl_WorkPlace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Cbo_IsYeri
            // 
            this.Cbo_IsYeri.Enabled = false;
            this.Cbo_IsYeri.Location = new System.Drawing.Point(92, 150);
            this.Cbo_IsYeri.Name = "Cbo_IsYeri";
            this.Cbo_IsYeri.Size = new System.Drawing.Size(131, 22);
            this.Cbo_IsYeri.TabIndex = 4;
            this.Cbo_IsYeri.SelectedIndexChanged += new System.EventHandler(this.Cbo_IsYeri_SelectedIndexChanged);
            // 
            // Cbo_Depo
            // 
            this.Cbo_Depo.Enabled = false;
            this.Cbo_Depo.Location = new System.Drawing.Point(92, 178);
            this.Cbo_Depo.Name = "Cbo_Depo";
            this.Cbo_Depo.Size = new System.Drawing.Size(131, 22);
            this.Cbo_Depo.TabIndex = 5;
            this.Cbo_Depo.SelectedIndexChanged += new System.EventHandler(this.Cbo_Depo_SelectedIndexChanged);
            // 
            // Lbl_Warehouse
            // 
            this.Lbl_Warehouse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_Warehouse.Location = new System.Drawing.Point(13, 180);
            this.Lbl_Warehouse.Name = "Lbl_Warehouse";
            this.Lbl_Warehouse.Size = new System.Drawing.Size(74, 20);
            this.Lbl_Warehouse.Text = "Depo Kodu";
            this.Lbl_Warehouse.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Enabled = false;
            this.Btn_Ok.Location = new System.Drawing.Point(13, 246);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(96, 30);
            this.Btn_Ok.TabIndex = 6;
            this.Btn_Ok.Text = "Tamam";
            this.Btn_Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(127, 246);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(96, 30);
            this.Btn_Cancel.TabIndex = 7;
            this.Btn_Cancel.Text = "İptal";
            this.Btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // img_header
            // 
            this.img_header.Location = new System.Drawing.Point(13, 3);
            this.img_header.Name = "img_header";
            this.img_header.Size = new System.Drawing.Size(210, 53);
            // 
            // Btn_Settings
            // 
            this.Btn_Settings.Location = new System.Drawing.Point(127, 209);
            this.Btn_Settings.Name = "Btn_Settings";
            this.Btn_Settings.Size = new System.Drawing.Size(96, 31);
            this.Btn_Settings.TabIndex = 8;
            this.Btn_Settings.Text = "Ayarlar";
            this.Btn_Settings.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tamam";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblbuild
            // 
            this.lblbuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbuild.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblbuild.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblbuild.Location = new System.Drawing.Point(9, 280);
            this.lblbuild.Name = "lblbuild";
            this.lblbuild.Size = new System.Drawing.Size(214, 15);
            this.lblbuild.Text = "label1";
            this.lblbuild.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Frm_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.ControlBox = false;
            this.Controls.Add(this.lblbuild);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Settings);
            this.Controls.Add(this.img_header);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Cbo_Depo);
            this.Controls.Add(this.Lbl_Warehouse);
            this.Controls.Add(this.Cbo_IsYeri);
            this.Controls.Add(this.Lbl_WorkPlace);
            this.Controls.Add(this.Lbl_PassWord);
            this.Controls.Add(this.Tx_PassWord);
            this.Controls.Add(this.Lbl_UserCode);
            this.Controls.Add(this.Tx_UserCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Giris";
            this.Text = "Kullanıcı Giriş";
            this.Load += new System.EventHandler(this.Frm_Giris_Load);
            this.ResumeLayout(false);

        }

        private void Lbl_PassWord_ParentChanged(object sender, EventArgs e)
        {
        }

        private void Tx_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }

        private void Tx_PassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.Cbo_IsYeri.Focus();
            }
        }

        private void Tx_PassWord_LostFocus(object sender, EventArgs e)
        {
        }

        private void Tx_UserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Tx_PassWord.Focus();
            }
        }

        private void Tx_UserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                this.Tx_PassWord.Focus();
            }
        }
    }
}

