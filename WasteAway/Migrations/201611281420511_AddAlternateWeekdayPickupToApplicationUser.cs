namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlternateWeekdayPickupToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AlternatePickupWeekdayId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "AlternatePickupWeekdayId");
            AddForeignKey("dbo.AspNetUsers", "AlternatePickupWeekdayId", "dbo.Weekdays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "AlternatePickupWeekdayId", "dbo.Weekdays");
            DropIndex("dbo.AspNetUsers", new[] { "AlternatePickupWeekdayId" });
            DropColumn("dbo.AspNetUsers", "AlternatePickupWeekdayId");
        }
    }
}
