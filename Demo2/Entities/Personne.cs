using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Entities
{
    public class Personne : ICloneable
    {
        private static int globalId = 0;
        private int id;
        private string prenom;
        private String nom;
        private int age;

        public int Id { get => id; private set => id = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Age { get => age; set => age = value; }

        public Personne()
        {
            globalId++;
            id = globalId;
        }

        public Personne(string prenom, string nom) : this()
        {
            this.prenom = prenom;
            this.nom = nom;
        }

        public Personne(string prenom, string nom, int age) : this(prenom, nom)
        {
            this.age = age;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}",this.Id, this.Age, this.Nom, this.Prenom);
        }

        public object Clone()
        {
            return new Personne { Age = this.Age, Id = this.Id, Nom = this.Nom, Prenom = this.Prenom };
        }
    }
}
