namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class langues : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Langues", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Langues", new[] { "candidat_Id" });
            DropTable("dbo.Langues");
        }
    }
}
