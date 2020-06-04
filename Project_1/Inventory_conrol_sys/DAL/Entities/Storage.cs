using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Storage
    {
        public int storage_id { get; set; }
        public string storage_address { get; set; }
        public string item_name { get; set; }
        public int item_amount { get; set; }
    }
}
