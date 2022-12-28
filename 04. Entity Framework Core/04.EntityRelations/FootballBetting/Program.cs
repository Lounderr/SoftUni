using E02_FootballBetting.Data;

var db = new FootballBettingContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
Console.WriteLine("Completed!");