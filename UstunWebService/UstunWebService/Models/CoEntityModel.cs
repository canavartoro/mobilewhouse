using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class CoEntityModel
    {
        public int EntityId { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string GroupCode1 { get; set; }
        public string GroupName1 { get; set; }
        public string GroupCode2 { get; set; }
        public string GroupName2 { get; set; }
        public string GroupCode3 { get; set; }
        public string GroupName3 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string TownName { get; set; }
        public string CityName { get; set; }
    }
}