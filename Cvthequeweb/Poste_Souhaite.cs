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
    
    public partial class Poste_Souhaite
    {
        public int Id { get; set; }
        public string Titre_Poste { get; set; }
        public Nullable<double> Fourchette_Salarial { get; set; }
        public string Secteur_Activite { get; set; }
        public string Mobile { get; set; }
        public int Id_Candiat { get; set; }
    
        public virtual Candidat Candidat { get; set; }
    }
}
