namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePickupsTruckIdAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks");
            DropIndex("dbo.Pickups", new[] { "TruckId" });
            AlterColumn("dbo.Pickups", "TruckId", c => c.Int());
            CreateIndex("dbo.Pickups", "TruckId");
            AddForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks");
            DropIndex("dbo.Pickups", new[] { "TruckId" });
            AlterColumn("dbo.Pickups", "TruckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pickups", "TruckId");
            AddForeignKey("dbo.Pickups", "TruckId", "dbo.Trucks", "Id", cascadeDelete: true);
        }
    }
}
