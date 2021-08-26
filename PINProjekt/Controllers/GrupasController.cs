using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PINProjekt.Models;

namespace PINProjekt.Controllers
{
    public class GrupasController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: Grupas
        public ActionResult Index()
        {
            return View(db.Grupa.ToList());
        }

        // GET: Grupas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupa.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // GET: Grupas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Grupa1,Godina")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                db.Grupa.Add(grupa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupa);
        }

        // GET: Grupas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupa.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // POST: Grupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Grupa1,Godina")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupa);
        }

        // GET: Grupas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = db.Grupa.Find(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // POST: Grupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupa grupa = db.Grupa.Find(id);
            db.Grupa.Remove(grupa);
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
