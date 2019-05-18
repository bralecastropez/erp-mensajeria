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
    public class SolicitudProveedoresController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: SolicitudProveedores
        public ActionResult Index()
        {
            var solicitudProveedor = db.SolicitudProveedor.Include(s => s.Proveedor);
            return View(solicitudProveedor.ToList());
        }

        // GET: SolicitudProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudProveedor solicitudProveedor = db.SolicitudProveedor.Find(id);
            if (solicitudProveedor == null)
            {
                return HttpNotFound();
            }
            return View(solicitudProveedor);
        }

        // GET: SolicitudProveedores/Create
        public ActionResult Create()
        {
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            return View();
        }

        // POST: SolicitudProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SolicitudProveedor,ID_Proveedor,Fecha_Ingreso,Hora_Ingreso,Fecha_Creacion,Descripcion_Corta,Elevador,Estado_Entrega,Entregado,Aprobado,Tipo")] SolicitudProveedor solicitudProveedor)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudProveedor.Add(solicitudProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", solicitudProveedor.ID_Proveedor);
            return View(solicitudProveedor);
        }

        // GET: SolicitudProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudProveedor solicitudProveedor = db.SolicitudProveedor.Find(id);
            if (solicitudProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", solicitudProveedor.ID_Proveedor);
            return View(solicitudProveedor);
        }

        // POST: SolicitudProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SolicitudProveedor,ID_Proveedor,Fecha_Ingreso,Hora_Ingreso,Fecha_Creacion,Descripcion_Corta,Elevador,Estado_Entrega,Entregado,Aprobado,Tipo")] SolicitudProveedor solicitudProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", solicitudProveedor.ID_Proveedor);
            return View(solicitudProveedor);
        }

        // GET: SolicitudProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudProveedor solicitudProveedor = db.SolicitudProveedor.Find(id);
            if (solicitudProveedor == null)
            {
                return HttpNotFound();
            }
            return View(solicitudProveedor);
        }

        // POST: SolicitudProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudProveedor solicitudProveedor = db.SolicitudProveedor.Find(id);
            db.SolicitudProveedor.Remove(solicitudProveedor);
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
