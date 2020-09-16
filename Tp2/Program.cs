using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule3.BO;
using TPModule3.Database;

namespace TPModule3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Example
            List<Livre> livres = FakeDb.Instance.ListeLivres.Where(x => x.Auteur.Nom.StartsWith("H")).ToList();
            Livre l1 = FakeDb.Instance.ListeLivres.FirstOrDefault();
            FakeDb.Instance.ListeLivres.Any();
            FakeDb.Instance.ListeLivres.All(x => x.NbPages > 0);
            //FakeDb.Instance.ListeLivres.ForEach((x)=> {  x.Id });

            List<string> livres1 = FakeDb.Instance.ListeLivres
                .Where(x => x.Auteur.Nom.StartsWith("H"))
                .Select(x => x.Synopsis).ToList();

            List<Auteur> auteurs = FakeDb.Instance.ListeLivres
                .Where(x => x.Auteur.Nom.StartsWith("H"))
                .Select(x => x.Auteur).ToList();

            List<Facture> factures = FakeDb.Instance.ListeLivres
                .Where(x => x.Auteur.Nom.StartsWith("H"))
                .Select(x => x.Auteur)
                .SelectMany(x => x.Factures)
                .Where(x => x.Montant > 0)
                .OrderBy(x => x.Auteur.Nom).ToList();
            #endregion

            // Afficher la liste des prénoms des auteurs dont le nom commence par "G"

            //FakeDb.Instance.ListeAuteurs.Where(a => a.Nom.Substring(0, 1).Equals("G"));
            //List<Auteur> auteursQ1 = FakeDb.Instance.ListeAuteurs
            //    .Where(a => a.Nom.StartsWith("G")).ToList();
            List<String> prenomAuteurQ1 = FakeDb.Instance.ListeAuteurs
                .Where(a => a.Nom.Substring(0, 1).Equals("G"))
                .Select(a => a.Prenom).ToList();

            Console.WriteLine("Q1 :");

            foreach (var prenomAuteur in prenomAuteurQ1)
            {
                Console.WriteLine(prenomAuteur);
            }

            Console.ReadKey();
            Console.WriteLine();

            //Afficher l’auteur ayant écrit le plus de livres
            //IGrouping<Auteur, Livre> auteurQ2 = FakeDb.Instance.ListeLivres
            //    .GroupBy(l => l.Auteur)
            //    .OrderByDescending(g => g.Count())
            //    .FirstOrDefault();

            //FakeDb.Instance.ListeLivres
            //    .GroupBy(l => l.Auteur).Max(x => x.Count()

            //IEnumerable <IGrouping <Auteur, Livre>> auteurQ2 = FakeDb.Instance.ListeLivres
            //    .GroupBy(l => l.Auteur)
            //    .Where(g => g.Count() == FakeDb.Instance.ListeLivres
            //      .GroupBy(l => l.Auteur).Max(x => x.Count()));

            //foreach (var item in auteurQ2)
            //{
            //    Console.WriteLine($"{item.Key.Nom} {item.Key.Prenom}");
            //}

            IGrouping<Auteur, Livre> auteurQ2 = FakeDb.Instance.ListeLivres
                .GroupBy(l => l.Auteur)
                .OrderByDescending(g => g.Count()).FirstOrDefault();


            //IGrouping<Auteur, Livre> auteurQ2 = FakeDb.Instance.ListeLivres
            //    .GroupBy(l => l.Auteur)
            //    .FirstOrDefault(g => g.Count() == l.Max(g.Count());

            Console.WriteLine("Q2 :");
            Console.WriteLine($"{auteurQ2.Key.Nom} {auteurQ2.Key.Prenom}");

            Console.ReadKey();
            Console.WriteLine();

            //Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine("Q3 :");
            foreach (IGrouping<Auteur,Livre> groupingAuteurLivre in FakeDb.Instance.ListeLivres.GroupBy(l => l.Auteur))
            {
                Console.WriteLine($"{groupingAuteurLivre.Key.Nom} {groupingAuteurLivre.Key.Prenom}");
                Console.WriteLine($"Moyenne des pages = {groupingAuteurLivre.Average(l => l.NbPages)}");
            }

            //FakeDb.Instance.ListeLivres.GroupBy(l => l.Auteur).ToList().ForEach((s) => 
            //{
            //    Console.WriteLine($"{s.Key.Nom} {s.Key.Prenom}");
            //    Console.WriteLine($"Moyenne des pages = {s.Average(l => l.NbPages)}");
            //});

            Console.ReadKey();
            Console.WriteLine();

            //Afficher le titre du livre avec le plus de pages
            //FakeDb.Instance.ListeLivres.Max(x => x.NbPages)
            Livre livreQ4 = FakeDb.Instance.ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine("Q4 :");
            Console.WriteLine($"Livre avec le maximum de page : {livreQ4.Titre}");

            Console.ReadKey();
            Console.WriteLine();

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            decimal moyenneQ5 = FakeDb.Instance.ListeAuteurs
                .Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine("Q5 :");
            Console.WriteLine($"Moyenne des sommes gagnés par les auteurs : {moyenneQ5}");
            // A modifier
            Console.ReadKey();
            Console.WriteLine();

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) // par auteur
            Console.WriteLine("Q5 bis :");
            FakeDb.Instance.ListeAuteurs.ForEach(x => {
                var montant = x.Factures.Count > 0 ? x.Factures.Average(y => y.Montant) : 0;
                Console.WriteLine($"Moyenne des factures pour {x.Nom} {x.Prenom} = {montant}");
            });

            // A modifier
            Console.ReadKey();
            Console.WriteLine();

            //Afficher les auteurs et la liste de leurs livres
            //foreach (var item in FakeDb.Instance.ListeAuteurs)
            //{
            //    foreach (var livre in FakeDb.Instance.ListeLivres)
            //    {
            //        if (livre.Auteur.Equals(item))
            //        {

            //        }
            //    }
            //}

            Console.WriteLine("Q6 :");
            var groupingAuteurLivreQ6s = FakeDb.Instance.ListeLivres.GroupBy(l => l.Auteur);
            foreach (var auteurAvecLivres in groupingAuteurLivreQ6s)
            {
                Console.WriteLine($"{auteurAvecLivres.Key.Nom} {auteurAvecLivres.Key.Prenom}");
                foreach (var livre in auteurAvecLivres)
                {
                    Console.WriteLine($"Livre : {livre.Titre}");
                }
            }

            Console.ReadKey();
            Console.WriteLine();

            // Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine("Q7 :");
            //Func<string, string> f1 = (item) => 
            //{
            //    return item; 
            //};
            // t => t
            List<String> titreQ7s = FakeDb.Instance.ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList();
            foreach (var item in titreQ7s)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            titreQ7s.ForEach((s) =>
            {
                Console.WriteLine(s);
            });

            Console.WriteLine();
            titreQ7s.ForEach(Console.WriteLine);

            Console.ReadKey();
            Console.WriteLine();

            // Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            double nbPageMoyenneQ8 = FakeDb.Instance.ListeLivres.Average(l => l.NbPages);
            //List<Livre> livresQ8 = FakeDb.Instance.ListeLivres.Where(l => l.NbPages > nbPageMoyenneQ8).ToList();

            Console.WriteLine("Q8 :");
            FakeDb.Instance.ListeLivres.Where(l => l.NbPages > nbPageMoyenneQ8)
                .ToList().ForEach((l) =>
                {
                    Console.WriteLine(l.Titre);
                });

            Console.ReadKey();
            Console.WriteLine();

            // Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("Q9 :");
            Auteur auteurQ9 = FakeDb.Instance.ListeAuteurs
                .OrderBy(a => FakeDb.Instance.ListeLivres.Count(l => l.Auteur == a))
                .FirstOrDefault();
            Console.WriteLine($"{auteurQ9.Nom} {auteurQ9.Prenom}");

            Console.ReadKey();
        }
    }
}
