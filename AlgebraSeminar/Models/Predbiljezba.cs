using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgebraSeminar.Models
{
    public class Predbiljezba
    {
        [Key]
        public int PredbiljezbaId { get; set; }

        [Required]
        [UIHint("Date")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Ime je obavezno za unos.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Broj znakova u imenu mora biti između 1 i 50.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno za unos.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Broj znakova u prezimenu mora biti između 1 i 50.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Adresa je obavezna za unos.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Broj znakova u adresi mora biti između 1 i 100.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Email adresa je obavezna za unos.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Broj znakova u email adresi mora biti između 1 i 100.")]
        [UIHint("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Broj telefona je obavezan za unos.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Broj znakova u broju telefona mora biti između 1 i 20.")]
        [UIHint("Phone")]
        public string Telefon { get; set; }



        [Required]
        public int SeminarId { get; set; }
        public Seminar Seminar { get; set; }


        // eventualna napomena osoblja škole 
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Broj znakova opisa mora sadržavati minimalno 1 znak.")]
        [UIHint("MultilineText")]
        public string Napomena { get; set; }


        [Required]
        public string Status { get; set; }


        /* unaprijed zadana inicijalna vrijednost svojstva Status */
        public Predbiljezba()
        {
            Status = "Zaprimljena";
        }
    }
}