using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class AssetCardModel
    {

        public int ASSET_CARD_ID { get; set; }
        public int ASSET_GNL_CARD_ID { get; set; }

        
        public string SERIAL_NO { get; set; }
        public string ASSET_GNL_CODE { get; set; }
        public string ASSET_GNL_DESC { get; set; }
        public int ASSET_LOCATION_ID { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }

    }
}

