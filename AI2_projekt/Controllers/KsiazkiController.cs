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
    public class KsiazkiController : Controller
    {
        private BibliotekaEntities2 db = new BibliotekaEntities2();

        // GET: Ksiazki
        public ActionResult Index()
        {
            var ksiazki = db.Ksiazki.Include(k => k.Kategorie);
            return View(ksiazki.ToList());
        }

        // GET: Ksiazki/Details/5
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

        public ActionResult Wypozycz(bool confirm,int? id)
        {
            if (confirm == true)
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
                ksiazki.Ilość_na_stanie--;
                Wypozyczenia wyp = new Wypozyczenia();
                wyp.Wypożyczający = int.Parse(Session["userId"].ToString());
                wyp.Książka = int.Parse(ksiazki.Id.ToString());
                wyp.Status = 1;
                wyp.Data_rezerwacji = DateTime.Today;
                db.Wypozyczenia.Add(wyp);
                db.SaveChanges();
            }
            else { }
            return View();
            
        }

        // GET: Ksiazki/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria");
        //    return View();
        //}

        //// POST: Ksiazki/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Tytuł,Kategoria,Autor,Opis,Rok_wydania,Ilość_na_stanie")] Ksiazki ksiazki)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Ksiazki.Add(ksiazki);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
        //    return View(ksiazki);
        //}

        //// GET: Ksiazki/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ksiazki ksiazki = db.Ksiazki.Find(id);
        //    if (ksiazki == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
        //    return View(ksiazki);
        //}

        //// POST: Ksiazki/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Tytuł,Kategoria,Autor,Opis,Rok_wydania,Ilość_na_stanie")] Ksiazki ksiazki)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ksiazki).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Kategoria = new SelectList(db.Kategorie, "Id", "Kategoria", ksiazki.Kategoria);
        //    return View(ksiazki);
        //}

        //// GET: Ksiazki/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ksiazki ksiazki = db.Ksiazki.Find(id);
        //    if (ksiazki == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ksiazki);
        //}

        //// POST: Ksiazki/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Ksiazki ksiazki = db.Ksiazki.Find(id);
        //    db.Ksiazki.Remove(ksiazki);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
