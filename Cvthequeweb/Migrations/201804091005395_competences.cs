namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class competences : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competences_Pro", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Competences_Pro", new[] { "candidat_Id" });
            DropTable("dbo.Competences_Pro");
        }
    }
}
