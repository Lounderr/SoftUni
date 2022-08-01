SELECT FirstName, LastName
FROM Employees 
WHERE FirstName LIKE 'Sa%';

-- #

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

-- #

SELECT FirstName 
FROM Employees
WHERE DepartmentID IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005;

-- #

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

-- #

SELECT Name
FROM Towns
WHERE LEN(Name) IN (5, 6)
ORDER BY Name ASC;

-- #

SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC;

-- #

SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[^RDB]%'
ORDER BY [Name] ASC;

-- #

GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE YEAR(HireDate) > 2000
GO

-- #

SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5;

-- #

SELECT EmployeeID, 
	FirstName,
	LastName, 
	Salary, 
	DENSE_RANK() OVER (
		PARTITION BY Salary
		ORDER BY EmployeeID
	) AS [Rank] 
FROM Employees 
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC;

-- #

SELECT * FROM (
	SELECT EmployeeID, 
		FirstName,
		LastName, 
		Salary, 
		DENSE_RANK() OVER (
			PARTITION BY Salary
			ORDER BY EmployeeID
		) AS [Rank] 
	FROM Employees 
	WHERE Salary BETWEEN 10000 AND 50000
) AS Result
WHERE [Rank] = 2 
ORDER BY Salary DESC

-- #

USE Geography;

--SELECT CountryName, IsoCode
--FROM Countries
--WHERE LEN(REPLACE(CountryName, 'a', '')) <= LEN(CountryName) - 3
--ORDER BY IsoCode;

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

-- #

SELECT PeakName, RiverName, LOWER((PeakName + RiverName)) AS Mix 
FROM Rivers AS r 
JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
JOIN Countries AS c ON cr.CountryCode = c.CountryCode
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m on mc.MountainId = m.Id
JOIN Peaks AS p on m.Id = p.MountainId
ORDER BY PeakName ASC;

-- #

USE Diablo;

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd', 'bg-BG')
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012;

-- #

SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
FROM Users
ORDER BY Email ASC, Username ASC

-- #

SELECT Username, IpAddress 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

-- # 

SELECT 
	Name, 
	CASE
		WHEN DATENAME(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATENAME(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATENAME(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day], 
		CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY Name ASC, Duration ASC, [Part of the Day] ASC;

-- #

SELECT 
	ProductName, 
	OrderDate, 
	DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders.dbo.Orders;

-- #

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(80) NOT NULL,
	Birthdate DATE NOT NULL
);

INSERT People (Name, Birthdate)
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000');

-- #

SELECT 
Name, 
DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years], 
DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months], 
DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days], 
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes] 
FROM People;