using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SGATOriente.Models;

namespace SGATOriente.Controllers
{
    public class ProgresoEstudiantesController : Controller
    {
        private SGATOrienteDBEntities6 db = new SGATOrienteDBEntities6();

        // GET: ProgresoEstudiantes
        public ActionResult Index()
        {
            return View(db.ProgresoEstudiantes.ToList());
        }

        // GET: ProgresoEstudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgresoEstudiante progresoEstudiante = db.ProgresoEstudiantes.Find(id);
            if (progresoEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(progresoEstudiante);
        }

        // GET: ProgresoEstudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgresoEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgresoID,NombreEstudiante,CambioGrado,FechaExamen,NivelAlcanzado")] ProgresoEstudiante progresoEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.ProgresoEstudiantes.Add(progresoEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(progresoEstudiante);
        }

        // GET: ProgresoEstudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgresoEstudiante progresoEstudiante = db.ProgresoEstudiantes.Find(id);
            if (progresoEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(progresoEstudiante);
        }

        // POST: ProgresoEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgresoID,NombreEstudiante,CambioGrado,FechaExamen,NivelAlcanzado")] ProgresoEstudiante progresoEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progresoEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(progresoEstudiante);
        }

        // GET: ProgresoEstudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgresoEstudiante progresoEstudiante = db.ProgresoEstudiantes.Find(id);
            if (progresoEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(progresoEstudiante);
        }

        // POST: ProgresoEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgresoEstudiante progresoEstudiante = db.ProgresoEstudiantes.Find(id);
            db.ProgresoEstudiantes.Remove(progresoEstudiante);
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
