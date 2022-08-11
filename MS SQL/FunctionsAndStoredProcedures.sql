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















