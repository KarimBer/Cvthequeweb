namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reference : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidats", t => t.candidat_Id)
                .Index(t => t.candidat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.References", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.References", new[] { "candidat_Id" });
            DropTable("dbo.References");
        }
    }
}
