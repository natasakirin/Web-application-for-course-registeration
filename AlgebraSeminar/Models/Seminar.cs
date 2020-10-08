using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgebraSeminar.Models
{
    public class Seminar
    {
        [Key]
        public int SeminarId { get; set; }

        [Required(ErrorMessage = "Naziv seminar je obavezan za unos.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Broj znakova u nazivu seminara mora biti između 1 i 100.")]
        public string NazivSeminara { get; set; }

        [Required(ErrorMessage = "Opis je obavezan za unos.")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Broj znakova opisa mora sadržavati minimalno 1 znak.")]
        [UIHint("MultilineText")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Podrucje seminara je obavezno za unos.")]
        [UIHint("TemplateStatusPodrucje")]
        public string Podrucje { get; set; }

        [Required(ErrorMessage = "Datum početka seminara je obavezan za unos.")]
        [UIHint("Date")]
        /* yyyy-MM-dd je jedini format u kojem se datum prikazuje u Edit-modu u GoogleChrome pregledniku */
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Trajanje seminara je obavezno za unos.")]
        [Range(1, 3000, ErrorMessage = "Trajanje seminara mora biti unutar intervala [1 - 3000] sati.")]
        public int TrajanjeSeminaraSati { get; set; }

        [Required(ErrorMessage = "Ime i prezime predavaca je obavezno za unos.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Broj znakova u imenu predavača mora biti između 1 i 50.")]
        public string Predavac { get; set; }

        [Required]
        public int UpisaniBrPolaznika { get; set; }

        [Required(ErrorMessage = "Maksimalni broj polaznika je obavezan za unos.")]
        [Range(1, 30, ErrorMessage = "Maksimalni broj polaznika mora biti unutar intervala [1 - 30].")]
        public int MaxBrPolaznika { get; set; }

        [Required]
        public bool Popunjen { get; set; }

        [Required]
        public string Slika { get; set; }

        /* unaprijed zadane vrijednosti svojstava */
        public Seminar()
        {
            /* Upisani broj polaznika - inicijalno */
            UpisaniBrPolaznika = 0;

            /* Popunjenost seminara */
            Popunjen = false;

            /* Slika - generira se random broj, kojim se automatski bira jedna od 10 dostupnih slika */
            Random random = new Random();
            Slika = "Slika" + random.Next(0, 10) + ".jpg";
        }
    }
}