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
    public class AgregarNuevosEstudiantesController : Controller
    {
        private SGATOrienteDBEntities db = new SGATOrienteDBEntities();

        // GET: AgregarNuevosEstudiantes
        public ActionResult Index()
        {
            return View(db.AgregarNuevosEstudiantes.ToList());
        }

        // GET: AgregarNuevosEstudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarNuevosEstudiantes agregarNuevosEstudiantes = db.AgregarNuevosEstudiantes.Find(id);
            if (agregarNuevosEstudiantes == null)
            {
                return HttpNotFound();
            }
            return View(agregarNuevosEstudiantes);
        }

        // GET: AgregarNuevosEstudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgregarNuevosEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudianteID,Nombre Completo,Número Telefónico,Dirección,Fecha de Ingreso,Edad,Fecha de Nacimiento,Padecimientos")] AgregarNuevosEstudiantes agregarNuevosEstudiantes)
        {
            if (ModelState.IsValid)
            {
                db.AgregarNuevosEstudiantes.Add(agregarNuevosEstudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agregarNuevosEstudiantes);
        }

        // GET: AgregarNuevosEstudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarNuevosEstudiantes agregarNuevosEstudiantes = db.AgregarNuevosEstudiantes.Find(id);
            if (agregarNuevosEstudiantes == null)
            {
                return HttpNotFound();
            }
            return View(agregarNuevosEstudiantes);
        }

        // POST: AgregarNuevosEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudianteID,Nombre Completo,Número Telefónico,Dirección,Fecha de Ingreso,Edad,Fechade Nacimiento,Padecimientos")] AgregarNuevosEstudiantes agregarNuevosEstudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agregarNuevosEstudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agregarNuevosEstudiantes);
        }

        // GET: AgregarNuevosEstudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarNuevosEstudiantes agregarNuevosEstudiantes = db.AgregarNuevosEstudiantes.Find(id);
            if (agregarNuevosEstudiantes == null)
            {
                return HttpNotFound();
            }
            return View(agregarNuevosEstudiantes);
        }

        // POST: AgregarNuevosEstudiantes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgregarNuevosEstudiantes agregarNuevosEstudiantes = db.AgregarNuevosEstudiantes.Find(id);
            db.AgregarNuevosEstudiantes.Remove(agregarNuevosEstudiantes);
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
