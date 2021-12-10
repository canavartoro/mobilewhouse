using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Params
{
    public class LoginParam
    {
        public string userid { get; set; }
        public string username { get; set; }
        public bool status { get; set; }
        public string mesaj { get; set; }
        public double masterno { get; set; }
        public string versiyon { get; set; }
        public string token { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
        }
    }
}