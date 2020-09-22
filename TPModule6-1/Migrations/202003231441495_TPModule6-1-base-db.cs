namespace TPModule6_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPModule61basedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Degats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Samourais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Force = c.Int(nullable: false),
                        Nom = c.String(),
                        Arme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armes", t => t.Arme_Id)
                .Index(t => t.Arme_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes");
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropTable("dbo.Samourais");
            DropTable("dbo.Armes");
        }
    }
}
