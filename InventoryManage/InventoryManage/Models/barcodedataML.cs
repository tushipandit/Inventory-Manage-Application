using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManage.Models
{
    public class barcodedataML
    {

        public long ID { get; set; }
        public string Barcode { get; set; }
        public Nullable<long> Rid { get; set; }
        public Nullable<long> Rcol { get; set; }

    }
}