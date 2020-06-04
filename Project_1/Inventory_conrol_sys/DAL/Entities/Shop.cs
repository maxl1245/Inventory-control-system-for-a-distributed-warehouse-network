using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Shop
    {
        public int shop_id { get; set; }
        public string shop_address { get; set; }
        public string item_name { get; set; }
        public int item_amount { get; set; }
    }
}
