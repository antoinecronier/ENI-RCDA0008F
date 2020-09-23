using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class Samourai : BaseDbEntity
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();

        [NotMapped]
        [DisplayName("Mon super potentiel")]
        public int Potentiel
        {
            get {
                int potentiel = this.Force;
                if (this.Arme != null)
                {
                    potentiel += this.Arme.Degats;
                }
                potentiel *= (this.ArtMartials.Count + 1);
                return  potentiel; 
            }
        }

    }
}
