namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBillsTableAndAddBalanceToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BillId", "dbo.Bills");
            DropIndex("dbo.AspNetUsers", new[] { "BillId" });
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.AspNetUsers", "BillId");
            DropTable("dbo.Bills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "BillId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Balance");
            CreateIndex("dbo.AspNetUsers", "BillId");
            AddForeignKey("dbo.AspNetUsers", "BillId", "dbo.Bills", "Id");
        }
    }
}
