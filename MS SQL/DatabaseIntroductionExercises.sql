-- Problem 1.	Create Database
CREATE DATABASE [Minions];
USE [Minions];

-- Problem 2.	Create Tables
CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY, 
	[Name] NVARCHAR(MAX), 
	[Age] INT,
);

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY, 
	[Name] NVARCHAR(MAX), 
);

-- Problem 3.	Alter Minions Table
ALTER TABLE [Minions] 
	ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]);

-- Problem 4.	Insert Records in Both Tables
INSERT INTO [Towns] VALUES (1, 'Sofia');
INSERT INTO [Towns] VALUES (2, 'Plovdiv');
INSERT INTO [Towns] VALUES (3, 'Varna');

INSERT INTO [Minions] VALUES (1, 'Kevin', 22, 1);
INSERT INTO [Minions] VALUES (2, 'Bob', 15, 3);
INSERT INTO [Minions] VALUES (3, 'Steward', NULL, 2);

-- Problem 5.	Truncate Table Minions
TRUNCATE TABLE [Minions]; 

-- Problem 6.	Drop All Tables
DROP TABLE [Minions];
DROP TABLE [Towns];

-- Problem 7.	Create Table People
CREATE TABLE [People] (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARCHAR(MAX),
	[Height] DECIMAL(8, 2),
	[Weight] DECIMAL(8, 2),
	[Gender] CHAR(1) NOT NULL CHECK([Gender] IN ('m', 'f')),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX),
);

INSERT [People] 
VALUES 
	('Name1', 'C:/Temp/picture1.png', 1.71, 65.1, 'm', '2001-11-01', 'mybio1'),
	('Name2', 'C:/Temp/picture2.png', 1.72, 65.2, 'm', '2001-11-02', 'mybio2'),
	('Name3', 'C:/Temp/picture3.png', 1.73, 65.3, 'm', '2001-11-03', 'mybio3'),
	('Name4', 'C:/Temp/picture4.png', 1.74, 65.4, 'm', '2001-11-04', 'mybio4'),
	('Name5', 'C:/Temp/picture5.png', 1.75, 65.5, 'm', '2001-11-05', 'mybio5');

-- Problem 8.	Create Table Users
CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL,
);

INSERT [Users] 
VALUES 
	('Name1', 'password1', 'C:/Temp/picture1.png', '2001-11-01 12:50:21.22', '0'),
	('Name2', 'password2', 'C:/Temp/picture2.png', '2001-11-02 12:50:22.22', '0'),
	('Name3', 'password3', 'C:/Temp/picture3.png', '2001-11-03 12:50:23.22', '1'),
	('Name4', 'password4', 'C:/Temp/picture4.png', '2001-11-04 12:50:24.22', '0'),
	('Name5', 'password5', 'C:/Temp/picture5.png', '2001-11-05 12:50:25.22', '1');

-- Problem 9.	Change Primary Key
ALTER TABLE Users 
	DROP CONSTRAINT "PK__Users__3214EC07AC6F86B7";
ALTER TABLE Users
	ADD PRIMARY KEY (Id, Username);

-- Problem 10.	Add Check Constraint
ALTER TABLE Users
	ADD CHECK(LEN([Password]) >= 5);

-- Problem 11.	Set Default Value of a Field
ALTER TABLE Users 
	ADD DEFAULT GetDate() FOR LastLoginTime;

INSERT Users (Username, [Password], ProfilePicture, IsDeleted) 
VALUES ('NowTest', 'password1', 'C:/Temp/picture1.png', '0');

-- Problem 12.	Set Unique Field
ALTER TABLE Users 
	DROP CONSTRAINT PK__Users__77222459DD25860D;
ALTER TABLE Users 
	ADD PRIMARY KEY (Id);
ALTER TABLE Users
	ADD CHECK(LEN(Username) >= 3);
ALTER TABLE Users
	ADD UNIQUE (Username);

-- Problem 13.	Movies Database
CREATE DATABASE Movies;
USE Movies;

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(30) UNIQUE NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Directors(DirectorName, Notes)
VALUES
	('John', 'asdfgh'),
	('John2', 'asdfgh'),
	('John34', 'asdfgh'),
	('John4', 'asdfgh'),
	('John5', 'asdfgh');

INSERT INTO Genres(GenreName, Notes)
VALUES
	('Crime', 'asdfgh'),
	('Fantacy', 'asdfgh'),
	('Crime2', 'asdfgh'),
	('Horror', 'asdfgh'),
	('Romantic', 'asdfgh');

INSERT INTO Categories(CategoryName, Notes)
VALUES
	('Categoria1', 'asdfgh'),
	('Categoria2', 'asdfgh'),
	('Categoria3', 'asdfgh'),
	('Categoria4', 'asdfgh'),
	('Categoria5', 'asdfgh');

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
	(' King' ,5,1999,78,1,5,10,'otlichen'),
	('RRIRIR',4,2000,90,2,4,9,'otlichen'),
	('plpppo',3,1980,100,3,3,5,'otlichen'),
	('kkiklo',2,1890,20,4,2,10,'iopkll'),
	('ukukkk',1,1990,120,5,1,10,'plpppp');


-- Problem 14.	Car Rental Database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		CategoryName NVARCHAR(50) UNIQUE NOT NULL,
		DailyRate INT NOT NULL,
		WeeklyRate INT, 
		MonthlyRate INT NOT NULL,
		WeekendRate INT
)

CREATE TABLE Cars(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		PlateNumber BIGINT UNIQUE NOT NULL,
		Manufacturer NVARCHAR(20) NOT NULL,
		Model NVARCHAR(20) NOT NULL,
		CarYear INT NOT NULL,
		CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
		Doors INT NOT NULL,
		Picture VARBINARY(2000),
		Condition VARCHAR(20),
		Available BIT NOT NULL,
)

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		Title NVARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Customers(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		DriverLicenceNumber INT NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		[Address] NVARCHAR(20) NOT NULL,
		City NVARCHAR(20) NOT NULL,
		ZIPCode NVARCHAR(10),
		NOTES NVARCHAR(100)
)

CREATE TABLE RentalOrders(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
		CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
		CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
		TankLevel INT NOT NULL,
		KilometrageStart INT NOT NULL,
		KilometrageEnd INT NOT NULL,
		TotalKilometrage INT NOT NULL,
		StartDate DATE NOT NULL,
		EndDate DATE NOT NULL,
		TotalDays INT NOT NULL,
		RateApplied INT,
		TaxRate INT,
		OrderStatus VARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

INSERT INTO Categories(CategoryName, DailyRate, MonthlyRate)
VALUES
('Sedan', 17, 5),
('Sedan3', 10, 6),
('4x4', 11, 3)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
(123458, 'BMW', '330 xd', 1990, 1, 4, 'Good', 1),
(896547, 'VW', 'golf 5', 1993, 1, 5, 'Bad', 0),
(236589, 'Audi', 'a6 ', 1991, 1, 2, 'Good', 1)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Ivan', 'Kurta', 'zaglaviq'),
('Angata', 'Beibe', 'zaglaviq'),
('Malinkov', 'Neta', 'zaglaviq')

INSERT INTO Customers(DriverLicenceNumber, FirstName, [Address], City, ZIPCode)
VALUES
(354128, 'Ivan Kurtacha', 'Hristo smirnenski 3', 'Bracigovo', '4430'),
(374128, 'Angata Kurtacha', 'Hristo smirnenski 2', 'peshtera', '4431'),
(263417, 'Malinkov Kurtacha', 'Hristo smirnenski 1', 'varvara', '4432')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, OrderStatus)
VALUES
(1, 1, 2, 200, 0, 180, 160, '04.24.2004', '04.04.2069', 55555, 'Available'),
(2, 2, 3, 300, 0, 220, 220, '03.21.2004', '03.04.2069', 55555, 'Available'),
(3, 3, 1, 180, 0, 260, 270, '12.12.2004', '12.04.2069', 55555, 'Available')

-- Problem 15.	Hotel Database
CREATE DATABASE Hotel;
USE Hotel;
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX),
);

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY, 
	FirstName VARCHAR(90) NOT NULL, 
	LastName VARCHAR(90) NOT NULL, 
	PhoneNumber CHAR(10) NOT NULL, 
	EmergencyName VARCHAR(90), 
	EmergencyNumber CHAR(10), 
	Notes VARCHAR(MAX),
);

CREATE TABLE RoomStatus(
		RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomTypes(
		RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE BedTypes(
		BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate INT,
	RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	NOTES NVARCHAR(100)
)


CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged INT,
	TaxRate DECIMAL(3,2) NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal INT,
	Notes NVARCHAR(30)
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge INT,
	Notes NVARCHAR(20)
)



INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Ivan', 'Kurtacha', 'Zaglabie'),
('Ivan1', 'Kurtacha', 'Zaglabie'),
('Ivan2', 'Kurtacha', 'Zaglabie')


INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
(1542, 'iVAN', 'kurtacha', 0884552, 'Malinkov', 07744),
(1522, 'iVAN2', 'kurtacha', 0884552, 'Malinkov', 07744),
(1532, 'iVAN3', 'kurtacha', 0884552, 'Malinkov', 07744)

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Available'),
('Busy'),
('busy2')

INSERT INTO RoomTypes(RoomType)
VALUES
('squad'),
('duo'),
('solo')

INSERT INTO BedTypes(BedType)
VALUES
('adult'),
('baby'),
('teen')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(1425, 'squad', 'adult', 'Busy'),
(1456, 'duo', 'baby', 'busy2'),
(14266, 'solo', 'teen', 'Available')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, TaxRate, TaxAmount)
VALUES
(1, '04.18.2020', 23 , 2.58, 550),
(2, '04.18.2020', 44 , 4.58, 533),
(2, '04.18.2020', 12, 1.58, 512)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
(1, '12.24.2020', 17, 1, 85),
(2, '12.24.2020', 77, 2, 65),
(3, '12.24.2020', 177, 4, 12)

SELECT TaxRate FROM Payments

SELECT TaxRate * 1000 as TR FROM Payments 

SELECT FirstName, PhoneNumber + 'BG' FROM Customers  WHERE FirstName LIKE 'i%' ORDER BY Customers.FirstName;

DELETE FROM Customers WHERE FirstName LIKE '%3';
