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
    public class WypozyczController : Controller
    {
        private BibliotekaEntities2 db = new BibliotekaEntities2();

        // GET: Wypozycz
        public ActionResult Index()
        {
            var wypozyczenia = db.Wypozyczenia.Include(w => w.Karta).Include(w => w.Karta1).Include(w => w.Ksiazki).Include(w => w.Status1);
            return View(wypozyczenia.ToList());
        }

        // GET: Wypozycz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // GET: Wypozycz/Create
        public ActionResult Create()
        {
            ViewBag.Pracownik = new SelectList(db.Karta, "Id", "Numer_karty");
            ViewBag.Wypożyczający = new SelectList(db.Karta, "Id", "Numer_karty");
            ViewBag.Książka = new SelectList(db.Ksiazki, "Id", "Tytuł");
            ViewBag.Status = new SelectList(db.Status, "Id", "status_name");
            return View();
        }

        // POST: Wypozycz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pracownik,Wypożyczający,Książka,Status,Data_rezerwacji,Data_wypożyczenia,Termin_Zwrotu,Wysokość_kary")] Wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia.Add(wypozyczenia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pracownik = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Pracownik);
            ViewBag.Wypożyczający = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Wypożyczający);
            ViewBag.Książka = new SelectList(db.Ksiazki, "Id", "Tytuł", wypozyczenia.Książka);
            ViewBag.Status = new SelectList(db.Status, "Id", "status_name", wypozyczenia.Status);
            return View(wypozyczenia);
        }

        // GET: Wypozycz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pracownik = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Pracownik);
            ViewBag.Wypożyczający = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Wypożyczający);
            ViewBag.Książka = new SelectList(db.Ksiazki, "Id", "Tytuł", wypozyczenia.Książka);
            ViewBag.Status = new SelectList(db.Status, "Id", "status_name", wypozyczenia.Status);
            return View(wypozyczenia);
        }

        // POST: Wypozycz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pracownik,Wypożyczający,Książka,Status,Data_rezerwacji,Data_wypożyczenia,Termin_Zwrotu,Wysokość_kary")] Wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pracownik = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Pracownik);
            ViewBag.Wypożyczający = new SelectList(db.Karta, "Id", "Numer_karty", wypozyczenia.Wypożyczający);
            ViewBag.Książka = new SelectList(db.Ksiazki, "Id", "Tytuł", wypozyczenia.Książka);
            ViewBag.Status = new SelectList(db.Status, "Id", "status_name", wypozyczenia.Status);
            return View(wypozyczenia);
        }

        // GET: Wypozycz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // POST: Wypozycz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            db.Wypozyczenia.Remove(wypozyczenia);
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
