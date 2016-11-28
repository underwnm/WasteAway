namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropIndex("dbo.Cities", new[] { "State_Id" });
            RenameColumn(table: "dbo.Cities", name: "State_Id", newName: "StateId");
            AlterColumn("dbo.Cities", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "StateId");
            AddForeignKey("dbo.Cities", "StateId", "dbo.States", "Id", cascadeDelete: true);
            DropColumn("dbo.Cities", "StringId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "StringId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropIndex("dbo.Cities", new[] { "StateId" });
            AlterColumn("dbo.Cities", "StateId", c => c.Int());
            RenameColumn(table: "dbo.Cities", name: "StateId", newName: "State_Id");
            CreateIndex("dbo.Cities", "State_Id");
            AddForeignKey("dbo.Cities", "State_Id", "dbo.States", "Id");
        }
    }
}
