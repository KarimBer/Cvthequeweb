namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formation : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formations", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Formations", new[] { "candidat_Id" });
            DropTable("dbo.Formations");
        }
    }
}
