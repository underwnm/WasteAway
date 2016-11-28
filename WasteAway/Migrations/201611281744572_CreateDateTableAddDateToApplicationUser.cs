namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateTableAddDateToApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayId = c.Int(nullable: false),
                        MonthId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Months", t => t.MonthId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.DayId)
                .Index(t => t.MonthId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "LeaveDateId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ReturnDateId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "LeaveDateId");
            CreateIndex("dbo.AspNetUsers", "ReturnDateId");
            AddForeignKey("dbo.AspNetUsers", "LeaveDateId", "dbo.Dates", "Id");
            AddForeignKey("dbo.AspNetUsers", "ReturnDateId", "dbo.Dates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ReturnDateId", "dbo.Dates");
            DropForeignKey("dbo.AspNetUsers", "LeaveDateId", "dbo.Dates");
            DropForeignKey("dbo.Dates", "YearId", "dbo.Years");
            DropForeignKey("dbo.Dates", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Dates", "DayId", "dbo.Days");
            DropIndex("dbo.AspNetUsers", new[] { "ReturnDateId" });
            DropIndex("dbo.AspNetUsers", new[] { "LeaveDateId" });
            DropIndex("dbo.Dates", new[] { "YearId" });
            DropIndex("dbo.Dates", new[] { "MonthId" });
            DropIndex("dbo.Dates", new[] { "DayId" });
            DropColumn("dbo.AspNetUsers", "ReturnDateId");
            DropColumn("dbo.AspNetUsers", "LeaveDateId");
            DropTable("dbo.Years");
            DropTable("dbo.Months");
            DropTable("dbo.Days");
            DropTable("dbo.Dates");
        }
    }
}
