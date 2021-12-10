using UstunWebService.Process.Objects;
using UstunWebService.Process.Params;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class BaseMethod<T> where T : ServiceParam
    {
        protected bool versiyon = false;
        protected T serviceparam;
        protected HttpResponse Response;
        protected HttpRequest Request;
        protected HttpContext Context;
        protected UTerminalService.UTerminalServices utermService;
        protected Prod.Production productionService = null;
        protected MobileWhouseService.MobileWhouse mobileWhouse = null;

        public UTerminalService.UTerminalServices GetUTerminalService()
        {
            if (utermService == null)
            {
                utermService = new UTerminalService.UTerminalServices();
                string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
                if (string.IsNullOrWhiteSpace(url)) url = @"http://hyperv01:1120/WebService/General/GeneralSenfoniService.asmx";
                if (!url.ToLower().Contains("uterminalservices"))
                {
                    if (url.EndsWith("/")) url = string.Concat(url, "webservice/trm/uterminalservices.asmx");
                    else
                        url = string.Concat(url, "/webservice/trm/uterminalservices.asmx");
                }
                utermService.Url = url;
                utermService.Timeout = 999999;
            }
            return utermService;
        }

        public Prod.Production GetProductionService()
        {
            if (productionService == null)
            {
                productionService = new Prod.Production();
                string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
                if (string.IsNullOrWhiteSpace(url)) url = @"http://oratest.ofis.uyumcloud.com/WebService/MW/Production.asmx";
                if (!url.ToLower().Contains("production"))
                {
                    if (url.EndsWith("/")) url = string.Concat(url, "WebService/MW/Production.asmx");
                    else
                        url = string.Concat(url, "/WebService/MW/Production.asmx");
                }
                productionService.Url = url;
                productionService.Timeout = 999999;
            }
            return productionService;
        }

        public MobileWhouseService.MobileWhouse GetMobileWhouse()
        {
            if (mobileWhouse == null)
            {
                mobileWhouse = new MobileWhouseService.MobileWhouse();
                string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
                if (string.IsNullOrWhiteSpace(url)) url = @"http://oratest.ofis.uyumcloud.com/WebService/MW/Production.asmx";
                if (!url.ToLower().Contains("production"))
                {
                    if (url.EndsWith("/")) url = string.Concat(url, "WebService/MW/MobileWhouse.asmx");
                    else
                        url = string.Concat(url, "/WebService/MW/MobileWhouse.asmx");
                }
                mobileWhouse.Url = url;
                mobileWhouse.Timeout = 999999;
            }
            return mobileWhouse;
        }

        protected string Action { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        private Stopwatch stopwatch = null;
        public long Memory { get; private set; }
        public long TotalMemory { get; private set; }
        public long ElapsedTime { get; private set; }
        public string LogText { get; private set; }

        public BaseMethod() { }

        public BaseMethod(HttpContext context)
        {
            Request = context.Request;
            Response = context.Response;
            Context = context;
        }

        public JsonObject<string> IsValidate()
        {
            if (serviceparam == null)
            {
                LoginParam();
            }
            if (serviceparam == null)
            {
                return new JsonObject<string>()
                {
                    Values = "",
                    Message = "Oturum açılmadı! Güvenlik hatası. (1)",
                    Status = false,
                    Version = true
                };
            }

            if (serviceparam.Token == null)
            {
                return new JsonObject<string>()
                {
                    Status = false,
                    Message = "Oturum açılmadı! Güvenlik hatası (2)."
                };
            }

            return null;
        }

        public bool IsLogin
        {
            get
            {
                if (serviceparam == null)
                {
                    LoginParam();
                }
                return serviceparam != null && serviceparam.Token != null;
            }
        }

        public bool IsVersiyoned
        {
            get
            {
                if (serviceparam == null)
                {
                    LoginParam();
                }
                return false;
            }
        }

        protected void LoginParam()
        {
            if (Request != null && Request.InputStream != null)
            {
                using (var sr = new StreamReader(Request.InputStream, System.Text.Encoding.UTF8, true)) // 1254 OLD
                {
                    string str = sr.ReadToEnd();
                    var settings = new JsonSerializerSettings();
                    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    serviceparam = JsonConvert.DeserializeObject<T>(str);
                }
            }
        }

        public virtual string Execute()
        {
            throw new NotImplementedException();
        }

        public string Run()
        {
            this.StartTime = DateTime.Now;
            this.TotalMemory = GC.GetTotalMemory(true);
            stopwatch = Stopwatch.StartNew();

            Action = Request.QueryString["action"];

            var data = this.Execute();

            this.EndTime = DateTime.Now;
            stopwatch.Stop();
            this.Memory = GC.GetTotalMemory(true);
            this.ElapsedTime = this.stopwatch.ElapsedMilliseconds;

            this.LogText = string.Concat("Start: ", this.StartTime, ", End: ", this.EndTime, ", Memory-1: ", this.Memory, " Memory-2: ", this.TotalMemory, ", ElapsedMillisecond:", this.stopwatch.ElapsedMilliseconds);
            System.Diagnostics.Trace.WriteLine(this.LogText);

            return data;
        }

        protected void AppendHeader()
        {
            Context.Response.AppendHeader("Content-encoding", "gzip");
            Context.Response.Filter = new GZipStream(Context.Response.Filter, CompressionMode.Compress);
            Context.Response.AppendHeader("Content-Encoding", "gzip");
        }

        //protected string toStringWithCompress(object value)
        //{
        //    using (var memStream = new MemoryStream())
        //    {
        //        var data = new DataContractJsonSerializer(typeof(JsonObject));
        //        data.WriteObject(memStream, value);
        //        memStream.Position = 0;
        //        var contentToPost = new StreamContent(this.Compress(memStream));
        //        contentToPost.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //        contentToPost.Headers.Add("Content-Encoding", "gzip");

        //    }
        //    return "";
        //}

        private MemoryStream Compress(MemoryStream ms)
        {
            byte[] buffer = new byte[ms.Length];
            // Use the newly created memory stream for the compressed data.
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(buffer, 0, buffer.Length);
            // Close the stream.
            compressedzipStream.Close();
            MemoryStream ms1 = new MemoryStream(buffer);
            return ms1;
        }
    }
}