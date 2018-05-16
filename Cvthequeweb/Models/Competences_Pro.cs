using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Competences_Pro
    {
        public int Id { get; set; }
        public string Competences { get; set; }
        public string CandidatId { get; set; }
        public virtual Candidat candidat { get; set; }
    }
}