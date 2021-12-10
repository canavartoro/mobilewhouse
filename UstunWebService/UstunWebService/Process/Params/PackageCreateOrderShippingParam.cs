using UstunWebService.UTerminalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class PackageCreateOrderShippingParam : ServiceParam
    {
        public string Note1 { get; set; } //İrsaliye Açıklama-1
        public string Note2 { get; set; } //İrsaliye Açıklama-2
        public string Note3 { get; set; } //İrsaliye Açıklama-3

        //public int OrderMId { get; set; }
        public int NakliyeSekliId { get; set; }
        public int NakliyeKoduId { get; set; }
        public int IrsaliyeKoduId { get; set; }
        public DateTime IrsaliyeTarihi { get; set; }
        public string IrsaliyeNo { get; set; }
        public string IrsaliyeSeri { get; set; }
        public string IrsaliyeSiraNo { get; set; }
        public bool IsMixedPalet { get; set; } //Karma Palet
        public int SalesPersonId { get; set; } //Satış Temsilcisi



        //public string IssueTime { get; set; } //E-İrsaliye Düzenleme saati
        //public string StartTime { get; set; } //Fiili Sevk Saati
        //public DateTime ActualDespatchDate { get; set; } //Fiili Sevk Tarihi
        //public string RegisterName { get; set; } //Teslim Eden
        public int VehicleId { get; set; } //Araç Kodu Id
        public string LicencePlate { get; set; } //Plaka

        public string DriverName { get; set; } //Ad
        public string DriverFamilyName { get; set; } //Soyad
        public string DriverIdentifyNo { get; set; } //Tckn
        public string DriverGsmNo { get; set; } //Gsm
        public string TransportEquipment { get; set; } //Dorse plaka
        public string ShippingDesc1 { get; set; } //Araç Açıklama
        public int AgainstWhouseId { get; set; } //Transfer İrsaliyesinde Hedef Depo
        public PackageCreateOrderShippingOrderOut[] Orders { get; set; }
        public PackageCreateOrderShippingPackageOut[] Packages { get; set; }
        public PackageCreateOrderShippingPackageDetailOut[] PackageDetails { get; set; }

        public int SourceMId { get; set; }
        public int SourceDId { get; set; }
        public int SourceApp { get; set; }

        public static explicit operator UTerminalService.PackageCreateOrderShippingMOut(PackageCreateOrderShippingParam shippingParam)
        {
            UTerminalService.PackageCreateOrderShippingMOut mOut = new PackageCreateOrderShippingMOut();
            mOut.Note1 = shippingParam.Note1;
            mOut.Note2 = shippingParam.Note2;
            mOut.Note3 = shippingParam.Note3;

            mOut.NakliyeSekliId = shippingParam.NakliyeSekliId;
            mOut.NakliyeKoduId = shippingParam.NakliyeKoduId;
            mOut.IrsaliyeKoduId = shippingParam.IrsaliyeKoduId;
            mOut.IrsaliyeTarihi = shippingParam.IrsaliyeTarihi;
            mOut.IrsaliyeNo = shippingParam.IrsaliyeNo;
            mOut.IrsaliyeSeri = shippingParam.IrsaliyeSeri;
            mOut.IrsaliyeSiraNo = shippingParam.IrsaliyeSiraNo;
            mOut.IsMixedPalet = shippingParam.IsMixedPalet;
            mOut.SalesPersonId = shippingParam.SalesPersonId;

            mOut.VehicleId = shippingParam.VehicleId;
            mOut.LicencePlate = shippingParam.LicencePlate;

            mOut.DriverName = shippingParam.DriverName;
            mOut.DriverFamilyName = shippingParam.DriverFamilyName;
            mOut.DriverIdentifyNo = shippingParam.DriverIdentifyNo;
            mOut.DriverGsmNo = shippingParam.DriverGsmNo;
            mOut.TransportEquipment = shippingParam.TransportEquipment;
            mOut.ShippingDesc1 = shippingParam.ShippingDesc1;
            mOut.AgainstWhouseId = shippingParam.AgainstWhouseId;

            mOut.Orders = shippingParam.Orders;
            mOut.Packages = shippingParam.Packages;
            mOut.PackageDetails = shippingParam.PackageDetails;

            mOut.SourceMId = shippingParam.SourceMId;
            mOut.SourceDId = shippingParam.SourceDId;
            mOut.SourceApp = shippingParam.SourceApp;

            return mOut;
        }
    }
}