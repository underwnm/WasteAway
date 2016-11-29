namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTruckAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes");
            DropIndex("dbo.Trucks", new[] { "ZipcodeId" });
            AlterColumn("dbo.Trucks", "ZipcodeId", c => c.Int());
            CreateIndex("dbo.Trucks", "ZipcodeId");
            AddForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes");
            DropIndex("dbo.Trucks", new[] { "ZipcodeId" });
            AlterColumn("dbo.Trucks", "ZipcodeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trucks", "ZipcodeId");
            AddForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes", "Id", cascadeDelete: true);
        }
    }
}
