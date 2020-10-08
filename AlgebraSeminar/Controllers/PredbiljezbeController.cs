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
    public class PredbiljezbeController : Controller
    {
        private PredbiljezbeRepository repo2 = new PredbiljezbeRepository();
        private SeminariRepository repo = new SeminariRepository();

        // GET: Sve Predbiljezbe
        public ActionResult Index()
        {
            List<Predbiljezba> predbiljezbe = repo2.SvePredbiljezbe();
            return View(predbiljezbe);
        }


        /* NOVA PREDBILJEZBA */
        [AllowAnonymous]
        public ActionResult NovaPredbiljezba(int id)
        {
            ViewBag.SeminarId = id;
            return View(new Predbiljezba());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult NovaPredbiljezba(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                predbiljezba.Datum = DateTime.Now;
                ViewBag.Poruka = repo2.NovaPredbiljezba(predbiljezba);
                return View(new Predbiljezba());
            }
            else
            {
                ViewBag.SeminarId = predbiljezba.SeminarId;
                return View(new Predbiljezba());
            }
        }


        /* PRIHVATI (ODOBRI) PREDBILJEZBU */
        public RedirectResult Odobri(int id)
        {
            Predbiljezba predbiljezba = repo2.DohvatiPredbiljezbu(id);
            repo2.Odobri(predbiljezba);

            // radimo redirekciju
            return Redirect("/Predbiljezbe/Index");
        }

        /* ODBACI PREDBILJEZBU */
        public RedirectResult Odbaci(int id)
        {
            Predbiljezba predbiljezba = repo2.DohvatiPredbiljezbu(id);
            repo2.Odbaci(predbiljezba);

            // radimo redirekciju
            return Redirect("/Predbiljezbe/Index");
        }


        /* UREDI PREDBILJEZBU */
        public ActionResult UrediPredbiljezbu(int id)
        {
            Predbiljezba predbiljezba = repo2.DohvatiPredbiljezbu(id);
            return View(predbiljezba);
        }

        [HttpPost]
        public ActionResult UrediPredbiljezbu(Predbiljezba predbiljezba)
        {
            ViewBag.Poruka = repo2.UrediPredbiljezbu(predbiljezba);
            return View(new Predbiljezba());
        }


        /* OBRISI PREDBILJEZBU */
        public ActionResult ObrisiPredbiljezbu(int id)
        {
            ViewBag.Poruka = repo2.ObrisiPredbiljezbu(id);
            return View();
        }


        /* SORTIRANJE PREDBILJEZBI PREMA NJIHOVOM STATUSU */
        public ActionResult OdabirPoStatusuPredbiljezbe(string id)
        {
            List<Predbiljezba> predbiljezbePoStatusu = repo2.OdabirPoStatusuPredbiljezbe(id);
            ViewBag.StatusPredbiljezbe = id;
            return View(predbiljezbePoStatusu);
        }
    }
}