namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMonthsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Months ON");
            Sql("INSERT INTO Months (Id, Name) VALUES (1, 'January')");
            Sql("INSERT INTO Months (Id, Name) VALUES (2, 'February')");
            Sql("INSERT INTO Months (Id, Name) VALUES (3, 'March')");
            Sql("INSERT INTO Months (Id, Name) VALUES (4, 'April')");
            Sql("INSERT INTO Months (Id, Name) VALUES (5, 'May')");
            Sql("INSERT INTO Months (Id, Name) VALUES (6, 'June')");
            Sql("INSERT INTO Months (Id, Name) VALUES (7, 'July')");
            Sql("INSERT INTO Months (Id, Name) VALUES (8, 'August')");
            Sql("INSERT INTO Months (Id, Name) VALUES (9, 'September')");
            Sql("INSERT INTO Months (Id, Name) VALUES (10, 'October')");
            Sql("INSERT INTO Months (Id, Name) VALUES (11, 'November')");
            Sql("INSERT INTO Months (Id, Name) VALUES (12, 'December')");
            Sql("SET IDENTITY_INSERT Months OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Months WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)");
        }
    }
}
