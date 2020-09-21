using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo10.Data;
using Demo10.Models;

namespace Demo10.Controllers
{
    public class Class2Controller : Controller
    {
        private Demo10Context db = new Demo10Context();

        // GET: Class2
        public ActionResult Index()
        {
            return View(db.Class2.ToList());
        }

        // GET: Class2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = db.Class2.Find(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // GET: Class2/Create
        public ActionResult Create()
        {
            Class2VM vm = new Class2VM();
            vm.Class1s = db.Class1.ToList();
            return View(vm);
        }

        // POST: Class2/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class2VM vm)
        {
            if (ModelState.IsValid)
            {
                vm.Class2.Class1 = db.Class1.Find(vm.Class1Id);
                db.Class2.Add(vm.Class2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Class2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = db.Class2.Find(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // POST: Class2/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prop1")] Class2 class2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(class2);
        }

        // GET: Class2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = db.Class2.Find(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // POST: Class2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class2 class2 = db.Class2.Find(id);
            db.Class2.Remove(class2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
