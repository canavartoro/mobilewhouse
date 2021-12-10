using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    public class invd_item
    {
        public invd_item() { }

        public int item_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public int unit_id { get; set; }
        public string unit_code { get; set; }
    }
}
