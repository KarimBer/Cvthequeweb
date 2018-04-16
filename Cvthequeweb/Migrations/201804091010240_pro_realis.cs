namespace Cvthequeweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pro_realis : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projet_Realise", "candidat_Id", "dbo.Candidats");
            DropIndex("dbo.Projet_Realise", new[] { "candidat_Id" });
            DropTable("dbo.Projet_Realise");
        }
    }
}
