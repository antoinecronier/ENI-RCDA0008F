namespace Demo10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prop1 = c.String(),
                        Prop2 = c.String(),
                        Prop3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Class1");
        }
    }
}
