using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Centres_Interet
    {
        public int Id { get; set; }
        public string Interet { get; set; }
        public string CandidatId { get; set; }
        public Candidat candidat { get; set; }
    }
}