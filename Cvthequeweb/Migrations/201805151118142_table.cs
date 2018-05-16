namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centres_Interet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interet = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
            CreateTable(
                "dbo.Competences_Pro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Competences = c.String(),
                        CandidatId = c.String(),
                        candidat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.References", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Projet_Realise", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Poste_Souhaite", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Langues", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Formations", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Competences_Pro", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Certifications", "candidat_Id", "dbo.Candidats");
            DropForeignKey("dbo.Centres_Interet", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.References", new[] { "candidat_Id" });
            DropIndex("dbo.Projet_Realise", new[] { "candidat_Id" });
            DropIndex("dbo.Poste_Souhaite", new[] { "candidat_Id" });
            DropIndex("dbo.Langues", new[] { "candidat_Id" });
            DropIndex("dbo.Formations", new[] { "candidat_Id" });
            DropIndex("dbo.Competences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Certifications", new[] { "candidat_Id" });
            DropIndex("dbo.Centres_Interet", new[] { "candidat_Id" });
            DropTable("dbo.References");
            DropTable("dbo.Projet_Realise");
            DropTable("dbo.Poste_Souhaite");
            DropTable("dbo.Langues");
            DropTable("dbo.Formations");
            DropTable("dbo.Competences_Pro");
            DropTable("dbo.Certifications");
            DropTable("dbo.Centres_Interet");
        }
    }
}
