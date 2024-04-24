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
    public class PagosEstudiantesController : Controller
    {
        private SGATOrienteDBEntities db = new SGATOrienteDBEntities();

        // GET: PagosEstudiantes
        public ActionResult Index()
        {
            var pagosEstudiantes = db.PagosEstudiantes.Include(p => p.AgregarNuevosEstudiantes);
            return View(pagosEstudiantes.ToList());
        }

        // GET: PagosEstudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosEstudiantes pagosEstudiantes = db.PagosEstudiantes.Find(id);
            if (pagosEstudiantes == null)
            {
                return HttpNotFound();
            }
            return View(pagosEstudiantes);
        }

        // GET: PagosEstudiantes/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteID = new SelectList(db.AgregarNuevosEstudiantes, "EstudianteID", "NombreCompleto");
            return View();
        }

        // POST: PagosEstudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagoID,EstudianteID,Monto,FechaPago")] PagosEstudiantes pagosEstudiantes)
        {
            if (ModelState.IsValid)
            {
                db.PagosEstudiantes.Add(pagosEstudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteID = new SelectList(db.AgregarNuevosEstudiantes, "EstudianteID", "NombreCompleto", pagosEstudiantes.EstudianteID);
            return View(pagosEstudiantes);
        }

        // GET: PagosEstudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosEstudiantes pagosEstudiantes = db.PagosEstudiantes.Find(id);
            if (pagosEstudiantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteID = new SelectList(db.AgregarNuevosEstudiantes, "EstudianteID", "NombreCompleto", pagosEstudiantes.EstudianteID);
            return View(pagosEstudiantes);
        }

        // POST: PagosEstudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagoID,EstudianteID,Monto,FechaPago")] PagosEstudiantes pagosEstudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagosEstudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteID = new SelectList(db.AgregarNuevosEstudiantes, "EstudianteID", "NombreCompleto", pagosEstudiantes.EstudianteID);
            return View(pagosEstudiantes);
        }

        // GET: PagosEstudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosEstudiantes pagosEstudiantes = db.PagosEstudiantes.Find(id);
            if (pagosEstudiantes == null)
            {
                return HttpNotFound();
            }
            return View(pagosEstudiantes);
        }

        // POST: PagosEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagosEstudiantes pagosEstudiantes = db.PagosEstudiantes.Find(id);
            db.PagosEstudiantes.Remove(pagosEstudiantes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: PagosEstudiantes/RegistrarPago
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarPago(string nombreCompleto, decimal montoPago, DateTime fechaPago)
        {
            // Buscar el estudiante por su nombre completo
            var estudiante = db.AgregarNuevosEstudiantes.FirstOrDefault(e => e.NombreCompleto == nombreCompleto);

            if (estudiante != null)
            {
                // Crear el objeto de pago con el estudiante encontrado
                var pago = new PagosEstudiantes
                {
                    EstudianteID = estudiante.EstudianteID,
                    Monto = montoPago,
                    FechaPago = fechaPago
                };

                // Agregar el pago a la base de datos y guardar los cambios
                db.PagosEstudiantes.Add(pago);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "El estudiante no fue encontrado. Por favor, verifica el nombre e intenta nuevamente.");
                return View();
            }
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
