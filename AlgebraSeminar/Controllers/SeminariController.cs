using AlgebraSeminar.Models;
using AlgebraSeminar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    [Authorize]
    public class SeminariController : Controller
    {
        private SeminariRepository repo = new SeminariRepository();

        // GET: Seminari
        public ActionResult Index()
        {
            List<Seminar> seminari = repo.SviSeminari();
            return View(seminari);
        }


        /* NOVI SEMINAR */
        public ActionResult NoviSeminar()
        {
            return View(new Seminar());
        }

        [HttpPost]
        public ActionResult NoviSeminar(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Poruka = repo.NoviSeminar(seminar);
                return View(new Seminar());
            }
            else
            {
                return View(new Seminar());
            }
        }


        /* UREDI SEMINAR */
        public ActionResult UrediSeminar(int id)
        {
            Seminar seminar = repo.DohvatiSeminar(id);
            return View(seminar);
        }

        [HttpPost]
        public ActionResult UrediSeminar(Seminar seminar)
        {
            ViewBag.Poruka = repo.UrediSeminar(seminar);
            return View(new Seminar());
        }


        /* OBRISI SEMINAR */
        public ActionResult ObrisiSeminar(int id)
        {
            ViewBag.Poruka = repo.ObrisiSeminar(id);
            return View();
        }
    }
}