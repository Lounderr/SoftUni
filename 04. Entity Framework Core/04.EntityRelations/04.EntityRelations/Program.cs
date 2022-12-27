using EntityRelationsDemo.Models;

var db = new ApplicationDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

for (int i = 0; i < 10; i++)
{
    db.Employees.Add(new Employee
    {
        FirstName = "Niki_" + i,
        LastName = "Kostov",
        StartWorkDate = new DateTime(2010 + i, 1, 1),
        Salary = 100 + i,
    });
}

db.SaveChanges();
