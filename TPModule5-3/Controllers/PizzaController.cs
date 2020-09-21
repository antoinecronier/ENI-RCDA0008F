using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_3.Models;
using TPModule5_3.Utils;
using TPModule5_3_BO;
using TPModule5_3.Annotations;

namespace TPModule5_3.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Pizzas);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                if (ModelState.IsValid && /*this.ValidateVM(vm)*/vm.Validate(ModelState, FakeDb.Instance.Pizzas))
                {
                    Pizza pizza = vm.Pizza;

                    pizza.Pate = FakeDb.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);

                    pizza.Ingredients = FakeDb.Instance.IngredientsDisponible.Where(
                        x => vm.IdsIngredients.Contains(x.Id))
                        .ToList();

                    pizza.Id = FakeDb.Instance.Pizzas.Count == 0 ? 1 : FakeDb.Instance.Pizzas.Max(x => x.Id) + 1;

                    FakeDb.Instance.Pizzas.Add(pizza);

                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                    vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                        .ToList();

                    return View(vm);
                }
            }
            catch(Exception e)
            {
                vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                    x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                    .ToList();

                return View(vm);
            }
        }

       private bool ValidateVM(PizzaViewModel vm)
        {
            bool result = true;

            if (vm.IdsIngredients.Count < 2 || vm.IdsIngredients.Count > 5)
            {
                ModelState.AddModelError("IdsIngredients", "Il faut sélectionner entre 2 et 5 ingredients");
                result = false;
            }

            if (FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Nom == vm.Pizza.Nom) != null)
            {
                ModelState.AddModelError("Pizza.Nom.AlreadyExists", "Il existe déjà une pizza avec ce nom");
                result = false;
            }

            //foreach (var pizza in FakeDb.Instance.Pizzas)
            //{
            //    if (vm.IdsIngredients.Count == pizza.Ingredients.Count)
            //    {
            //        bool isDifferent = false;
            //        List<Ingredient> pizzaDb = pizza.Ingredients.OrderBy(x => x.Id).ToList();
            //        vm.IdsIngredients = vm.IdsIngredients.OrderBy(x => x).ToList();
            //        for (int i = 0; i < vm.IdsIngredients.Count; i++)
            //        {
            //            if (vm.IdsIngredients.ElementAt(i) != pizzaDb.ElementAt(i).Id)
            //            {
            //                isDifferent = true;
            //                break;
            //            }
            //        }
            //
            //        if (!isDifferent)
            //        {
            //            ModelState.AddModelError("Ingredient.AlreadyExists", "Il existe déjà une pizza avec ces ingredients");
            //            result = false;
            //        }
            //    }
            //}
            if (FakeDb.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(vm.IdsIngredients.OrderBy(z => z))))
            {
                ModelState.AddModelError("Ingredient.AlreadyExists", "Il existe déjà une pizza avec ces ingredients");
                result = false;
            }
            return result;
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = FakeDb.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDb.Instance.IngredientsDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDb.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDb.Instance.IngredientsDisponible.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }
    }
}
