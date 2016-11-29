namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBillAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "Amount", c => c.Int(nullable: false));
        }
    }
}
