SELECT COUNT(*) AS Count
FROM WizzardDeposits

-- #

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

-- #

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

-- #

SELECT DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

-- #

SELECT
	DepositGroup, 
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

-- #

SELECT
	DepositGroup, 
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup 
HAVING SUM(DepositAmount) < 150000

-- #

SELECT 
	DepositGroup,
	MagicWandCreator, 
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--  #

SELECT age_range, COUNT(*) AS WizzardCount
FROM (
	SELECT 
		CASE
			WHEN Age <= 10 THEN '[0-10]'
			WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
			WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
			WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
			WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
			WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
			WHEN Age >= 61 THEN '[61+]'
		END AS age_range
	FROM WizzardDeposits
) AS k
GROUP BY age_range

-- #

SELECT LEFT(FirstName, 1)
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

-- #

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- #

SELECT SUM(CurrentDepositAmount - NextDepositAmount) FROM
(SELECT
	FirstName AS CurrentName,
	DepositAmount AS CurrentDepositAmount,
	LEAD(FirstName, 1) OVER (ORDER BY Id) AS NextName,
	LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS NextDepositAmount
FROM WizzardDeposits) AS k

-- &

SELECT SUM(DepositAmount - nDepositAmount)
FROM 
	(SELECT
		FirstName,
		DepositAmount,

		nRowNum,
		nFirstName, 
		nDepositAmount
	FROM WizzardDeposits
		JOIN 
			(SELECT 
				ROW_NUMBER() OVER (ORDER BY Id) AS nRowNum,
				FirstName nFirstName, 
				DepositAmount nDepositAmount
			FROM WizzardDeposits
			WHERE Id != 1
			) AS NextRows ON nRowNum = Id
	) AS CombinedRows

-- #

SELECT DepartmentID, SUM(Salary) 
FROM Employees e
GROUP BY DepartmentID
ORDER BY DepartmentID

-- #

SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- #

SELECT * INTO #EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM #EmployeesWithHighSalaries
WHERE ManagerID = 42

UPDATE #EmployeesWithHighSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM #EmployeesWithHighSalaries
GROUP BY DepartmentID

-- #

SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- #

SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- #

SELECT DepartmentID, Salary FROM 
(SELECT 
	DepartmentID,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank,
	Salary 
FROM Employees) as k
WHERE Rank = 3
GROUP BY DepartmentID, Salary

-- #

SELECT TOP(10) 
	FirstName, 
	LastName, 
	DepartmentID 
FROM Employees as emp
WHERE 
	Salary >
			(SELECT 
				AVG(Salary) AS AvgDeptSalary
			FROM Employees e
			WHERE DepartmentID = emp.DepartmentID
			GROUP BY e.DepartmentID)
ORDER BY DepartmentID
