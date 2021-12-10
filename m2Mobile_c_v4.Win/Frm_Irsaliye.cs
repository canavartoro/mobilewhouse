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
    public partial class Frm_Irsaliye : Form, IDisposable
    {
        string _xNakliyeSekli = "";
        string _xNakliyeSekliId = "";
        string _xNakliyeKodu = "";
        string _xNakliyeKoduId = "";
        string _xIrsaliyeKodu = "";
        Nullable<DateTime> _xIrsaliyeTarihi = null;
        string _xIrsaliyeNo = "";
        string _xIrsaliyeSeri = "";
        string _xIrsaliyeSira = "";
        string _xIrsaliyeKoduId = "";
        Boolean _Multi = false;
        int _Type = 0;
        int _TypeFilter = 0;
        

        public Frm_Irsaliye(Boolean _MultiSelect, int _pType,int _pTypeFilter)
        {
            InitializeComponent();
            _Multi = _MultiSelect;
            _Type = _pType;
            _TypeFilter = _pTypeFilter;
        }

        public string _NakliyeSekli
        {
            get { return _xNakliyeSekli; }
        }
        public string _NakliyeSekliId
        {
            get { return _xNakliyeSekliId; }
        }
        public string _NakliyeKodu
        {
            get { return _xNakliyeKodu; }
        }
        public string _NakliyeKoduId
        {
            get { return _xNakliyeKoduId; }
        }

        public string _IrsaliyeKodu
        {
            get { return _xIrsaliyeKodu; }
        }
        public string _IrsaliyeKoduId
        {
            get { return _xIrsaliyeKoduId; }
        }
        public Nullable<DateTime> _IrsaliyeTarihi
        {
            get { return _xIrsaliyeTarihi; }
        }
        public string _IrsaliyeNo
        {
            get { return _xIrsaliyeNo; }
        }
        public string _IrsaliyeSeri
        {
            get { return _xIrsaliyeSeri; }
        }
        public string _IrsaliyeSira
        {
            get { return _xIrsaliyeSira; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                //_xNakliyeSekli = Cbo_Nakliye.Text.ToString();
                //_xNakliyeKodu = Cbo_NakliyeKod.Text.ToString();
                _xIrsaliyeTarihi = DateTime.Parse(Dt_IrsaliyeTarihi.Text.ToString());
                _xIrsaliyeSira = Tx_IrsaliyeSira.Text.ToString();
                _xIrsaliyeSeri = Tx_IrsaliyeSeri.Text.ToString();
                _xIrsaliyeNo = Tx_IrsaliyeNo.Text.ToString();
                _xIrsaliyeKodu = Tx_IrsaliyeKodu.Text.ToString();
                //_xNakliyeSekliId = ((ComboboxItem)Cbo_Nakliye.SelectedItem).Id.ToString();
                //_xNakliyeKoduId = ((ComboboxItem)Cbo_NakliyeKod.SelectedItem).Id.ToString();
                _xIrsaliyeKoduId = Tx_IrsaliyeKodu.Tag.ToString();

                if (_xNakliyeSekli == null) _xNakliyeSekli = "";
                if (_xNakliyeKodu == null) _xNakliyeKodu = "";
                if (_xIrsaliyeSira == null) _xIrsaliyeSira = "";
                if (_xNakliyeSekliId == null) _xNakliyeSekli = "";
                if (_xNakliyeKoduId == null) _xNakliyeSekli = "";
                if (_xIrsaliyeNo == null) _xIrsaliyeNo = "";
                if (_xIrsaliyeKodu == null) _xIrsaliyeKodu = "";
                

                this.Close();

             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _xNakliyeKoduId = "";
            _xIrsaliyeKodu = "";
            _xIrsaliyeNo = "";
            _xIrsaliyeSeri = "";
            _xIrsaliyeTarihi = null;
            _xIrsaliyeSira = "";
            _xNakliyeKodu = "";
            _xNakliyeSekli = "";
            _xIrsaliyeKoduId = "";
            this.Close();
        }

        private void FrmIrsaliye_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            string _Gelen = "";
            foreach (Control Ctrl in this.Controls)
            {
                _Gelen = "";
                _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                if (_Gelen == null) continue;
                Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            }

            foreach (Control Ctrl in this.panel1.Controls)
            {
                _Gelen = "";
                _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                if (_Gelen == null) continue;
                Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            }

            m2Mobile_c_v4.WebReference.ServiceRequestOfString _Giden = new m2Mobile_c_v4.WebReference.ServiceRequestOfString();
            _Giden.Token = new m2Mobile_c_v4.WebReference.Token();
            _Giden.Token = Data._Token.Token;

            m2Mobile_c_v4.WebReference.ServiceResultOfListOfNameIdItem _Response = Data._UService.GetTransportTypes(_Giden);

            foreach (m2Mobile_c_v4.WebReference.NameIdItem _Val in _Response.Value)
            {
                ComboboxItem Ci = new ComboboxItem();
                Ci.Text = _Val.Name;
                Ci.Value = _Val.Name;
                Ci.Id = _Val.Id;
                Cbo_Nakliye.Items.Add(Ci);
            }

            if (_Multi == true)
            {
                Lbl_WaybillNumber.Visible = false;
                Tx_IrsaliyeNo.Visible = false;
                Lbl_WaybillSerialOrder.Visible = false;
                Tx_IrsaliyeSeri.Visible = false;
                Tx_IrsaliyeSira.Visible = false;
            }

            Cursor.Current = Cursors.Default;
            Cursor.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmArama Fa = new FrmArama("DocTra2", 0,0,_TypeFilter);
            this.Visible = false;
            Fa.Show();
            /*
            if(Fa.DoubleClick==Click)
                this.Visible=true;
             */
            Tx_IrsaliyeKodu.Tag = Fa.RetKey.ToString();
            Tx_IrsaliyeKodu.Text = Fa.RetKey2.ToString();
           
        }

        private void Tx_IrsaliyeSeri_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cbo_Nakliye_SelectedIndexChanged(object sender, EventArgs e)
        {
            _xNakliyeSekliId = ((ComboboxItem)Cbo_Nakliye.SelectedItem).Value.ToString();
            m2Mobile_c_v4.WebReference.ServiceRequestOfString _Giden = new m2Mobile_c_v4.WebReference.ServiceRequestOfString();
            _Giden.Token = new m2Mobile_c_v4.WebReference.Token();
            _Giden.Token = Data._Token.Token;


            m2Mobile_c_v4.WebReference.ServiceResultOfListOfNameIdItem _Response = Data._UService.GetTransporters(_Giden);

            foreach (m2Mobile_c_v4.WebReference.NameIdItem _Val in _Response.Value)
            {
                ComboboxItem Ci = new ComboboxItem();
                Ci.Text = _Val.Name;
                Ci.Value = _Val.Name;
                Ci.Id = _Val.Id;
                Cbo_NakliyeKod.Items.Add(Ci);
            }
            
        }

        private void Cbo_NakliyeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _xNakliyeKoduId = ((ComboboxItem)Cbo_NakliyeKod.SelectedItem).Value.ToString();
            
            
        }

        private void Lbl_Waybill_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Dt_IrsaliyeTarihi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_WaybillDate_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_WaybillNumber_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Tx_IrsaliyeNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_WaybillSerialOrder_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Tx_IrsaliyeSira_TextChanged(object sender, EventArgs e)
        {

        }
    }
}