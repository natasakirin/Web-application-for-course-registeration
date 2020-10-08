using AlgebraSeminar.Models;
using AlgebraSeminar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    public class HomeController : Controller
    {
        private SeminariRepository repo = new SeminariRepository();

        // GET: Seminari
        public ActionResult Predbiljezba(string searchString)
        {
            List<Seminar> seminari = repo.SviSeminari();

            if (!String.IsNullOrEmpty(searchString))
            {
                seminari = seminari.Where(s => s.NazivSeminara.ToLower().Contains(searchString.ToLower()) || s.Opis.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return View(seminari);
        }

        public ActionResult SeminarInfo(int id)
        {
            Seminar seminar = repo.DohvatiSeminar(id);
            return View(seminar);
        }

        public ActionResult ONama()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Kontakt()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}