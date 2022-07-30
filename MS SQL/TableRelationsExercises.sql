CREATE DATABASE PeopleAndPassports;
USE PeopleAndPassports;

CREATE TABLE Passports (
    PassportID INT PRIMARY KEY IDENTITY(101, 1),
    PassportNumber CHAR(8) NOT NULL,
);

CREATE TABLE Persons (
    PersonID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(80) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    PassportID INT UNIQUE NOT NULL REFERENCES Passports(PassportID),
);

INSERT Passports (PassportNumber) VALUES ('N34FG21B');
INSERT Passports (PassportNumber) VALUES ('K65LO4R7');
INSERT Passports (PassportNumber) VALUES ('ZE657QP2');

INSERT Persons (FirstName, Salary, PassportID) VALUES ('Roberto',43300.00,102)
INSERT Persons (FirstName, Salary, PassportID) VALUES ('Tom',56100.00,103)
INSERT Persons (FirstName, Salary, PassportID) VALUES ('Yana',60200.00,101)


SELECT * FROM Persons;

DROP TABLE Passports;
DROP TABLE Persons;





CREATE DATABASE Phones;
USE Phones;

CREATE TABLE Manufacturers(
    ManufacturerID INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(80) NOT NULL,
    EstablishedOn DATE NOT NULL,
);

CREATE TABLE Models (
    ModelID INT IDENTITY(101, 1) PRIMARY KEY,
    [Name] VARCHAR(80),
    ManufacturerID INT NOT NULL REFERENCES Manufacturers(ManufacturerID),
);

INSERT Manufacturers(Name, EstablishedOn) VALUES ('BMW','1916-03-07');
INSERT Manufacturers(Name, EstablishedOn) VALUES ('Tesla','2003-01-01');
INSERT Manufacturers(Name, EstablishedOn) VALUES ('Lada','1966-05-01');

INSERT Models(Name, ManufacturerID) VALUES('X1',1);
INSERT Models(Name, ManufacturerID) VALUES('i6',1);
INSERT Models(Name, ManufacturerID) VALUES('Model S',2);
INSERT Models(Name, ManufacturerID) VALUES('Model X',2);
INSERT Models(Name, ManufacturerID) VALUES('Model 3',2);
INSERT Models(Name, ManufacturerID) VALUES('Nova',3);







CREATE TABLE Students (
    StudentID INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(80),
);

CREATE TABLE Exams (
    ExamID INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(80),
);

CREATE TABLE StudentsExams (
    StudentID INT REFERENCES Students(StudentID),
    ExamID INT REFERENCES Exams(ExamID),
    PRIMARY KEY (StudentID, ExamID)
);


INSERT Students([Name]) VALUES ('Mila');            
INSERT Students([Name]) VALUES ('Toni');
INSERT Students([Name]) VALUES ('Ron');
