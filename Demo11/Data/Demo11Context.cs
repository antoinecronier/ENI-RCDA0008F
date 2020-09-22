using Demo11.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Demo11.Data
{
    public class Demo11Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Demo11Context() : base("name=Demo11Context")
        {
        }

        public System.Data.Entity.DbSet<Demo11.Entities.Conducteur> Conducteurs { get; set; }

        public System.Data.Entity.DbSet<Demo11.Entities.Voiture> Voitures { get; set; }

        public System.Data.Entity.DbSet<Demo11.Entities.Permi> Permis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voiture>().HasRequired(x => x.Driver).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Voiture>().HasMany(x => x.Drivers).WithMany();
            modelBuilder.Entity<Conducteur>().HasMany(x => x.Permis);
        }
    }
}
