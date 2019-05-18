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
    public class EntregasController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: Entregas
        public ActionResult Index()
        {
            var entrega = db.Entrega.Include(e => e.Contacto).Include(e => e.Empresa).Include(e => e.Proveedor);
            return View(entrega.ToList());
        }

        // GET: Entregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // GET: Entregas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre");
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            return View();
        }

        // POST: Entregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Entrega,ID_Empresa,ID_Proveedor,ID_Contacto,No_Paquetes,Anticipada")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entrega.Add(entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", entrega.ID_Contacto);
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", entrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", entrega.ID_Proveedor);
            return View(entrega);
        }

        // GET: Entregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", entrega.ID_Contacto);
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", entrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", entrega.ID_Proveedor);
            return View(entrega);
        }

        // POST: Entregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Entrega,ID_Empresa,ID_Proveedor,ID_Contacto,No_Paquetes,Anticipada")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", entrega.ID_Contacto);
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", entrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", entrega.ID_Proveedor);
            return View(entrega);
        }

        // GET: Entregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entrega.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // POST: Entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entrega.Find(id);
            db.Entrega.Remove(entrega);
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
