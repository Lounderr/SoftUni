-- Section 1 DDL
USE master;
GO
CREATE DATABASE CigarShop;
GO
USE CigarShop;
GO
CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY,
	Length INT NOT NULL,
		CHECK(Length BETWEEN 10 AND 25),
	RingRange DECIMAL(18, 2) NOT NULL,
		CHECK(RingRange BETWEEN 1.5 AND 7.5)
);

CREATE TABLE Tastes(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
);

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY, 
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
);

CREATE TABLE Cigars(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT REFERENCES Brands(Id) NOT NULL,
	TastId INT REFERENCES Tastes(Id) NOT NULL,
	SizeId INT REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(18, 2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
);

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
);

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
);

CREATE TABLE ClientsCigars(
	ClientId INT REFERENCES Clients(Id) NOT NULL,
	CigarId INT REFERENCES Cigars(Id) NOT NULL,
	PRIMARY KEY (ClientId, CigarId)
);

-- Section 2 DML

INSERT INTO Cigars VALUES
('COHIBA ROBUSTO',	9,	1,	5,	15.50,	'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5,	11,	7.50,	'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4,	15,	32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg');

INSERT INTO Addresses VALUES
('Sofia',	'Bulgaria',	'18 Bul. Vasil levski',	1000),
('Athens',	'Greece',	'4342 McDonald Avenue',	10435),
('Zagreb',	'Croatia',	'4333 Lauren Drive',	10000);

-- #

UPDATE Cigars
	SET 
		PriceForSingleCigar = PriceForSingleCigar + 0.2 * PriceForSingleCigar 
	FROM Cigars c
		JOIN Tastes t ON t.Id = c.TastId
	WHERE TasteType = 'Spicy'

UPDATE Brands
	SET 
		BrandDescription = 'New description'
	FROM Brands b
	WHERE BrandDescription IS NULL

	SELECT * FROM Brands

-- #

-- Broken exercise

-- Section 3 Querying

SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars ORDER BY PriceForSingleCigar ASC, CigarName DESC

-- #

SELECT c.Id, CigarName, PriceForSingleCigar, TasteType, TasteStrength FROM Cigars c JOIN Tastes t ON c.TastId = t.Id WHERE t.TasteType IN ('Earthy', 'Woody') ORDER BY PriceForSingleCigar DESC

-- #

SELECT cl.Id, FirstName + ' ' + LastName AS ClientName, Email FROM Clients cl
	LEFT JOIN ClientsCigars clci ON cl.Id = clci.ClientId
	LEFT JOIN Cigars ci ON ci.Id = clci.CigarId
WHERE CigarId IS NULL
ORDER BY ClientName ASC

-- #

SELECT TOP(5) 
	CigarName, 
	PriceForSingleCigar, 
	ImageURL 
FROM Cigars c
	JOIN Sizes s ON s.Id = c.SizeId
WHERE [Length] >= 12 AND (c.CigarName LIKE '%ci%' OR PriceForSingleCigar > 50) AND RingRange > 2.55
ORDER BY CigarName ASC, PriceForSingleCigar DESC

-- #

SELECT 
	FirstName + ' ' + LastName AS FullName,
	Country,
	ZIP,
	CONCAT('$', MAX(PriceForSingleCigar)) FROM Addresses a
	JOIN Clients c ON c.AddressId = a.Id
	JOIN ClientsCigars ccig ON ccig.ClientId = c.Id
	JOIN Cigars cig ON cig.Id = ccig.CigarId
WHERE ISNUMERIC(ZIP) = 1 
GROUP BY FirstName + ' ' + LastName, Country, ZIP

-- #

SELECT LastName, AVG(s.Length), CEILING(AVG(RingRange)) FROM Clients c
	LEFT JOIN ClientsCigars ccig ON ccig.ClientId = c.Id
	LEFT JOIN Cigars cig ON cig.Id = ccig.CigarId
	LEFT JOIN Sizes s ON cig.SizeId = s.Id
WHERE CigarId IS NOT NULL
GROUP BY LastName
ORDER BY AVG(s.Length) DESC

-- #
GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
	RETURN 
	(
		SELECT COUNT(*)
		FROM Clients c
			JOIN ClientsCigars cc ON cc.ClientId = c.Id
		WHERE FirstName = @name 
	)
END

GO

-- #

CREATE OR ALTER PROC usp_SearchByTaste(@taste NVARCHAR(50))
AS
SELECT CigarName, CONCAT('$', PriceForSingleCigar), TasteType, BrandName, CONCAT(Length, ' cm') AS CigarLength, CONCAT(RingRange, ' cm') AS CigarRingRange
FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	JOIN Brands b ON c.BrandId = b.Id
	JOIN Sizes s ON s.Id = c.SizeId
WHERE @taste = t.TasteType
ORDER BY CigarLength ASC, CigarRingRange DESC

EXEC usp_SearchByTaste 'Woody'