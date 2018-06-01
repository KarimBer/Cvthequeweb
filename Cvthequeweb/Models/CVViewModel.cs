using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class CVViewModel
    {
        public Candidat Candidat { get; set; }
        public List<Candidat> Candidats { get; set; }
        public Formation Formation { get; set; }
        public List<Formation> Formations { get; set; }
        public Poste_Souhaite Poste_Souhaite { get; set; }
        public List<Poste_Souhaite> Poste_Souhaites { get; set; }
    }
}