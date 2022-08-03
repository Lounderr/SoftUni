USE SoftUni;


SELECT TOP(5) 
	EmployeeId, 
	JobTitle, 
	a.AddressID, 
	AddressText 
FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID

-- #

SELECT TOP(50) 
	FirstName, 
	LastName, 
	t.Name AS Town, 
	AddressText 
FROM Employees e 
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
ORDER BY FirstName ASC, LastName ASC

-- #

SELECT 
	EmployeeID, 
	FirstName, 
	LastName, 
	d.Name AS DepartmentName
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID ASC

-- #

SELECT TOP(5) 
	EmployeeID, 
	FirstName, 
	Salary, 
	d.Name AS DepartmentName
FROM Employees e 
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID ASC

-- #

SELECT TOP(3) 
	e.EmployeeID, 
	e.FirstName
FROM Employees e
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID IS NULL
ORDER BY EmployeeID ASC

-- #

SELECT 
	FirstName, 
	LastName, 
	HireDate, 
	d.Name AS DeptName 
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-1-1' AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY e.HireDate ASC;

-- #

SELECT TOP(5) 
	e.EmployeeID, 
	FirstName, 
	p.Name AS ProjectName
FROM Employees e
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID ASC

-- #

SELECT 
	e.EmployeeID, 
	e.FirstName, 
	CASE 
	WHEN YEAR(p.StartDate) >= '2005' THEN NULL
	ELSE p.Name 
	END AS ProjectName
FROM Employees e
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- #

SELECT 
	e.EmployeeID, 
	e.FirstName, 
	e.ManagerID, 
	m.FirstName AS ManagerName
FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID ASC;

-- #

SELECT TOP(50)
	e.EmployeeID, 
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	JOIN Employees m ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID

-- #

SELECT TOP(1) AVG(Salary) AS AvgSalary
FROM Employees 
GROUP BY DepartmentID
ORDER BY AvgSalary

-- #

USE Geography

SELECT 
	c.CountryCode, 
	MountainRange, 
	PeakName, 
	Elevation 
FROM Peaks p
	JOIN Mountains m ON m.Id = p.MountainId
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	JOIN Countries c ON mc.CountryCode = c.CountryCode
WHERE 
	c.CountryCode = 'BG' AND
	p.Elevation > 2835
ORDER BY Elevation DESC

-- #

SELECT 
	c.CountryCode, 
	COUNT(MountainRange)
FROM Peaks p
	JOIN Mountains m ON m.Id = p.MountainId
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	JOIN Countries c ON mc.CountryCode = c.CountryCode
WHERE 
	c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode

-- #

SELECT TOP(5)
	CountryName,
	RiverName
FROM Countries c
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON cr.RiverId = r.Id
WHERE
	c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

-- #
-- Hard

SELECT ContinentCode, CurrencyCode, CurrencyUsage 
FROM (
	SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage, 
		DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
	FROM Countries
	GROUP BY ContinentCode, CurrencyCode) AS k
WHERE [Ranked] = 1 AND [CurrencyUsage] > 1
ORDER BY ContinentCode

-- #

SELECT COUNT(*)
FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
WHERE MountainId IS NULL

-- #

SELECT 
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength
FROM Countries c 
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id

	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

-- #

SELECT TOP(1000) 
	ISNULL(Country, '(no highest peak)'),
	ISNULL([Highest Peak Name], '(no highest peak)'),
	ISNULL([Highest Peak Elevation], 0),
	ISNULL(Mountain, '(no mountain)')
FROM 
	(SELECT 
		DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(Elevation) DESC) AS [Rank],
		CountryName AS Country, 
		PeakName AS [Highest Peak Name],
		MAX(Elevation) AS [Highest Peak Elevation], 
		MountainRange Mountain
	FROM Peaks p
		RIGHT JOIN Mountains m ON m.Id = p.MountainId
		RIGHT JOIN MountainsCountries mc ON mc.MountainId = m.Id
		RIGHT JOIN Countries c ON c.CountryCode = mc.CountryCode
	GROUP BY CountryName, PeakName, MountainRange) AS nfo
WHERE Rank = 1
ORDER BY Country ASC, [Highest Peak Elevation] DESC


