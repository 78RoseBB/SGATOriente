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
    public class NotificacionesController : Controller
    {
        private SGATOrienteDBEntities db = new SGATOrienteDBEntities();

        // GET: Notificaciones
        public ActionResult Index()
        {
            return View(db.Notificaciones.ToList());
        }

        // GET: Notificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificaciones notificaciones = db.Notificaciones.Find(id);
            if (notificaciones == null)
            {
                return HttpNotFound();
            }
            return View(notificaciones);
        }

        // GET: Notificaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotificacionID,TipoNotificacion,Mensaje,FechaEnvio")] Notificaciones notificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Notificaciones.Add(notificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notificaciones);
        }

        // GET: Notificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificaciones notificaciones = db.Notificaciones.Find(id);
            if (notificaciones == null)
            {
                return HttpNotFound();
            }
            return View(notificaciones);
        }

        // POST: Notificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotificacionID,TipoNotificacion,Mensaje,FechaEnvio")] Notificaciones notificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificaciones);
        }

        // GET: Notificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificaciones notificaciones = db.Notificaciones.Find(id);
            if (notificaciones == null)
            {
                return HttpNotFound();
            }
            return View(notificaciones);
        }


        // POST: Notificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notificaciones notificaciones = db.Notificaciones.Find(id);
            db.Notificaciones.Remove(notificaciones);
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
