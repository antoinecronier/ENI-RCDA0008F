using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule3.BO
{
    public class Facture
    {
        public Facture(Decimal montant, Auteur auteur)
        {
            this.Montant = montant;
            this.Auteur = auteur;
        }

        public Decimal Montant { get; set; }
        public Auteur Auteur { get; set; }
    }
}
