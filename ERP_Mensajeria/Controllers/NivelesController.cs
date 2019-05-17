using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP_Mensajeria.Models;

namespace ERP_Mensajeria.Controllers
{
    public class NivelesController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: Niveles
        public ActionResult Index()
        {
            var nivel = db.Nivel.Include(n => n.Edificio);
            return View(nivel.ToList());
        }

        // GET: Niveles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // GET: Niveles/Create
        public ActionResult Create()
        {
            ViewBag.ID_Edificio = new SelectList(db.Edificio, "ID_Edificio", "Nombre");
            return View();
        }

        // POST: Niveles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nivel,ID_Edificio,Nombre,Detalle,Estado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Nivel.Add(nivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Edificio = new SelectList(db.Edificio, "ID_Edificio", "Nombre", nivel.ID_Edificio);
            return View(nivel);
        }

        // GET: Niveles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificio, "ID_Edificio", "Nombre", nivel.ID_Edificio);
            return View(nivel);
        }

        // POST: Niveles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nivel,ID_Edificio,Nombre,Detalle,Estado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificio, "ID_Edificio", "Nombre", nivel.ID_Edificio);
            return View(nivel);
        }

        // GET: Niveles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Nivel.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nivel nivel = db.Nivel.Find(id);
            db.Nivel.Remove(nivel);
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
