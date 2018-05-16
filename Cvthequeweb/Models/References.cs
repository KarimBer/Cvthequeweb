using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class References
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Titre { get; set; }
        public string Entreprise { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Type { get; set; }
        public string CandidatId { get; set; }
        public virtual Candidat candidat { get; set; }
    }
}