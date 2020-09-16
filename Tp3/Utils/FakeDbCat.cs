using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_1.Models;

namespace TPModule5_1.Utils
{
    public class FakeDbCat
    {
        private static FakeDbCat _instance;
        static readonly object instanceLock = new object();

        private FakeDbCat()
        {
            chats = this.GetMeuteDeChats();
        }

        public static FakeDbCat Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbCat();
                    }
                }
                return _instance;
            }
        }

        private List<Chat> chats;

        public List<Chat> Chats
        {
            get { return chats; }
        }

        private List<Chat> GetMeuteDeChats()
        {
            var i = 1;
            return new List<Chat>
            {
                new Chat{Id=i++,Nom = "Felix",Age = 3,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 1)},
                new Chat{Id=i++,Nom = "Minette",Age = 1,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 3)},
                new Chat{Id=i++,Nom = "Miss",Age = 10,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 2)},
                new Chat{Id=i++,Nom = "Garfield",Age = 6,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 1)},
                new Chat{Id=i++,Nom = "Chatran",Age = 4,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 2)},
                new Chat{Id=i++,Nom = "Minou",Age = 2,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 4)},
                new Chat{Id=i,Nom = "Bichette",Age = 12,Couleur = this.Couleurs.FirstOrDefault(x => x.Id == 1)},
            };
        }

        public List<Couleur> Couleurs { get; } = new List<Couleur>() 
        {
            new Couleur() { Id = 1, Name = "Blanc" },
            new Couleur() { Id = 2, Name = "Noir" },
            new Couleur() { Id = 3, Name = "Rouge" },
            new Couleur() { Id = 4, Name = "Bleu" },
        };
    }
}