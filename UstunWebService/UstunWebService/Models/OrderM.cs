using UstunWebService.SenfoniGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class OrderM
    {
        public int OrderMId { get; set; }

        public string DocNo { get; set; }

        public DateTime DocDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Note1 { get; set; }

        public string Note2 { get; set; }

        public string Note3 { get; set; }


    }
}