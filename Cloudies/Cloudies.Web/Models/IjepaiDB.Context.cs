﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cloudies.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IjepaiEntities : DbContext
    {
        public IjepaiEntities()
            : base("name=IjepaiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<LabConfiguration> LabConfigurations { get; set; }
        public virtual DbSet<LabParticipant> LabParticipants { get; set; }
        public virtual DbSet<LabSoftware> LabSoftwares { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SoftwareList> SoftwareLists { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
