using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo10.Models
{
    public class Class2 : DbEntity
    {
        private string prop1;

        public virtual Class1 Class1 { get; set; }
        public string Prop1 { get => prop1; set => prop1 = value; }
    }
}