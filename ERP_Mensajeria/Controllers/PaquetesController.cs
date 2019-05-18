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
    public class PaquetesController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: Paquetes
        public ActionResult Index()
        {
            var paquete = db.Paquete.Include(p => p.SolicitudProveedor);
            return View(paquete.ToList());
        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            ViewBag.ID_SolicitudProveedor = new SelectList(db.SolicitudProveedor, "ID_SolicitudProveedor", "Descripcion_Corta");
            return View();
        }

        // POST: Paquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Paquete,ID_SolicitudProveedor,Descripcion,Detalle,Estado,Extra")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Paquete.Add(paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SolicitudProveedor = new SelectList(db.SolicitudProveedor, "ID_SolicitudProveedor", "Descripcion_Corta", paquete.ID_SolicitudProveedor);
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SolicitudProveedor = new SelectList(db.SolicitudProveedor, "ID_SolicitudProveedor", "Descripcion_Corta", paquete.ID_SolicitudProveedor);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Paquete,ID_SolicitudProveedor,Descripcion,Detalle,Estado,Extra")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SolicitudProveedor = new SelectList(db.SolicitudProveedor, "ID_SolicitudProveedor", "Descripcion_Corta", paquete.ID_SolicitudProveedor);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paquete paquete = db.Paquete.Find(id);
            db.Paquete.Remove(paquete);
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
