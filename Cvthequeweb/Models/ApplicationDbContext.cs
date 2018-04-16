using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Cvthequeweb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Candidat> candidat { get; set; }
        public DbSet<Experiences_Pro> experiences_pro { get; set; }
        public DbSet<Formations> formations { get; set; }
        public DbSet<Certifications> certifications { get; set; }
        public DbSet<Competences_Pro> competences_pro { get; set; }
        public DbSet<Projet_Realise> projets_realise { get; set; }
        public DbSet<Langues> langues { get; set; }
        public DbSet<Centres_Interet> centres_interet { get; set; }
        public DbSet<References> references { get; set; }
        public DbSet<Poste_Souhaite> poste_souhaite { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}