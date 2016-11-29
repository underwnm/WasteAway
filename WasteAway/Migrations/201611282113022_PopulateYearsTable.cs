namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateYearsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Years ON");
            Sql("INSERT INTO Years (Id, Name) VALUES (1, '2016')");
            Sql("INSERT INTO Years (Id, Name) VALUES (2, '2017')");
            Sql("SET IDENTITY_INSERT Years OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Years WHERE Id IN (1, 2)");
        }
    }
}
