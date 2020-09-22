using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo11.Entities
{
    public class Permi : DbEntity
    {
        private string name;
        private int points;

        public string Name { get => name; set => name = value; }
        public int Points { get => points; set => points = value; }
    }
}