using Demo2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Personne p1 = new Personne();
            p1.Age = 10;
            p1.Nom = "oazkepkaz";
            p1.Prenom = "oziejoiazk;";

            Console.WriteLine(p1);

            Personne p2 = new Personne { Age = 12, Nom = "pokazpokepa", Prenom = "zapkeôkazp" };

            Console.WriteLine(p2);

            Personne p3 = new Personne("pkpokpok", "bxwchbkaj", 62);

            Console.WriteLine(p3);

            Console.ReadKey();

            p2 = p3;
        }
    }
}
