using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Formations
    {
        public int Id { get; set; }
        public string Diplome { get; set; }
        public string Specialite { get; set; }
        public DateTime Date_Obtention { get; set; }
        public string Etablissement { get; set; }
        public string Niveau { get; set; }
    }
}