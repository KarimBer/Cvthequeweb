﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cvthequeweb.Models
{
    public class Poste_Souhaite
    {
        public int Id { get; set; }
        public string Titre_Poste { get; set; }
        public float Fourchette_salariale { get; set; }
        public string Secteur_Activite { get; set; }
        public string Mobile { get; set; }
    }
}