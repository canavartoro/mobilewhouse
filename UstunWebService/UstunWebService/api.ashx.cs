using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace UstunWebService
{
    /// <summary>
    /// Summary description for api1
    /// </summary>
    public class api : IRequiresSessionState, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string value = string.Empty;
            try
            {
                string action = context.Request.QueryString["action"];

                if (!string.IsNullOrWhiteSpace(action))
                {
                    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        if (action.IndexOf("method", StringComparison.OrdinalIgnoreCase) == -1)
                            action = string.Concat(action, "Method");

                        var type = asm.GetType(string.Format("UstunWebService.Process.Action.{0}", action));
                        if (type != null)
                        {
                            object[] args = { context };
                            ConstructorInfo constructor = null;
                            object instance = null;
                            ConstructorInfo[] constructors = type.GetConstructors();
                            if (constructors != null && constructors.Length > 0)
                            {
                                foreach (ConstructorInfo cns in constructors)
                                {
                                    ParameterInfo[] param = cns.GetParameters();
                                    if (param != null && param.Length == 1 && param[0].ParameterType.Name.Equals("HttpContext"))
                                        constructor = cns;
                                }
                            }
                            if (constructor != null)
                            {
                                instance = constructor.Invoke(args);
                            }
                            else
                            {
                                instance = Activator.CreateInstance(type);
                            }
                            var method = type.GetMethod("Run", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public);
                            if (method != null) value = method.Invoke(instance, null).ToString();
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(value))
                    {
                        Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(string.Concat("Method bulunamadı (", action, ")")).ToString());
                        value = new JsonObject<string>()
                        {
                            Status = false,
                            Message = string.Concat("Method bulunamadı (", action, ")"),
                            Values = ""
                        }.ToString();
                    }
                }
                else
                {
                    Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append("Parametre gerekli (action)").ToString());
                    value = new JsonObject<string>()
                    {
                        Status = false,
                        Message = "Parametre gerekli (action)",
                        Values = ""
                    }.ToString();
                }

            }
            catch (NullReferenceException nullexc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(nullexc.Message).Append("Detay:").Append(nullexc.StackTrace).ToString());
                value = new JsonObject<string>()
                {
                    Status = false,
                    Message = nullexc.Message,
                    Values = nullexc.StackTrace
                }.ToString();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                value = new JsonObject<string>()
                {
                    Status = false,
                    Message = exc.Message,
                    Values = exc.StackTrace
                }.ToString();
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(value);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}