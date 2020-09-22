using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo11.Data;
using Demo11.Entities;

namespace Demo11.Controllers
{
    public class ConducteursController : Controller
    {
        private Demo11Context db = new Demo11Context();

        // GET: Conducteurs
        public ActionResult Index()
        {
            return View(db.Conducteurs.ToList());
        }

        // GET: Conducteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conducteur conducteur = db.Conducteurs.Find(id);
            if (conducteur == null)
            {
                return HttpNotFound();
            }
            return View(conducteur);
        }

        // GET: Conducteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conducteurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname")] Conducteur conducteur)
        {
            if (ModelState.IsValid)
            {
                db.Conducteurs.Add(conducteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conducteur);
        }

        // GET: Conducteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conducteur conducteur = db.Conducteurs.Find(id);
            if (conducteur == null)
            {
                return HttpNotFound();
            }
            return View(conducteur);
        }

        // POST: Conducteurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname")] Conducteur conducteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conducteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conducteur);
        }

        // GET: Conducteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conducteur conducteur = db.Conducteurs.Find(id);
            if (conducteur == null)
            {
                return HttpNotFound();
            }
            return View(conducteur);
        }

        // POST: Conducteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conducteur conducteur = db.Conducteurs.Find(id);
            //db.Entry(conducteur).State = EntityState.Deleted;
            db.Conducteurs.Remove(conducteur);
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
