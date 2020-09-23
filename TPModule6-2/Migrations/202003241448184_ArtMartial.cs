namespace TPModule6_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtMartial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtMartials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Samourai_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Samourais", t => t.Samourai_Id)
                .Index(t => t.Samourai_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtMartials", "Samourai_Id", "dbo.Samourais");
            DropIndex("dbo.ArtMartials", new[] { "Samourai_Id" });
            DropTable("dbo.ArtMartials");
        }
    }
}
