using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;
using m2Mobile_c_v4.WebReference;
using System.IO;

namespace m2Mobile_c_v4
{
    public partial class Frm_Giris : Form, IDisposable
    {
        // Kaynak okumak için gerekli
        IResourceReader _reader;
        IDictionaryEnumerator en; 
        public Frm_Giris()
        {
            InitializeComponent();

        }

        private void Frm_Giris_Load(object sender, EventArgs e)
        {
            Data._UService.Url = Classes.SysDefinitions.GetXmlData("MainParam", "WebServiceUrl");
            Cbo_IsYeri.Items.Clear();
            Cbo_Depo.Items.Clear();

            try
            {
                if (Data.CheckWebService(Data._UService.Url.ToString()) == System.Net.HttpStatusCode.OK)
                {
                    Data._UService.Timeout = 50000;
                    Btn_Ok.Enabled = false;
                    Btn_Cancel.Enabled = true;
                    Cbo_Depo.Text = Classes.SysDefinitions.GetXmlData("MainParam", "LastWareHouse");
                    Cbo_IsYeri.Text = Classes.SysDefinitions.GetXmlData("MainParam", "LastWorkPlace");
                   
                }
                else
                {
                    Btn_Ok.Enabled = false;
                    Btn_Cancel.Enabled = true;
                    Btn_Settings.Enabled = true;
                }
            }
            catch (SystemException)
            {
                Btn_Ok.Enabled = false;
                Btn_Cancel.Enabled = false;
                Btn_Settings.Enabled = true;

            }
            // Frame 2.0 da kaynak okuma için gerekli
            var asm=typeof(Frm_Giris).Assembly;
            var tt=   asm.GetManifestResourceNames();
            Stream ss = asm.GetManifestResourceStream("m2Mobile_c_v4.Resources.Languages.Tr_TR.resources");
            _reader = new ResourceReader(ss); 
            en = _reader.GetEnumerator();

        //    string _Gelen = "";

            /*
           while (en.MoveNext()) {
           //     foreach(IDictionaryEnumerator Ctrl in this._reader){
           //      Console.WriteLine();
           //      Console.WriteLine("Name: {0}", en.Key);
           //      Console.WriteLine("Value: {0}", en.Value);
                 _Gelen = en.Value.ToString();
                 if (_Gelen == null) continue;
                 
            }*/
            _reader.Close();
            /*
            foreach (Control Ctrl in this.Controls)
            {
                _Gelen = "";
                _Gelen = Resources.Languages.Tr_TR.ResourceManager.GetString(Ctrl.Name.ToString());
               // _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                if (_Gelen == null) continue;
                Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            }
             */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Classes.SysDefinitions._SysUserId = 0;
          //  this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.SysDefinitions.SetXmlData("MainParam", "LastWorkPlace", Cbo_IsYeri.Text.ToString());
            Classes.SysDefinitions.SetXmlData("MainParam", "LastWareHouse", Cbo_Depo.Text.ToString());
          

            Data._SelectedWareHouse = Int32.Parse(((ComboboxItem)Cbo_Depo.SelectedItem).Value.ToString());

            Classes.SysDefinitions._SysUserId = 1;
           
            Frm_Menu menu = new Frm_Menu();
            menu.Show();




          //  this.Visible = false;
            //this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Ayarlar Fa = new Frm_Ayarlar();
            Fa.ShowDialog();
            Classes.SysDefinitions.FirstLoad();
            Fa.Dispose();
            GC.Collect();
            GC.SuppressFinalize(Fa);
            Frm_Giris_Load(null, null);
        }

        private void Tx_UserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                Tx_PassWord.Focus();

        }



        private void Cbo_IsYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_IsYeri.Text == "") return;
            Cbo_Depo.Enabled = true;
            Cbo_Depo.Items.Clear();

            Data._Token.Token.BranchId = Int32.Parse(((ComboboxItem)Cbo_IsYeri.SelectedItem).Value.ToString());
            Data._Token.Token.CoId = Int32.Parse(((ComboboxItem)Cbo_IsYeri.SelectedItem).Id.ToString());

            
            WebReference.ServiceRequestOfDepotSelectParam _SelParam = new m2Mobile_c_v4.WebReference.ServiceRequestOfDepotSelectParam();
            _SelParam.Token = Data._Token.Token;



            _SelParam.Value = new m2Mobile_c_v4.WebReference.DepotSelectParam();
            WebReference.ServiceResultOfListOfDepot _ListWp = Data._UService.GetWareHouses(_SelParam);


            foreach (Depot _Val in _ListWp.Value)
            {
                ComboboxItem Ci = new ComboboxItem();
                Ci.Text = _Val.Code;
                Ci.Value = _Val.Id;
                Cbo_Depo.Items.Add(Ci);

            }
            _ListWp = null;
        }

        private void Cbo_Depo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_Ok.Enabled = true;
        }

        private void Tx_PassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                Cbo_IsYeri.Focus();
        }

        private void Tx_PassWord_LostFocus(object sender, EventArgs e)
        {



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                /* Kullanıcı Adı ve Parolası  bos ise işlem yapma diğer durumda
                 * Data Clas ının içindeki Token.Value değerini eklediğimiz web
                 * servisinden bir değer olarak oluşturup, kullanıcı adı ve parolasını
                 * Data._UService.Login(Data._Token) değerine göndererek bağlantı yapılıyor
                 */
                if (Tx_PassWord.Text == "" && Tx_PassWord.Text == null) return;
                Classes.SysDefinitions._SysUserId = 0;
                Classes.SysDefinitions.CursorState("Wait");

                Data._Token.Value = new m2Mobile_c_v4.WebReference.Token();
                Data._Token.Value.UserName = Tx_UserCode.Text.ToString();
                Data._Token.Value.Password = Tx_PassWord.Text.ToString();

                WebReference.ServiceResultOfLoginResult Rs = Data._UService.Login(Data._Token);

                if (Rs.Result == false)
                {
                    Classes.SysDefinitions.CursorState("Default");
                    MessageBox.Show("Hatalı Şifre");
                    return;

                }

                Data._Token.Token = new m2Mobile_c_v4.WebReference.Token();
                Data._Token.Token.UserName = Data._Token.Value.UserName;
                Data._Token.Token.Password = Data._Token.Value.Password;



                Cbo_IsYeri.Enabled = true;
                /* WebReference.ServiceRequestOfWorkPlaceSelectParam _SelParam 
                 * objesi oluşturulup, Data._Token.Token (login olan kullanıcının)
                 * seçebileceği depo alanı ve iş yeri bilgisi servisten çekiliyor
                 */
                WebReference.ServiceRequestOfWorkPlaceSelectParam _SelParam = new m2Mobile_c_v4.WebReference.ServiceRequestOfWorkPlaceSelectParam();
                _SelParam.Token = Data._Token.Token;
                _SelParam.Value = new m2Mobile_c_v4.WebReference.WorkPlaceSelectParam();
                WebReference.ServiceResultOfListOfWorkPlace _ListWp = Data._UService.GetWorkPlaces(_SelParam);


                foreach (WorkPlace _Val in _ListWp.Value)
                {
                    ComboboxItem Ci = new ComboboxItem();
                    Ci.Text = _Val.Code;
                    Ci.Value = _Val.Id;
                    Ci.Id = _Val.CoId;
                    Cbo_IsYeri.Items.Add(Ci);
                }
                Classes.SysDefinitions.CursorState("Default");
                Cbo_IsYeri.Focus();
                if (Classes.SysDefinitions.GetXmlData("MainParam", "LastWorkPlace").ToString() != "")
                {
                    Cbo_IsYeri.Text = Classes.SysDefinitions.GetXmlData("MainParam", "LastWorkPlace").ToString();
                    Cbo_IsYeri_SelectedIndexChanged(null, null);
                }

                if (Classes.SysDefinitions.GetXmlData("MainParam", "LastWareHouse").ToString() != "")
                {
                    Cbo_Depo.Text = Classes.SysDefinitions.GetXmlData("MainParam", "LastWareHouse").ToString();
                    Cbo_Depo_SelectedIndexChanged(null, null);
                }
            }
            catch (ObjectDisposedException ex)
            {
                Classes.SysDefinitions.CursorState("Default");
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Tx_UserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Tx_PassWord.Focus();
            }
        }

        private void Tx_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void Lbl_PassWord_ParentChanged(object sender, EventArgs e)
        {

        }




    }
}