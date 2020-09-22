using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo11.Entities
{
    [Table("drivers")]
    public class Conducteur : DbEntity
    {
        private string firstname;
        private string lastname;
        private List<Permi> permis;

        [Column("prenom")]
        public string Firstname { get => firstname; set => firstname = value; }
        [Column("nom")]
        public string Lastname { get => lastname; set => lastname = value; }
        public List<Permi> Permis { get => permis; set => permis = value; }
    }
}