﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_2_BO.Utils;
using TPModule5_2_BO;

namespace TPModule5_2.Controllers
{
    public class HomeController : Controller
    {
        private Pizza pizza;
        public ActionResult Index()
        {
            var i = new Pizza() 
            { 
                Id = 10, 
                Nom = "pizzaToClone", 
                Pate = new Pate() 
                { 
                    Id = 1, 
                    Nom = "pate1" 
                }, 
                Ingredients = new List<Ingredient>() 
                { 
                    new Ingredient() { Id = 1, Nom = "ingredient 1" }, 
                    new Ingredient() { Id = 2, Nom = "ingredient 2" } 
                } 
            };
            var j = Hydratator.Hydrate<Pizza>(i);
            var k = i;
            Debug.WriteLine("i ref : " + i.GetRefId());
            Debug.WriteLine("k ref : " + k.GetRefId());
            Debug.WriteLine("j ref : " + j.GetRefId());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}