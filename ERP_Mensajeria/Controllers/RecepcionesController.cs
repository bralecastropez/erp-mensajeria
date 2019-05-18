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
    public class RecepcionesController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: Recepciones
        public ActionResult Index()
        {
            var recepcion = db.Recepcion.Include(r => r.Contacto).Include(r => r.Proveedor);
            return View(recepcion.ToList());
        }

        // GET: Recepciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // GET: Recepciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            return View();
        }

        // POST: Recepciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Recepcion,ID_Contacto,ID_Proveedor,Tipo")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Recepcion.Add(recepcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", recepcion.ID_Contacto);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", recepcion.ID_Proveedor);
            return View(recepcion);
        }

        // GET: Recepciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", recepcion.ID_Contacto);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", recepcion.ID_Proveedor);
            return View(recepcion);
        }

        // POST: Recepciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Recepcion,ID_Contacto,ID_Proveedor,Tipo")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", recepcion.ID_Contacto);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", recepcion.ID_Proveedor);
            return View(recepcion);
        }

        // GET: Recepciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // POST: Recepciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recepcion recepcion = db.Recepcion.Find(id);
            db.Recepcion.Remove(recepcion);
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
