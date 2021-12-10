using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class EntityModel
    {
    }
    public class EntityListModel
    {
        public int ENTITY_ID { get; set; }
        public string ENTITY_CODE { get; set; }
        public string ENTITY_NAME { get; set; }
        public bool IsSelected { get; set; }
        public int CO_ID { get; set; }
    }
    public class EntityFilterModel {
        public int ENTITY_ID { get; set; }
        public string ENTITY_CODE { get; set; }
        public string ENTITY_NAME { get; set; }
        public bool IsSelected { get; set; }
        public int CO_ID { get; set; }
    }


}