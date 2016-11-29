namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateWeekdaysTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Weekdays ON");
            Sql("INSERT INTO Weekdays (Id, Name) VALUES (1, 'Monday')");
            Sql("INSERT INTO Weekdays (Id, Name) VALUES (2, 'Tuesday')");
            Sql("INSERT INTO Weekdays (Id, Name) VALUES (3, 'Wednesday')");
            Sql("INSERT INTO Weekdays (Id, Name) VALUES (4, 'Thursday')");
            Sql("INSERT INTO Weekdays (Id, Name) VALUES (5, 'Friday')");
            Sql("SET IDENTITY_INSERT Weekdays OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM States WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
