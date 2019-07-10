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
    public class KsiazkiUserController : Controller
    {
        private BibliotekaEntities2 db = new BibliotekaEntities2();

        // GET: KsiazkiUser
        public ActionResult Index()
        {
            var ksiazki = db.Ksiazki.Include(k => k.Kategorie);
            return View(ksiazki.ToList());
        }

        // GET: KsiazkiUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazki ksiazki = db.Ksiazki.Find(id);
            if (ksiazki == null)
            {
                return HttpNotFound();
            }
            return View(ksiazki);
        }

        // GET: KsiazkiUser/Create
        public ActionResult Create()
        {
            ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria");
            return View();
        }

        // POST: KsiazkiUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tytuł,Kategoria,Autor,Opis,Rok_wydania,Ilość_na_stanie")] Ksiazki ksiazki)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Add(ksiazki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
            return View(ksiazki);
        }

        // GET: KsiazkiUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazki ksiazki = db.Ksiazki.Find(id);
            if (ksiazki == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
            return View(ksiazki);
        }

        // POST: KsiazkiUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tytuł,Kategoria,Autor,Opis,Rok_wydania,Ilość_na_stanie")] Ksiazki ksiazki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
            return View(ksiazki);
        }

        // GET: KsiazkiUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazki ksiazki = db.Ksiazki.Find(id);
            if (ksiazki == null)
            {
                return HttpNotFound();
            }
            return View(ksiazki);
        }

        // POST: KsiazkiUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazki ksiazki = db.Ksiazki.Find(id);
            db.Ksiazki.Remove(ksiazki);
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
