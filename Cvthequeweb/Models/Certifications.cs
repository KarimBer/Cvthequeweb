using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Certifications
    {
        public int Id { get; set; }
        public string Nom_certif { get; set; }
        public string Nom_Organisme { get; set; }
        public DateTime Date_Obtention { get; set; }
        public string CandidatId { get; set; }
        public Candidat candidat { get; set; }
    }
}