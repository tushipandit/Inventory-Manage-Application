﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InventoryDBEntities : DbContext
    {
        public InventoryDBEntities()
            : base("name=InventoryDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<barcodedata> barcodedatas { get; set; }
        public virtual DbSet<color> colors { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Rack> Racks { get; set; }
        public virtual DbSet<Rackcolumn> Rackcolumns { get; set; }
        public virtual DbSet<size> sizes { get; set; }
        public virtual DbSet<weight> weights { get; set; }
    }
}
