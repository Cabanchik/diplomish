﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace diplomish
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bazedEntities1 : DbContext
    {
        public bazedEntities1()
            : base("name=bazedEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<branch> branch { get; set; }
        public virtual DbSet<company> company { get; set; }
        public virtual DbSet<file> file { get; set; }
        public virtual DbSet<gender> gender { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}
