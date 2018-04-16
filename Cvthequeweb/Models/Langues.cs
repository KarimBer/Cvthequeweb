using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Langues
    {
        public int Id { get; set; }
        public string Langue { get; set; }
        public string Niveau { get; set; }
        public string CandidatId { get; set; }
        public Candidat candidat { get; set; }
    }
}