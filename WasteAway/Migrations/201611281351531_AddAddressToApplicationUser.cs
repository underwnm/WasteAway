namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PickupAddressId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PickupWeekdayId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "PickupAddressId");
            CreateIndex("dbo.AspNetUsers", "PickupWeekdayId");
            AddForeignKey("dbo.AspNetUsers", "PickupAddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.AspNetUsers", "PickupWeekdayId", "dbo.Weekdays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PickupWeekdayId", "dbo.Weekdays");
            DropForeignKey("dbo.AspNetUsers", "PickupAddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "PickupWeekdayId" });
            DropIndex("dbo.AspNetUsers", new[] { "PickupAddressId" });
            DropColumn("dbo.AspNetUsers", "PickupWeekdayId");
            DropColumn("dbo.AspNetUsers", "PickupAddressId");
        }
    }
}
