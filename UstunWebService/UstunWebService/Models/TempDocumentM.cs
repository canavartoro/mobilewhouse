using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class TempDocumentM
    {
        public int Id { get; set; }
        public TempDocumentType DocumentType { get; set; }
        public int UserId { get; set; }
        public DateTime DocDate { get; set; }
        public string DocNo { get; set; }
        public int WhouseId { get; set; }
        public int WhouseId2 { get; set; }
        public int ProjectMId { get; set; }
        public int BranchId { get; set; }
        public string SerialNumber { get; set; }
        public string SortNo { get; set; }
        public int TransactionId { get; set; }
        public string BranchCode { get; set; }
        public int CoId { get; set; }
        public string CoCode { get; set; }
        public string DocTraCode { get; set; }
        public PurchaseSales PurchaseSales { get; set; }
        public InventoryStatus InventoryStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

    public enum TempDocumentType
    {
        SatinAlmaKabul = 1,
        ProjeCikis = 2,
        BagimsizGiris = 3,
        BagimsizCikis = 4,
        DepolarArasıTransfer = 5,
        DepoSayim = 6,
        Bagimsizİslem = 7,
    }

    public enum PurchaseSales
    {
        Alış = 1,
        Satış = 2,
        Satış_İade = 3,
        Alış_İade = 4
    }

    public enum InventoryStatus
    {
        Giriş = 1,
        Çıkış = 2,
        Transfer = 3,
        Devir = 4
    }
}