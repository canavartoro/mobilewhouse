using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse
{
    public sealed class Statics
    {
        public const int OPERASYONELURETIMGIRIS = 10;
        public const int ELTERMINALIURETIMGIRISI = 80;
        public const int USTUN_WCENTER_ID = 249; //Ü-01
        public const string DECIMAL_STRING_FORMAT = "0.#####";
        //public const string DECIMAL_STRING_FORMAT = "0,000.#####";
        //public const string DECIMAL_STRING_FORMAT = "#,###.#####";

        //public const string SqlConnectionString = @"server=TPPSSERVER,1433;database=BARKODTKP;uid=sa;password=22121984;Connect Timeout=10;MultipleActiveResultSets=True;";
        public const string SqlConnectionString = @"data source=10.0.0.73,1433;database=BARKODTKP;User Id=sa;Password=22121984;";

        public static List<string> Printers = null;
        public static List<string> Designs = null;
    }
}
