namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Centres_Interet", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Certifications", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Competences_Pro", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Experiences_Pro", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Formations", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Langues", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Poste_Souhaite", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Projet_Realise", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.References", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Centres_Interet", new[] { "candidat_Id" });
            DropIndex("dbo.Certifications", new[] { "candidat_Id" });
            DropIndex("dbo.Competences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Experiences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Formations", new[] { "candidat_Id" });
            DropIndex("dbo.Langues", new[] { "candidat_Id" });
            DropIndex("dbo.Poste_Souhaite", new[] { "candidat_Id" });
            DropIndex("dbo.Projet_Realise", new[] { "candidat_Id" });
            DropIndex("dbo.References", new[] { "candidat_Id" });
            DropTable("dbo.Candidats");
            DropTable("dbo.Centres_Interet");
            DropTable("dbo.Certifications");
            DropTable("dbo.Competences_Pro");
            DropTable("dbo.Experiences_Pro");
            DropTable("dbo.Formations");
            DropTable("dbo.Langues");
            DropTable("dbo.Poste_Souhaite");
            DropTable("dbo.Projet_Realise");
            DropTable("dbo.References");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Titre = c.String(),
                        Entreprise = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projet_Realise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Theme = c.String(),
                        Organisme = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Poste_Souhaite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre_Poste = c.String(),
                        Fourchette_salariale = c.Single(nullable: false),
                        Secteur_Activite = c.String(),
                        Mobile = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Langues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Langue = c.String(),
                        Niveau = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Diplome = c.String(),
                        Specialite = c.String(),
                        Date_Obtention = c.DateTime(nullable: false),
                        Etablissement = c.String(),
                        Niveau = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences_Pro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                        Nature = c.String(),
                        Type = c.String(),
                        Employeur = c.String(),
                        Secteur_Activite = c.String(),
                        Titre_Poste = c.String(),
                        Description = c.String(),
                        Duree = c.Int(nullable: false),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competences_Pro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Competences = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom_certif = c.String(),
                        Nom_Organisme = c.String(),
                        Date_Obtention = c.DateTime(nullable: false),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Centres_Interet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interet = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Tel = c.String(),
                        Adresse = c.String(),
                        Date_Naissance = c.DateTime(nullable: false),
                        Genre = c.String(),
                        Situation_Familiale = c.String(),
                        Ville = c.String(),
                        CIN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.References", "candidat_Id");
            CreateIndex("dbo.Projet_Realise", "candidat_Id");
            CreateIndex("dbo.Poste_Souhaite", "candidat_Id");
            CreateIndex("dbo.Langues", "candidat_Id");
            CreateIndex("dbo.Formations", "candidat_Id");
            CreateIndex("dbo.Experiences_Pro", "candidat_Id");
            CreateIndex("dbo.Competences_Pro", "candidat_Id");
            CreateIndex("dbo.Certifications", "candidat_Id");
            CreateIndex("dbo.Centres_Interet", "candidat_Id");
            AddForeignKey("dbo.References", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Projet_Realise", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Poste_Souhaite", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Langues", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Formations", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Experiences_Pro", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Competences_Pro", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Certifications", "candidat_Id", "dbo.Candidats", "Id");
            AddForeignKey("dbo.Centres_Interet", "candidat_Id", "dbo.Candidats", "Id");
        }
    }
}
