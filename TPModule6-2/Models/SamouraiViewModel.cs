using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPModule6_2.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdSelectedArme { get; set; }
        public List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        public List<int> ArtMartialsIds { get; set; } = new List<int>();
    }
}