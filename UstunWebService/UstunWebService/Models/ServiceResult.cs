using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            this.Success = false;
            this.ErrorMessage = "";
        }

        public ServiceResult(bool success)
        {
            this.Success = success;
        }

        public ServiceResult(bool success, string message)
        {
            this.Success = success;
            this.ErrorMessage = message;
        }

        public ServiceResult(string message)
        {
            this.Success = false;
            this.ErrorMessage = message;
        }

        public ServiceResult(Exception exception)
        {
            this.Success = false;
            this.ErrorMessage = exception.Message;
        }

        public T Result { get; set; }
        public string ErrorMessage { get; set; } = "";
        public bool Success { get; set; }

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