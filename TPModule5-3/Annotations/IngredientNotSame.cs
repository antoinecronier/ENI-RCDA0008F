using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPModule5_3.Models;
using TPModule5_3.Utils;

namespace TPModule5_3.Annotations
{
    public class IngredientNotSame : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Ces ingredients sont déjà utilisés";
        }

        public override bool IsValid(object value)
        {
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;

                if (FakeDb.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                {
                    result = false;
                }
            }

            return result;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;
                var vm = validationContext.ObjectInstance as PizzaViewModel;
                if (vm.Pizza != null && vm.Pizza.Id != 0)
                {
                    if (FakeDb.Instance.Pizzas.Where(x => x.Id != vm.Pizza.Id).Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                }
                else
                {
                    if (FakeDb.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                }
            }

            if (result == false)
            {
                return new ValidationResult("Ces ingredients sont déjà utilisés");
            }
            else
            {
                return null;
            }
        }
    }
}