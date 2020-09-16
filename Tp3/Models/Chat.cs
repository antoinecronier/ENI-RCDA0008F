using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_1.Utils;

namespace TPModule5_1.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public Couleur Couleur { get; set; }

        //public static List<Chat> GetMeuteDeChats()
        //{
        //    var i = 1;
        //    return new List<Chat>
        //    {
        //        new Chat{Id=i++,Nom = "Felix",Age = 3,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 1)},
        //        new Chat{Id=i++,Nom = "Minette",Age = 1,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 3)},
        //        new Chat{Id=i++,Nom = "Miss",Age = 10,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 2)},
        //        new Chat{Id=i++,Nom = "Garfield",Age = 6,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 1)},
        //        new Chat{Id=i++,Nom = "Chatran",Age = 4,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 2)},
        //        new Chat{Id=i++,Nom = "Minou",Age = 2,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 4)},
        //        new Chat{Id=i,Nom = "Bichette",Age = 12,Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == 1)},
        //    };
        //}
    }
}