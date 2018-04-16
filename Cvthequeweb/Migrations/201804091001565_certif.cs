namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class certif : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Certifications", new[] { "candidat_Id" });
            DropTable("dbo.Certifications");
        }
    }
}
