﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDSampleAppEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CRUDSampleEntities : DbContext
    {
        public CRUDSampleEntities()
            : base("name=CRUDSampleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblCatalog> tblCatalogs { get; set; }
        public DbSet<tblCatalogType> tblCatalogTypes { get; set; }
        public DbSet<tblDetail> tblDetails { get; set; }
        public DbSet<tblStudent> tblStudents { get; set; }
        public DbSet<tblContactDetail> tblContactDetails { get; set; }
    }
}