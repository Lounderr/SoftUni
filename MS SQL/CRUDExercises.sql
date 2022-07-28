USE SoftUni;


SELECT * FROM Departments;


SELECT [Name] FROM Departments;


SELECT FirstName, LastName, Salary FROM Employees;


SELECT FirstName, MiddleName, LastName FROM Employees;


SELECT * FROM Employees;


SELECT DISTINCT Salary FROM Employees ORDER BY Salary ASC;


SELECT * FROM Employees WHERE JobTitle LIKE 'Sales Representative';


SELECT FirstName, LastName, JobTitle FROM Employees WHERE Salary BETWEEN 20000 AND 30000;


SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] FROM Employees WHERE Salary IN (25000, 14000, 12500, 23600);


SELECT FirstName, LastName FROM Employees WHERE ManagerID IS NULL;


SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > 50000 ORDER BY Salary DESC;


SELECT TOP(5) FirstName, LastName FROM Employees ORDER BY Salary DESC;


SELECT FirstName, LastName FROM Employees WHERE DepartmentID != 4


SELECT * FROM Employees ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC;


CREATE VIEW V_EmployeesSalaries
AS
SELECT FirstName, LastName, Salary
FROM Employees;

SELECT * FROM V_EmployeesSalaries;


ALTER VIEW V_EmployeeNameJobTitle
AS 
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle AS [Job Title] FROM Employees;

SELECT * FROM V_EmployeeNameJobTitle;


SELECT DISTINCT JobTitle FROM Employees;


SELECT * FROM Projects WHERE StartDate IS NOT NULL ORDER BY StartDate ASC, [Name] ASC;


SELECT TOP(7) FirstName, LastName, HireDate 
FROM Employees ORDER BY HireDate DESC;


UPDATE Employees
SET Salary *= 1.12
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Departments.Name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

select Salary FROM EmployeesTin

--  21