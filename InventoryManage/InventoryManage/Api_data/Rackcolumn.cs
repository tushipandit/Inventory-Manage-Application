//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManage.Api_data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rackcolumn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rackcolumn()
        {
            this.barcodedatas = new HashSet<barcodedata>();
        }
    
        public long Id { get; set; }
        public Nullable<long> colorid { get; set; }
        public Nullable<long> sizeid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<barcodedata> barcodedatas { get; set; }
        public virtual color color { get; set; }
        public virtual size size { get; set; }
    }
}
