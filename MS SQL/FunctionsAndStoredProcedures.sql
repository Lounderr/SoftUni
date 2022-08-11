CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS 
	SELECT FirstName, LastName 
	FROM SoftUni.dbo.Employees
	WHERE Salary > 35000
GO

-- #

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS 
	SELECT FirstName, LastName 
	FROM SoftUni.dbo.Employees
	WHERE Salary > @Number
GO

-- #

CREATE PROCEDURE usp_GetTownsStartingWith(@StartString NVARCHAR(MAX))
AS
	SELECT Name
	FROM SoftUni.dbo.Towns
	WHERE LEFT(Name, 1) = @StartString
GO

-- #

CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName NVARCHAR(MAX))
AS
	SELECT FirstName, LastName
	FROM SoftUni.dbo.Employees e
		JOIN SoftUni.dbo.Addresses a ON e.AddressID = a.AddressID
		JOIN SoftUni.dbo.Towns t ON t.TownID = a.TownID 
	WHERE t.Name = @TownName
GO

-- # 

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
		IF @salary <= 13500.00 
			RETURN 'LOW'
		ELSE IF @salary >= 43300.00 AND @salary < 125500.00 
			RETURN 'AVERAGE'
		ELSE IF @salary >= 125500.00 
			RETURN 'HIGH'

		RETURN NULL
END

GO

-- #

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
BEGIN
	SELECT 
		FirstName, 
		LastName 
	FROM SoftUni.dbo.Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
END

GO

-- #

CREATE FUNCTION ufn_IsWordComprised
(
	@SetOfLetters NVARCHAR(100), 
	@Word NVARCHAR(100)
)
RETURNS BIT
AS 
BEGIN
	IF CHARINDEX(@SetOfLetters, @Word) = 0
		RETURN 0
	RETURN 1
END

GO 

-- #

USE SoftUni

ALTER TABLE Employees
	ALTER COLUMN ManagerID INT NULL 

GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
	DELETE
	FROM SoftUni.dbo.Employees
	WHERE DepartmentID = @DepartmentId

	DELETE
	FROM SoftUni.dbo.Departments
	WHERE DepartmentID = @DepartmentId

	SELECT COUNT(*)
	FROM SoftUni.dbo.Employees
END

EXEC usp_DeleteEmployeesFromDepartment 1;

GO

-- #

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Bank.dbo.AccountHolders
END

GO

-- #
USE Bank;

GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Number INT)
AS
BEGIN
	SELECT 
		FirstName, 
		LastName
	FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
	GROUP BY ah.Id,	FirstName, LastName
	HAVING SUM(a.Balance) > @Number
END

GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue 
(
	@Sum DECIMAL(10, 4), 
	@YearlyInterestRate FLOAT, 
	@Years INT
)
RETURNS DECIMAL(10, 4)
AS
BEGIN
	DECLARE @FV DECIMAL(10, 4)

	SET @FV = @Sum * (POWER(1 + @YearlyInterestRate, @Years))

	RETURN ROUND(@FV, 4)
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

GO

-- #

USE Bank
GO

CREATE PROCEDURE usp_CalculateFutureValueForAccount
(
	@AccountId INT,
	@InterestRate FLOAT
)
AS
BEGIN
	SELECT 
		a.Id AS [Account Id],
		FirstName AS [First Name],
		LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
END

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1

GO

-- #

USE Diablo

SELECT * FROM dbo.UsersGames

GO

CREATE FUNCTION ufn_CashInUsersGames 
(
	@GameName NVARCHAR(MAX)	
)
RETURNS TABLE
AS 
RETURN 
	(
	SELECT SUM(Cash) AS SumCash
	FROM
		(
		SELECT
			ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNum, 
			Cash,
			Name
		FROM UsersGames ug
			JOIN Games g ON ug.GameId = g.Id
		) AS k
	WHERE RowNum % 2 != 0 AND 'Love in a mist' = k.Name
	)

