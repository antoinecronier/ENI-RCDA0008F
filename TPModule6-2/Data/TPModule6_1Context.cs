using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPModule6_2.Data
{
    public class TPModule6_2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public TPModule6_2Context() : base("name=TPModule6_2Context")
        {
            //if (this.Database.Exists() && !this.Database.CompatibleWithModel(true))
            //{
            //    this.Database.Delete();
            //    this.Database.Create();
            //}
        }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO.ArtMartial> ArtMartials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtMartials).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}
