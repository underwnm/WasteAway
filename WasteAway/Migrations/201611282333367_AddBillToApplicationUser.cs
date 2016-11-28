namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BillId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BillId");
            AddForeignKey("dbo.AspNetUsers", "BillId", "dbo.Bills", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BillId", "dbo.Bills");
            DropIndex("dbo.AspNetUsers", new[] { "BillId" });
            DropColumn("dbo.AspNetUsers", "BillId");
        }
    }
}
