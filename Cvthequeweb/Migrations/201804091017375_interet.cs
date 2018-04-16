namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interet : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Centres_Interet", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Centres_Interet", new[] { "candidat_Id" });
            DropTable("dbo.Centres_Interet");
        }
    }
}
