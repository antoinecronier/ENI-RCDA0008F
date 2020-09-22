using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpModule6Bo;

namespace TPModule6_1.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdSelectedArme { get; set; }
    }
}