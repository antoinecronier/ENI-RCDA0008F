using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TpModule6Bo;

namespace TPModule6_1.Data
{
    public class TPModule6_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TPModule6_1Context() : base("name=TPModule6_1Context")
        {
        }

        public System.Data.Entity.DbSet<Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<Samourai> Samourais { get; set; }
    }
}
