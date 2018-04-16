namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poste : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Poste_Souhaite", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Poste_Souhaite", new[] { "candidat_Id" });
            DropTable("dbo.Poste_Souhaite");
        }
    }
}
