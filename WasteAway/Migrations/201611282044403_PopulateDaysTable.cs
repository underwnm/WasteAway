namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDaysTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Days ON");
            Sql("INSERT INTO Days (Id, Name) VALUES (1, '1')");
            Sql("INSERT INTO Days (Id, Name) VALUES (2, '2')");
            Sql("INSERT INTO Days (Id, Name) VALUES (3, '3')");
            Sql("INSERT INTO Days (Id, Name) VALUES (4, '4')");
            Sql("INSERT INTO Days (Id, Name) VALUES (5, '5')");
            Sql("INSERT INTO Days (Id, Name) VALUES (6, '6')");
            Sql("INSERT INTO Days (Id, Name) VALUES (7, '7')");
            Sql("INSERT INTO Days (Id, Name) VALUES (8, '8')");
            Sql("INSERT INTO Days (Id, Name) VALUES (9, '9')");
            Sql("INSERT INTO Days (Id, Name) VALUES (10, '10')");
            Sql("INSERT INTO Days (Id, Name) VALUES (11, '11')");
            Sql("INSERT INTO Days (Id, Name) VALUES (12, '12')");
            Sql("INSERT INTO Days (Id, Name) VALUES (13, '13')");
            Sql("INSERT INTO Days (Id, Name) VALUES (14, '14')");
            Sql("INSERT INTO Days (Id, Name) VALUES (15, '15')");
            Sql("INSERT INTO Days (Id, Name) VALUES (16, '16')");
            Sql("INSERT INTO Days (Id, Name) VALUES (17, '17')");
            Sql("INSERT INTO Days (Id, Name) VALUES (18, '18')");
            Sql("INSERT INTO Days (Id, Name) VALUES (19, '19')");
            Sql("INSERT INTO Days (Id, Name) VALUES (20, '20')");
            Sql("INSERT INTO Days (Id, Name) VALUES (21, '21')");
            Sql("INSERT INTO Days (Id, Name) VALUES (22, '22')");
            Sql("INSERT INTO Days (Id, Name) VALUES (23, '23')");
            Sql("INSERT INTO Days (Id, Name) VALUES (24, '24')");
            Sql("INSERT INTO Days (Id, Name) VALUES (25, '25')");
            Sql("INSERT INTO Days (Id, Name) VALUES (26, '26')");
            Sql("INSERT INTO Days (Id, Name) VALUES (27, '27')");
            Sql("INSERT INTO Days (Id, Name) VALUES (28, '28')");
            Sql("INSERT INTO Days (Id, Name) VALUES (29, '29')");
            Sql("INSERT INTO Days (Id, Name) VALUES (30, '30')");
            Sql("INSERT INTO Days (Id, Name) VALUES (31, '31')");
            Sql("SET IDENTITY_INSERT Days OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM States WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10," +
                " 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31");
        }
    }
}
