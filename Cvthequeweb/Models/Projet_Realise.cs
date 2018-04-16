using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Projet_Realise
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Organisme { get; set; }
        public string CandidatId { get; set; }
        public Candidat candidat { get; set; }
    }
}