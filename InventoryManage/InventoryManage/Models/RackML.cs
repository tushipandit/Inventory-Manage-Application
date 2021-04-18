using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManage.Models
{
    public class RackML
    {

        public long Id { get; set; }
        public string Category { get; set; }
        public string description { get; set; }
        public Nullable<long> weightid { get; set; }
    }
}