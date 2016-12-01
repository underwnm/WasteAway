namespace WasteAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "RoleId");
        }
    }
}
