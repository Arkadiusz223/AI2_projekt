using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AI2_project.Models;

namespace AI2_project.Controllers
{
    public class OsobyController : Controller
    {
        private BibliotekaEntities2 db = new BibliotekaEntities2();

        // GET: Osoby
        public ActionResult Index()
        {
            var osoba = db.Osoba.Include(o => o.Adres1);
            return View(osoba.ToList());
        }

        // GET: Osoby/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // GET: Osoby/Create
        public ActionResult Create()
        {
            ViewBag.Adres = new SelectList(db.Adres, "Id", "Miejscowość");
            return View();
        }

        // POST: Osoby/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adres,Imie,Nazwisko,telefon,email")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Osoba.Add(osoba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Adres = new SelectList(db.Adres, "Id", "Miejscowość", osoba.Adres);
            return View(osoba);
        }

        // GET: Osoby/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            ViewBag.Adres = new SelectList(db.Adres, "Id", "Miejscowość", osoba.Adres);
            return View(osoba);
        }

        // POST: Osoby/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adres,Imie,Nazwisko,telefon,email")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Adres = new SelectList(db.Adres, "Id", "Miejscowość", osoba.Adres);
            return View(osoba);
        }

        // GET: Osoby/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osoba.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // POST: Osoby/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoba osoba = db.Osoba.Find(id);
            db.Osoba.Remove(osoba);
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
