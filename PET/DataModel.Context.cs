﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PET
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PETEksameEntities : DbContext
    {
        public PETEksameEntities()
            : base("name=PETEksameEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Informants> Informants { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Nationalities> Nationalities { get; set; }
        public virtual DbSet<Observants> Observants { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Valutas> Valutas { get; set; }
    }
}