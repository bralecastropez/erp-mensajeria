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
    public class RutaEntregasController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: RutaEntregas
        public ActionResult Index()
        {
            var rutaEntrega = db.RutaEntrega.Include(r => r.Empresa).Include(r => r.Proveedor);
            return View(rutaEntrega.ToList());
        }

        // GET: RutaEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            return View();
        }

        // POST: RutaEntregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RutaEntrega,ID_Empresa,ID_Proveedor,ORDEN")] RutaEntrega rutaEntrega)
        {
            if (ModelState.IsValid)
            {
                db.RutaEntrega.Add(rutaEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", rutaEntrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", rutaEntrega.ID_Proveedor);
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", rutaEntrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", rutaEntrega.ID_Proveedor);
            return View(rutaEntrega);
        }

        // POST: RutaEntregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RutaEntrega,ID_Empresa,ID_Proveedor,ORDEN")] RutaEntrega rutaEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutaEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", rutaEntrega.ID_Empresa);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", rutaEntrega.ID_Proveedor);
            return View(rutaEntrega);
        }

        // GET: RutaEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            if (rutaEntrega == null)
            {
                return HttpNotFound();
            }
            return View(rutaEntrega);
        }

        // POST: RutaEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RutaEntrega rutaEntrega = db.RutaEntrega.Find(id);
            db.RutaEntrega.Remove(rutaEntrega);
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
