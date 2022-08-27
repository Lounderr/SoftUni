-- Section 1 DDL

CREATE DATABASE Airport

GO

USE Airport

GO

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(100) UNIQUE NOT NULL,
	Email NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age TINYINT NOT NULL,
		CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT,
		CHECK(Rating BETWEEN 0 AND 10)
);

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY,
	TypeName NVARCHAR(30) UNIQUE NOT NULL,
);

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer NVARCHAR(25) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
);

CREATE TABLE PilotsAircraft(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id),
	PRIMARY KEY (AircraftId, PilotId)
);

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY,
	AirportName NVARCHAR(70) UNIQUE NOT NULL,
	Country NVARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT 15
);

-- Section 2 DML

-- For each pilot with an id between 5 and 15 insert 

INSERT INTO Passengers 
	SELECT
		FirstName + ' ' + LastName AS FullName,
		FirstName + LastName + '@gmail.com'
	FROM Pilots 
	WHERE Id BETWEEN 5 AND 15

-- #

UPDATE Aircraft
	SET Condition = 'A'
	WHERE 
		Condition IN ('C', 'B') AND
		(FlightHours IS NULL OR FlightHours <= 100) AND
		[Year] >= 2013

-- #

DELETE FROM Passengers
WHERE LEN(FullName) <= 10

-- Section 3 Querying

SELECT Manufacturer, Model, FlightHours, Condition 
FROM Aircraft 
ORDER BY FlightHours DESC

-- #

SELECT p.FirstName, p.LastName, Manufacturer, Model, FlightHours  
FROM Pilots p
	JOIN PilotsAircraft pa ON pa.PilotId = p.Id
	JOIN Aircraft a ON pa.AircraftId = a.Id
WHERE FlightHours IS NOT NULL AND FlightHours <= 304
ORDER BY FlightHours DESC, p.FirstName ASC

-- #

SELECT TOP(20) fd.Id, fd.Start, p.FullName, aps.AirportName, TicketPrice
FROM FlightDestinations fd
	JOIN Passengers p ON p.Id = fd.PassengerId
	JOIN Airports aps ON aps.Id = fd.AirportId
WHERE DAY(Start) % 2 = 0
ORDER BY TicketPrice DESC, AirportName ASC

-- #

SELECT a.Id, a.Manufacturer, a.FlightHours, COUNT(fd.Id) AS FlightDestinationsCount, ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft a
	JOIN FlightDestinations fd ON fd.AircraftId = a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY COUNT(fd.Id) DESC, a.Id ASC

-- #

SELECT FullName, COUNT(AircraftId) AS CountOfAircraft, SUM(TicketPrice) AS TotalPayed
FROM Passengers p
	JOIN FlightDestinations fd ON fd.PassengerId = p.Id
	JOIN Aircraft a ON a.Id = fd.AircraftId
WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY FullName
HAVING COUNT(AircraftId) > 1
ORDER BY FullName

-- #

SELECT AirportName, Start AS DayTime, TicketPrice, FullName, Manufacturer, Model
FROM FlightDestinations fd
	JOIN Airports a ON a.Id = fd.AirportId
	JOIN Passengers p ON fd.PassengerId = p.Id
	JOIN Aircraft ac ON ac.Id = fd.AircraftId

WHERE 
	(DATEPART(HOUR, Start) BETWEEN 6 AND 20) 
	AND 
	TicketPrice > 2500
ORDER BY Model ASC

-- #
GO

CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(150))
RETURNS INT 
AS 
BEGIN
	RETURN 
	(
		SELECT COUNT(fd.Id) 
		FROM FlightDestinations fd 
			JOIN Passengers p ON fd.PassengerId = p.Id 
		WHERE p.Email = @email
	)
END

-- #
GO

CREATE PROCEDURE usp_SearchByAirportName(@airportName NVARCHAR(70))
AS
BEGIN
	SELECT 
		AirportName, 
		FullName, 
		(
		CASE
			WHEN TicketPrice <= 400 THEN 'LOW'
			WHEN TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			WHEN TicketPrice > 1501 THEN 'High'
		END
		) AS LevelOfTicketPrice, 
		Manufacturer, 
		Condition, 
		TypeName
	FROM Airports ap
		JOIN FlightDestinations fd ON ap.Id = fd.AirportId
		JOIN Passengers p ON p.Id = fd.PassengerId
		JOIN Aircraft ac ON ac.Id = fd.AircraftId
		JOIN AircraftTypes act ON act.Id = ac.TypeId
	WHERE AirportName = @airportName
	ORDER BY Manufacturer ASC, FullName ASC
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'