using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo10.Models
{
    public class Class2VM
    {
        public Class2 Class2 { get; set; }
        public List<Class1> Class1s { get; set; }
        public int? Class1Id { get; set; }
    }
}