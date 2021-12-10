using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace uTerminal.Classes
{
    /*
     Web Servislerde Enum değerleri o Dan başladığı için kullanılan enumlar yazıldı.
     * 
     * public enum ReservationType
    {        
        İş_Emri = 1,        
        Satış_Siparişi = 2
    }
            İken client da oluşan , Enum aşağıdaki gibi olmakta ve bizim değerlerimiz , aktarırmamaktadır.
            public enum ReservationType {
        
        /// <remarks/>
        İş_Emri,
        
        /// <remarks/>
        Satış_Siparişi,
    }

     * 
     * http://www.kerrywong.com/2006/11/09/be-careful-when-using-enums-in-web-services/
     */

    public enum ReservationType
    {
        İş_Emri = 1,
        Satış_Siparişi = 2
    }

    public enum PackageDetailType
    {
        A = 1,
        S = 2
    }

    public enum LineType
    {
        S = 1,
        M = 2,
        H = 3
    }

    public enum VatStatus
    {
        Dahil = 1,
        Hariç = 2
    }
    

}
