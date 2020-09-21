using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_3.Annotations;
using TPModule5_3.Utils;
using TPModule5_3_BO;

namespace TPModule5_3.Models
{
    public class PizzaViewModel
    {
        [Checker(new string[] { "Nom" }, Checker.CheckerAction.Length, Checker.CheckerAction.Required, Checker.CheckerAction.DatasOccurs, LengthMin = 5, LengthMax = 25, OccurMin = 0, OccurMax = 0)]
        public Pizza Pizza { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        [Required]
        [Checker(null, Checker.CheckerAction.Required)]
        public int? IdPate { get; set; }

        [Checker(null, Checker.CheckerAction.Length, LengthMin = 2, LengthMax = 5)]
        [Checker(null, Checker.CheckerAction.NotSame)]
        public List<int> IdsIngredients { get; set; } = new List<int>();
        
    }
}