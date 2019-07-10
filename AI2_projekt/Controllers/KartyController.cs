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
    public class KartyController : Controller
    {
        private BibliotekaEntities2 db = new BibliotekaEntities2();

        // GET: Karty
        public ActionResult Index()
        {
            var karta = db.Karta.Include(k => k.Role).Include(k => k.Osoba);
            return View(karta.ToList());
        }

        // GET: Karty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            return View(karta);
        }

        // GET: Karty/Create
        public ActionResult Create()
        {
            ViewBag.Rola_karty = new SelectList(db.Role, "Id", "Rola");
            ViewBag.Wlasciciel = new SelectList(db.Osoba, "Id", "Imie");
            return View();
        }

        // POST: Karty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numer_karty,Wlasciciel,Rola_karty")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                db.Karta.Add(karta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rola_karty = new SelectList(db.Role, "Id", "Rola", karta.Rola_karty);
            ViewBag.Wlasciciel = new SelectList(db.Osoba, "Id", "Imie", karta.Wlasciciel);
            return View(karta);
        }

        // GET: Karty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rola_karty = new SelectList(db.Role, "Id", "Rola", karta.Rola_karty);
            ViewBag.Wlasciciel = new SelectList(db.Osoba, "Id", "Imie", karta.Wlasciciel);
            return View(karta);
        }

        // POST: Karty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numer_karty,Wlasciciel,Rola_karty")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rola_karty = new SelectList(db.Role, "Id", "Rola", karta.Rola_karty);
            ViewBag.Wlasciciel = new SelectList(db.Osoba, "Id", "Imie", karta.Wlasciciel);
            return View(karta);
        }

        // GET: Karty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            return View(karta);
        }

        // POST: Karty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karta karta = db.Karta.Find(id);
            db.Karta.Remove(karta);
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
