using UstunWebService.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using UstunWebService.Data;

namespace UstunWebService.Helpers
{
    public class LoginHelper
    {
        public string Login(string Username, string Password, DataClient data)
        {
            ServiceResult<Token> tokenResult = new ServiceResult<Token>();
            try
            {

                tokenResult.Success = false;
                tokenResult.ErrorMessage = string.Format("0|Kullanıcı bulunamadı. UserName : {0}",
                        Username);

                string text = string.Format(@"SELECT cast(t.us_id as int) us_id,t.us_username,t.us_password FROM USERS t WHERE t.us_username = '{0}' AND t.Us_Password = '{1}'  AND t.us_enabled = 1
                                                 ", Username, Password);
                //EventLog.WriteEntry("Application", text, EventLogEntryType.Information, 23345);
                string appVersionNo = ConfigurationManager.AppSettings["appVersionNo"].ToString();
                string appVersionFtp = ConfigurationManager.AppSettings["appVersionFtp"].ToString();
                using (IDataReader reader = data.Select(text))
                {
                    if (reader.Read())
                    {
                        tokenResult.Success = true;
                        tokenResult.Result = new Token();
                        Token token = new Token();
                        tokenResult.Result.Username = Username;
                        tokenResult.Result.Password = Password;
                        tokenResult.Result.UserId = Convert.ToInt32(reader["US_ID"].ToString());
                        tokenResult.Result.appVersionNo = appVersionNo;
                        tokenResult.Result.appVersionFtp = appVersionFtp;
                    }
                    if (reader != null)
                    {
                        reader.Close();
                        reader.Dispose();
                    }
                }
                if (tokenResult.Success)
                {
                    using (IDataReader reader = data.Select($@"SELECT BRANCH_PROFILE.CO_ID,COMPANY.CO_CODE,COMPANY.CO_DESC,BRANCH_PROFILE.BRANCH_ID, BRANCH.BRANCH_CODE, BRANCH.BRANCH_DESC, BRANCH_PROFILE.WHOUSE_ID,WHOUSE.WHOUSE_CODE,WHOUSE.DESCRIPTION 
FROM UYUMSOFT.GNLD_PROFILE PROFILE INNER JOIN 
UYUMSOFT.GNLP_BRANCH_PROFILE BRANCH_PROFILE ON PROFILE.PROFILE_ID = BRANCH_PROFILE.PROFILE_ID INNER JOIN
UYUMSOFT.GNLD_BRANCH BRANCH ON BRANCH_PROFILE.BRANCH_ID = BRANCH.BRANCH_ID INNER JOIN 
UYUMSOFT.INVD_WHOUSE WHOUSE ON BRANCH_PROFILE.WHOUSE_ID = WHOUSE.WHOUSE_ID INNER JOIN
UYUMSOFT.GNLD_COMPANY COMPANY ON COMPANY.CO_ID = BRANCH_PROFILE.CO_ID
WHERE PROFILE.PROFILE_CODE = '{Username}'  {QueryHelper.GetLimitCommand(data.Connection)}"))
                    {
                        if (reader.Read())
                        {
                            tokenResult.Result.CoId = Convert.ToInt32(reader["CO_ID"].ToString());
                            tokenResult.Result.CoCode = reader["CO_CODE"].ToString();
                            tokenResult.Result.CoDesc = reader["CO_DESC"].ToString();
                            tokenResult.Result.BranchId = Convert.ToInt32(reader["BRANCH_ID"].ToString());
                            tokenResult.Result.BranchCode = reader["BRANCH_CODE"].ToString();
                            tokenResult.Result.BranchDesc = reader["BRANCH_DESC"].ToString();
                            tokenResult.Result.WhouseId = Convert.ToInt32(reader["WHOUSE_ID"].ToString());
                            tokenResult.Result.WhouseCode = reader["WHOUSE_CODE"].ToString();
                            tokenResult.Result.WhouseDesc = reader["DESCRIPTION"].ToString();
                        }
                        if (reader != null)
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                    }
                }


                return JsonConvert.SerializeObject(tokenResult);
            }
            catch (Exception ex)
            {
                tokenResult.Success = false;
                tokenResult.ErrorMessage = ex.Message;
            }
            finally
            {
            }

            return JsonConvert.SerializeObject(tokenResult);
        }
    }
}