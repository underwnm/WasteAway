namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickupsTodayToApplciationUsersAndTrucks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pickups", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes");
            DropIndex("dbo.Pickups", new[] { "UserId" });
            DropIndex("dbo.Trucks", new[] { "ZipcodeId" });
            AddColumn("dbo.Pickups", "TruckId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "TruckId", c => c.Int());
            AlterColumn("dbo.Pickups", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Trucks", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Trucks", "ZipcodeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pickups", "UserId");
            CreateIndex("dbo.Pickups", "TruckId");
            CreateIndex("dbo.Trucks", "ZipcodeId");
            CreateIndex("dbo.AspNetUsers", "TruckId");
            AddForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "TruckId", "dbo.Trucks", "Id");
            AddForeignKey("dbo.Pickups", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes");
            DropForeignKey("dbo.Pickups", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "TruckId", "dbo.Trucks");
            DropForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks");
            DropIndex("dbo.AspNetUsers", new[] { "TruckId" });
            DropIndex("dbo.Trucks", new[] { "ZipcodeId" });
            DropIndex("dbo.Pickups", new[] { "TruckId" });
            DropIndex("dbo.Pickups", new[] { "UserId" });
            AlterColumn("dbo.Trucks", "ZipcodeId", c => c.Int());
            AlterColumn("dbo.Trucks", "Number", c => c.String());
            AlterColumn("dbo.Pickups", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUsers", "TruckId");
            DropColumn("dbo.Pickups", "TruckId");
            CreateIndex("dbo.Trucks", "ZipcodeId");
            CreateIndex("dbo.Pickups", "UserId");
            AddForeignKey("dbo.Trucks", "ZipcodeId", "dbo.Zipcodes", "Id");
            AddForeignKey("dbo.Pickups", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
