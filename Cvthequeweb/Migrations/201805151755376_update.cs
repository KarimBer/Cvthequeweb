namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Centres_Interet", new[] { "candidat_Id" });
            DropIndex("dbo.Certifications", new[] { "candidat_Id" });
            DropIndex("dbo.Competences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Experiences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Formations", new[] { "candidat_Id" });
            DropIndex("dbo.Langues", new[] { "candidat_Id" });
            DropIndex("dbo.Poste_Souhaite", new[] { "candidat_Id" });
            DropIndex("dbo.Projet_Realise", new[] { "candidat_Id" });
            DropIndex("dbo.References", new[] { "candidat_Id" });
            AlterColumn("dbo.Centres_Interet", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Certifications", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Competences_Pro", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Experiences_Pro", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Formations", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Langues", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Poste_Souhaite", "Candidat_Id", c => c.String());
            AlterColumn("dbo.Projet_Realise", "Candidat_Id", c => c.String());
            AlterColumn("dbo.References", "Candidat_Id", c => c.String());
            CreateIndex("dbo.Centres_Interet", "candidat_Id");
            CreateIndex("dbo.Certifications", "candidat_Id");
            CreateIndex("dbo.Competences_Pro", "candidat_Id");
            CreateIndex("dbo.Experiences_Pro", "candidat_Id");
            CreateIndex("dbo.Formations", "candidat_Id");
            CreateIndex("dbo.Langues", "candidat_Id");
            CreateIndex("dbo.Poste_Souhaite", "candidat_Id");
            CreateIndex("dbo.Projet_Realise", "candidat_Id");
            CreateIndex("dbo.References", "candidat_Id");
            DropColumn("dbo.Centres_Interet", "CandidatId");
            DropColumn("dbo.Certifications", "CandidatId");
            DropColumn("dbo.Competences_Pro", "CandidatId");
            DropColumn("dbo.Experiences_Pro", "CandidatId");
            DropColumn("dbo.Formations", "CandidatId");
            DropColumn("dbo.Langues", "CandidatId");
            DropColumn("dbo.Poste_Souhaite", "CandidatId");
            DropColumn("dbo.Projet_Realise", "CandidatId");
            DropColumn("dbo.References", "CandidatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.References", "CandidatId", c => c.String());
            AddColumn("dbo.Projet_Realise", "CandidatId", c => c.String());
            AddColumn("dbo.Poste_Souhaite", "CandidatId", c => c.String());
            AddColumn("dbo.Langues", "CandidatId", c => c.String());
            AddColumn("dbo.Formations", "CandidatId", c => c.String());
            AddColumn("dbo.Experiences_Pro", "CandidatId", c => c.String());
            AddColumn("dbo.Competences_Pro", "CandidatId", c => c.String());
            AddColumn("dbo.Certifications", "CandidatId", c => c.String());
            AddColumn("dbo.Centres_Interet", "CandidatId", c => c.String());
            DropIndex("dbo.References", new[] { "candidat_Id" });
            DropIndex("dbo.Projet_Realise", new[] { "candidat_Id" });
            DropIndex("dbo.Poste_Souhaite", new[] { "candidat_Id" });
            DropIndex("dbo.Langues", new[] { "candidat_Id" });
            DropIndex("dbo.Formations", new[] { "candidat_Id" });
            DropIndex("dbo.Experiences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Competences_Pro", new[] { "candidat_Id" });
            DropIndex("dbo.Certifications", new[] { "candidat_Id" });
            DropIndex("dbo.Centres_Interet", new[] { "candidat_Id" });
            AlterColumn("dbo.References", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Projet_Realise", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Poste_Souhaite", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Langues", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Formations", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Experiences_Pro", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Competences_Pro", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Certifications", "Candidat_Id", c => c.Int());
            AlterColumn("dbo.Centres_Interet", "Candidat_Id", c => c.Int());
            CreateIndex("dbo.References", "candidat_Id");
            CreateIndex("dbo.Projet_Realise", "candidat_Id");
            CreateIndex("dbo.Poste_Souhaite", "candidat_Id");
            CreateIndex("dbo.Langues", "candidat_Id");
            CreateIndex("dbo.Formations", "candidat_Id");
            CreateIndex("dbo.Experiences_Pro", "candidat_Id");
            CreateIndex("dbo.Competences_Pro", "candidat_Id");
            CreateIndex("dbo.Certifications", "candidat_Id");
            CreateIndex("dbo.Centres_Interet", "candidat_Id");
        }
    }
}
