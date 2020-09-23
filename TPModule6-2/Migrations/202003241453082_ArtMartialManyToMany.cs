namespace TPModule6_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtMartialManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtMartials", "Samourai_Id", "dbo.Samourais");
            DropIndex("dbo.ArtMartials", new[] { "Samourai_Id" });
            CreateTable(
                "dbo.SamouraiArtMartials",
                c => new
                    {
                        Samourai_Id = c.Int(nullable: false),
                        ArtMartial_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Samourai_Id, t.ArtMartial_Id })
                .ForeignKey("dbo.Samourais", t => t.Samourai_Id, cascadeDelete: false)
                .ForeignKey("dbo.ArtMartials", t => t.ArtMartial_Id, cascadeDelete: false)
                .Index(t => t.Samourai_Id)
                .Index(t => t.ArtMartial_Id);
            
            DropColumn("dbo.ArtMartials", "Samourai_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtMartials", "Samourai_Id", c => c.Int());
            DropForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials");
            DropForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais");
            DropIndex("dbo.SamouraiArtMartials", new[] { "ArtMartial_Id" });
            DropIndex("dbo.SamouraiArtMartials", new[] { "Samourai_Id" });
            DropTable("dbo.SamouraiArtMartials");
            CreateIndex("dbo.ArtMartials", "Samourai_Id");
            AddForeignKey("dbo.ArtMartials", "Samourai_Id", "dbo.Samourais", "Id");
        }
    }
}
