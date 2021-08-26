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
    public class RegistracijasController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: Registracijas
        public ActionResult Index()
        {
            var registracija = db.Registracija.Include(r => r.Grupa).Include(r => r.Kurs);
            return View(registracija.ToList());
        }

        // GET: Registracijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registracija registracija = db.Registracija.Find(id);
            if (registracija == null)
            {
                return HttpNotFound();
            }
            return View(registracija);
        }

        // GET: Registracijas/Create
        public ActionResult Create()
        {
            ViewBag.Grupa_id = new SelectList(db.Grupa, "id", "Grupa1");
            ViewBag.Kurs_id = new SelectList(db.Kurs, "id", "Kurs1");
            return View();
        }

        // POST: Registracijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Prezime,E_mail,Telefon,Kurs_id,Grupa_id")] Registracija registracija)
        {
            if (ModelState.IsValid)
            {
                db.Registracija.Add(registracija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grupa_id = new SelectList(db.Grupa, "id", "Grupa1", registracija.Grupa_id);
            ViewBag.Kurs_id = new SelectList(db.Kurs, "id", "Kurs1", registracija.Kurs_id);
            return View(registracija);
        }

        // GET: Registracijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registracija registracija = db.Registracija.Find(id);
            if (registracija == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grupa_id = new SelectList(db.Grupa, "id", "Grupa1", registracija.Grupa_id);
            ViewBag.Kurs_id = new SelectList(db.Kurs, "id", "Kurs1", registracija.Kurs_id);
            return View(registracija);
        }

        // POST: Registracijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Prezime,E_mail,Telefon,Kurs_id,Grupa_id")] Registracija registracija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registracija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grupa_id = new SelectList(db.Grupa, "id", "Grupa1", registracija.Grupa_id);
            ViewBag.Kurs_id = new SelectList(db.Kurs, "id", "Kurs1", registracija.Kurs_id);
            return View(registracija);
        }

        // GET: Registracijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registracija registracija = db.Registracija.Find(id);
            if (registracija == null)
            {
                return HttpNotFound();
            }
            return View(registracija);
        }

        // POST: Registracijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registracija registracija = db.Registracija.Find(id);
            db.Registracija.Remove(registracija);
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
