using P01_StudentSystem.Data;

var db = new ApplicationDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

