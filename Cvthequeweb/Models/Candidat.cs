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
        public string CentreInteretId { get; set; }
        public Centres_Interet centres_Interet { get; set; }
        public string CertificationId { get; set; }
        public Certifications certifications { get; set; }
        public string Competences_Pro { get; set; }
        public Competences_Pro competences_Pro { get; set; }
        public string Experiences_Pro { get; set; }
        public Experiences_Pro experiences_Pro { get; set; }
        public string Formations { get; set; }
        public Formations formations { get; set; }
        public string Langues { get; set; }
        public Langues langues { get; set; }
        public string Poste_souhaite { get; set; }
        public Poste_Souhaite poste_souhaite { get; set; }
        public string Projet_Realise { get; set; }
        public Projet_Realise projet_realise { get; set; }
        public string References { get; set; }
        public References references { get; set; }
    }
}