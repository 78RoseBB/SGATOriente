using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGATOriente.Models;

namespace SGATOriente.Controllers
{
    public class RecursosEducacionalesController : Controller
    {
        private SGATOrienteDBEntities7 db = new SGATOrienteDBEntities7();

        // GET: RecursosEducacionales
        public ActionResult Index()
        {
            return View(db.RecursosEducacionales.ToList());
        }

        // GET: RecursosEducacionales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecursosEducacionale recursosEducacionale = db.RecursosEducacionales.Find(id);
            if (recursosEducacionale == null)
            {
                return HttpNotFound();
            }
            return View(recursosEducacionale);
        }

        // GET: RecursosEducacionales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecursosEducacionales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecursoID,Nombre,URL")] RecursosEducacionale recursosEducacionale)
        {
            if (ModelState.IsValid)
            {
                db.RecursosEducacionales.Add(recursosEducacionale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recursosEducacionale);
        }

        // GET: RecursosEducacionales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecursosEducacionale recursosEducacionale = db.RecursosEducacionales.Find(id);
            if (recursosEducacionale == null)
            {
                return HttpNotFound();
            }
            return View(recursosEducacionale);
        }

        // POST: RecursosEducacionales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecursoID,Nombre,URL")] RecursosEducacionale recursosEducacionale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recursosEducacionale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recursosEducacionale);
        }

        // GET: RecursosEducacionales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecursosEducacionale recursosEducacionale = db.RecursosEducacionales.Find(id);
            if (recursosEducacionale == null)
            {
                return HttpNotFound();
            }
            return View(recursosEducacionale);
        }

        // POST: RecursosEducacionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecursosEducacionale recursosEducacionale = db.RecursosEducacionales.Find(id);
            db.RecursosEducacionales.Remove(recursosEducacionale);
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
