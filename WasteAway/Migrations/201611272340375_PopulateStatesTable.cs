namespace WasteAway.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateStatesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT States ON");
            Sql("INSERT INTO States (Id, Name) VALUES (1, 'Alabama')");
            Sql("INSERT INTO States (Id, Name) VALUES (2, 'Alaska')");
            Sql("INSERT INTO States (Id, Name) VALUES (3, 'Arizona')");
            Sql("INSERT INTO States (Id, Name) VALUES (4, 'Arkansas')");
            Sql("INSERT INTO States (Id, Name) VALUES (5, 'California')");
            Sql("INSERT INTO States (Id, Name) VALUES (6, 'Colorado')");
            Sql("INSERT INTO States (Id, Name) VALUES (7, 'Connecticut')");
            Sql("INSERT INTO States (Id, Name) VALUES (8, 'Delaware')");
            Sql("INSERT INTO States (Id, Name) VALUES (9, 'Florida')");
            Sql("INSERT INTO States (Id, Name) VALUES (10, 'Georgia')");
            Sql("INSERT INTO States (Id, Name) VALUES (11, 'Hawaii')");
            Sql("INSERT INTO States (Id, Name) VALUES (12, 'Idaho')");
            Sql("INSERT INTO States (Id, Name) VALUES (13, 'Illinois')");
            Sql("INSERT INTO States (Id, Name) VALUES (14, 'Indiana')");
            Sql("INSERT INTO States (Id, Name) VALUES (15, 'Iowa')");
            Sql("INSERT INTO States (Id, Name) VALUES (16, 'Kansas')");
            Sql("INSERT INTO States (Id, Name) VALUES (17, 'Kentucky')");
            Sql("INSERT INTO States (Id, Name) VALUES (18, 'Louisiana')");
            Sql("INSERT INTO States (Id, Name) VALUES (19, 'Maine')");
            Sql("INSERT INTO States (Id, Name) VALUES (20, 'Maryland')");
            Sql("INSERT INTO States (Id, Name) VALUES (21, 'Massachusetts')");
            Sql("INSERT INTO States (Id, Name) VALUES (22, 'Michigan')");
            Sql("INSERT INTO States (Id, Name) VALUES (23, 'Minnesota')");
            Sql("INSERT INTO States (Id, Name) VALUES (24, 'Mississippi')");
            Sql("INSERT INTO States (Id, Name) VALUES (25, 'Missouri')");
            Sql("INSERT INTO States (Id, Name) VALUES (26, 'Montana')");
            Sql("INSERT INTO States (Id, Name) VALUES (27, 'Nebraska')");
            Sql("INSERT INTO States (Id, Name) VALUES (28, 'Nevada')");
            Sql("INSERT INTO States (Id, Name) VALUES (29, 'New Hampshire')");
            Sql("INSERT INTO States (Id, Name) VALUES (30, 'New Jersey')");
            Sql("INSERT INTO States (Id, Name) VALUES (31, 'New Mexico')");
            Sql("INSERT INTO States (Id, Name) VALUES (32, 'New York')");
            Sql("INSERT INTO States (Id, Name) VALUES (33, 'North Carolina')");
            Sql("INSERT INTO States (Id, Name) VALUES (34, 'North Dakota')");
            Sql("INSERT INTO States (Id, Name) VALUES (35, 'Ohio')");
            Sql("INSERT INTO States (Id, Name) VALUES (36, 'Oklahoma')");
            Sql("INSERT INTO States (Id, Name) VALUES (37, 'Oregon')");
            Sql("INSERT INTO States (Id, Name) VALUES (38, 'Pennsylvania')");
            Sql("INSERT INTO States (Id, Name) VALUES (39, 'Rhode Island')");
            Sql("INSERT INTO States (Id, Name) VALUES (40, 'South Carolina')");
            Sql("INSERT INTO States (Id, Name) VALUES (41, 'South Dakota')");
            Sql("INSERT INTO States (Id, Name) VALUES (42, 'Tennessee')");
            Sql("INSERT INTO States (Id, Name) VALUES (43, 'Texas')");
            Sql("INSERT INTO States (Id, Name) VALUES (44, 'Utah')");
            Sql("INSERT INTO States (Id, Name) VALUES (45, 'Vermont')");
            Sql("INSERT INTO States (Id, Name) VALUES (46, 'Virginia')");
            Sql("INSERT INTO States (Id, Name) VALUES (47, 'Washington')");
            Sql("INSERT INTO States (Id, Name) VALUES (48, 'West Virginia')");
            Sql("INSERT INTO States (Id, Name) VALUES (49, 'Wisconsin')");
            Sql("INSERT INTO States (Id, Name) VALUES (50, 'Wyoming')");
            Sql("SET IDENTITY_INSERT States OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM States WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10," +
                " 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30," +
                " 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50)");
        }
    }
}
