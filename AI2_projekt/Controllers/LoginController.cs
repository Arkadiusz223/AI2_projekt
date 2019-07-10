using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AI2_project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(AI2_project.Models.Karta logModel)
        {
            using (Models.BibliotekaEntities2 db = new Models.BibliotekaEntities2())
            {
                var logDetails = db.Karta.Where(x => x.Numer_karty == logModel.Numer_karty && x.Haslo == logModel.Haslo).FirstOrDefault();
                if (logDetails == null)
                {
                    logModel.LoginErrorMessage = "Zły numer karty lub hasło!";
                    return View("Index", logModel);

                }
                else
                {
                    Session["userID"] = logDetails.Id;
                    Session["userCard"] = logDetails.Numer_karty;
                    Session["roleID"] = logDetails.Rola_karty;
                    return RedirectToAction("Index", "ksiazki");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}