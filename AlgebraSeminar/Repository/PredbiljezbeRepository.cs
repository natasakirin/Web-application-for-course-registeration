using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AlgebraSeminar.Models;

namespace AlgebraSeminar.Repository
{
    public class PredbiljezbeRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Predbiljezba> SvePredbiljezbe()
        {
            List<Predbiljezba> predbiljezbe = (from p in _db.Predbiljezbe
                                               .Include(x => x.Seminar)
                                               select p).ToList();
            return predbiljezbe;
        }


        public string NovaPredbiljezba(Predbiljezba predbiljezba)
        {
            string poruka;

            _db.Predbiljezbe.Add(predbiljezba);
            int brojRedaka = _db.SaveChanges();

            if (brojRedaka > 0)
            {
                poruka = "Predbilježba je uspješno zaprimljena.";
            }
            else
            {
                poruka = "Greška pri predbilježavanju.";
            }
            return poruka;
        }

        public Predbiljezba DohvatiPredbiljezbu(int id)
        {
            Predbiljezba predbiljezba = (from p in _db.Predbiljezbe
                                         .Include(x => x.Seminar)
                                         where p.PredbiljezbaId == id
                                         select p).SingleOrDefault();
            return predbiljezba;
        }

        public void Odobri(Predbiljezba predbiljezba)
        {
            if (predbiljezba.Seminar.Popunjen == false)
            {
                if (predbiljezba.Status != "Prihvaćena")
                {
                    predbiljezba.Status = "Prihvaćena";
                    predbiljezba.Seminar.UpisaniBrPolaznika++;
                }

                /* Popunjenost seminara */
                if (predbiljezba.Seminar.UpisaniBrPolaznika < predbiljezba.Seminar.MaxBrPolaznika)
                {
                    predbiljezba.Seminar.Popunjen = false;
                }
                else
                {
                    predbiljezba.Seminar.Popunjen = true;
                }

                _db.Entry(predbiljezba).State = EntityState.Modified;
                int brojRedaka = _db.SaveChanges();
            }
        }


        public void Odbaci(Predbiljezba predbiljezba)
        {
            if (predbiljezba.Status == "Prihvaćena")
            {
                predbiljezba.Status = "Odbijena";
                predbiljezba.Seminar.UpisaniBrPolaznika--;
            }
            else
            {
                predbiljezba.Status = "Odbijena";
            }


            /* Popunjenost seminara */
            if (predbiljezba.Seminar.UpisaniBrPolaznika < predbiljezba.Seminar.MaxBrPolaznika)
            {
                predbiljezba.Seminar.Popunjen = false;
            }
            else
            {
                predbiljezba.Seminar.Popunjen = true;
            }

            _db.Entry(predbiljezba).State = EntityState.Modified;
            int brojRedaka = _db.SaveChanges();
        }


        /* UREDI PREDBILJEZBU - npr. dodaj opasku */
        public string UrediPredbiljezbu(Predbiljezba predbiljezba)
        {
            string poruka;

            _db.Entry(predbiljezba).State = EntityState.Modified;
            int brojRedaka = _db.SaveChanges();

            if (brojRedaka > 0)
            {
                poruka = "Predbilježba je uspješno uređena.";
            }
            else
            {
                poruka = "Greška kod uređivanja predbilježbe.";
            }
            return poruka;
        }


        /* Obrisi predbiljezbu */
        public string ObrisiPredbiljezbu(int id)
        {
            string poruka;

            Predbiljezba predbiljezba = _db.Predbiljezbe.Find(id);
            _db.Predbiljezbe.Remove(predbiljezba);
            int brojRedaka = _db.SaveChanges();
            if (brojRedaka > 0)
            {
                poruka = "Uspješno brisanje predbilježbe.";
            }
            else
            {
                poruka = "Greška kod brisanja predbilježbe.";
            }
            return poruka;
        }


        /* PRIKAZ SAMO PRIHVACENIH / ODBIJENIH PREDDBILJEZBI */
        public List<Predbiljezba> OdabirPoStatusuPredbiljezbe(string status)
        {
            List<Predbiljezba> predbiljezbe = (from p in _db.Predbiljezbe
                                               .Include(x => x.Seminar)
                                               where p.Status == status
                                               select p).ToList();
            return predbiljezbe;
        }
    }
}