using EFCoreIntroductionDemo;

var db = new SoftUniContext();
db.Database.EnsureCreated();

// Database first approach