using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPModule5_1.Models
{
    public class ChatCreateViewModel
    {
        public Chat Chat { get; set; }
        public List<Couleur> Couleurs { get; set; }
        public int IdCouleur { get; set; }
    }
}