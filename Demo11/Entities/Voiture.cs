using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo11.Entities
{
    [Table("cars")]
    public class Voiture : DbEntity
    {
        private string name;
        private Conducteur driver;
        private List<Conducteur> drivers;

        public string Name { get => name; set => name = value; }
        public Conducteur Driver { get => driver; set => driver = value; }
        public List<Conducteur> Drivers { get => drivers; set => drivers = value; }
    }
}