namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTruckTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ZipcodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zipcodes", t => t.ZipcodeId, cascadeDelete: true)
                .Index(t => t.ZipcodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes");
            DropIndex("dbo.Trucks", new[] { "ZipcodeId" });
            DropTable("dbo.Trucks");
        }
    }
}
