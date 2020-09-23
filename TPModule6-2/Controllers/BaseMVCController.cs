using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPModule6_2.Data;

namespace TPModule6_2.Controllers
{
    public abstract class BaseMVCController<T,TVM> : Controller where T : BaseDbEntity where TVM : class, new() 
    {
        protected TPModule6_2Context db = new TPModule6_2Context();

        public virtual ActionResult Index()
        {
            return View(this.IndexDataLoader());
        }

        protected virtual List<T> IndexDataLoader()
        {
            return db.Set<T>().ToList();
        }

        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = db.Set<T>().Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public virtual ActionResult Create()
        {
            TVM vm = new TVM();
            this.LoadVMCreate(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TVM vm)
        {
            if (ModelState.IsValid)
            {
                this.PreDataCreateSave(vm);
                db.Set<T>().Add(this.GetVMItem(vm));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            this.LoadVMCreate(vm);
            return View(vm);
        }

        protected virtual void LoadVMCreate(TVM vm)
        {
        }

        protected virtual T GetVMItem(TVM vm)
        {
            return vm as T;
        }

        protected virtual void PreDataCreateSave(TVM vm)
        {
        }

        // GET: ArtMartials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVM vm = this.EditItemLoader(id);
            if (this.EditItemValidation(vm))
            {
                return HttpNotFound();
            }
            this.LoadVMEdit(vm);
            return View(vm);
        }

        protected virtual void LoadVMEdit(TVM vm)
        {
        }

        protected virtual bool EditItemValidation(TVM vm)
        {
            return (vm as T) == null;
        }

        protected virtual TVM EditItemLoader(int? id)
        {
            return db.Set<T>().Find(id) as TVM;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TVM vm)
        {
            if (ModelState.IsValid)
            {
                this.PreDataEditUpdate(vm);
                db.Entry(this.GetVMItem(vm)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.LoadVMEdit(vm);
            return View(vm);
        }

        protected virtual void PreDataEditUpdate(TVM vm)
        {

        }

        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (this.DeleteRejected(id))
            {
                return View();
            }
            T item = db.Set<T>().Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        protected virtual bool DeleteRejected(int? id)
        {
            return false;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            T item = db.Set<T>().Find(id);
            this.PreDeleteAction(item);
            db.Set<T>().Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected virtual void PreDeleteAction(T item)
        {
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