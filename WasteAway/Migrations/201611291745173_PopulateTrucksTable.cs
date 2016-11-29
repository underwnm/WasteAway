namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTrucksTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT States ON");
            Sql("INSERT INTO States (Id, Name) VALUES (1, 'Wisconsin')");
            Sql("SET IDENTITY_INSERT States OFF");

            Sql("SET IDENTITY_INSERT Cities ON");
            Sql("INSERT INTO Cities (Id, Name, StateId) VALUES (1, 'Port Washington', '1')");
            Sql("INSERT INTO Cities (Id, Name, StateId) VALUES (2, 'Saukville', '1')");
            Sql("INSERT INTO Cities (Id, Name, StateId) VALUES (3, 'Cedarburg', '1')");
            Sql("INSERT INTO Cities (Id, Name, StateId) VALUES (4, 'Grafton', '1')");
            Sql("INSERT INTO Cities (Id, Name, StateId) VALUES (5, 'Mequon', '1')");
            Sql("SET IDENTITY_INSERT Cities OFF");

            Sql("SET IDENTITY_INSERT Zipcodes ON");
            Sql("INSERT INTO Zipcodes (Id, Name) VALUES (1, '53074')");
            Sql("INSERT INTO Zipcodes (Id, Name) VALUES (2, '53080')");
            Sql("INSERT INTO Zipcodes (Id, Name) VALUES (3, '53012')");
            Sql("INSERT INTO Zipcodes (Id, Name) VALUES (4, '53024')");
            Sql("INSERT INTO Zipcodes (Id, Name) VALUES (5, '53097')");
            Sql("SET IDENTITY_INSERT Zipcodes OFF");

            Sql("SET IDENTITY_INSERT Trucks ON");
            Sql("INSERT INTO Trucks (Id, Number, ZipcodeId) VALUES (1, 'USDOT 8888880',  1)");
            Sql("INSERT INTO Trucks (Id, Number, ZipcodeId) VALUES (2, 'USDOT 8888881',  2)");
            Sql("INSERT INTO Trucks (Id, Number, ZipcodeId) VALUES (3, 'USDOT 8888882',  3)");
            Sql("INSERT INTO Trucks (Id, Number, ZipcodeId) VALUES (4, 'USDOT 8888883',  4)");
            Sql("INSERT INTO Trucks (Id, Number, ZipcodeId) VALUES (5, 'USDOT 8888885',  5)");
            Sql("SET IDENTITY_INSERT Trucks OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM States WHERE Id IN (1)");
            Sql("DELETE FROM Cities WHERE Id IN (1, 2, 3, 4, 5)");
            Sql("DELETE FROM Zipcodes WHERE Id IN (1, 2, 3, 4, 5)");
            Sql("DELETE FROM Trucks WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
