using SoftUni;
using SoftUni.Data;

var db = new SoftUniContext();
db.Database.EnsureCreated();

// Database first approach

Exercises exercises = new Exercises(db);
exercises.Run();