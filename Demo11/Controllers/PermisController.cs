using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo11.Data;
using Demo11.Entities;

namespace Demo11.Controllers
{
    public class PermisController : Controller
    {
        private Demo11Context db = new Demo11Context();

        // GET: Permis
        public async Task<ActionResult> Index()
        {
            return View(await db.Permis.ToListAsync());
        }

        // GET: Permis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permi permi = await db.Permis.FindAsync(id);
            if (permi == null)
            {
                return HttpNotFound();
            }
            return View(permi);
        }

        // GET: Permis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Points")] Permi permi)
        {
            if (ModelState.IsValid)
            {
                db.Permis.Add(permi);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(permi);
        }

        // GET: Permis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permi permi = await db.Permis.FindAsync(id);
            if (permi == null)
            {
                return HttpNotFound();
            }
            return View(permi);
        }

        // POST: Permis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Points")] Permi permi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permi).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(permi);
        }

        // GET: Permis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permi permi = await db.Permis.FindAsync(id);
            if (permi == null)
            {
                return HttpNotFound();
            }
            return View(permi);
        }

        // POST: Permis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Permi permi = await db.Permis.FindAsync(id);
            db.Permis.Remove(permi);
            await db.SaveChangesAsync();
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
