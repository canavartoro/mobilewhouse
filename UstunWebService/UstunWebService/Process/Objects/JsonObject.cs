using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Objects
{
    public class JsonObject<T>
    {
        public JsonObject()
        {
            Values = default(T);
            Version = true;
        }

        public bool Status { get; set; }
        public bool Version { get; set; }
        public string Message { get; set; }
        public int RowCount { get; set; }
        public T Values { get; set; }
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.Default,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
                    DateFormatString = "yyyy-MM-dd"
                });
        }
    }
}