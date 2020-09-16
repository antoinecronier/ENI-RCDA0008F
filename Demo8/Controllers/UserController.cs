using Demo8.Entities;
using Demo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo8.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<User> users = new List<User>();
            users.Add(new Entities.User() { Id = 1, Firstname = "azpoejia", Lastname = "aoize", DayOfBirth = DateTime.Parse("1950/12/12") });
            users.Add(new Entities.User() { Id = 2, Firstname = "sdf", Lastname = "tyuty", DayOfBirth = DateTime.Parse("1980/01/24") });
            users.Add(new Entities.User() { Id = 3, Firstname = "aze", Lastname = "hjkhj", DayOfBirth = DateTime.Parse("1990/08/09") });

            List<UserVM> vm = new List<UserVM>();

            foreach (var item in users)
            {
                vm.Add(new UserVM { User = item });
            }
            
            return View(vm);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
