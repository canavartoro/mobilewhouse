using System.Windows.Forms;
using System;
using System.Linq;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class FrmAracBilgi : Form, IDisposable
    {
        int _xVehicleId = 0; //ARaç Kodu
        string _xLicencePlate = string.Empty; //Plaka
        string _xDriverName = string.Empty; // Ad
        string _xDriverFamilyName = string.Empty; //Soyad
        string _xDriverIdentifyNo = string.Empty; //Tckn
        string _xDriverGsmNo = string.Empty; //gsm
        string _xTransportEquipment = string.Empty; //Dorse Plaka
        string _xShippingDesc1 = string.Empty; //Açıklama

        public FrmAracBilgi()
        {

            InitializeComponent();
        }
        public int _VehicleId { get { return _xVehicleId; } }
        public string _LicencePlate  {get { return _xLicencePlate; }}
        public string _DriverName  {get { return _xDriverName; }}
        public string _DriverFamilyName  {get { return _xDriverFamilyName; }}
        public string _DriverIdentifyNo  {get { return _xDriverIdentifyNo; }}
        public string _DriverGsmNo  {get { return _xDriverGsmNo; }}
        public string _TransportEquipment {get { return _xTransportEquipment; }}
        public string _ShippingDesc1 { get { return _xShippingDesc1; } }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ClearValues();
            this.Close();
        }

        private void ClearValues()
        {
            _xVehicleId = 0; //ARaç Kodu
            _xLicencePlate = string.Empty; //Plaka
            _xDriverName = string.Empty; // Ad
            _xDriverFamilyName = string.Empty; //Soyad
            _xDriverIdentifyNo = string.Empty; //Tckn
            _xDriverGsmNo = string.Empty; //gsm
            _xTransportEquipment = string.Empty; //Dorse Plaka
            _xShippingDesc1 = string.Empty; //Açıklama
        }
        /*
        private void FrmAracBilgi(object sender, EventArgs e)
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

            Cursor.Current = Cursors.Default;
            Cursor.Hide();
        }
        */
        private void button_VehicleCode_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("GetVehicleOutList", 0, 0, 0);
            fa.TopMost = true; 
            fa.ShowDialog();
            if (string.IsNullOrEmpty(fa.RetKey)) return;
            try
            {
                Screens.ShowWait();

                _xVehicleId = Int32.Parse(fa.RetKey.ToString());
                Tx_VehicleCode.Text = fa.RetKey2.ToString();
                Tx_LicencePlate.Text = fa.RetKey3.ToString();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Hata [Araç Bilgi-GetVehicleOutList]" + ex.Message);
            }

            Screens.HideWait();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            _xVehicleId = _VehicleId; //ARaç Kodu
            _xLicencePlate = Tx_LicencePlate.Text; //Plaka
            _xDriverName = Tx_DriverName.Text; // Ad
            _xDriverFamilyName = Tx_DriverFamilyName.Text; //Soyad
            _xDriverIdentifyNo = Tx_DriverIdentifyNo.Text; //Tckn
            _xDriverGsmNo = Tx_DriverGsmNo.Text; //gsm
            _xTransportEquipment = Tx_TransportEquipment.Text; //Dorse Plaka
            _xShippingDesc1 = Tx_ShippingDesc1.Text; //Açıklama

            this.Close();
        }
    }
}