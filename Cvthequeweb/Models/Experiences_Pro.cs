using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Experiences_Pro
    {
        public int Id { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string Nature { get; set; }
        public string Type { get; set; }
        public string Employeur { get; set; }
        public string Secteur_Activite { get; set; }
        public string Titre_Poste { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public string CandidatId { get; set; }
        public Candidat candidat { get; set; }
    }
}