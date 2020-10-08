using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AlgebraSeminar.Models;

namespace AlgebraSeminar.Repository
{
    public class SeminariRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Seminar> SviSeminari()
        {
            List<Seminar> seminari = (from s in _db.Seminari
                                      select s).ToList();
            return seminari;
        }

        public string NoviSeminar(Seminar seminar)
        {
            string poruka;

            _db.Seminari.Add(seminar);
            int brojRedaka = _db.SaveChanges();

            if (brojRedaka > 0)
            {
                poruka = "Uspješno dodavanje seminara.";
            }
            else
            {
                poruka = "Greška kod dodavanja novog seminara.";
            }
            return poruka;
        }

        public Seminar DohvatiSeminar(int id)
        {
            Seminar seminar = (from s in _db.Seminari
                               where s.SeminarId == id
                               select s).SingleOrDefault();
            return seminar;
        }

        public string UrediSeminar(Seminar seminar)
        {
            string poruka;

            _db.Entry(seminar).State = EntityState.Modified;
            int brojRedaka = _db.SaveChanges();

            if (brojRedaka > 0)
            {
                poruka = "Seminar je uspješno uređen.";
            }
            else
            {
                poruka = "Greška kod uređivanja seminara.";
            }
            return poruka;
        }


        public string ObrisiSeminar(int id)
        {
            string poruka;

            Seminar seminar = _db.Seminari.Find(id);
            _db.Seminari.Remove(seminar);
            int brojRedaka = _db.SaveChanges();
            if (brojRedaka > 0)
            {
                poruka = "Uspješno brisanje seminara.";
            }
            else
            {
                poruka = "Greška kod brisanja seminara.";
            }
            return poruka;
        }
    }
}