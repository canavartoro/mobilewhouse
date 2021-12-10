using UstunWebService.SenfoniGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UstunWebService.Helpers;

namespace UstunWebService.Models
{
    public class RecordModel
    {
        public int RecordModelId { get; set; }

        public string DocNo { get; set; }

        //IsoDateTimeConverter,UnixDateTimeConverter))]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DocDate { get; set; }

        public int EntityId { get; set; }

        public string EntityCode { get; set; }

        public string EntityName { get; set; }

        public int WarehouseId { get; set; }

        public string WarehouseCode { get; set; }

        public string WarehouseName { get; set; }

        public int PurchaseSales { get; set; }

        public int DocumentType { get; set; } // Sayim:30,Alis:20,Satis:50


    }


    public class RecordDetailModel
    {
        public TempDocumentMModel TempDocumentM { get; set; }
        public List<TempDocumentDModel> TempDocumentD { get; set; }
    }
}