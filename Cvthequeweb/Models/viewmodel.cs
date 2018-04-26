using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class viewmodel
    {
        public Candidat candidat { get; set; }
        public List<Candidat> Candidats { get; set; }

        public Centres_Interet centres_Interet { get; set; }
        public List<Centres_Interet> Centres_Interets { get; set; }

        public Certifications certifications { get; set; }
        public List<Certifications> certificatiions { get; set; }

        public Competences_Pro competences_Pro { get; set; }
        public List<Competences_Pro> Competences_Pros { get; set; }

        public Experiences_Pro experiences_Pro { get; set; }
        public List<Experiences_Pro> Experiences_Pros { get; set; }

        public Formations formations { get; set; }
        public List<Formations> Formatiions { get; set; }

        public Langues langues { get; set; }
        public List<Langues> Languees { get; set; }

        public Poste_Souhaite poste_Souhaite { get; set; }
        public List<Poste_Souhaite> Postes_Souhaites { get; set; }

        public Projet_Realise projet_Realise { get; set; }
        public List<Projet_Realise> Projets_Realises { get; set; }

        public References references { get; set; }
        public List<References> Referencees { get; set; }
    }
}