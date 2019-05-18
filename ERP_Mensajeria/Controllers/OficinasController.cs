﻿using System;
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
    public class OficinasController : Controller
    {
        private ERPMensajeriaEntities db = new ERPMensajeriaEntities();

        // GET: Oficinas
        public ActionResult Index()
        {
            var oficina = db.Oficina.Include(o => o.Empresa);
            return View(oficina.ToList());
        }

        // GET: Oficinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // GET: Oficinas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre");
            return View();
        }

        // POST: Oficinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Oficina,ID_Empresa,Nombre,Detalle,Estado")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Oficina.Add(oficina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", oficina.ID_Empresa);
            return View(oficina);
        }

        // GET: Oficinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", oficina.ID_Empresa);
            return View(oficina);
        }

        // POST: Oficinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Oficina,ID_Empresa,Nombre,Detalle,Estado")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oficina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Empresa = new SelectList(db.Empresa, "ID_Empresa", "Nombre", oficina.ID_Empresa);
            return View(oficina);
        }

        // GET: Oficinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficina oficina = db.Oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oficina oficina = db.Oficina.Find(id);
            db.Oficina.Remove(oficina);
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
