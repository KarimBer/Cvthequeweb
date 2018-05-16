using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public DateTime Date_Naissance { get; set; }
        public string Genre { get; set; }
        public string Situation_Familiale { get; set; }
        public string Ville { get; set; }
        public string CIN { get; set; }
    }
}