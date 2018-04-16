namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exp : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences_Pro", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Experiences_Pro", new[] { "candidat_Id" });
            DropTable("dbo.Experiences_Pro");
        }
    }
}
