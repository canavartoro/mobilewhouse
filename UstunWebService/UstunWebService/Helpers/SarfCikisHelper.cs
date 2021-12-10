using UstunWebService.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace UstunWebService.Helpers
{
    public class SarfCikisHelper
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string CostCenterCode(int whouseId, DataClient data)
        {
            try
            {
                var whouse = data.ExecuteScalar($@"select 
                                W.WHOUSE_ID ""WHOUSE_ID""
                                ,W.WHOUSE_CODE ""WHOUSE_CODE""
                                ,W.DESCRIPTION ""DESCRIPTION""
                                from INVD_WHOUSE W WHERE W.WHOUSE_ID = {whouseId} ");

                if (!object.ReferenceEquals(whouse,null))
                {
                    var revinifile = HttpContext.Current.Server.MapPath($"~/KarMerkezTanim.ini");
                    StringBuilder temp = new StringBuilder(255);
                    int i = GetPrivateProfileString("KARMERKEZ", whouse.ToString(), "", temp, 255, revinifile);
                    if (i == 0)
                    {
                        WritePrivateProfileString("KARMERKEZ", whouse.ToString(), "", revinifile);
                    }
                    return temp.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
            }
            finally
            {
            }
            return string.Empty;
        }
    }
}