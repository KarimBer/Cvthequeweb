//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cvthequeweb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Formation
    {
        public int Id { get; set; }
        public string Diplome { get; set; }
        public string Specialite { get; set; }
        public string Date_Obtention { get; set; }
        public string Etablissement { get; set; }
        public string Niveau { get; set; }
        public int Id_Candiat { get; set; }
    
        public virtual Candidat Candidat { get; set; }
    }
}