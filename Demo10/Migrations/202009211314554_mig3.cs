namespace Demo10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prop1 = c.String(),
                        Class1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class1", t => t.Class1_Id)
                .Index(t => t.Class1_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Class2", "Class1_Id", "dbo.Class1");
            DropIndex("dbo.Class2", new[] { "Class1_Id" });
            DropTable("dbo.Class2");
        }
    }
}
