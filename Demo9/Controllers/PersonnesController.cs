using Demo9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo9.Controllers
{
    public class PersonnesController : Controller
    {
        // GET: Personnes
        public ActionResult Index()
        {
            return View(new List<Personne>()
            {
                new Personne() { Id = 1, Firstname = "zaoiej", Lastname = "azej" }
            });
        }

        // GET: Personnes/Details/5
        public ActionResult Details(int id)
        {
            return View(new Personne() { Id = 1, Firstname = "zaoiej", Lastname = "azej" });
        }

        // GET: Personnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personnes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personnes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personnes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Personne() { Id = 1, Firstname = "zaoiej", Lastname = "azej" });
        }

        // POST: Personnes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
