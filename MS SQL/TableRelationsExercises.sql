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
    ExamID INT IDENTITY(101, 1) PRIMARY KEY,
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

INSERT Exams([Name]) VALUES ('SpringMVC');
INSERT Exams([Name]) VALUES ('Neo4j');
INSERT Exams([Name]) VALUES ('Oracle 11g');

SELECT * FROM StudentsExams

INSERT StudentsExams 
VALUES 
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103);

-- SELECT * FROM StudentsExams AS se JOIN Exams as e ON se.ExamID = e.ExamID JOIN Students AS s ON s.StudentID = se.StudentID;




CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY(101, 1),
    [Name] VARCHAR(80),
    ManagerID INT REFERENCES Teachers(TeacherID)
);

INSERT Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101);


CREATE DATABASE [Online Store Database];
USE [Online Store Database];

CREATE TABLE Cities (
    CityID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50),
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50),
    Birthday DATE,
    CityID INT REFERENCES Cities(CityID),
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT REFERENCES Customers(CustomerID),
);

CREATE TABLE ItemTypes (
    ItemTypeID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50)
);

CREATE TABLE Items (
    ItemID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50),
    ItemTypeID INT REFERENCES ItemTypes(ItemTypeID),
);

CREATE TABLE OrderItems (
    OrderID INT REFERENCES Orders(OrderID),
    ItemID INT REFERENCES Items(ItemID),
    PRIMARY KEY (OrderID, ItemID)
);







CREATE DATABASE [University Database];
USE [University Database];

CREATE TABLE Majors (
    MajorID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30),
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY,
    StudentNumber VARCHAR(30),
    StudentName VARCHAR(30),
    MajorID INT REFERENCES Majors(MajorID),    
);

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
    PaymentDate DATE,
    PaymentAmount DECIMAL(10, 2),
    StudentID INT REFERENCES Students(StudentID),
);

CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY IDENTITY,
    SubjectName VARCHAR(30),
);


CREATE TABLE Agenda (
    StudentID INT REFERENCES Students(StudentID),
    SubjectID INT REFERENCES Subjects(SubjectID),
    PRIMARY KEY (StudentID, SubjectID),
);











USE [Geography];
SELECT MountainRange, PeakName, Elevation FROM Peaks AS p JOIN Mountains AS m ON m.Id = p.MountainId WHERE MountainRange = 'Rila' ORDER BY Elevation DESC;