namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class Frm_Ayarlar : Form, IDisposable
    {
        private string _MessageStr = "";
        private Button Btn_Cancel;
        private Button Btn_Save;
        private Button button1;
        private ComboBox Cbo_Dil;
        private IContainer components = null;
        private Label Lbl_Delay;
        private Label Lbl_Lang;
        private Label Lbl_WsAddr;
        private TextBox Tx_WebService;
        private ComboBox Tx_WriteDelay;

        public Frm_Ayarlar()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            try
            {
                if (Data.CheckWebService(this.Tx_WebService.Text.ToString()) == HttpStatusCode.OK)
                {
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WebServiceAvailable");
                    MessageBox.Show(this._MessageStr);
                }
                else
                {
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WebServiceUnAvailable");
                    MessageBox.Show(this._MessageStr);
                }
            }
            catch (SystemException)
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WebServiceUnAvailable");
                MessageBox.Show(this._MessageStr);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Cursor.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SysDefinitions.SetXmlData("MainParam", "WebServiceUrl", this.Tx_WebService.Text.ToString());
            SysDefinitions.SetXmlData("MainParam", "CurrentLanguage", this.Cbo_Dil.Text);
            SysDefinitions.SetXmlData("MainParam", "BarcodeDelay", this.Tx_WriteDelay.Text);
            SysDefinitions.FirstLoad();
            base.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data.UpdateWebServices("");
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

        private void Frm_Ayarlar_Load(object sender, EventArgs e)
        {
            this.Tx_WebService.Text = SysDefinitions.GetXmlData("MainParam", "WebServiceUrl");
            this.Cbo_Dil.Text = SysDefinitions._CurrentLanguage;
            this.Tx_WriteDelay.Items.Clear();
            for (int i = 0; i < 0x2710; i++)
            {
                this.Tx_WriteDelay.Items.Add(i.ToString());
            }
            this.Tx_WriteDelay.Text = SysDefinitions.GetXmlData("MainParam", "BarcodeDelay");
        }

        private void InitializeComponent()
        {
            this.Lbl_WsAddr = new System.Windows.Forms.Label();
            this.Tx_WebService = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Cbo_Dil = new System.Windows.Forms.ComboBox();
            this.Lbl_Lang = new System.Windows.Forms.Label();
            this.Lbl_Delay = new System.Windows.Forms.Label();
            this.Tx_WriteDelay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Lbl_WsAddr
            // 
            this.Lbl_WsAddr.Location = new System.Drawing.Point(3, 5);
            this.Lbl_WsAddr.Name = "Lbl_WsAddr";
            this.Lbl_WsAddr.Size = new System.Drawing.Size(125, 20);
            this.Lbl_WsAddr.Text = "Web Service Address";
            // 
            // Tx_WebService
            // 
            this.Tx_WebService.Location = new System.Drawing.Point(3, 23);
            this.Tx_WebService.Multiline = true;
            this.Tx_WebService.Name = "Tx_WebService";
            this.Tx_WebService.Size = new System.Drawing.Size(234, 116);
            this.Tx_WebService.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(89, 271);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(72, 20);
            this.Btn_Save.TabIndex = 3;
            this.Btn_Save.Text = "Kaydet";
            this.Btn_Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(165, 271);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(72, 20);
            this.Btn_Cancel.TabIndex = 4;
            this.Btn_Cancel.Text = "İptal";
            this.Btn_Cancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // Cbo_Dil
            // 
            this.Cbo_Dil.Items.Add("Turkish");
            this.Cbo_Dil.Items.Add("English");
            this.Cbo_Dil.Location = new System.Drawing.Point(73, 171);
            this.Cbo_Dil.Name = "Cbo_Dil";
            this.Cbo_Dil.Size = new System.Drawing.Size(164, 22);
            this.Cbo_Dil.TabIndex = 6;
            // 
            // Lbl_Lang
            // 
            this.Lbl_Lang.Location = new System.Drawing.Point(3, 171);
            this.Lbl_Lang.Name = "Lbl_Lang";
            this.Lbl_Lang.Size = new System.Drawing.Size(64, 20);
            this.Lbl_Lang.Text = "Dil";
            this.Lbl_Lang.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Delay
            // 
            this.Lbl_Delay.Location = new System.Drawing.Point(3, 200);
            this.Lbl_Delay.Name = "Lbl_Delay";
            this.Lbl_Delay.Size = new System.Drawing.Size(149, 20);
            this.Lbl_Delay.Text = "Barkod Yazma Süresi";
            this.Lbl_Delay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Tx_WriteDelay
            // 
            this.Tx_WriteDelay.Location = new System.Drawing.Point(158, 198);
            this.Tx_WriteDelay.Name = "Tx_WriteDelay";
            this.Tx_WriteDelay.Size = new System.Drawing.Size(80, 22);
            this.Tx_WriteDelay.TabIndex = 11;
            // 
            // Frm_Ayarlar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.Controls.Add(this.Tx_WriteDelay);
            this.Controls.Add(this.Lbl_Delay);
            this.Controls.Add(this.Lbl_Lang);
            this.Controls.Add(this.Cbo_Dil);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tx_WebService);
            this.Controls.Add(this.Lbl_WsAddr);
            this.MinimizeBox = false;
            this.Name = "Frm_Ayarlar";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Frm_Ayarlar_Load);
            this.ResumeLayout(false);

        }
    }
}

