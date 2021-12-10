using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService
{
    public class Token
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchDesc { get; set; }
        public int CoId { get; set; }
        public string CoCode { get; set; }
        public string CoDesc { get; set; }
        public int WhouseId { get; set; }
        public string WhouseCode { get; set; }
        public string WhouseDesc { get; set; }
        public string appVersionNo { get; set; }
        public string appVersionFtp { get; set; }

        public static explicit operator SenfoniGS.Token(Token token)
        {
            if (token == null) return null;

            SenfoniGS.Token tokenNew = new SenfoniGS.Token();
            tokenNew.BranchCode = token.BranchCode;
            tokenNew.BranchDesc = token.BranchDesc;
            tokenNew.BranchId = token.BranchId;
            tokenNew.CoId = token.CoId;
            tokenNew.DeviceId = "";
            tokenNew.Password = token.Password;
            tokenNew.UserName = token.Username;
            return tokenNew;
        }

        public static implicit operator MobileWhouseService.Token(Token token)
        {
            if (token == null) return null;
            MobileWhouseService.Token tokenNew = new MobileWhouseService.Token();
            tokenNew.BranchCode = token.BranchCode;
            tokenNew.BranchDesc = token.BranchDesc;
            tokenNew.BranchId = token.BranchId;
            tokenNew.CoId = token.CoId;
            tokenNew.DeviceId = "";
            tokenNew.Password = token.Password;
            tokenNew.UserName = token.Username;
            return tokenNew;
        }

        public static explicit operator UTerminalService.Token(Token token)
        {
            if (token == null) return null;
            UTerminalService.Token tokenNew = new UTerminalService.Token();
            tokenNew.BranchCode = token.BranchCode;
            tokenNew.BranchDesc = token.BranchDesc;
            tokenNew.BranchId = token.BranchId;
            tokenNew.CoId = token.CoId;
            tokenNew.DeviceId = "";
            tokenNew.Password = token.Password;
            tokenNew.UserName = token.Username;
            return tokenNew;
        }

        public static explicit operator Prod.Token(Token token)
        {
            if (token == null) return null;
            Prod.Token tokenNew = new Prod.Token();
            tokenNew.BranchCode = token.BranchCode;
            tokenNew.BranchDesc = token.BranchDesc;
            tokenNew.BranchId = token.BranchId;
            tokenNew.CoId = token.CoId;
            tokenNew.DeviceId = "";
            tokenNew.Password = token.Password;
            tokenNew.UserName = token.Username;
            return tokenNew;
        }

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