using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_3_BO;

namespace TPModule5_3.Utils
{
    public class FakeDb
    {
        private static FakeDb _instance;
        static readonly object instanceLock = new object();

        private FakeDb()
        {
            this.IngredientsDisponible = this.InitIngredientsDisponibles();
            this.PatesDisponible = this.InitPatesDisponibles();
            this.Pizzas = new List<Pizza>();
        }

        public static FakeDb Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDb();
                    }
                }
                return _instance;
            }
        }

        private List<Ingredient> ingredients;

        public List<Ingredient> IngredientsDisponible
        {
            get { return ingredients; }
            private set { this.ingredients = value; }
        }

        private List<Pate> pates;

        public List<Pate> PatesDisponible
        {
            get { return pates; }
            private set { this.pates = value; }
        }

        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
            private set { pizzas = value; }
        }


        private List<Ingredient> InitIngredientsDisponibles()
        {
            List<Ingredient> result = new List<Ingredient>();
            result.Add(new Ingredient { Id = 1, Nom = "Mozzarella" });
            result.Add(new Ingredient { Id = 2, Nom = "Jambon" });
            result.Add(new Ingredient { Id = 3, Nom = "Tomate" });
            result.Add(new Ingredient { Id = 4, Nom = "Oignon" });
            result.Add(new Ingredient { Id = 5, Nom = "Cheddar" });
            result.Add(new Ingredient { Id = 6, Nom = "Saumon" });
            result.Add(new Ingredient { Id = 7, Nom = "Champignon" });
            result.Add(new Ingredient { Id = 8, Nom = "Poulet" });

            return result;
        }

        private List<Pate> InitPatesDisponibles()
        {
            List<Pate> result = new List<Pate>();
            result.Add(new Pate { Id = 1, Nom = "Pate fine, base crême" });
            result.Add(new Pate { Id = 2, Nom = "Pate fine, base tomate" });
            result.Add(new Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            result.Add(new Pate { Id = 4, Nom = "Pate épaisse, base tomate" });

            return result;
        }
    }
}